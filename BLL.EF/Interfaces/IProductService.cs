using System;
using System.Collections.Generic;
using System.Text;
using BLL.EF.DTO;

namespace BLL.EF.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> GetByCategory(int? id);
        IEnumerable<ProductDTO> GetBySupplier(int? id);
        IEnumerable<ProductDTO> GetByPrice(decimal price);
    }
}
