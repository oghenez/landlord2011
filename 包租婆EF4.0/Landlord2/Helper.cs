using System;
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
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using Ionic.Zip;

namespace Landlord2
{
    static class Helper
    {
        #region 构造实体连接字符串
        public static string CreateConnectString()
        {
            //// Initialize the EntityConnectionStringBuilder.
            //EntityConnectionStringBuilder entityBuilder =
            //    new EntityConnectionStringBuilder();

            ////Set the provider name.
            //entityBuilder.Provider = "System.Data.SqlServerCe.3.5";

            //// Set the provider-specific connection string.
            //entityBuilder.ProviderConnectionString = @"Data Source=|DataDirectory|\Data\Landlord2.sdf;Password ='qwlpy0a'";

            //// Set the Metadata location.
            ////entityBuilder.Metadata = @"res://*/Data.Model1.csdl|res://*/Data.Model1.ssdl|res://*/Data.Model1.msl";
            //entityBuilder.Metadata = @"|DataDirectory|\Data\Model1.csdl||DataDirectory|\Data\Model1.ssdl||DataDirectory|\Data\Model1.msl";

            //return entityBuilder.ToString();

            //从加密狗中解密读取
            return ReadOffsetDataAndDecrypt(32, 320);
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

        [DllImport("wininet.dll")]
        private static extern bool InternetGetConnectedState(out int Description, int ReservedValue);

        /// <summary>
        ///判断当前的网络连接状态 
        /// </summary>
        public static bool IsConnectedToInternet()
        {
            int Desc;
            return InternetGetConnectedState(out Desc, 0);
        }

        /// <summary>
        /// 从资源文件中临时生成文件（此文件为zip压缩文件，html及jpg等），调用Ionic.zip.dll解压至临时目录，然后加载进web控件中。
        /// </summary>
        /// <param name="PropertyResource">针对的资源文件</param>
        /// <returns>返回临时目录路径（主html文件名都是Default.Html）【Web控件即可加载/关闭后即可依据此路径清除】</returns>
        public static string GetWebContent(byte[] PropertyResource)
        {
            /*
using(ZipFile zip= new ZipFile())
      {
        zip.AddFile(filename);
        zip.Save(NameOfZipFileTocreate);
      }
             * 
             * 
using (ZipFile zip = ZipFile.Read(NameOfExistingZipFile))
      {
        zip.ExtractAll(args[1]);
      }             
             */
            return string.Empty;
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
        /// 打开并以用户权限进入加密狗
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
                //string strSoftDigest = string.Empty;
                //for (int i = 0; i < 16; i++)
                //    strSoftDigest += string.Format("{0:X2}", bytDigest[i]);
                //return strSoftDigest;
                return System.Text.Encoding.Default.GetString(bytDigest);
            }
            else//失败
                return string.Empty;
        }

        /// <summary>
        /// 读取指定地址数据区的字符串，并解密。
        /// </summary>
        /// <param name="offset">偏移地址，范围0~999，字节为单位（整个数据区1000字节，每次读写限制长度60字节）</param>
        /// <param name="length">欲读取的字节长度</param>
        /// <returns></returns>
        public static string ReadOffsetDataAndDecrypt(int offset, int length)
        {
            string str = string.Empty;
            byte[] zyn = new byte[length];

            uint resultmess;
            while (length > 60)
            {
                byte[] temp = new byte[60];
                resultmess = ET99_API.et_Read(ET99_API.dogHandle, (ushort)offset, 60, temp);//读取60字节 
                if (resultmess != ET99_API.ET_SUCCESS)
                {
                    ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show("加密狗数据错误！", "错误",
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    System.Windows.Forms.Application.Exit();
                }
                Array.Copy(temp, 0, zyn, zyn.Length - length, 60);
                offset += 60;
                length -= 60;
            }
            //剩余数据，不需分割
            byte[] others = new byte[length];
            resultmess = ET99_API.et_Read(ET99_API.dogHandle, (ushort)offset, length, others);//读取 
            if (resultmess != ET99_API.ET_SUCCESS)
            {
                ComponentFactory.Krypton.Toolkit.KryptonMessageBox.Show("加密狗数据错误！", "错误",
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                System.Windows.Forms.Application.Exit();

            }
            Array.Copy(others, 0, zyn, zyn.Length - length, length);
            //转化成字符串
            str = System.Text.Encoding.Default.GetString(zyn);
            if (string.IsNullOrWhiteSpace(str.Replace('\0', ' ')))
                return string.Empty;//类似加密狗初期没有的数据‘起始时间’等，直接返回空。

            //======解密
            int intRandom = new Random().Next(1,9);//随即取1~8
            string key16 = HMAC_MD5_dog(intRandom, "武汉创方科技");
            return RC2Decrypt(str,key16);

        }

        /// <summary>
        /// 临时获得管理员权限，写入数据到加密狗，然后返回到用户权限
        /// </summary>
        /// <param name="origin">欲写入的原始字串</param>
        /// <param name="offset">偏移字节地址</param>
        public static void TempAdminWriteDog(string origin, int offset)
        { 
            //因为此函数的调用前提是通过校验了的狗，省略相关校验，加速
            //获取SOPIN
            string sopin = Helper.ReadOffsetDataAndDecrypt(0, 32);
            //提升管理员权限
            byte[] bytPIN = new byte[16];
            bytPIN = System.Text.Encoding.ASCII.GetBytes(sopin);
            ET99_API.et_Verify(ET99_API.dogHandle, ET99_API.ET_VERIFY_SOPIN, bytPIN);
            //写入
            int intRandom = new Random().Next(1, 9);//随即取1~8
            string key16 = Helper.HMAC_MD5_dog(intRandom, "武汉创方科技");
            string encryptString = Helper.RC2Encrypt(origin, key16);//密文
            byte[] zyn = System.Text.Encoding.Default.GetBytes(encryptString);
            ET99_API.et_Write(ET99_API.dogHandle, (ushort)offset, zyn.Length, zyn);
            //重新进入用户权限
            bytPIN = System.Text.Encoding.ASCII.GetBytes(Properties.Resources.UserPIN);
            ET99_API.et_Verify(ET99_API.dogHandle, ET99_API.ET_VERIFY_USERPIN, bytPIN);
        }
        #endregion

        #region 系统使用的加解密算法(RC2算法 加密解密)
        /**===================================================================================================*
         *  ET99加密狗密钥存储区可以存储8个32字节密钥，用于HMAC-MD5计算。实际上相当于种子码算法，通过输入（每次不超过51字节）
         *  进行计算，产生结果，将结果与应用软件中的数据进行加密处理，产生密文存储在多功能锁中。这样在应用软件使用时，必须通过该
         *  把多功能锁中的密钥计算产生的结果与密文进行反向解密处理产生明文，供软件使用。
         *  
         *  因为RC2算法默认密钥大小128(Bit)=16字节=加密狗通过密钥存储区内的密钥加密运算后的结果长度
        ***===================================================================================================*/
        /// <summary>
        /// RC2 加密(用变长密钥对大量数据进行加密)
        /// </summary>
        /// <param name="EncryptString">待加密密文</param>
        /// <param name="EncryptKey">加密密钥-->即加密狗计算后的16字节数据结果</param>
        /// <returns>returns</returns>
        public static string RC2Encrypt(string EncryptString, string EncryptKey)
        {
            if (string.IsNullOrEmpty(EncryptString))
                throw (new Exception("密文不得为空"));
            if (string.IsNullOrEmpty(EncryptKey))
                throw (new Exception("密钥不得为空"));
            if (EncryptKey.Length < 5 || EncryptKey.Length > 16)//RC2算法有效密钥大小40~128(Bit)
                throw (new Exception("密钥必须为5-16位"));

            string m_strEncrypt = "";
            byte[] m_btIV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            RC2CryptoServiceProvider m_RC2Provider = new RC2CryptoServiceProvider();
            try
            {
                byte[] m_btEncryptString = Encoding.Default.GetBytes(EncryptString);
                MemoryStream m_stream = new MemoryStream();
                CryptoStream m_cstream = new CryptoStream(m_stream, 
                    m_RC2Provider.CreateEncryptor(Encoding.Default.GetBytes(EncryptKey), m_btIV), 
                    CryptoStreamMode.Write);
                m_cstream.Write(m_btEncryptString, 0, m_btEncryptString.Length);
                m_cstream.FlushFinalBlock();
                m_strEncrypt = Convert.ToBase64String(m_stream.ToArray());
                m_stream.Close(); 
                m_stream.Dispose();
                m_cstream.Close(); 
                m_cstream.Dispose();
            }
            catch (IOException ex) 
            { 
                throw ex;
            }
            catch (CryptographicException ex) 
            { 
                throw ex;
            }
            catch (ArgumentException ex) 
            { 
                throw ex;
            }
            catch (Exception ex) 
            { 
                throw ex;
            }
            finally 
            {
                m_RC2Provider.Clear(); 
            }
            return m_strEncrypt;
        }
        /// <summary>
        /// RC2 解密(用变长密钥对大量数据进行加密)
        /// </summary>
        /// <param name="DecryptString">待解密密文</param>
        /// <param name="DecryptKey">解密密钥-->即加密狗计算后的16字节数据结果</param>
        /// <returns>returns</returns>
        public static string RC2Decrypt(string DecryptString, string DecryptKey)
        {
            if (string.IsNullOrEmpty(DecryptString))
                throw (new Exception("密文不得为空"));
            if (string.IsNullOrEmpty(DecryptKey))
                throw (new Exception("密钥不得为空"));
            if (DecryptKey.Length < 5 || DecryptKey.Length > 16)
                throw (new Exception("密钥必须为5-16位"));
            byte[] m_btIV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            string m_strDecrypt = "";
            RC2CryptoServiceProvider m_RC2Provider = new RC2CryptoServiceProvider();
            try
            {
                byte[] m_btDecryptString = Convert.FromBase64String(DecryptString);
                MemoryStream m_stream = new MemoryStream();
                CryptoStream m_cstream = new CryptoStream(m_stream,
                    m_RC2Provider.CreateDecryptor(Encoding.Default.GetBytes(DecryptKey), m_btIV), 
                    CryptoStreamMode.Write);
                m_cstream.Write(m_btDecryptString, 0, m_btDecryptString.Length);
                m_cstream.FlushFinalBlock();
                m_strDecrypt = Encoding.Default.GetString(m_stream.ToArray());
                m_stream.Close();
                m_stream.Dispose();
                m_cstream.Close(); 
                m_cstream.Dispose();
            }
            catch (IOException ex) 
            { 
                throw ex;
            }
            catch (CryptographicException ex)
            { 
                throw ex; 
            }
            catch (ArgumentException ex)
            { 
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            { 
                m_RC2Provider.Clear(); 
            }
            return m_strDecrypt;
        }
        #endregion
    }

}
