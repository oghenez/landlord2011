using System;

namespace Landlord2.Data
{
    public partial class DailyLosses
    {
        public DailyLosses()
        {
            this.ID = Guid.NewGuid();
            this.֧������ = DateTime.Today;
        }
    }
   
}
