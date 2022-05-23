using System;
using System.Collections.Generic;
using System.Text;
using Agricathon2022;
using Microsoft.EntityFrameworkCore;

namespace EFCoreApp2021
{
    public class AgricathonContext : DbContext {
        
        public DbSet<Parcelle> ParcelleSet { get; set; }
        public DbSet<Exploitant> ExploitantSet { get; set; }
        public DbSet<Proprietaire> ProprietaireSet { get; set; }
        //public DbSet<User> UserSet { get; set; }
        public DbSet<Transaction> TransactionSet {get;set;}


        // SQL Express
        public static string ConnectionString { get; set; } = "Data Source=153.109.124.35;Initial Catalog=AgricathonParcelles2022;User ID=6231db;Password=Pwd46231.;Pooling=False";

        public AgricathonContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder) {
            builder.UseSqlServer(ConnectionString);

            //builder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            //préciser / forcer les clés ici !

            builder.Entity<Proprietaire>().HasMany(p => p.Parcelles)
                .WithOne(e => e.Propietaire)
                .HasForeignKey(k => k.ProprietaireID);

            builder.Entity<Exploitant>().HasMany(a => a.Parcelles)
                .WithOne(b => b.Exploitant)
                .HasForeignKey(c => c.ExploitantID).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
