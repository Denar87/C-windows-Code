using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMS_Entity;
using IMS_Service;

namespace IMS_Business
{
    public class ResetBusiness
    {
        ResetDataService aResetDataService = new ResetDataService();
        
        ~ResetBusiness()
         {
            aResetDataService.Dispose();
            aResetDataService = null;
         }
        public bool deleteall()
        {
            return aResetDataService.deleteall() > 0;
        }
    }
}
