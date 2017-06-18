using Evite.Models;
using System;
using System.Linq;
//using Evite.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
namespace Evite.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = new EviteDBContext(serviceProvider.GetRequiredService<DbContextOptions<EviteDBContext>>());
 
            context.Database.EnsureCreated();
            // var evites = context.ResponseToEvites;
            // Look for any students.
            if (context.ResponseToEvites.Any())
            {
                return;   // DB has been seeded
            }
            var evites = new ResponseToEvite[]
            {
            new ResponseToEvite{Name="Darshan Lam",Email="DarshanLam@gmail.com",Phone="(305) 793-2596",WillAttend=true},
            new ResponseToEvite{Name="Alexander Nunez",Email="xanderve@gmail.com",Phone="(305) 111-1111",WillAttend=true},
            new ResponseToEvite{Name="Dylan Tackoor",Email="dylan@cs50xmiami.com",Phone="(305) 567-3854",WillAttend=false},
            new ResponseToEvite{Name="Evelyn Feristin",Email="eferistin@gmail.com",Phone="(954) 756-7746",WillAttend=true},
            new ResponseToEvite{Name="Jack Rus",Email="enagimov@gmail.com",Phone="(305) 333-3434",WillAttend=true}
            };
            foreach (ResponseToEvite s in evites)
            {
                context.ResponseToEvites.Add(s);
                //AllResponses.AddResponse(s);
                context.SaveChanges();
            }
            context.SaveChanges();
        }
    }
} 