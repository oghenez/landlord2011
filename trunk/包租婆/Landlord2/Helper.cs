using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.EntityClient;

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

    }
}
