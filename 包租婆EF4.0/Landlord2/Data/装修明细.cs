using System;

namespace Landlord2.Data
{
    ///////////////////////////////////////////////////////////
    /// EF4的实体框架对GUID列的支持还不好，这里在构造函数里初始化GUID
    ///////////////////////////////////////////////////////////

    public partial class 装修明细
    {
        public 装修明细()
        {
            this.ID = Guid.NewGuid();
            this.日期 = DateTime.Today;
        }
    }
}
