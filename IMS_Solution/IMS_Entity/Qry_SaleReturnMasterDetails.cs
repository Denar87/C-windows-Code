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
    
    public partial class Qry_SaleReturnMasterDetails
    {
        public int SaleReturn_SlNo { get; set; }
        public string SaleMaster_InvoiceNo { get; set; }
        public System.DateTime SaleReturn_ReturnDate { get; set; }
        public decimal SaleReturn_ReturnAmount { get; set; }
        public string SaleReturn_Description { get; set; }
        public int SaleReturnDetails_SlNo { get; set; }
        public System.DateTime SaleReturnDetails_ReturnDate { get; set; }
        public int Product_SlNo { get; set; }
        public decimal SaleReturnDetails_ReturnAmount { get; set; }
        public double SaleReturnDetails_ReturnQuantity { get; set; }
        public double SaleReturnDetails_SaleQuantity { get; set; }
        public double SaleReturn_ReturnQuantity { get; set; }
        public string Product_Name { get; set; }
        public string Product_Code { get; set; }
        public string Product_BarCode { get; set; }
        public string Unit_Name { get; set; }
    }
}