//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Landlord2.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class SourceRoomPaymentDetail
    {
        public System.DateTime 缴费时间 { get; set; }
        public decimal 缴费金额 { get; set; }
        public Nullable<System.DateTime> 期始 { get; set; }
        public Nullable<System.DateTime> 期止 { get; set; }
        public string 付款人 { get; set; }
        public string 收款人 { get; set; }
        public string 备注 { get; set; }
        public System.Guid 源房ID { get; set; }
        public string 缴费项 { get; set; }
        public System.Guid ID { get; set; }
    
        public virtual SourceRoom SourceRoom { get; set; }
    }
}
