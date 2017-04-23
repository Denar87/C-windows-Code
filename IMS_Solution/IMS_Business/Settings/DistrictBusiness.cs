using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMS_Entity;
using IMS_Service;

namespace IMS_Business
{
    public class DistrictBusiness
    {
        DistrictService aDistrictService = new DistrictService();

        ~DistrictBusiness()
        {
            aDistrictService.Dispose();
            aDistrictService = null;
        }

        public string validateOnSave(Tbl_District aTbl_District)
        {
            if (aTbl_District.District_Name == string.Empty)
            {
                return "Enter District Name";
            }
            if (GetAllDistrict(aTbl_District.District_Name) != null)
            {
                return "District name already exist";
            }
            return string.Empty;
        }

        public string validateOnUpdate(Tbl_District aTbl_District)
        {
            if (aTbl_District.District_Name == string.Empty)
            {
                return "Enter District Name";
            }
            if (GetAllDistrict(aTbl_District.District_SlNo, aTbl_District.District_Name) != null)
            {
                return "District name already exist";
            }
            return string.Empty;
        }

        public List<Tbl_District> GetAllDistrict()
        {
            return aDistrictService.GetAllDistrict();
        }

        public Tbl_District GetAllDistrict(int autoid)
        {
            return aDistrictService.GetAllDistrict(autoid);
        }
        public Tbl_District GetAllDistrict(string name)
        {
            return aDistrictService.GetAllDistrict(name);
        }
        public Tbl_District GetAllDistrict(int autoId, string name)
        {
            return aDistrictService.GetAllDistrict(autoId, name);
        }
        public bool Insert(Tbl_District aTbl_District)
        {
            return aDistrictService.Insert(aTbl_District) > 0;
        }
        public bool Update(Tbl_District aTbl_District)
        {
            return aDistrictService.Update(aTbl_District) > 0;
        }
    }
}
