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
    
    public partial class SourceRoom
    {
        public SourceRoom()
        {
            this.DecorationDetail = new HashSet<DecorationDetail>();
            this.GuestRoom = new HashSet<GuestRoom>();
            this.SourceRoomPaymentDetail = new HashSet<SourceRoomPaymentDetail>();
            this.SourceRoomCheck = new HashSet<SourceRoomCheck>();
            this.SourceRoomUpRentalAgreement = new HashSet<SourceRoomUpRentalAgreement>();
        }
    
        public string 房名 { get; set; }
        public string 用途 { get; set; }
        public string 结构 { get; set; }
        public double 建筑面积 { get; set; }
        public short 室 { get; set; }
        public short 厅 { get; set; }
        public short 卫 { get; set; }
        public string 装修 { get; set; }
        public string 权证号 { get; set; }
        public string 房东 { get; set; }
        public string 联系地址 { get; set; }
        public string 身份证号 { get; set; }
        public string 电话1 { get; set; }
        public string 电话2 { get; set; }
        public decimal 押金 { get; set; }
        public short 支付月数 { get; set; }
        public byte[] 租赁协议照片1 { get; set; }
        public byte[] 租赁协议照片2 { get; set; }
        public byte[] 租赁协议照片3 { get; set; }
        public string 备注 { get; set; }
        public decimal 月物业费 { get; set; }
        public double 水始码 { get; set; }
        public double 电始码 { get; set; }
        public double 气始码 { get; set; }
        public decimal 中介费用 { get; set; }
        public decimal 月卫生费 { get; set; }
        public string 源房东银行卡 { get; set; }
        public string 水表编号 { get; set; }
        public string 电表编号 { get; set; }
        public string 气表编号 { get; set; }
        public bool 水务代扣卫生费 { get; set; }
        public decimal 月宽带费 { get; set; }
        public string 阶梯水价 { get; set; }
        public string 阶梯电价 { get; set; }
        public decimal 气单价 { get; set; }
        public System.Guid ID { get; set; }
    
        public virtual ICollection<DecorationDetail> DecorationDetail { get; set; }
        public virtual ICollection<GuestRoom> GuestRoom { get; set; }
        public virtual ICollection<SourceRoomPaymentDetail> SourceRoomPaymentDetail { get; set; }
        public virtual ICollection<SourceRoomCheck> SourceRoomCheck { get; set; }
        public virtual ICollection<SourceRoomUpRentalAgreement> SourceRoomUpRentalAgreement { get; set; }
    }
}
