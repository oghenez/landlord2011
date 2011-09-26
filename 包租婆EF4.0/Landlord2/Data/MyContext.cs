using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Landlord2.Data
{
    public class MyContext : Entities
    {
        public MyContext()
            : base(AppRoot.MyConnection)
        {
            //!+ 项目调用这个构造Context
        }
    }
}
