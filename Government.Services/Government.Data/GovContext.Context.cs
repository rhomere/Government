﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Government.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CityEntities : DbContext
    {
        public CityEntities()
            : base("name=CityEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Municipal> Municipalities { get; set; }
        public virtual DbSet<Official> Officials { get; set; }
        public virtual DbSet<OfficialXGovFile> OfficialXGovFiles { get; set; }
        public virtual DbSet<GovernmentFile> GovernmentFiles { get; set; }
    }
}
