using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMS_Entity;
using IMS_Service;

namespace IMS_Business
{
    public class EmployeeBusiness
    {
        EmployeeService aEmployeeService = new EmployeeService();
       ~EmployeeBusiness()
       {
           aEmployeeService.Dispose();
           aEmployeeService = null;
       }

       public string validateOnSave(Tbl_Employee aTbl_Employee)
       {
           if (aTbl_Employee.Employee_Name == string.Empty)
           {
               return "Enter Employee Name";
           }
           
           if (GetAllEmployee(aTbl_Employee.Employee_Name) != null)
           {
               return "Employee name already exist";
           }
           return string.Empty;
       }

       public string validateOnUpdate(Tbl_Employee aTbl_Employee)
       {
           if (aTbl_Employee.Employee_Name == string.Empty)
           {
               return "Enter Employee Name";
           }
           
           if (GetAllEmployee(aTbl_Employee.Employee_SlNo, aTbl_Employee.Employee_ID, aTbl_Employee.Employee_Name) != null)
           {
               return "Employee name already exist";
           }
           return string.Empty;
       }

       public List<Tbl_Employee> GetAllEmployeeByDepartment(int id)
       {
           return aEmployeeService.GetAllEmployeeByDepartment(id);
       }
       public List<Tbl_Employee> GetAllEmployeeByDesignation(int id)
       {
           return aEmployeeService.GetAllEmployeeByDesignation(id);
       }
       public List<Qry_Employee> GetAllQryEmployee()
       {
           return aEmployeeService.GetAllQryEmployee();
       }
       public List<Tbl_Employee> GetAllEmployee()
       {
           return aEmployeeService.GetAllEmployee();
       }
       public List<Qry_Employee> GetAllQry_EmployeeCode(string code)
       {
           return aEmployeeService.GetAllQry_EmployeeCode(code);
       }
       public List<Qry_Employee> GetAllQry_EmployeeByAutoID(int autoid)
       {
           return aEmployeeService.GetAllQry_EmployeeByAutoID(autoid);
       }
       public Tbl_Employee GetAllEmployee(int autoid)
       {
           return aEmployeeService.GetAllEmployee(autoid);
       }
       public Tbl_Employee GetAllEmployee(string name)
       {
           return aEmployeeService.GetAllEmployee(name);
       }
       public Tbl_Employee GetAllEmployeeCode(string code)
       {
           return aEmployeeService.GetAllEmployeeCode(code);
       }
       public Tbl_Employee GetAllEmployee(int autoId, string code, string name)
       {
           return aEmployeeService.GetAllEmployee(autoId, code, name);
       }
       public bool Insert(Tbl_Employee aTbl_Employee)
       {
           return aEmployeeService.Insert(aTbl_Employee) > 0;
       }
       public bool Update(Tbl_Employee aTbl_Employee)
       {
           return aEmployeeService.Update(aTbl_Employee) > 0;
       }
       public List<Tbl_Employee> GetAllEmployeeByID(string empId)
       {
           return aEmployeeService.GetAllEmployeeByID(empId);
       }



       public List<Tbl_Employee> GetAllEmployeebyCode(string code)
        {
            return aEmployeeService.GetAllEmployeebyCode(code);
        }
        public Tbl_Employee GetLastEmployee()
        {
            return aEmployeeService.GetLastEmployee();
        }


        public string GenerateEmployeeCode()
        {
            Tbl_Employee Employee = GetLastEmployee();
            string prefix = "E";
            string subprefix = string.Empty;
            int cnt = 0;
            string code = string.Empty;
            if (Employee != null)
            {
                subprefix = Employee.Employee_ID;
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
