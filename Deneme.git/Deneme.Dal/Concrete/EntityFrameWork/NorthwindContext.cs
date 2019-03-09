using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using Deneme.Entities.Concrete;
using Microsoft.EntityFrameworkCore;


namespace Deneme.Dal.Concrete.EntityFrameWork
{
    public class NorthwindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\MSSQLLocalDB;Database=Northwind;Integrated Security=True;");
        }
        public DbSet<Product> Products  { get; set; }
        public DbSet<Category> Categories { get; set; }
}
    
}
