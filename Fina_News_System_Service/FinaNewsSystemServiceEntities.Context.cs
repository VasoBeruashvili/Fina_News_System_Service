﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fina_News_System_Service
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Fina_News_System_ServiceEntities : DbContext
    {
        public Fina_News_System_ServiceEntities()
            : base("name=Fina_News_System_ServiceEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<ModuleTypes> ModuleTypes { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<NewsCompanyCodes> NewsCompanyCodes { get; set; }
        public DbSet<ShowTypes> ShowTypes { get; set; }
        public DbSet<Types> Types { get; set; }
    }
}
