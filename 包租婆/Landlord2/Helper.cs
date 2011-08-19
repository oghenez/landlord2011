using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.EntityClient;
using System.Data;
using System.Data.Objects;

namespace Landlord2
{
    class Helper
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
            entityBuilder.Metadata = @"res://*/Data.Model1.csdl|res://*/Data.Model1.ssdl|res://*/Data.Model1.msl";


            return entityBuilder.ToString();
        }
        #endregion

        /// <summary>
        /// 保存到数据库
        /// </summary>
        /// <param name="entity">针对的实体对象</param>
        /// <param name="ResultMsg">返回的消息</param>
        /// <returns>返回是否成功标志</returns>
        public static bool saveData(object entity, out string ResultMsg)
        {
            bool flag = false;
            int num;
            try
            {
                num = Main.context.SaveChanges();
                flag = true;
                ResultMsg = string.Format("成功操作{0}条记录。", num);
            }
            catch (OptimisticConcurrencyException)
            {
                Main.context.Refresh(RefreshMode.ClientWins, entity);
                num = Main.context.SaveChanges();
                flag = true;
                ResultMsg = string.Format("成功处理开放式并发异常，并操作{0}条记录。",num);
            }
            catch (Exception ex)
            {
                string msg = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message;
                ResultMsg = string.Format("数据操作失败：{0}",  msg);
            }
            return flag;
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
    }
}
