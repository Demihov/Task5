using System;
using System.Collections.Generic;
using System.Text;
using DAL.EF;
using DAL.EF.Interfaces;
using DAL.EF.Models;
using DAL.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.EF
{
    public class DALConfiguration
    {
        public static IServiceCollection Configure(string connection)
        {
            var services = new ServiceCollection();

            services.AddDbContext<ShopContext>(options =>
                options.UseSqlServer(connection));

            services.AddSingleton<IRepository<Product>, ProductRepository>();
            services.AddSingleton<IRepository<Category>, CategoryRepository>();
            services.AddSingleton<IRepository<Supplier>, SupplierRepository>();
            services.AddSingleton<IUnitOfWork, EFUnitOfWork>();
            
            return services;
        }

    }
}
