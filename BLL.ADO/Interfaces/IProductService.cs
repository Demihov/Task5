using BLL.ADO.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ADO.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> GetByCategory(int? id);
        IEnumerable<ProductDTO> GetBySupplier(int? id);
        IEnumerable<ProductDTO> GetByPrice(decimal cost);
    }
}
