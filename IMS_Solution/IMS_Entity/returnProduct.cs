using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMS_Entity
{
   public class returnProduct
    {
        public int Product_SlNo { get; set; }
        public string Product_Name { get; set; }
        public double TotalQuantity { get; set; }
        public decimal TotalAmount { get; set; }
        public double AlreadyReturnQuantity { get; set; }
        public double ReturnQuantity { get; set; }
        public decimal ReturnAmount { get; set; }
        public decimal AlreadyReturnAmount { get; set; }
        public DateTime ReturnDate { get; set; }
        public string InvoiceNo { get; set; }
        public string Unit_Name { get; set; }
        public string Return_Description { get; set; }
        public string Customer_Name { get; set; }
        public string Supplier_Name { get; set; }
    }
}
