﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.EntityClient;
using System.Data;
using System.Data.Objects;
using System.IO;
using System.Data.Objects.DataClasses;
using System.Reflection;
using Landlord2.Data;
using System.ComponentModel;
using Equin.ApplicationFramework;

namespace Landlord2
{
    static class Helper
    {
        #region 构造实体连接字符串
        public static string CreateConnectString()
        {
            // Initialize the EntityConnectionStringBuilder.
            EntityConnectionStringBuilder entityBuilder =
                new EntityConnectionStringBuilder();

            //Set the provider name.
            entityBuilder.Provider = "System.Data.SqlServerCe.3.5";

            // Set the provider-specific connection string.
            entityBuilder.ProviderConnectionString = @"Data Source=|DataDirectory|\Data\Landlord2.sdf;Password ='qwlpy0a'";

            // Set the Metadata location.
            //entityBuilder.Metadata = @"res://*/Data.Model1.csdl|res://*/Data.Model1.ssdl|res://*/Data.Model1.msl";
            entityBuilder.Metadata = @"|DataDirectory|\Data\Model1.csdl||DataDirectory|\Data\Model1.ssdl||DataDirectory|\Data\Model1.msl";

            return entityBuilder.ToString();
        }
        #endregion
              
        /// <summary>
        /// 本地查询[Added,Modified,Unchanged对象]（基于ObjectSet的扩展方法）
        /// 因为“实体框架执行的查询根据数据源中的数据进行计算，且结果将不反映对象上下文中的新对象。http://msdn.microsoft.com/zh-cn/library/bb896241.aspx ”
        /// 那么本地新增对象未保存时，下次查询不包括这些新对象。所以增加此本地查询[Added,Modified,Unchanged对象]功能。http://blogs.msdn.com/b/dsimmons/archive/2009/02/21/local-queries.aspx
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectSet"></param>
        /// <returns></returns>
        public static IEnumerable<T> Local<T>(this ObjectSet<T> objectSet) where T : class
        {
            return from stateEntry in objectSet.Context.ObjectStateManager
                                               .GetObjectStateEntries(EntityState.Added |
                                                                      EntityState.Modified |
                                                                      EntityState.Unchanged)
                   where stateEntry.Entity != null && stateEntry.EntitySet == objectSet.EntitySet
                   select stateEntry.Entity as T;
        }

        /// <summary>
        /// 将IEnumerable集合转换为BindingListView集合，便于数据绑定、排序。（基于IEnumerable的扩展方法）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static BindingListView<T> ToBindingListView<T>(this IEnumerable<T> source) where T : class
        {
            return new BindingListView<T>(source.ToList());
        }

        /// <summary>
        /// 是否有Added状态对象（基于ObjectSet的扩展方法）
        /// 如果有的话，那么查询时应该调用Local扩展方法得到本地对象；否则可以调用‘预编译’查询加速
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectSet"></param>
        /// <returns></returns>
        public static bool HasAddedObject<T>(this ObjectSet<T> objectSet) where T : class
        {
            var objectStateEntries = objectSet.Context.ObjectStateManager.GetObjectStateEntries(EntityState.Added);
            foreach (var entity in objectStateEntries)
            {
                if (entity.EntitySet == objectSet.EntitySet)// T 类型对象有Added
                    return true;
            }
            return false;
        }


        /// <summary>
        /// 保存到数据库
        /// </summary>
        /// <param name="entity">针对的实体对象</param>
        /// <param name="ResultMsg">返回的消息</param>
        /// <returns>返回是否成功标志</returns>
        public static bool saveData(MyContext context, object entity, out string ResultMsg)
        {
            bool flag = false;
            int num;
            try
            {
                num = context.SaveChanges();
                flag = true;
                
#if DEBUG
                ResultMsg = string.Format("成功操作{0}条记录。", num);
#else
                ResultMsg = string.Format("数据操作成功。");
#endif
            }
            catch (OptimisticConcurrencyException)
            {
                context.Refresh(RefreshMode.ClientWins, entity);
                num = context.SaveChanges();
                flag = true;
                
#if DEBUG
                ResultMsg = string.Format("成功处理开放式并发异常，并操作{0}条记录。", num);
#else
                ResultMsg = string.Format("数据操作成功。");
#endif
            }
            catch (Exception ex)
            {
                string msg = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message;
                
#if DEBUG
                ResultMsg = string.Format("数据操作失败：{0}", msg);
#else
                ResultMsg = string.Format("数据操作失败，详细信息请查看日志文件。");
                PrintLog(string.Format("数据操作失败：{0}", msg));
#endif
            }
            return flag;
        }

        /// <summary>
        /// 写日志，当前目录下的log.txt文件。
        /// </summary>
        /// <param name="msg"></param>
        public static void PrintLog(string msg)
        {
            string path = Directory.GetCurrentDirectory();
            using (StreamWriter sw = File.AppendText(Path.Combine(path, "Landlord2.log")))
            {
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") +msg);
            }
        }

        /// <summary>
        /// 解析阶梯水价（从字符串到Dictionary<string, decimal>）
        /// 字典中的key，对应界面控件的取值k1,k10,k11;k2,k20,k21;k3,k30
        /// 格式说明如下：“1.9,0,25;2.45,25,33;3,33" 表示：1.9元/吨，0~25吨（含）；2.45元/吨，25~33吨（含）；3元/吨，33吨以上。
        /// </summary>
        /// <param name="value">阶梯水价字符串</param>
        /// <returns></returns>
        public static Dictionary<string, decimal> trans阶梯水价(string value)
        {
            Dictionary<string, decimal> dic = new Dictionary<string, decimal>();            
            var s = value.Split(new char[] { ';', ',' });
            System.Diagnostics.Debug.Assert(s.Count() == 1 || s.Count() == 8);
            if (s.Count() == 1)//不使用阶梯水价
            {
                dic.Add("k1", Convert.ToDecimal(s[0]));
            }
            else
            {
                dic.Add("k1", Convert.ToDecimal(s[0]));
                dic.Add("k10", Convert.ToDecimal(s[1]));
                dic.Add("k11", Convert.ToDecimal(s[2]));
                dic.Add("k2", Convert.ToDecimal(s[3]));
                dic.Add("k20", Convert.ToDecimal(s[4]));
                dic.Add("k21", Convert.ToDecimal(s[5]));
                dic.Add("k3", Convert.ToDecimal(s[6]));
                dic.Add("k30", Convert.ToDecimal(s[7]));
            }
            return dic;
        }

        /// <summary>
        /// 根据用水吨数和水价计算水费
        /// </summary>
        /// <param name="value">阶梯水价</param>
        /// <param name="number">用水吨数</param>
        /// <returns></returns>
        public static decimal calculate水费(string value, decimal number)
        {
            decimal returnVal = 0.00M;
            Dictionary<string, decimal> dic = trans阶梯水价(value);
            if (dic.Count == 1)//不使用阶梯水价
            {
                returnVal = dic["k1"] * number;
            }
            else
            {
                if (number > dic["k30"])
                    returnVal = (number - dic["k30"]) * dic["k3"] +
                                (dic["k21"] - dic["k20"]) * dic["k2"] +
                                (dic["k11"] - dic["k10"]) * dic["k1"];
                else if (number > dic["k20"])
                    returnVal = (number - dic["k20"]) * dic["k2"] +
                                (dic["k11"] - dic["k10"]) * dic["k1"];
                else
                    returnVal = (number - dic["k10"]) * dic["k1"];
            }
            return decimal.Round(returnVal,2);
        }

        /// <summary>
        /// 根据用电量数和电价计算电费（暂时不考虑阶梯电价）
        /// </summary>
        /// <param name="value"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static decimal calculate电费(string value, decimal number)
        {
            decimal returnVal = 0.00M;
            returnVal = Convert.ToDecimal(value) * number;
            return decimal.Round(returnVal,2);
        }

        #region 加密狗相关
        /// <summary>
        /// 查询本机是否安装加密狗
        /// </summary>
        /// <param name="errMsg">如未检测到，回传错误信息</param>
        /// <returns></returns>
        public static bool FindDog(out string errMsg)
        {
            errMsg = string.Empty;
            byte[] bytPID = new byte[8];
            int count = 0;
            bytPID = System.Text.Encoding.ASCII.GetBytes(Properties.Resources.PID);
            uint result = ET99_API.et_FindToken(bytPID, out count);
            if (result == ET99_API.ET_SUCCESS)
                return true;
            else
            {
                errMsg = string.Format("系统未检测到加密狗，请检查！\r\n错误：{0}",
                    ET99_API.ShowResultText(result));
                return false;
            }
        }

        /// <summary>
        /// 打开并进入加密狗
        /// </summary>
        /// <param name="errMsg"></param>
        public static bool OpenDog(out string errMsg)
        {
            errMsg = string.Empty;
            int index = 1;//默认仅打开第一个加密狗
            byte[] bytPID = new byte[8];
            bytPID = System.Text.Encoding.ASCII.GetBytes(Properties.Resources.PID);
            uint result = ET99_API.et_OpenToken(ref ET99_API.dogHandle, bytPID, index);
            if (result == ET99_API.ET_SUCCESS)//打开成功
            {
                byte[] bytPIN = new byte[16];
                bytPIN = System.Text.Encoding.ASCII.GetBytes(Properties.Resources.UserPIN);
                result = ET99_API.et_Verify(ET99_API.dogHandle,ET99_API.ET_VERIFY_USERPIN, bytPIN);
                if (result == ET99_API.ET_SUCCESS)
                    return true;
                else
                {
                    errMsg = string.Format("加密狗认证失败，请检查！\r\n错误：{0}",
                                       ET99_API.ShowResultText(result));
                    return false;
                }
            }
            else
            {
                errMsg = string.Format("打开加密狗失败，请检查！\r\n错误：{0}",
                    ET99_API.ShowResultText(result));
                return false;
            }
        }

        /// <summary>
        /// 关闭加密狗
        /// </summary>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public static bool CloseDog(out string errMsg)
        {
            errMsg = string.Empty;
            uint result = ET99_API.et_CloseToken(ET99_API.dogHandle);
            if (result == ET99_API.ET_SUCCESS)
            {
                ET99_API.dogHandle = System.IntPtr.Zero;
                return true;
            }
            else
            {
                errMsg = string.Format("关闭加密狗失败，请检查！\r\n错误：{0}",
                    ET99_API.ShowResultText(result));
                return false;
            }            
        }

        /// <summary>
        /// 闪烁LED灯n次
        /// </summary>
        /// <param name="times">闪烁次数</param>
        /// <param name="interval">间隔毫秒数，300貌似不错</param>
        public static void FlashLED(int times, int interval)
        {
            int count = 0;
            System.Timers.Timer turnOffTimer = new System.Timers.Timer(interval);
            turnOffTimer.AutoReset = false;
            System.Timers.Timer turnOnTimer = new System.Timers.Timer(interval);
            turnOnTimer.AutoReset = false;
            turnOffTimer.Elapsed += new System.Timers.ElapsedEventHandler((m, n) =>
            {
                ET99_API.et_TurnOffLED(ET99_API.dogHandle);
                turnOnTimer.Start();
            });
            turnOnTimer.Elapsed += new System.Timers.ElapsedEventHandler((m, n) =>
            {
                count++;
                ET99_API.et_TurnOnLED(ET99_API.dogHandle);
                if (count < times)
                    turnOffTimer.Start();
            });

            turnOffTimer.Start();
        }

        /// <summary>
        /// 软件计算HMAC_MD5
        /// 加密狗中可存储8个32字节HMAC_MD5密钥（每一个密钥都是由1个16字节密钥种子重复一次而成，这里存储的是8个16字节‘密钥种子’）
        /// </summary>
        /// <param name="MD5KeyIndexInDog">密钥index[范围1~8，对应加密狗中密钥存储范围1~8]</param>
        /// <param name="origin">原始字串</param>
        /// <returns>加密后字串</returns>
        public static string HMAC_MD5_soft(int MD5KeyIndexInDog,string origin)
        {
            uint result;
            string strMD5Key = Properties.Resources.HMAC_MD5.Substring((MD5KeyIndexInDog - 1) * 16, 16);//获取对应index的‘密钥种子’
            strMD5Key += strMD5Key;//重复一次，形成32字节密钥

            byte[] bytRandomCode = new byte[origin.Length];//第一个参数是随机数
            bytRandomCode = System.Text.Encoding.ASCII.GetBytes(origin);
            byte randomlen = byte.Parse(origin.Length.ToString());//第二个参数是随机数长度
            byte[] bytShortKey = new byte[strMD5Key.Length];//第三个参数是分配给客户的密钥
            bytShortKey = System.Text.Encoding.ASCII.GetBytes(strMD5Key);
            byte keylen = byte.Parse(strMD5Key.Length.ToString());//第四个参数是分配给客户的密钥的长度
            byte[] sbMd5Key = new byte[32];//第五个参数没有作用
            byte[] sbdigest = new byte[16];//第六个参数为软件计算的结果

            //第一个参数是随机数
            //第二个参数是随机数长度
            //第三个参数是分配给客户的密钥
            //第四个参数是分配给客户的密钥的长度
            //第五个参数没有作用
            //第六个参数为软件计算的结果
            result = ET99_API.MD5_HMAC(bytRandomCode, randomlen, bytShortKey, keylen, sbMd5Key, sbdigest);
            if (result == ET99_API.ET_SUCCESS)
            {
                string strSoftDigest = string.Empty;
                for (int i = 0; i < 16; i++)
                    strSoftDigest += string.Format("{0:X2}", sbdigest[i]);
                return strSoftDigest;
            }
            else//失败
                return string.Empty;
        }

        /// <summary>
        /// 硬件加密狗计算HMAC_MD5
        /// </summary>
        /// <param name="MD5KeyIndexInDog">密钥index[范围1~8，对应加密狗中密钥存储范围1~8]</param>
        /// <param name="origin">原始字串</param>
        /// <returns>加密后字串</returns>
        public static string HMAC_MD5_dog(int MD5KeyIndexInDog, string origin)
        {
            uint result;

            byte[] bytRandomCode = new byte[origin.Length];//第四个参数为随机数
            bytRandomCode = System.Text.Encoding.ASCII.GetBytes(origin);
            byte[] bytDigest = new byte[16];//第五个参数为硬件中计算结果

            //硬件中计算
            //第一个参数为设备的handle句柄
            //第二个参数为硬件中密钥索引
            //第三个参数为随机数长度
            //第四个参数为随机数
            //第五个参数为硬件中计算结果
            result = ET99_API.et_HMAC_MD5(ET99_API.dogHandle, MD5KeyIndexInDog, origin.Length, bytRandomCode, bytDigest);
            if (result == ET99_API.ET_SUCCESS)
            {
                string strSoftDigest = string.Empty;
                for (int i = 0; i < 16; i++)
                    strSoftDigest += string.Format("{0:X2}", bytDigest[i]);
                return strSoftDigest;
            }
            else//失败
                return string.Empty;
        }

        #endregion
    }

}
