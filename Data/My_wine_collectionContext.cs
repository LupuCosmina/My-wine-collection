using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using My_wine_collection.Models;

namespace My_wine_collection.Data
{
    public class My_wine_collectionContext : DbContext
    {
        public My_wine_collectionContext (DbContextOptions<My_wine_collectionContext> options)
            : base(options)
        {
        }

        public DbSet<My_wine_collection.Models.Wine> Wine { get; set; }

        public DbSet<My_wine_collection.Models.Producer> Producer { get; set; }

        public DbSet<My_wine_collection.Models.Type> Type { get; set; }

        public DbSet<My_wine_collection.Models.WineType> WineType { get; set; }
    }
}
