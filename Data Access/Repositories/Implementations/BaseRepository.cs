using Data_Access.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Data_Access.Repositories
{
    class BaseRepository<TEntity> : IDisposable, IBaseRepository<TEntity> where TEntity : class
    {
        protected LocalContext Lc = new LocalContext();

        public void Add(TEntity obj)
        {
            Lc.Set<TEntity>().Add(obj);
            Lc.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            return Lc.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Lc.Set<TEntity>().ToList();
        }

        public void Remove(TEntity obj)
        {
            Lc.Set<TEntity>().Remove(obj);
            Lc.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            Lc.Entry(obj).State = EntityState.Modified;
            Lc.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
