﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ADO.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
    }
}
