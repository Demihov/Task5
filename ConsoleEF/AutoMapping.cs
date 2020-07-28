using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BLL.EF.DTO;
using DAL.EF.Models;

namespace ConsoleEF
{
   public class AutoMapping: Profile
    {
        public AutoMapping()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<Supplier, SupplierDTO>();
        }
    }
}
