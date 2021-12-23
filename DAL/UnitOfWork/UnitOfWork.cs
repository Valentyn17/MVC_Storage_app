using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StorageContext db;
        private IRepository<Good> goodRepository;  
        private IRepository<Order> orderRepository;

        public UnitOfWork(string connectionString)
        {
            db = new StorageContext(connectionString);
        }

        public IRepository<Good> Goods
        {
            get
            {
                if (goodRepository == null)
                    goodRepository = new GoodRepository(db);
                return goodRepository;
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(db);
                return orderRepository;
            }
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
