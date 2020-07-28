using BLL.ADO.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ADO.Interfaces
{
    public interface ISupplierService
    {
        IEnumerable<SupplierDTO> GetByCategory(int? id);
        IEnumerable<SupplierDTO> GetByItemsWithMaxNumberCategories();
    }
}
