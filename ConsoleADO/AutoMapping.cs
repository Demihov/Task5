using AutoMapper;
using BLL.ADO.DTO;
using DAL.ADO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleADO
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<Supplier, SupplierDTO>();
        }
    }
}
