using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMS_Entity
{
    public class productPrint
    {
        public string productId { get; set; }
        public string productName {get; set; }
        public byte[] BARCODE { get; set; }
        public string ArticleNo { get; set; }
        public decimal SellPrice { get; set; }
    }
}

