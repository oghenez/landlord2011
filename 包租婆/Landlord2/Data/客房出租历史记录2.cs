using System;
using System.Data.Objects;
using System.Linq;

namespace Landlord2.Data
{

    public partial class GuestRoomRentHistory
    {
        public GuestRoomRentHistory()
        {
            this.ID = Guid.NewGuid();
        }

    }

   
}
