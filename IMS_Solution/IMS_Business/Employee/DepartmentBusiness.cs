using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMS_Entity;
using IMS_Service;


namespace IMS_Business
{
    public class DepartmentBusiness
    {
        DepartmentService aDepartmentService = new DepartmentService();
        ~DepartmentBusiness()
        {
            aDepartmentService.Dispose();
            aDepartmentService = null;
        }

        public string validateOnSave(Tbl_Department aTbl_Department)
        {
            if (aTbl_Department.Department_Name == string.Empty)
            {
                return "Enter Department Name";
            }
            if (GetAllDepartment(aTbl_Department.Department_Name) != null)
            {
                return "Department name already exist";
            }
            return string.Empty;
        }

        public string validateOnUpdate(Tbl_Department aTbl_Department)
        {
            if (aTbl_Department.Department_Name == string.Empty)
            {
                return "Enter Department Name";
            }
            if (GetAllDepartment(aTbl_Department.Department_SlNo, aTbl_Department.Department_Name) != null)
            {
                return "Department name already exist";
            }
            return string.Empty;
        }
        public List<Tbl_Department> GetAllDepartment()
        {
            return aDepartmentService.GetAllDepartment();
        }

        public Tbl_Department GetAllDepartment(int autoid)
        {
            return aDepartmentService.GetAllDepartment(autoid);
        }
        public Tbl_Department GetAllDepartment(string name)
        {
            return aDepartmentService.GetAllDepartment(name);
        }
        public Tbl_Department GetAllDepartment(int autoId, string name)
        {
            return aDepartmentService.GetAllDepartment(autoId, name);
        }
        public bool Insert(Tbl_Department aTbl_Department)
        {
            return aDepartmentService.Insert(aTbl_Department) > 0;
        }
        public bool Update(Tbl_Department aTbl_Department)
        {
            return aDepartmentService.Update(aTbl_Department) > 0;
        }
    }
}
