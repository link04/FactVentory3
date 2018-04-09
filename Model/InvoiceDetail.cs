using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    public class InvoiceDetail  
    {

        public int InvoiceDetailId { get; set; }
        [ForeignKey("Invoice")]
        public int? InvoiceId  { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public float Quantity { get; set; }
        public float UnitPrice { get; set; }  
        public float Total { get; set; }

    }
}
