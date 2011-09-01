using System;

namespace Landlord2.Data
{
    ///////////////////////////////////////////////////////////
    /// EF4的实体框架对GUID列的支持还不好，这里在构造函数里初始化GUID
    ///////////////////////////////////////////////////////////

    public partial class 客房
    {
        public 客房()
        {
            this.ID = Guid.NewGuid();
        }
    }

   
}
