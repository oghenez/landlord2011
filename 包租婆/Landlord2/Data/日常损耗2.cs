using System;

namespace Landlord2.Data
{
    public partial class 日常损耗
    {
        public 日常损耗()
        {
            this.ID = Guid.NewGuid();
            this.支出日期 = DateTime.Today;
        }
    }
   
}
