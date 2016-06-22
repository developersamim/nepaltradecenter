using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NepalTradeCenterWebAPI.Interface;
using System.Data.Entity;

namespace NepalTradeCenterWebAPI.Models
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private MyContext myContext = null;
        private DbSet<T> table = null;

        public GenericRepository()
        {
            this.myContext = new MyContext();
            this.table = myContext.Set<T>();
        }

        public void add(T obj)
        {
            table.Add(obj);
        }

        public T get(object id)
        {
            return table.Find(id);
        }

        public IEnumerable<T> getAll()
        {
            return table.ToList();            
        }

        public void saveChanges()
        {
            myContext.SaveChanges();
        }

        public void update(T obj)
        {
            table.Attach(obj);
            myContext.Entry(obj).State = EntityState.Modified;
        }

        public void delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
    }
}