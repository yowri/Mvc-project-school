﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectMvC.DataModels
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class spelerModel : DbContext
    {
        public spelerModel()
            : base("name=spelerModel")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Speler> Spelers { get; set; }
        public DbSet<StatsTeam> StatsTeams { get; set; }
        public DbSet<StatsTeamExtended> StatsTeamExtendeds { get; set; }
    }
}