using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EFCoreApp2021
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var ctx = new AgricathonContext();

            var e = ctx.Database.EnsureCreated();

            if (e)
                Console.WriteLine("Database has been created.");
            else
                Console.WriteLine("Database already exists");

            Console.WriteLine("done."); 
        }
    }
}
