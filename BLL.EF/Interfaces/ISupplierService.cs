using BLL.EF.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.EF.Interfaces
{
    public interface ISupplierService
    {
        IEnumerable<SupplierDTO> GetByCategory(int? id);
    }
}
