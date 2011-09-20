using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Landlord2.Data
{
    public partial class Entities
    {
        public Entities()
            : base(AppRoot.MyConnection, true)
        {
            //自定义了连接
        }
    }
}
