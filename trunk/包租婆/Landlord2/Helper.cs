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
    }
}
