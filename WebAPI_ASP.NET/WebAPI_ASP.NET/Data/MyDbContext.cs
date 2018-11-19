using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI_ASP.NET.Model;

namespace WebAPI_ASP.NET.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext (DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public DbSet<WebAPI_ASP.NET.Model.Person> Person { get; set; }
    }
}
