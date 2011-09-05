using System;
using System.Data.Objects;
using System.Linq;

namespace Landlord2.Data
{
    ///////////////////////////////////////////////////////////
    /// EF4的实体框架对GUID列的支持还不好，这里在构造函数里初始化GUID
    ///////////////////////////////////////////////////////////


    public partial class 客房出租历史记录
    {
        public 客房出租历史记录()
        {
            this.ID = Guid.NewGuid();
        }

    }

   
}
