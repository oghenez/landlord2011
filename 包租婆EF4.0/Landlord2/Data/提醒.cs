using System;

namespace Landlord2.Data
{
    ///////////////////////////////////////////////////////////
    /// EF4的实体框架对GUID列的支持还不好，这里在构造函数里初始化GUID
    ///////////////////////////////////////////////////////////


    public partial class 提醒
    {
        public 提醒()
        {
            this.ID = Guid.NewGuid();
            this.提醒时间 = DateTime.Today;
            this.创建日期 = DateTime.Today;
        }
    }
   
}
