//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BudgetWebApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Transaction
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<System.DateTime> PaymentDate { get; set; }
        public Nullable<int> PaymentType { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}
