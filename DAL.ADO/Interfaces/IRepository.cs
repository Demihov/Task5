using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.ADO.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Insert(T product);
        void Update(T product);
        void Delete(int id);
    }
}
