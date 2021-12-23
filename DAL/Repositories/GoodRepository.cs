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
    public class GoodRepository : IRepository<Good>
    {
        private readonly StorageContext db;

        public GoodRepository(StorageContext context)
        {
            db = context;
        }
        public void Create(Good item)
        {
            db.Goods.Add(item);
        }

        public void Delete(int id)
        {
            Good good = db.Goods.Find(id);
            if (good != null)
            {
                db.Goods.Remove(good);
            }

        }

        public IEnumerable<Good> Find(Func<Good, bool> predicate)
        {
            return db.Goods.Where(predicate).ToList();
        }

        public Good Get(int id)
        {
            return db.Goods.Find(id);
        }

        public IEnumerable<Good> GetAll()
        {
            return db.Goods;
        }

        public void Update(Good item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
