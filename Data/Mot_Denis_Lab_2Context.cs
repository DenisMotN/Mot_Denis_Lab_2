using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mot_Denis_Lab_2.Models;

namespace Mot_Denis_Lab_2.Data
{
    public class Mot_Denis_Lab_2Context : DbContext
    {
        public Mot_Denis_Lab_2Context (DbContextOptions<Mot_Denis_Lab_2Context> options)
            : base(options)
        {
        }

        public DbSet<Mot_Denis_Lab_2.Models.Book> Book { get; set; } = default!;

        public DbSet<Mot_Denis_Lab_2.Models.Publisher> Publisher { get; set; }

        internal object Include(Func<object, object> value)
        {
            throw new NotImplementedException();
        }

        public DbSet<Mot_Denis_Lab_2.Models.Author> Author { get; set; }
    }
}
