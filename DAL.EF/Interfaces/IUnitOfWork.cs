using System;
using System.Collections.Generic;
using System.Text;
using DAL.EF.Models;

namespace DAL.EF.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Category> Categories { get; }
        IRepository<Product> Products { get; }
        IRepository<Supplier> Suppliers { get; }
        void Save();
    }
}
