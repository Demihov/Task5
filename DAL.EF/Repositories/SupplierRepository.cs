using System;
using System.Collections.Generic;
using System.Text;
using DAL.EF.Interfaces;
using DAL.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.Repositories
{
    public class SupplierRepository: IRepository<Supplier>
    {
        private ShopContext db;

        public SupplierRepository(ShopContext context)
        {
            db = context;
        }

        public IEnumerable<Supplier> GetAll()
        {
            return db.Suppliers;
        }
        public Supplier Get(int id)
        {
            return db.Suppliers.Find(id);
        }
        public void Insert(Supplier supplier)
        {
            if (supplier != null)
                db.Suppliers.Add(supplier);
        }
        public void Update(Supplier supplier)
        {
            db.Entry(supplier).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier != null)
                db.Remove(supplier);
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
