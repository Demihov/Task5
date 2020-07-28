using System;
using System.Collections.Generic;
using System.Text;
using DAL.ADO.Interfaces;
using DAL.ADO.Models;

namespace DAL.ADO.Repositories
{
    public class ADOUnitOfWork : IUnitOfWork, IDisposable
    {
        private SupplierRepository supplierRepository;
        private ProductRepository productRepository;
        private CategoryRepository categoryRepository;

        private string _connectionString;

        public ADOUnitOfWork(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IRepository<Category> Categories => categoryRepository ?? new CategoryRepository(_connectionString);

        public IRepository<Product> Products => productRepository ?? new ProductRepository(_connectionString);

        public IRepository<Supplier> Suppliers => supplierRepository ?? new SupplierRepository(_connectionString);

        public void Dispose() { }
    }
}
