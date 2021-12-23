using DAL.Entities;
using DAL.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class StorageContext : DbContext
    {
        public DbSet<Good> Goods { get; set; }
        public DbSet<Order> Orders { get; set; }

        static StorageContext()
        {
            Database.SetInitializer<StorageContext>(new StoreDbInitializer());
        }

        public StorageContext(string connectionString)
            : base(connectionString)
        {

        }
    }

    public class StoreDbInitializer : CreateDatabaseIfNotExists<StorageContext>
    {
        protected override void Seed(StorageContext db)
        {
            Good good1 = new Good()
            {
                Name = "Apple",
                Count = 500,
                Price = (decimal)20,
                Descr = "Good red apples"

            };
            Good good2 = new Good()
            {

                Name = "Pear",
                Count = 200,
                Price = (decimal)30,
                Descr = "Yellow tasty pears"
            }; Good good3 = new Good()
            {
                Name = "Plum",
                Count = 300,
                Price = (decimal)40,
                Descr = "Ukrainian plums"
            }; Good good4 = new Good()
            {
                Name = "Potato",
                Count = 1000,
                Price = (decimal)10,
                Descr = "Natural potatoes"
            }; Good good5 = new Good()
            {
                Name = "Tomatoes",
                Count = 100,
                Price = (decimal)80,
                Descr = "Spanish tomatoes"
            };
            db.Goods.Add(good1);
            db.Goods.Add(good2);
            db.Goods.Add(good3);
            db.Goods.Add(good4);
            db.Goods.Add(good5);
            Order order1 = new Order()
            {
                Count = 50,
                Good = good1,
                GoodId = good1.Id,
                Email = "anna@ukr.net",
                Sum = 50 * good1.Price,
                Date = new DateTime(2021, 12, 10),
                Status = Status.New
            };
            Order order2 = new Order()
            {
                Count = 30,
                Good = good2,
                GoodId = good2.Id,
                Email = "valik@gmail.com",
                Sum = 30 * good2.Price,
                Date = new DateTime(2021, 11, 1),
                Status = Status.New
            };
            db.Orders.Add(order1);
            db.Orders.Add(order2);
            db.SaveChanges();
        }

    }
}
