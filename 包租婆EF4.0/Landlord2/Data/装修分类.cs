using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Landlord2.Data
{
    public partial class 装修分类
    {
        public 装修分类()
        {
            this.ID = Guid.NewGuid();
        }
    }
}
