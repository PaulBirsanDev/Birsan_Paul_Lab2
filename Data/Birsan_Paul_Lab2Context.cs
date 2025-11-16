using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Birsan_Paul_Lab2.Models;

namespace Birsan_Paul_Lab2.Data
{
    public class Birsan_Paul_Lab2Context : DbContext
    {
        public Birsan_Paul_Lab2Context (DbContextOptions<Birsan_Paul_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Birsan_Paul_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Birsan_Paul_Lab2.Models.Publisher> Publisher { get; set; } = default!;
    }
}
