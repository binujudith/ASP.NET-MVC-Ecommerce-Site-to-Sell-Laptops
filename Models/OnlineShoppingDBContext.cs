using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OnlineShopping.Models
{
    public class OnlineShoppingDBContext:DbContext
    {
        public OnlineShoppingDBContext()
        {
        }

        public OnlineShoppingDBContext(DbContextOptions<OnlineShoppingDBContext> options)
            : base(options)
        {
        }
        public DbSet<Laptops> laptop { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Laptops>().HasData(
                new Laptops { serialNo = 1,Image="/laptop10.jpg", ModelName = "HP", specification = "10th Gen i3-1005G1/8GB/256GB", Colour = "Black", Price = 45000 },
                new Laptops { serialNo = 2, Image= "/laptop11.jpg", ModelName = "Dell", specification = "10th gen Intel Core i3/ 8GB / 1TB", Colour = "Black", Price = 36990 },
                new Laptops { serialNo = 3, Image= "/laptop19.jpg", ModelName = "Lenovo", specification = "4GB/1TB HDD/Windows 10/MS", Colour = "Platinum Grey", Price = 50000 },
                new Laptops { serialNo = 4, Image = "/laptop20.jpg", ModelName = "HP", specification = "i5-10210U/8GB/512GB ", Colour = "Jet Black", Price = 52490 },
                new Laptops { serialNo = 5, Image= "/laptop6.jpg", ModelName = "HP", specification = "Ryzen 5 3450U/8GB/512GB SSD", Colour = "Silver", Price = 45490 },
                new Laptops { serialNo = 6, Image = "/laptop7.jpg", ModelName = "Asus", specification = "4GB RAM/1 TB HDD/Windows 10", Colour = "Transparent Silver", Price = 25269 },
                new Laptops { serialNo = 7, Image = "/laptop8.jpg", ModelName = "Aser", specification = "4GB Ram/1TB HDD/Window 10", Colour = "Pure Silver", Price = 28670 }
                );
        }
        //public Laptops find(string id)
        //{
        //    List<Laptops> laptop=();
        //    var lap = laptop.Where(a => a.serialNo == id).FirstOrDefault();
        //    return lap;

        //}
    }
}
