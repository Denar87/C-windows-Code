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
    
    public partial class Qry_PurchaseInvoice
    {
        public string ProductCategory_Name { get; set; }
        public int ProductCategory_SlNo { get; set; }
        public string Product_Code { get; set; }
        public int Product_SlNo { get; set; }
        public string Product_Name { get; set; }
        public string Product_BarCode { get; set; }
        public bool Product_IsRawMaterial { get; set; }
        public bool Product_IsFinishedGoods { get; set; }
        public int Unit_SlNo { get; set; }
        public string Unit_Name { get; set; }
        public int Employee_SlNo { get; set; }
        public string Employee_ID { get; set; }
        public string Employee_Name { get; set; }
        public int PurchaseInventory_SlNo { get; set; }
        public string PurchaseMaster_InvoiceNo { get; set; }
        public System.DateTime PurchaseMaster_OrderDate { get; set; }
        public string PurchaseMaster_Description { get; set; }
        public string PurchaseMaster_PurchaseType { get; set; }
        public decimal PurchaseMaster_TotalAmount { get; set; }
        public decimal PurchaseMaster_DiscountAmount { get; set; }
        public decimal PurchaseMaster_Tax { get; set; }
        public decimal PurchaseMaster_Freight { get; set; }
        public decimal PurchaseMaster_PaidAmount { get; set; }
        public decimal PurchaseMaster_SubTotalAmount { get; set; }
        public decimal PurchaseMaster_DueAmount { get; set; }
        public System.DateTime PurchaseMaster_ReceiveDate { get; set; }
        public string PurchaseMaster_Status { get; set; }
        public decimal PurchaseDetails_Rate { get; set; }
        public System.DateTime PurchaseDetails_ExpireDate { get; set; }
        public decimal PurchaseDetails_Discount { get; set; }
        public decimal PurchaseDetails_Freight { get; set; }
        public decimal PurchaseDetails_Tax { get; set; }
        public decimal PurchaseDetails_TotalAmount { get; set; }
        public int PurchaseMaster_SlNo { get; set; }
        public int PurchaseDetails_SlNo { get; set; }
        public string Supplier_Web { get; set; }
        public int Supplier_SlNo { get; set; }
        public string Supplier_Code { get; set; }
        public string Supplier_Name { get; set; }
        public string Supplier_Type { get; set; }
        public string Supplier_Phone { get; set; }
        public string Supplier_Mobile { get; set; }
        public string Supplier_Email { get; set; }
        public string Supplier_Address { get; set; }
        public string Supplier_OfficePhone { get; set; }
        public string CountryName { get; set; }
        public string District_Name { get; set; }
        public string AddBy { get; set; }
        public double PurchaseInventory_TotalQuantity { get; set; }
        public double PurchaseInventory_ReceiveQuantity { get; set; }
        public double PurchaseDetails_TotalQuantity { get; set; }
        public double PurchaseDetail_ReceiveQuantity { get; set; }
    }
}