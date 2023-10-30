using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(string connectionString) : base("EShopyyConnection") { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<User> Users { get; set; }


        public class DataDbContextFactory : IDbContextFactory<DataDbContext>
        {
            public DataDbContext Create()
            {
                return new DataDbContext("name=EshopyyConnection");
            }

        }
    }
}
