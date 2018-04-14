using System;
using System.Collections.Generic;
using Domain.Interfaces.Repositories;
using Data_Access.EF;
using System.Linq;
using System.Data.Entity;

namespace Repositories.Repositories
{
    public abstract class BaseRepository<T> : IDisposable, IBaseRepository<T> where T : class
    {
        protected RemoteContext Rc = new RemoteContext();

        public T GetById(int id)
        {
            return Rc.Set<T>().Find(id);
        }

        public IEnumerable<T> GetSubset(int start, int end)
        {
            return Rc.Set<T>().Skip(start).Take(end).ToList();
        }

        public IEnumerable<T> GetAll()
        {
            return Rc.Set<T>().ToList();
        }

        public int Add(T obj)
        {
            Rc.Set<T>().Add(obj);
            return Rc.SaveChanges();
        }

        public int Update(T obj)
        {
            Rc.Entry(obj).State = EntityState.Modified;
            return Rc.SaveChanges();
        }

        public int Remove(T obj)
        {
            Rc.Set<T>().Remove(obj);
            return Rc.SaveChanges();
        }

        public void Dispose()
        {
            Rc.Dispose();
        }
    }
}
