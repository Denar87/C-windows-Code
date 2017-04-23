using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMS_Entity;
using IMS_Service;

namespace IMS_Business
{
    public class CompanyBusiness
    {
        CompanyService aCompanyService = new CompanyService();
        ~CompanyBusiness()
        {
            aCompanyService.Dispose();
            aCompanyService = null;
        }

        public string validateOnSave(Tbl_Company aTbl_Company)
        {
            if (aTbl_Company.Company_Name == string.Empty)
            {
                return "Enter Company Name";
            }
            if (aTbl_Company.Repot_Heading == string.Empty)
            {
                return "Enter Company Description";
            }
            return string.Empty;
        }

        public string validateOnUpdate(Tbl_Company aTbl_Company)
        {
            if (aTbl_Company.Company_Name == string.Empty)
            {
                return "Enter Company Name";
            }
            if (aTbl_Company.Repot_Heading == string.Empty)
            {
                return "Enter Company Description";
            }
            if (GetAllCompany(aTbl_Company.Company_SlNo, aTbl_Company.Company_Name) != null)
            {
                return "Company Name already exist";
            }
            return string.Empty;
        }
        public List<Tbl_Company> GetAllCompany()
        {
            return aCompanyService.GetAllCompany();
        }

        
        public Tbl_Company GetAllCompany(int autoid)
        {
            return aCompanyService.GetAllCompany(autoid);
        }
        public Tbl_Company GetAllCompanyByInvoiceType()
        {
            return aCompanyService.GetAllCompanyByInvoiceType();
        }
        public Tbl_Company GetAllCompany(string name)
        {
            return aCompanyService.GetAllCompany(name);
        }
        public Tbl_Company GetAllCompany(int autoId, string name)
        {
            return aCompanyService.GetAllCompany(autoId, name);
        }
        public bool Insert(Tbl_Company aTbl_Company)
        {
            return aCompanyService.Insert(aTbl_Company) > 0;
        }
        public bool Update(Tbl_Company aTbl_Company)
        {
            return aCompanyService.Update(aTbl_Company) > 0;
        }
        public bool InsertorUpdate(Tbl_Company aTbl_Company)
        {
            return aCompanyService.InsertorUpdate(aTbl_Company) > 0;
        }
        
    }
}
