using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EFCoreApp2021
{
    public class AgricathonContext : DbContext {
        
        public DbSet<Parcelle> ParcelleSet { get; set; }
        public DbSet<User> UserSet { get; set; }


        // SQL Express
        public static string ConnectionString { get; set; } = @"Server=(localDB)\MSSQLLocalDB;Database=AgricathonParcelles2022;"+
                                                  "Trusted_Connection=True;App=Agricathon2022;MultipleActiveResultSets=true";

        public AgricathonContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder) {
            builder.UseSqlServer(ConnectionString);

            //builder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            
           

        }


    }
}
