using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace DAL.EF.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
