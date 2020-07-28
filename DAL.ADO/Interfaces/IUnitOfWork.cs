using DAL.ADO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.ADO.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Category> Categories { get; }
        IRepository<Product> Products { get; }
        IRepository<Supplier> Suppliers { get; }
    }
}
