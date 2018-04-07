using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public int CostumerId { get; set; }
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

        public List<InvoiceDetail> details { get; set; }
        public virtual Costumer Costumer { get; set; }
        public virtual Company Company { get; set; }
    }
}
