using System;

namespace Landlord2.Data
{
    ///////////////////////////////////////////////////////////
    /// EF4的实体框架对GUID列的支持还不好，这里在构造函数里初始化GUID
    ///////////////////////////////////////////////////////////

    public partial class 源房抄表
    {
        public 源房抄表()
        {
            this.ID = Guid.NewGuid();
            this.抄表时间 = DateTime.Today;
        }
    }
}
