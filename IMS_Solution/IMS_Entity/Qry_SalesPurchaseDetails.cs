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
    
    public partial class Qry_SalesPurchaseDetails
    {
        public int SaleDetails_SlNo { get; set; }
        public decimal SaleDetails_Rate { get; set; }
        public decimal SaleDetails_TotalAmount { get; set; }
        public string ProductCategory_Name { get; set; }
        public string Unit_Name { get; set; }
        public string Product_Code { get; set; }
        public string Product_Name { get; set; }
        public string AddBy { get; set; }
        public string SaleMaster_InvoiceNo { get; set; }
        public int SaleMaster_SlNo { get; set; }
        public System.DateTime SaleMaster_SaleDate { get; set; }
        public decimal SaleMaster_TotalSaleAmount { get; set; }
        public decimal SaleMaster_TotalDiscountAmount { get; set; }
        public decimal SaleMaster_TaxAmount { get; set; }
        public decimal SaleMaster_Freight { get; set; }
        public decimal SaleMaster_PaidAmount { get; set; }
        public decimal SaleMaster_DueAmount { get; set; }
        public decimal SaleMaster_SubTotalAmount { get; set; }
        public Nullable<decimal> PurchaseDetails_Rate { get; set; }
        public int Product_SlNo { get; set; }
        public decimal Product_Purchase_Rate { get; set; }
        public decimal Product_SellingPrice { get; set; }
        public double SaleDetails_TotalQuantity { get; set; }
    }
}