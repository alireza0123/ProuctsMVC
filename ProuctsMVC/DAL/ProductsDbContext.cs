using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ProuctsMVC.Models;

namespace ProuctsMVC.DAL
{
    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext(): base("name = ProductsDbContext")
            {
            }
        public DbSet<Products> Product { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Company> Companies { get; set; }
       

    }
}