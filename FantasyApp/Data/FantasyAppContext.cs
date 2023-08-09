using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FantasyApp.Models;

namespace FantasyApp.Data
{
    public class FantasyAppContext : DbContext
    {
        public FantasyAppContext (DbContextOptions<FantasyAppContext> options)
            : base(options)
        {
        }

        public DbSet<FantasyApp.Models.Volume> Volume { get; set; } = default!;
    }
}
