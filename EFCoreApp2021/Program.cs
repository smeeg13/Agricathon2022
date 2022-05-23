using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Agricathon2022;

namespace EFCoreApp2021
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new AgricathonContext();

            var e = ctx.Database.EnsureCreated();

            if (e)
                Console.WriteLine("Database has been created.");
            else
                Console.WriteLine("Database already exists");

            Console.WriteLine("done.");

            populateDatabase(ctx);

        }

        private static void populateDatabase(AgricathonContext ctx)
        {
            Exploitant exploitant1 = new Exploitant() { NoExploitant="742", Firstname="Doriane", Lastname="Papilloud", Address="Chemin de Sierre 12", Email="doriane@gmail.ch", Password="password"};
            ctx.ExploitantSet.Add(exploitant1);

            Proprietaire proprietaire1 = new Proprietaire() { Firstname = "Gaétan", Lastname = "Mottet", Address="Route des vignobles 3", Email="gaetan@gmail.ch", Password="password" };
            ctx.ProprietaireSet.Add(proprietaire1);




            ctx.SaveChanges();

        }


    }
}
