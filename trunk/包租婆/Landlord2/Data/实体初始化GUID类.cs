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

    public partial class 客房出租历史记录
    {
        public 客房出租历史记录()
        {
            this.ID = Guid.NewGuid();
        }
    }
    public partial class 客房租金明细
    {
        public 客房租金明细()
        {
            this.ID = Guid.NewGuid();
        }
    }
    public partial class 日常损耗
    {
        public 日常损耗()
        {
            this.ID = Guid.NewGuid();
        }
    }
    public partial class 提醒
    {
        public 提醒()
        {
            this.ID = Guid.NewGuid();
        }
    }
    public partial class 源房
    {
        public 源房()
        {
            this.ID = Guid.NewGuid();
        }
    }
    public partial class 源房缴费明细
    {
        public 源房缴费明细()
        {
            this.ID = Guid.NewGuid();
        }
    }
    public partial class 源房水电气核查
    {
        public 源房水电气核查()
        {
            this.ID = Guid.NewGuid();
        }
    }
    public partial class 源房涨租协定
    {
        public 源房涨租协定()
        {
            this.ID = Guid.NewGuid();
        }
    }
    public partial class 装修明细
    {
        public 装修明细()
        {
            this.ID = Guid.NewGuid();
        }
    }
}
