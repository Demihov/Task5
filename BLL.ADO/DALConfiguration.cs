using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.ADO.Interfaces;
using DAL.ADO.Repositories;
using DAL.ADO.Models;

namespace BLL.ADO
{
    public class DALConfiguration
    {
        public static IServiceCollection Configure(string connection)
        {
            var services = new ServiceCollection();
            services.AddSingleton<IUnitOfWork>(new ADOUnitOfWork(connection));
            services.AddSingleton<IRepository<Product>, ProductRepository>();
            services.AddSingleton<IRepository<Category>, CategoryRepository>();
            services.AddSingleton<IRepository<Supplier>, SupplierRepository>();

            return services;
        }
    }
}
