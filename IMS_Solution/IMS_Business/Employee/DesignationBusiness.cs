using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMS_Entity;
using IMS_Service;
namespace IMS_Business
{
   public class DesignationBusiness
    {
       DesignationService aDesignationService = new DesignationService();
       ~DesignationBusiness()
       {
           aDesignationService.Dispose();
           aDesignationService = null;
       }
       public string validateOnSave(Tbl_Designation aTbl_Designation)
       {
           if (aTbl_Designation.Designation_Name == string.Empty)
           {
               return "Enter Designation Name";
           }
           if (GetAllDesignation(aTbl_Designation.Designation_Name) != null)
           {
               return "Designation name already exist";
           }
           return string.Empty;
       }
       public string validateOnUpdate(Tbl_Designation aTbl_Designation)
       {
           if (aTbl_Designation.Designation_Name == string.Empty)
           {
               return "Enter Designation Name";
           }
           if (GetAllDesignation(aTbl_Designation.Designation_SlNo, aTbl_Designation.Designation_Name) != null)
           {
               return "Designation name already exist";
           }
           return string.Empty;
       }
       public List<Tbl_Designation> GetAllDesignation()
       {
           return aDesignationService.GetAllDesignation();
       }

       public Tbl_Designation GetAllDesignation(int autoid)
       {
           return aDesignationService.GetAllDesignation(autoid);
       }
       public Tbl_Designation GetAllDesignation(string name)
       {
           return aDesignationService.GetAllDesignation(name);
       }
       public Tbl_Designation GetAllDesignation(int autoId,string name)
       {
           return aDesignationService.GetAllDesignation(autoId,name);
       }
       public bool Insert(Tbl_Designation aTbl_Designation)
       {
           return aDesignationService.Insert(aTbl_Designation)>0;
       }
       public bool Update(Tbl_Designation aTbl_Designation)
       {
           return aDesignationService.Update(aTbl_Designation) > 0;
       }
    }
}
