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
using System.Data.Entity.Infrastructure;

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
              
        //=========EF4.1自带本地查询机制==========
        ///// <summary>
        ///// 本地查询[Added,Modified,Unchanged对象]（基于ObjectSet的扩展方法）
        ///// 因为“实体框架执行的查询根据数据源中的数据进行计算，且结果将不反映对象上下文中的新对象。http://msdn.microsoft.com/zh-cn/library/bb896241.aspx ”
        ///// 那么本地新增对象未保存时，下次查询不包括这些新对象。所以增加此本地查询[Added,Modified,Unchanged对象]功能。http://blogs.msdn.com/b/dsimmons/archive/2009/02/21/local-queries.aspx
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="objectSet"></param>
        ///// <returns></returns>
        //public static IEnumerable<T> Local<T>(this ObjectSet<T> objectSet) where T : class
        //{
        //    return from stateEntry in objectSet.Context.ObjectStateManager
        //                                       .GetObjectStateEntries(EntityState.Added |
        //                                                              EntityState.Modified |
        //                                                              EntityState.Unchanged)
        //           where stateEntry.Entity != null && stateEntry.EntitySet == objectSet.EntitySet
        //           select stateEntry.Entity as T;
        //}

        /////// <summary>
        /////// 是否有Added状态对象（基于ObjectSet的扩展方法）
        /////// 如果有的话，那么查询时应该调用Local扩展方法得到本地对象；否则可以调用‘预编译’查询加速
        /////// </summary>
        /////// <typeparam name="T"></typeparam>
        /////// <param name="objectSet"></param>
        /////// <returns></returns>
        ////public static bool HasAddedObject<T>(this ObjectSet<T> objectSet) where T : class
        ////{
        ////    var objectStateEntries = objectSet.Context.ObjectStateManager.GetObjectStateEntries(EntityState.Added);
        ////    foreach (var entity in objectStateEntries)
        ////    {
        ////        if (entity.EntitySet == objectSet.EntitySet)// T 类型对象有Added
        ////            return true;
        ////    }
        ////    return false;
        ////}


        /// <summary>
        /// 保存到数据库
        /// </summary>
        /// <param name="entity">针对的实体对象</param>
        /// <param name="ResultMsg">返回的消息</param>
        /// <returns>返回是否成功标志</returns>
        public static bool saveData(Entities context, object entity, out string ResultMsg)
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
                ((IObjectContextAdapter)context).ObjectContext.Refresh(RefreshMode.ClientWins, entity);
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
            using (StreamWriter sw = File.AppendText(Path.Combine(path, "log.txt")))
            {
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + msg + Environment.NewLine) ;
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
            return returnVal;
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
            return returnVal;
        }
    }
}
