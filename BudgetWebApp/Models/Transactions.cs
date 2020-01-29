using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BudgetWebApp.Models
{
    public class Transactions
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<System.DateTime> PaymentDate { get; set; }
        public string PaymentType { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public bool Active { get; set; }

        public int PaymentID { get; set; }
        public string PaymentName { get; set; }

        public IEnumerable<SelectListItem> PaymentTypeList { get; set; }
        //public IEnumerable<PaymentType> PaymentTypeList { get; set; }
    }
}