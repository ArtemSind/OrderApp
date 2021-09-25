using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OrderApp.Models
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }


    }
}
