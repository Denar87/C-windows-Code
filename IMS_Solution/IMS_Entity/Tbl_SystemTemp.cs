using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMS_Entity
{
    public partial class Tbl_SystemTemp
    {
        public int Licence_SlNo { get; set; }
        public string Licence_Key { get; set; }
        public System.DateTime Licence_StartDate { get; set; }
        public System.DateTime Licence_EndDate { get; set; }
        public System.DateTime Licence_NoticeDate { get; set; }
    }
}
