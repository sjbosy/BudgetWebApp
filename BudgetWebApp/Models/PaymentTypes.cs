using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetWebApp.Models
{
    public class PaymentTypes
    {
        public int ID { get; set; }
        public string PaymentName { get; set; }
        public bool Active {get; set;}
    }
}