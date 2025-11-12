using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sabo_Gabriel_Lab2.Models;

namespace Sabo_Gabriel_Lab2.Data
{
    public class Sabo_Gabriel_Lab2Context : DbContext
    {
        public Sabo_Gabriel_Lab2Context (DbContextOptions<Sabo_Gabriel_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Sabo_Gabriel_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Sabo_Gabriel_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Sabo_Gabriel_Lab2.Models.Author> Author { get; set; } = default!;
        public DbSet<Sabo_Gabriel_Lab2.Models.Category> Category { get; set; } = default!;
    }
}
