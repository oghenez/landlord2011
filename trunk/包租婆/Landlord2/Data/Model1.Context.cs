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
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
            //手动添加
            this.Database.Connection.ConnectionString = Helper.CreateConnectString();            
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<客房> 客房 { get; set; }
        public DbSet<客房出租历史记录> 客房出租历史记录 { get; set; }
        public DbSet<客房租金明细> 客房租金明细 { get; set; }
        public DbSet<日常损耗> 日常损耗 { get; set; }
        public DbSet<提醒> 提醒 { get; set; }
        public DbSet<源房> 源房 { get; set; }
        public DbSet<源房缴费明细> 源房缴费明细 { get; set; }
        public DbSet<源房水电气核查> 源房水电气核查 { get; set; }
        public DbSet<源房涨租协定> 源房涨租协定 { get; set; }
        public DbSet<装修分类> 装修分类 { get; set; }
        public DbSet<装修明细> 装修明细 { get; set; }
    }
}
