﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Landlord2Entities : DbContext
    {
        //public Landlord2Entities()
        //    : base("name=Landlord2Entities")
        //{
        //}
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<DailyLosses> DailyLosses { get; set; }
        public DbSet<DecorationDetail> DecorationDetail { get; set; }
        public DbSet<DecorationType> DecorationType { get; set; }
        public DbSet<GuestRoom> GuestRoom { get; set; }
        public DbSet<GuestRoomRentalDetail> GuestRoomRentalDetail { get; set; }
        public DbSet<GuestRoomRentHistory> GuestRoomRentHistory { get; set; }
        public DbSet<Remind> Remind { get; set; }
        public DbSet<SourceRoom> SourceRoom { get; set; }
        public DbSet<SourceRoomCheck> SourceRoomCheck { get; set; }
        public DbSet<SourceRoomPaymentDetail> SourceRoomPaymentDetail { get; set; }
        public DbSet<SourceRoomUpRentalAgreement> SourceRoomUpRentalAgreement { get; set; }
    }
}
