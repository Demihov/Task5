using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.ADO.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public int SupplierId { get; set; }
    }
}
