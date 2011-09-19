using System;
using System.Data.Objects;
using System.Linq;

namespace Landlord2.Data
{
    ///////////////////////////////////////////////////////////
    /// EF4的实体框架对GUID列的支持还不好，这里在构造函数里初始化GUID
    ///////////////////////////////////////////////////////////

    public partial class 客房
    {
        public static 客房 MyCreate()
        {
            return new 客房() { ID = Guid.NewGuid(), 支付月数 = 3 };
        }

    }

   
}
