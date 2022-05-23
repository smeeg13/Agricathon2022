﻿using System;
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
        public static string ConnectionString { get; set; } = @"Server=(localDB)\MSSQLLocalDB;Database=AgricathonParcelles2022;"+
                                                  "Trusted_Connection=True;App=Agricathon2022;MultipleActiveResultSets=true";

        public AgricathonContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder) {
            builder.UseSqlServer(ConnectionString);

            //builder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            //préciser / forcer les clés ici !

            //builder.Entity<Parcelle>().HasOne(x => x.ExploitantID)
            

            //builder.Entity<Parcelle>()
            //        .HasOne(e => e.Exploitant)
            //        .WithMany()
            //        .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<Parcelle>()
            //        .HasOne(e => e.Propietaire)
            //        .WithMany()
            //        .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
