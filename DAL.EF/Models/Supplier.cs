using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Locality { get; set; }

        public List<Product> Products { get; set; }
    }
}
