﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZEMP.DAO
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
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
    
        public virtual DbSet<ZEMP_CONGDOAN> ZEMP_CONGDOAN { get; set; }
        public virtual DbSet<ZEMP_CH> ZEMP_CH { get; set; }
        public virtual DbSet<ZEMP_DAURA_KV> ZEMP_DAURA_KV { get; set; }
        public virtual DbSet<ZEMP_DAURA_NG> ZEMP_DAURA_NG { get; set; }
        public virtual DbSet<ZEMP_DAURA_WC> ZEMP_DAURA_WC { get; set; }
        public virtual DbSet<ZEMP_KV> ZEMP_KV { get; set; }
        public virtual DbSet<ZEMP_NG> ZEMP_NG { get; set; }
        public virtual DbSet<ZEMP_PQ> ZEMP_PQ { get; set; }
        public virtual DbSet<ZEMP_SL_CH> ZEMP_SL_CH { get; set; }
        public virtual DbSet<ZEMP_SL_KV> ZEMP_SL_KV { get; set; }
        public virtual DbSet<ZEMP_SL_NG> ZEMP_SL_NG { get; set; }
        public virtual DbSet<ZEMP_SL_WC> ZEMP_SL_WC { get; set; }
        public virtual DbSet<ZEMP_TK_KV> ZEMP_TK_KV { get; set; }
        public virtual DbSet<ZEMP_TK_NG> ZEMP_TK_NG { get; set; }
        public virtual DbSet<ZEMP_TK_WC> ZEMP_TK_WC { get; set; }
        public virtual DbSet<ZEMP_USER> ZEMP_USER { get; set; }
        public virtual DbSet<ZEMP_WC> ZEMP_WC { get; set; }
        public virtual DbSet<ZEMP_CF_MODE> ZEMP_CF_MODE { get; set; }
        public virtual DbSet<ZEMP_LOG> ZEMP_LOG { get; set; }
    
        public virtual int GetSanLuongOnline(string mode, string capdo, string giatricapdo, string congdoan, string ngay)
        {
            var modeParameter = mode != null ?
                new ObjectParameter("mode", mode) :
                new ObjectParameter("mode", typeof(string));
    
            var capdoParameter = capdo != null ?
                new ObjectParameter("capdo", capdo) :
                new ObjectParameter("capdo", typeof(string));
    
            var giatricapdoParameter = giatricapdo != null ?
                new ObjectParameter("giatricapdo", giatricapdo) :
                new ObjectParameter("giatricapdo", typeof(string));
    
            var congdoanParameter = congdoan != null ?
                new ObjectParameter("congdoan", congdoan) :
                new ObjectParameter("congdoan", typeof(string));
    
            var ngayParameter = ngay != null ?
                new ObjectParameter("ngay", ngay) :
                new ObjectParameter("ngay", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetSanLuongOnline", modeParameter, capdoParameter, giatricapdoParameter, congdoanParameter, ngayParameter);
        }
    
        public virtual ObjectResult<ListCapDo> GetListCapDo(string username)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ListCapDo>("GetListCapDo", usernameParameter);
        }
    }
}