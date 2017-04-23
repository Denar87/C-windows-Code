using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMS_Entity;
using System.Data;

namespace IMS_Service
{
    public class EmployeeService:IDisposable
    {
        IMS_Entities context = new IMS_Entities();

         #region Memory Optimizer
        ~EmployeeService()
       {
           if (context != null)
           {
               try
               {
                   context.Dispose();
                   context = null;
               }
               catch { }

           }
       }

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    if (context != null) { try { context.Dispose(); context = null; } catch { } }
                }
            }
            this.disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
#endregion

        public List<Tbl_Employee> GetAllEmployeebyCode(string code)
        {
            return context.Tbl_Employee.Where(x => x.Status.Trim() == "A" && x.Employee_ID.StartsWith(code) || x.Employee_Name.StartsWith(code)).ToList();
        }
        public List<Qry_Employee> GetAllQry_EmployeeCode(string code)
        {
            return context.Qry_Employee.Where(x => x.Employee_ID.StartsWith(code)).ToList();
        }
        public List<Qry_Employee> GetAllQry_EmployeeByAutoID(int autoid)
        {
            return context.Qry_Employee.Where(x => x.Employee_SlNo==autoid).ToList();
        }
        public Tbl_Employee GetLastEmployee()
        {
            return context.Tbl_Employee.Where(x => x.Status.Trim() == "A").OrderByDescending(x => x.Employee_SlNo).FirstOrDefault();
        }
        public List<Tbl_Employee> GetAllEmployeeByDepartment(int id)
        {
            return context.Tbl_Employee.Where(x => x.Department_SlNo==id).ToList();
        }
        public List<Tbl_Employee> GetAllEmployeeByDesignation(int id)
        {
            return context.Tbl_Employee.Where(x => x.Designation_SlNo == id).ToList();
        }
        public List<Qry_Employee> GetAllQryEmployee()
        {
            return context.Qry_Employee.ToList().OrderBy(x => x.Employee_Name).ToList();
        }
        public List<Tbl_Employee> GetAllEmployee()
        {
            return context.Tbl_Employee.Where(x => x.Status.Trim() == "A").ToList();
        }
        public List<Tbl_Employee> GetAllEmployeeByID(string empId)
        {
            return context.Tbl_Employee.Where(x => x.Status.Trim() == "A" && (x.Employee_ID.StartsWith(empId) || x.Employee_Name.StartsWith(empId))).ToList();
        }
        public Tbl_Employee GetAllEmployee(int autoId)
        {
            return context.Tbl_Employee.Where(x =>
                x.Employee_SlNo == autoId &&
                x.Status.Trim() == "A").FirstOrDefault();
        }
        public Tbl_Employee GetAllEmployeeCode(string code)
        {
            return context.Tbl_Employee.Where(x =>
                x.Employee_ID == code &&
                x.Status.Trim() == "A").FirstOrDefault();
        }
        public Tbl_Employee GetAllEmployee(string name)
        {
            return context.Tbl_Employee.Where(x =>
                x.Employee_Name == name &&
                x.Status.Trim() == "A").FirstOrDefault();
        }
        public Tbl_Employee GetAllEmployee(int autoId, string code, string name)
        {
            return context.Tbl_Employee.Where(x =>
                x.Employee_SlNo != autoId &&
                x.Employee_ID != code &&
                x.Employee_Name == name &&
                x.Status.Trim() == "A").FirstOrDefault();
        }
        public int Insert(Tbl_Employee aTbl_Employee)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;

            context.Tbl_Employee.Add(aTbl_Employee);
            return context.SaveChanges();
        }
        public int Update(Tbl_Employee aTbl_Employee)
        {
            context.Configuration.AutoDetectChangesEnabled = false;
            context.Configuration.ValidateOnSaveEnabled = false;

            context.Tbl_Employee.Attach(aTbl_Employee);
            context.Entry(aTbl_Employee).State = EntityState.Modified;
            return context.SaveChanges();
        }



    }
}
