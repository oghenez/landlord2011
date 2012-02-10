using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.EntityClient;

namespace Landlord2.Data
{
    public class MyContext : Entities
    {
        /// <summary>
        /// 常规窗体调用这个构造Context
        /// </summary>
        public MyContext()
            : base(new EntityConnection(Helper.CreateConnectString()))
        {
            //!+ 项目调用这个构造Context
        }

        /// <summary>
        /// 主窗体的Context用这个构造
        /// </summary>
        /// <param name="connection">AppRoot中的静态常开连接</param>
        public MyContext(EntityConnection connection)
            : base(connection)
        {
            //!+ 主窗体的Context用这个构造
        }
    }
}
