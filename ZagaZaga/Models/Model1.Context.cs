﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZagaZaga.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    
    public partial class mvcEntities : DbContext
    {
        public mvcEntities()
            : base("name=mvcEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<amount> amount { get; set; }
        public DbSet<bank_account> bank_account { get; set; }
        public DbSet<bank_transfer> bank_transfer { get; set; }
        public DbSet<check_sample> check_sample { get; set; }
        public DbSet<contact> contact { get; set; }
        public DbSet<craigslist> craigslist { get; set; }
        public DbSet<credit_card> credit_card { get; set; }
        public DbSet<dating_site> dating_site { get; set; }
        public DbSet<google_voice> google_voice { get; set; }
        public DbSet<leads> leads { get; set; }
        public DbSet<letter_writeups> letter_writeups { get; set; }
        public DbSet<mass_email> mass_email { get; set; }
        public DbSet<mass_text> mass_text { get; set; }
        public DbSet<news> news { get; set; }
        public DbSet<paypal_transfer> paypal_transfer { get; set; }
        public DbSet<phone_number> phone_number { get; set; }
        public DbSet<rdp> rdp { get; set; }
        public DbSet<send_check> send_check { get; set; }
        public DbSet<shipping_account> shipping_account { get; set; }
        public DbSet<suggest> suggest { get; set; }
        public DbSet<ticket> ticket { get; set; }
        public DbSet<transaction> transaction { get; set; }
        public DbSet<user> user { get; set; }
        public DbSet<company_chk> company_chk { get; set; }
        public DbSet<personal_chk> personal_chk { get; set; }
        public DbSet<crypto_payments> crypto_payments { get; set; }
        public DbSet<buy> buy { get; set; }
        public DbSet<trans_pay> trans_pay { get; set; }
        public DbSet<admin> admin { get; set; }
        public DbSet<ep> ep { get; set; }
        public DbSet<ssn> ssn { get; set; }
        public DbSet<my_stuff> my_stuff { get; set; }
        public DbSet<check_req> check_req { get; set; }
        public DbSet<chat> chat { get; set; }
    
    }
}
