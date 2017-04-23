using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMS_Entity;
using IMS_Service;

namespace IMS_Business
{
    public class CountryBusiness
    {
        CountryService aCountryService = new CountryService();

        ~CountryBusiness()
        {
            aCountryService.Dispose();
            aCountryService = null;
        }


        public string validateOnSave(Tbl_Country aTbl_Country)
        {
            if (aTbl_Country.CountryName == string.Empty)
            {
                return "Enter Country Name";
            }
            if (GetAllCountry(aTbl_Country.CountryName) != null)
            {
                return "Country name already exist";
            }
            return string.Empty;
        }

        public string validateOnUpdate(Tbl_Country aTbl_Country)
        {
            if (aTbl_Country.CountryName == string.Empty)
            {
                return "Enter Country Name";
            }
            if (GetAllCountry(aTbl_Country.Country_SlNo, aTbl_Country.CountryName) != null)
            {
                return "Country name already exist";
            }
            return string.Empty;
        }

        public List<Tbl_Country> GetAllCountry()
        {
            return aCountryService.GetAllCountry();
        }

        public Tbl_Country GetAllCountry(int autoid)
        {
            return aCountryService.GetAllCountry(autoid);
        }
        public Tbl_Country GetAllCountry(string name)
        {
            return aCountryService.GetAllCountry(name);
        }
        public Tbl_Country GetAllCountry(int autoId, string name)
        {
            return aCountryService.GetAllCountry(autoId, name);
        }
        public bool Insert(Tbl_Country aTbl_Country)
        {
            return aCountryService.Insert(aTbl_Country) > 0;
        }
        public bool Update(Tbl_Country aTbl_Country)
        {
            return aCountryService.Update(aTbl_Country) > 0;
        }


    }
}
