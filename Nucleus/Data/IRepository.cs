using System;
using System.Collections.Generic;

namespace Nucleus.Data
{
    public interface IRepository<T> where T:class
    {
        T GetById(int Id);
        T GetById(Guid Id);
        IEnumerable<T> Get();
        T Create(T Instance);
        void Update(T Instance);
        void Delete(T Instance);
    }
}