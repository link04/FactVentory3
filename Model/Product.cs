using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public class Product
    {
        public int ProductId { get; set; }
        
        public string ProductName { get; set; }
        
        public float UnitPrice { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }

    }
}
