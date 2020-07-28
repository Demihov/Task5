using System;
using System.Collections.Generic;
using System.Text;
using DAL.EF.Interfaces;
using DAL.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF.Repositories
{
    public class CategoryRepository: IRepository<Category>
    {
        private ShopContext db;

        public CategoryRepository(ShopContext context)
        {
            db = context;
        }

        public IEnumerable<Category> GetAll()
        {
            return db.Categories;
        }
        public Category Get(int id)
        {
            return db.Categories.Find(id);
        }
        public void Insert(Category category)
        {
            if (category != null)
                db.Categories.Add(category);
        }
        public void Update(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            Category category = db.Categories.Find(id);
            if (category != null)
                db.Remove(category);
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
