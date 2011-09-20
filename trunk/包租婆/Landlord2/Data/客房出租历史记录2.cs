using System;
using System.Data.Objects;
using System.Linq;

namespace Landlord2.Data
{

    public partial class 客房出租历史记录
    {
        public 客房出租历史记录()
        {
            this.ID = Guid.NewGuid();
        }

    }

   
}
