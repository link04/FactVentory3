using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        [ForeignKey("Costumer")]
        public int CostumerId { get; set; }
        [ForeignKey("Company")]
        public int CompanyId { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime InvoiceDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DueDate { get; set; }

        public float TotalAmount { get; set; }
        public float AmountPaid { get; set; }
        public float BalanceDue { get; set; }

        public string Status { get; set; }
        public string Notes { get; set; }


    }
}
