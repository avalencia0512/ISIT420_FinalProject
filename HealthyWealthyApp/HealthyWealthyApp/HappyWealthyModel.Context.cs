//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HealthyWealthyApp
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HappyWealthyLifeDbEntities : DbContext
    {
        public HappyWealthyLifeDbEntities()
            : base("name=HappyWealthyLifeDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Happiness> Happinesses { get; set; }
        public virtual DbSet<IncomePP> IncomePPs { get; set; }
        public virtual DbSet<LifeYear> LifeYears { get; set; }
    }
}
