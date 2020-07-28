using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using DAL.EF.Interfaces;
using DAL.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private ShopContext db;

        public ProductRepository(ShopContext context)
        {
            db = context;
        }

        public void Insert(Product product)
        {
            if (product != null)
                db.Products.Add(product);
        }
        public void Delete(int id)
        {
            Product product = db.Products.Find(id);
            if (product != null)
                db.Products.Remove(product);
        }
        public Product Get(int id)
        {
            return db.Products.Find(id);
        }
        public IEnumerable<Product> GetAll()
        {
            return db.Products.ToList();
        }
        public void Update(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
