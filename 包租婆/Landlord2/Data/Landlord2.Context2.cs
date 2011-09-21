using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Landlord2.Data
{
    public partial class Landlord2Entities
    {
        public Landlord2Entities()
            : base(AppRoot.MyConnection, ! AppRoot.IsAllInOneConnection)
        {
            //自定义了连接
        }
    }
}
