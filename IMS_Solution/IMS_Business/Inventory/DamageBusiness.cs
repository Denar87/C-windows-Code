using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMS_Entity;
using IMS_Service;

namespace IMS_Business
{
    public class DamageBusiness
    {
        DamageService aDamageService = new DamageService();
        ~DamageBusiness()
       {
           aDamageService.Dispose();
           aDamageService = null;
       }
        public Tbl_Damage GetLastDamageProduct()
        {
            return aDamageService.GetLastDamageProduct();
        }
        public List<Tbl_Damage> GetAllDamage()
        {
            return aDamageService.GetAllDamage();
        }
        public List<Get_DamagedProduct> GetDamageProduct()
        {
            return aDamageService.GetDamageProduct();
        }
        public Tbl_Damage GetAllDamage(int autoid)
        {
            return aDamageService.GetAllDamage(autoid);
        }
        public string validateOnSave(Tbl_Damage aTbl_Damage)
        {
            if (aTbl_Damage.Damage_InvoiceNo == string.Empty)
            {
                return "Enter Invoice";
            }
            return string.Empty;
        }
        public string validateDetailsOnSave(Tbl_DamageDetails aTbl_DamageDetails)
        {
            if (aTbl_DamageDetails.Product_SlNo == 0)
            {
                return "Enter Product";
            }
            if (aTbl_DamageDetails.DamageDetails_DamageQuantity == 0)
            {
                return "Enter Quantity";
            }
            return string.Empty;
        }

        public bool InsertDamage(Tbl_Damage aTbl_Damage)
        {
            return aDamageService.InsertDamage(aTbl_Damage) > 0;
        }
        public bool InsertDamageDetail(List<Tbl_DamageDetails> lstTbl_DamageDetails)
        {

            return aDamageService.InsertDamageDetail(lstTbl_DamageDetails) > 0;
        }
        public string GenerateInvoiceNo()
        {
            Tbl_Damage atbl_Damage = GetLastDamageProduct();
            string prefix = "D";
            string subprefix = string.Empty;
            int cnt = 0;
            string code = string.Empty;
            if (atbl_Damage != null)
            {
                subprefix = atbl_Damage.Damage_InvoiceNo;
                subprefix = subprefix.Substring(1).ToString();
                cnt = Convert.ToInt32(subprefix);
                cnt++;
                code = prefix + cnt.ToString("0000");
            }
            else
            {
                cnt++;

                code = prefix + cnt.ToString("0000");
            }
            return code;
        }
    }
}
