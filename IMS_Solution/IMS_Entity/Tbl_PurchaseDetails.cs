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
    
    public partial class Tbl_PurchaseDetails
    {
        public int PurchaseDetails_SlNo { get; set; }
        public int PurchaseMaster_SlNo { get; set; }
        public int Product_SlNo { get; set; }
        public double PurchaseDetails_TotalQuantity { get; set; }
        public double PurchaseDetail_ReceiveQuantity { get; set; }
        public decimal PurchaseDetails_Rate { get; set; }
        public System.DateTime PurchaseDetails_ExpireDate { get; set; }
        public decimal PurchaseDetails_Discount { get; set; }
        public decimal PurchaseDetails_Tax { get; set; }
        public decimal PurchaseDetails_Freight { get; set; }
        public decimal PurchaseDetails_TotalAmount { get; set; }
        public string Status { get; set; }
        public string AddBy { get; set; }
        public Nullable<System.DateTime> AddTime { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
    }
}