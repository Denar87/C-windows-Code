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
    
    public partial class Tbl_PurchaseReturnDetails
    {
        public int PurchaseReturnDetails_SlNo { get; set; }
        public int PurchaseReturn_SlNo { get; set; }
        public System.DateTime PurchaseReturnDetails_ReturnDate { get; set; }
        public int Product_SlNo { get; set; }
        public double PurchaseReturnDetails_ReceiveQuantity { get; set; }
        public double PurchaseReturnDetails_ReturnQuantity { get; set; }
        public decimal PurchaseReturnDetails_ReturnAmount { get; set; }
        public string Status { get; set; }
        public string AddBy { get; set; }
        public Nullable<System.DateTime> AddTime { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
    }
}
