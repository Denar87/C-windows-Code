//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IMS_Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_SaleDetails
    {
        public int SaleDetails_SlNo { get; set; }
        public int SaleMaster_SlNo { get; set; }
        public int Product_SlNo { get; set; }
        public double SaleDetails_TotalQuantity { get; set; }
        public Nullable<decimal> Purchase_Rate { get; set; }
        public decimal SaleDetails_Rate { get; set; }
        public decimal SaleDetails_Discount { get; set; }
        public decimal SaleDetails_Tax { get; set; }
        public decimal SaleDetails_Freight { get; set; }
        public decimal SaleDetails_TotalAmount { get; set; }
        public string Status { get; set; }
        public string AddBy { get; set; }
        public Nullable<System.DateTime> AddTime { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
    }
}
