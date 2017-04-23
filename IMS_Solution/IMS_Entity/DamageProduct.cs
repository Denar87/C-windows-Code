using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMS_Entity
{
    public class DamageProduct
    {
        public int Product_SlNo { get; set; }
        public string Product_Name { get; set; }
        public string Description { get; set; }
        public int AlreadyDamagedQuantity { get; set; }
        public int DamageQuantity { get; set; }
    }
}
