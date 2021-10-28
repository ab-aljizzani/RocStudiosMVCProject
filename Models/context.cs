using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace RocStudiosMVCProject.Models
{
    public class context : DbContext
    {
        public context() : base("RocConnection") { }

        public DbSet<About> abouts { get; set; }
        public DbSet<Portfolio> ports { get; set; }
        public DbSet<Services> servs { get;set; }
        public DbSet<Team> teams { get; set; }
        public DbSet<Clients> clis { get; set; }
        public DbSet<Account> accounts { get; set; }
        public DbSet<Order> orders { get; set; }
    }
}