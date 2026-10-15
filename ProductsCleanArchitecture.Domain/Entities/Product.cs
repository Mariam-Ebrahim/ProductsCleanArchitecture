using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsCleanArchitecture.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
