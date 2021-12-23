using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly StorageContext db;

        public OrderRepository(StorageContext context)
        {
            db = context;
        }
        public void Create(Order item)
        {
            db.Orders.Add(item);
        }

        public void Delete(int id)
        {
            Order order = db.Orders.Find(id);
            if (order != null)
            {
                db.Orders.Remove(order);
            }
        }

        public IEnumerable<Order> Find(Func<Order, bool> predicate)
        {
            return db.Orders.Where(predicate);
        }

        public Order Get(int id)
        {
            return db.Orders.AsNoTracking().FirstOrDefault(i=>i.Id==id);
        }

        public IEnumerable<Order> GetAll()
        {
            return db.Orders;
        }

        public void Update(Order item)
        {
            //db.As.Attach(item);  
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
