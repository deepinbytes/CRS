﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ABC_CRS
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ABC_CRSEntities2 : DbContext
    {
        public ABC_CRSEntities2()
            : base("name=ABC_CRSEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<CompanyHR> CompanyHRs { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Participant> Participants { get; set; }
        public virtual DbSet<Registration> Registrations { get; set; }
    }
}