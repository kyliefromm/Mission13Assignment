using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Mission13.Models
{
    public class BowlingDbContext : DbContext
    {

        public BowlingDbContext(DbContextOptions<BowlingDbContext> options) : base(options)
        {

        }

        public DbSet<Bowl> Bowlers { get; set; }
        public DbSet<Team> Teams { get; set; }

       
    }
}
