using System.Collections.Generic;

namespace Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        int Add(T obj);

        T GetById(int id);

        IEnumerable<T> GetSubset(int start, int end);

        IEnumerable<T> GetAll();

        void Update(T obj);

        void Remove(T obj);
    }
}
