using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public class Costumer
    {
        public int CostumerId { get; set; }
        
        public string FullName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }
       
        public string Address { get; set; }

    }
}
