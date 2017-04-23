using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMS_Service;
using IMS_Entity;

namespace IMS_Business
{
    public class UnitOfMeasurementBusiness
    {
        UnitOfMeasurementService aUnitOfMeasurementService = new UnitOfMeasurementService();
        ~UnitOfMeasurementBusiness()
        {
            aUnitOfMeasurementService.Dispose();
            aUnitOfMeasurementService = null;
        }

        public string validateOnSave(Tbl_Unit aTbl_Unit)
        {
            if (aTbl_Unit.Unit_Name == string.Empty)
            {
                return "Enter Unit Name";
            }
            if (GetAllUnit(aTbl_Unit.Unit_Name) != null)
            {
                return "Unit name already exist";
            }
            return string.Empty;
        }

        public string validateOnUpdate(Tbl_Unit aTbl_Unit)
        {
            if (aTbl_Unit.Unit_Name== string.Empty)
            {
                return "Enter Unit Name";
            }
            if (GetAllUnit(aTbl_Unit.Unit_SlNo, aTbl_Unit.Unit_Name) != null)
            {
                return "Unit name already exist";
            }
            return string.Empty;
        }

        public List<Tbl_Unit> GetAllUnit()
        {
            return aUnitOfMeasurementService.GetAllUnit();
        }

        public Tbl_Unit GetAllUnit(int autoid)
        {
            return aUnitOfMeasurementService.GetAllUnit(autoid);
        }
        public Tbl_Unit GetAllUnit(string name)
        {
            return aUnitOfMeasurementService.GetAllUnit(name);
        }
        public Tbl_Unit GetAllUnit(int autoId, string name)
        {
            return aUnitOfMeasurementService.GetAllUnit(autoId, name);
        }
        public bool Insert(Tbl_Unit aTbl_Unit)
        {
            return aUnitOfMeasurementService.Insert(aTbl_Unit) > 0;
        }
        public bool Update(Tbl_Unit aTbl_Unit)
        {
            return aUnitOfMeasurementService.Update(aTbl_Unit) > 0;
        }
    }
}
