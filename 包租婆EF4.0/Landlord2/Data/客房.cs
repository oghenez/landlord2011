using System;
using System.Data.Objects;
using System.Linq;

namespace Landlord2.Data
{

    public partial class 客房
    {
        public 客房()
        {
            this.ID = Guid.NewGuid();
            this.支付月数 = 3;//默认3月一付
        }

        /// <summary>
        /// 移除‘已出租’的客房中租户相关信息，置为‘未出租’状态。
        /// </summary>
        public void 移除租户信息()
        {
            this.租户 = null;
            this.电话1 = null;
            this.电话2 = null;
            this.联系地址 = null;
            this.身份证号 = null;
            this.期始 = null;
            this.期止 = null;
            this.押金 = 0;
            this.中介费用 = 0;
            this.租赁协议照片1 = null;
            this.租赁协议照片2 = null;
            this.租赁协议照片3 = null;
        }
    }

   
}
