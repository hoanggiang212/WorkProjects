﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TbsGroup.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TKTDSXEntities : DbContext
    {
        public TKTDSXEntities()
            : base("name=TKTDSXEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BI_COLOR_CDOAN> BI_COLOR_CDOAN { get; set; }
        public virtual DbSet<BI_CPTH> BI_CPTH { get; set; }
        public virtual DbSet<BI_PHAN_QUYEN> BI_PHAN_QUYEN { get; set; }
        public virtual DbSet<BI_SLKH_WC> BI_SLKH_WC { get; set; }
        public virtual DbSet<BI_SLLD_CHUYEN> BI_SLLD_CHUYEN { get; set; }
        public virtual DbSet<BI_SLLDNS> BI_SLLDNS { get; set; }
        public virtual DbSet<BI_SLSX_CHUYEN_NGAY> BI_SLSX_CHUYEN_NGAY { get; set; }
        public virtual DbSet<BI_SLSX_CHUYEN_THANG> BI_SLSX_CHUYEN_THANG { get; set; }
        public virtual DbSet<BI_SLSX_CHUYEN_TUAN> BI_SLSX_CHUYEN_TUAN { get; set; }
        public virtual DbSet<BI_TONGLD> BI_TONGLD { get; set; }
        public virtual DbSet<BI_ZQLSX> BI_ZQLSX { get; set; }
        public virtual DbSet<BI_SLKH_CH> BI_SLKH_CH { get; set; }
        public virtual DbSet<BI_SANLUONG_ONLINE> BI_SANLUONG_ONLINE { get; set; }
        public virtual DbSet<VW_SL_ONLINE> VW_SL_ONLINE { get; set; }
        public virtual DbSet<BI_USER> BI_USER { get; set; }
        public virtual DbSet<VW_TKLD> VW_TKLD { get; set; }
        public virtual DbSet<BI_SANLUONG_ONLINE_TEMP> BI_SANLUONG_ONLINE_TEMP { get; set; }
    }
}
