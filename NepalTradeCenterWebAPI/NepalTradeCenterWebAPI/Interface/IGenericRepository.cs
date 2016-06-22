using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NepalTradeCenterWebAPI.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> getAll();
        void add(T obj);
        void saveChanges();
        T get(object id);
        void update(T obj);
        void delete(object id);
    }
}