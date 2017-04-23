using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IMS_Business;
using IMS_Entity;
using CrystalDecisions.Shared;
using Utility;

namespace IMS_Win
{
    public partial class SupplierListReportForm : Form
    {
        CountryBusiness aCountryBusiness = new CountryBusiness();
        DistrictBusiness aDistrictBusiness = new DistrictBusiness();
        CompanyBusiness aCompanyBusiness = new CompanyBusiness();
        SupplierBusiness aSupplierBusiness = new SupplierBusiness();
        List<Qry_SupplierTotalPurchaseList> lstSupplierList = new List<Qry_SupplierTotalPurchaseList>();
        public SupplierListReportForm()
        {
            InitializeComponent();
        }

        void ShowReport()
        {
            try
            {
                List<Tbl_Company> lstCompanyList = aCompanyBusiness.GetAllCompany();
                lstSupplierList = aSupplierBusiness.GetAllSupplierTotalPurchase();

                ParameterFields paramFields = new ParameterFields();
                ParameterDiscreteValue objDiscreteValue = new ParameterDiscreteValue();
                ParameterField objParameterField = new ParameterField();

                objDiscreteValue = new ParameterDiscreteValue();
                objParameterField = new ParameterField();
                objParameterField.Name = "paramUser";
                objDiscreteValue.Value = SplashForm.username;
                objParameterField.CurrentValues.Add(objDiscreteValue);
                paramFields.Add(objParameterField);

                ReportViewerForm frm = new ReportViewerForm();
                frm.ReportViewer.ParameterFieldInfo = paramFields;

                if (cmbSearchBy.Text == "All")
                {
                    Reports.CRSupplierReport rpt = new Reports.CRSupplierReport();
                    DataTable dt = UtilityBusiness.GenericListToDataTable1<Qry_SupplierTotalPurchaseList>(lstSupplierList);
                    rpt.Subreports[0].SetDataSource(lstCompanyList);
                    rpt.SetDataSource(dt);

                    frm.ReportViewer.ReportSource = rpt;
                    frm.ShowDialog();
                }
                if (cmbSearchBy.Text == "ID Number")
                {
                    lstSupplierList = lstSupplierList.Where(x => x.Supplier_Code == cmbSearch.Text).ToList();
                    DataTable dt = UtilityBusiness.GenericListToDataTable1<Qry_SupplierTotalPurchaseList>(lstSupplierList);
                    Reports.CRSupplierInfoSingle rpt = new Reports.CRSupplierInfoSingle();
                    rpt.Subreports[0].SetDataSource(lstCompanyList);
                    rpt.SetDataSource(dt);

                    frm.ReportViewer.ReportSource = rpt;
                    frm.ShowDialog();
                }
                if (cmbSearchBy.Text == "Name")
                {
                    lstSupplierList = lstSupplierList.Where(x => x.Supplier_Name == cmbSearch.Text).ToList();
                    DataTable dt = UtilityBusiness.GenericListToDataTable1<Qry_SupplierTotalPurchaseList>(lstSupplierList);
                    Reports.CRSupplierInfoSingle rpt = new Reports.CRSupplierInfoSingle();
                    rpt.Subreports[0].SetDataSource(lstCompanyList);
                    rpt.SetDataSource(dt);

                    frm.ReportViewer.ReportSource = rpt;
                    frm.ShowDialog();
                }
                if (cmbSearchBy.Text == "Mobile No.")
                {
                    lstSupplierList = lstSupplierList.Where(x => x.Supplier_Mobile == cmbSearch.Text).ToList();
                    DataTable dt = UtilityBusiness.GenericListToDataTable1<Qry_SupplierTotalPurchaseList>(lstSupplierList);
                    Reports.CRSupplierInfoSingle rpt = new Reports.CRSupplierInfoSingle();
                    rpt.Subreports[0].SetDataSource(lstCompanyList);
                    rpt.SetDataSource(dt);

                    frm.ReportViewer.ReportSource = rpt;
                    frm.ShowDialog();
                }
                if (cmbSearchBy.Text == "District")
                {
                    lstSupplierList = lstSupplierList.Where(x => x.District_Name == cmbSearch.Text).ToList();
                    DataTable dt = UtilityBusiness.GenericListToDataTable1<Qry_SupplierTotalPurchaseList>(lstSupplierList);
                    Reports.CRDistrictwiseSupplierReport rpt = new Reports.CRDistrictwiseSupplierReport();
                    rpt.Subreports[0].SetDataSource(lstCompanyList);
                    rpt.SetDataSource(dt);

                    frm.ReportViewer.ReportSource = rpt;
                    frm.ShowDialog();
                }
                if (cmbSearchBy.Text == "Country")
                {
                    lstSupplierList = lstSupplierList.Where(x => x.CountryName == cmbSearch.Text).ToList();
                    DataTable dt = UtilityBusiness.GenericListToDataTable1<Qry_SupplierTotalPurchaseList>(lstSupplierList);
                    Reports.CRCountrywiseSupplierReport rpt = new Reports.CRCountrywiseSupplierReport();
                    rpt.Subreports[0].SetDataSource(lstCompanyList);
                    rpt.SetDataSource(dt);

                    frm.ReportViewer.ReportSource = rpt;
                    frm.ShowDialog();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void LoadGrid()
        {
            dgvSupplierList.AutoGenerateColumns = false;
            lstSupplierList = aSupplierBusiness.GetAllSupplierTotalPurchase();
            dgvSupplierList.DataSource = lstSupplierList;
        }

        private void SupplierListReportForm_Load(object sender, EventArgs e)
        {
            if (cmbSearchBy.Text == "All")
            {
                LoadGrid();
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            ShowReport();
        }

        private void GetIDForCombo()
        {
            cmbSearch.DataSource = null;
            cmbSearch.DisplayMember = "Supplier_Code";
            cmbSearch.ValueMember = "Supplier_SlNo";
            cmbSearch.DataSource = aSupplierBusiness.GetAllQrySupplier();
        }

        private void GetNameForCombo()
        {
            cmbSearch.DataSource = null;
            cmbSearch.DisplayMember = "Supplier_Name";
            cmbSearch.ValueMember = "Supplier_SlNo";
            cmbSearch.DataSource = aSupplierBusiness.GetAllQrySupplier();
        }

        private void GetMobileForCombo()
        {
            cmbSearch.DataSource = null;
            cmbSearch.DisplayMember = "Supplier_Mobile";
            cmbSearch.ValueMember = "Supplier_SlNo";
            cmbSearch.DataSource = aSupplierBusiness.GetAllQrySupplier();
        }

        private void GetDistrictForComboBox()
        {
            try
            {
                cmbSearch.DataSource = null;
                cmbSearch.DisplayMember = "District_Name";
                cmbSearch.ValueMember = "District_SlNo";
                cmbSearch.DataSource = aDistrictBusiness.GetAllDistrict();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetCountryForComboBox()
        {
            try
            {
                cmbSearch.DataSource = null;
                cmbSearch.DisplayMember = "CountryName";
                cmbSearch.ValueMember = "Country_SlNo";
                cmbSearch.DataSource = aCountryBusiness.GetAllCountry();
                //cmbCountry.SelectedItem = cmbCountry.Items[2];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void LoadSupplierByID()
        {
            dgvSupplierList.AutoGenerateColumns = false;
            lstSupplierList = aSupplierBusiness.GetAllSupplierbyID(cmbSearch.Text);

            dgvSupplierList.DataSource = lstSupplierList;
        }

        void LoadSupplierByName()
        {
            dgvSupplierList.AutoGenerateColumns = false;
            lstSupplierList = aSupplierBusiness.GetAllSupplierbyName(cmbSearch.Text);
            dgvSupplierList.DataSource = lstSupplierList;
        }

        void LoadSupplierByMobile()
        {
            dgvSupplierList.AutoGenerateColumns = false;
            lstSupplierList = aSupplierBusiness.GetAllSupplierbyMobile(cmbSearch.Text);
            dgvSupplierList.DataSource = lstSupplierList;
        }

        void LoadSupplierByDistrict()
        {
            dgvSupplierList.AutoGenerateColumns = false;
            lstSupplierList = aSupplierBusiness.GetAllSupplierbyDistrict(cmbSearch.Text);
            dgvSupplierList.DataSource = lstSupplierList;
        }

        void LoadSupplierByCountry()
        {
            dgvSupplierList.AutoGenerateColumns = false;
            lstSupplierList = aSupplierBusiness.GetAllSupplierbyCountry(cmbSearch.Text);
            dgvSupplierList.DataSource = lstSupplierList;
        }

        private void cmbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSearchBy.Text == "All")
            {
                LoadGrid();
                cmbSearch.Visible = false;
            }
            if (cmbSearchBy.Text == "ID Number")
            {
                cmbSearch.Visible = true;
                GetIDForCombo();
            }
            if (cmbSearchBy.Text == "Name")
            {
                cmbSearch.Visible = true;
                GetNameForCombo();
            }
            if (cmbSearchBy.Text == "Mobile No.")
            {
                cmbSearch.Visible = true;
                GetMobileForCombo();
            }
            if (cmbSearchBy.Text == "District")
            {
                cmbSearch.Visible = true;
                GetDistrictForComboBox();
            }
            if (cmbSearchBy.Text == "Country")
            {
                cmbSearch.Visible = true;
                GetCountryForComboBox();
            }
        }

        private void cmbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSearchBy.Text == "All")
            {
                LoadGrid();
            }
            if (cmbSearchBy.Text == "ID Number" && cmbSearch.Text != string.Empty)
            {
                LoadSupplierByID();
            }
            if (cmbSearchBy.Text == "Name")
            {
                LoadSupplierByName();
            }
            if (cmbSearchBy.Text == "Mobile No.")
            {
                LoadSupplierByMobile();
            }
            if (cmbSearchBy.Text == "District")
            {
                LoadSupplierByDistrict();
            }
            if (cmbSearchBy.Text == "Country")
            {
                LoadSupplierByCountry();
            }
        }

        private void btnviewSupplier_Click(object sender, EventArgs e)
        {
            if (cmbSearchBy.Text == "All")
            {
                LoadGrid();
            }
            if (cmbSearchBy.Text == "ID Number")
            {
                LoadSupplierByID();
            }
            if (cmbSearchBy.Text == "Name")
            {
                LoadSupplierByName();
            }
            if (cmbSearchBy.Text == "Mobile No.")
            {
                LoadSupplierByMobile();
            }
            if (cmbSearchBy.Text == "District")
            {
                LoadSupplierByDistrict();
            }
            if (cmbSearchBy.Text == "Country")
            {
                LoadSupplierByCountry();
            }
        }
    }
}
