using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF.Interfaces
{
    public interface IRepository<T> where T: class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Insert(T item);
        void Update(T item);
        void Delete(int id);
    }
}
