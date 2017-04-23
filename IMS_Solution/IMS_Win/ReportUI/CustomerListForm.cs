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
    public partial class CustomerListForm : Form
    {
        CountryBusiness aCountryBusiness = new CountryBusiness();
        CompanyBusiness aCompanyBusiness = new CompanyBusiness();
        CustomerBusiness aCustomerBusiness = new CustomerBusiness();
        DistrictBusiness aDistrictBusiness = new DistrictBusiness();

        List<Qry_Customer> lstCustomerList = new List<Qry_Customer>();
        Qry_Customer aTbl_Customer = new Qry_Customer();
        public CustomerListForm()
        {
            InitializeComponent();
        }

        void ShowReport()
        {
            try
            {
                if (cmbSearchBy.Text == "All")
                {
                    List<Tbl_Company> lstCompanyList = aCompanyBusiness.GetAllCompany();
                    lstCustomerList = aCustomerBusiness.GetAllQryCustomer().Where(x => x.Customer_Code != "C0001").ToList();
                    DataTable dt = UtilityBusiness.GenericListToDataTable1<Qry_Customer>(lstCustomerList);

                    if (lstCustomerList.Count == 0)
                    {
                        dgvCustomerList.DataSource = null;
                        UtilityBusiness.DisplayAlertMessage('W', "No Data found!");
                        return;
                    }

                    Reports.CRCustomerReport rpt = new Reports.CRCustomerReport();
                    rpt.Subreports[0].SetDataSource(lstCompanyList);

                    ParameterFields paramFields = new ParameterFields();
                    ParameterDiscreteValue objDiscreteValue = new ParameterDiscreteValue();
                    ParameterField objParameterField = new ParameterField();

                    objDiscreteValue = new ParameterDiscreteValue();
                    objParameterField = new ParameterField();
                    objParameterField.Name = "paramUser";
                    objDiscreteValue.Value = SplashForm.username;
                    objParameterField.CurrentValues.Add(objDiscreteValue);
                    paramFields.Add(objParameterField);

                    rpt.SetDataSource(dt);
                    ReportViewerForm frm = new ReportViewerForm();
                    frm.ReportViewer.ParameterFieldInfo = paramFields;
                    frm.ReportViewer.ReportSource = rpt;
                    frm.ShowDialog();
                }
                if (cmbSearchBy.Text == "ID Number")
                {
                    List<Tbl_Company> lstCompanyList = aCompanyBusiness.GetAllCompany();
                    lstCustomerList = aCustomerBusiness.GetAllQryCustomer().Where(x => x.Customer_Code == cmbSearch.Text).ToList();
                    DataTable dt = UtilityBusiness.GenericListToDataTable1<Qry_Customer>(lstCustomerList);

                    if (lstCustomerList.Count == 0)
                    {
                        dgvCustomerList.DataSource = null;
                        UtilityBusiness.DisplayAlertMessage('W', "No Data found!");
                        return;
                    }

                    Reports.CRCustomerReportSingle rpt = new Reports.CRCustomerReportSingle();
                    rpt.Subreports[0].SetDataSource(lstCompanyList);

                    ParameterFields paramFields = new ParameterFields();
                    ParameterDiscreteValue objDiscreteValue = new ParameterDiscreteValue();
                    ParameterField objParameterField = new ParameterField();

                    objDiscreteValue = new ParameterDiscreteValue();
                    objParameterField = new ParameterField();
                    objParameterField.Name = "paramUser";
                    objDiscreteValue.Value = SplashForm.username;
                    objParameterField.CurrentValues.Add(objDiscreteValue);
                    paramFields.Add(objParameterField);

                    rpt.SetDataSource(dt);
                    ReportViewerForm frm = new ReportViewerForm();
                    frm.ReportViewer.ParameterFieldInfo = paramFields;
                    frm.ReportViewer.ReportSource = rpt;
                    frm.ShowDialog();
                }
                if (cmbSearchBy.Text == "ID Number")
                {
                    List<Tbl_Company> lstCompanyList = aCompanyBusiness.GetAllCompany();
                    lstCustomerList = aCustomerBusiness.GetAllQryCustomer().Where(x => x.Customer_Code == cmbSearch.Text).ToList();
                    DataTable dt = UtilityBusiness.GenericListToDataTable1<Qry_Customer>(lstCustomerList);

                    if (lstCustomerList.Count == 0)
                    {
                        dgvCustomerList.DataSource = null;
                        UtilityBusiness.DisplayAlertMessage('W', "No Data found!");
                        return;
                    }
                    
                    Reports.CRCustomerReportSingle rpt = new Reports.CRCustomerReportSingle();
                    rpt.Subreports[0].SetDataSource(lstCompanyList);

                    ParameterFields paramFields = new ParameterFields();
                    ParameterDiscreteValue objDiscreteValue = new ParameterDiscreteValue();
                    ParameterField objParameterField = new ParameterField();

                    objDiscreteValue = new ParameterDiscreteValue();
                    objParameterField = new ParameterField();
                    objParameterField.Name = "paramUser";
                    objDiscreteValue.Value = SplashForm.username;
                    objParameterField.CurrentValues.Add(objDiscreteValue);
                    paramFields.Add(objParameterField);

                    rpt.SetDataSource(dt);
                    ReportViewerForm frm = new ReportViewerForm();
                    frm.ReportViewer.ParameterFieldInfo = paramFields;
                    frm.ReportViewer.ReportSource = rpt;
                    frm.ShowDialog();
                }
                if (cmbSearchBy.Text == "Name")
                {
                    List<Tbl_Company> lstCompanyList = aCompanyBusiness.GetAllCompany();
                    lstCustomerList = aCustomerBusiness.GetAllQryCustomer().Where(x => x.Customer_Name == cmbSearch.Text).ToList();
                    DataTable dt = UtilityBusiness.GenericListToDataTable1<Qry_Customer>(lstCustomerList);

                    if (lstCustomerList.Count == 0)
                    {
                        dgvCustomerList.DataSource = null;
                        UtilityBusiness.DisplayAlertMessage('W', "No Data found!");
                        return;
                    }

                    Reports.CRCustomerReportSingle rpt = new Reports.CRCustomerReportSingle();
                    rpt.Subreports[0].SetDataSource(lstCompanyList);

                    ParameterFields paramFields = new ParameterFields();
                    ParameterDiscreteValue objDiscreteValue = new ParameterDiscreteValue();
                    ParameterField objParameterField = new ParameterField();

                    objDiscreteValue = new ParameterDiscreteValue();
                    objParameterField = new ParameterField();
                    objParameterField.Name = "paramUser";
                    objDiscreteValue.Value = SplashForm.username;
                    objParameterField.CurrentValues.Add(objDiscreteValue);
                    paramFields.Add(objParameterField);

                    rpt.SetDataSource(dt);
                    ReportViewerForm frm = new ReportViewerForm();
                    frm.ReportViewer.ParameterFieldInfo = paramFields;
                    frm.ReportViewer.ReportSource = rpt;
                    frm.ShowDialog();
                }
                if (cmbSearchBy.Text == "Mobile No.")
                {
                    List<Tbl_Company> lstCompanyList = aCompanyBusiness.GetAllCompany();
                    lstCustomerList = aCustomerBusiness.GetAllQryCustomer().Where(x => x.Customer_Mobile == cmbSearch.Text).ToList();
                    DataTable dt = UtilityBusiness.GenericListToDataTable1<Qry_Customer>(lstCustomerList);

                    if (lstCustomerList.Count == 0)
                    {
                        dgvCustomerList.DataSource = null;
                        UtilityBusiness.DisplayAlertMessage('W', "No Data found!");
                        return;
                    }
                    Reports.CRCustomerReportSingle rpt = new Reports.CRCustomerReportSingle();
                    rpt.Subreports[0].SetDataSource(lstCompanyList);

                    ParameterFields paramFields = new ParameterFields();
                    ParameterDiscreteValue objDiscreteValue = new ParameterDiscreteValue();
                    ParameterField objParameterField = new ParameterField();

                    objDiscreteValue = new ParameterDiscreteValue();
                    objParameterField = new ParameterField();
                    objParameterField.Name = "paramUser";
                    objDiscreteValue.Value = SplashForm.username;
                    objParameterField.CurrentValues.Add(objDiscreteValue);
                    paramFields.Add(objParameterField);

                    rpt.SetDataSource(dt);
                    ReportViewerForm frm = new ReportViewerForm();
                    frm.ReportViewer.ParameterFieldInfo = paramFields;
                    frm.ReportViewer.ReportSource = rpt;
                    frm.ShowDialog();
                }
                if (cmbSearchBy.Text == "Area")
                {
                    List<Tbl_Company> lstCompanyList = aCompanyBusiness.GetAllCompany();
                    lstCustomerList = aCustomerBusiness.GetAllQryCustomer().Where(x => x.District_Name == cmbSearch.Text).ToList();
                    DataTable dt = UtilityBusiness.GenericListToDataTable1<Qry_Customer>(lstCustomerList);

                    if (lstCustomerList.Count == 0)
                    {
                        dgvCustomerList.DataSource = null;
                        UtilityBusiness.DisplayAlertMessage('W', "No Data found!");
                        return;
                    }
                    Reports.CRAreawiseCustomerList rpt = new Reports.CRAreawiseCustomerList();
                    rpt.Subreports[0].SetDataSource(lstCompanyList);

                    ParameterFields paramFields = new ParameterFields();
                    ParameterDiscreteValue objDiscreteValue = new ParameterDiscreteValue();
                    ParameterField objParameterField = new ParameterField();

                    objDiscreteValue = new ParameterDiscreteValue();
                    objParameterField = new ParameterField();
                    objParameterField.Name = "paramUser";
                    objDiscreteValue.Value = SplashForm.username;
                    objParameterField.CurrentValues.Add(objDiscreteValue);
                    paramFields.Add(objParameterField);

                    rpt.SetDataSource(dt);
                    ReportViewerForm frm = new ReportViewerForm();
                    frm.ReportViewer.ParameterFieldInfo = paramFields;
                    frm.ReportViewer.ReportSource = rpt;
                    frm.ShowDialog();
                }
                if (cmbSearchBy.Text == "Country")
                {
                    List<Tbl_Company> lstCompanyList = aCompanyBusiness.GetAllCompany();
                    lstCustomerList = aCustomerBusiness.GetAllQryCustomer().Where(x => x.CountryName == cmbSearch.Text).ToList();
                    DataTable dt = UtilityBusiness.GenericListToDataTable1<Qry_Customer>(lstCustomerList);

                    if (lstCustomerList.Count == 0)
                    {
                        dgvCustomerList.DataSource = null;
                        UtilityBusiness.DisplayAlertMessage('W', "No Data found!");
                        return;
                    }
                    Reports.CRCoutrywiseCustomerReport rpt = new Reports.CRCoutrywiseCustomerReport();
                    rpt.Subreports[0].SetDataSource(lstCompanyList);

                    ParameterFields paramFields = new ParameterFields();
                    ParameterDiscreteValue objDiscreteValue = new ParameterDiscreteValue();
                    ParameterField objParameterField = new ParameterField();

                    objDiscreteValue = new ParameterDiscreteValue();
                    objParameterField = new ParameterField();
                    objParameterField.Name = "paramUser";
                    objDiscreteValue.Value = SplashForm.username;
                    objParameterField.CurrentValues.Add(objDiscreteValue);
                    paramFields.Add(objParameterField);

                    rpt.SetDataSource(dt);
                    ReportViewerForm frm = new ReportViewerForm();
                    frm.ReportViewer.ParameterFieldInfo = paramFields;
                    frm.ReportViewer.ReportSource = rpt;
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetDistrictsForComboBox()
        {
            try
            {
                cmbSearch.DataSource = null;
                cmbSearch.DisplayMember = "District_Name";
                cmbSearch.ValueMember = "District_SlNo";
                cmbSearch.DataSource = aDistrictBusiness.GetAllDistrict();
                //cmbDistrict.Text = "Dhaka";
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

        private void GetIDForCombo()
        {
            cmbSearch.DataSource = null;
            cmbSearch.DisplayMember = "Customer_Code";
            cmbSearch.ValueMember = "Customer_SlNo";
            cmbSearch.DataSource = aCustomerBusiness.GetAllQryCustomer().Where(x => x.Customer_Code != "C0001").ToList();
        }

        private void GetNameForCombo()
        {
            cmbSearch.DataSource = null;
            cmbSearch.DisplayMember = "Customer_Name";
            cmbSearch.ValueMember = "Customer_SlNo";
            cmbSearch.DataSource = aCustomerBusiness.GetAllQryCustomer().Where(x => x.Customer_Code != "C0001").ToList();
        }

        private void GetMobileForCombo()
        {
            cmbSearch.DataSource = null;
            cmbSearch.DisplayMember = "Customer_Mobile";
            cmbSearch.ValueMember = "Customer_SlNo";
            cmbSearch.DataSource = aCustomerBusiness.GetAllQryCustomer().Where(x => x.Customer_Code != "C0001").ToList();
        }

        private void CustomerListForm_Load(object sender, EventArgs e)
        {
            if(cmbSearchBy.Text=="All")
            {
                LoadGrid();
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            ShowReport();
        }

        void LoadGrid()
        {
            dgvCustomerList.AutoGenerateColumns = false;
            lstCustomerList = aCustomerBusiness.GetAllQryCustomer().Where(x=>x.Customer_Code!="C0001").ToList();

            if (lstCustomerList.Count == 0)
            {
                dgvCustomerList.DataSource = null;
                UtilityBusiness.DisplayAlertMessage('W', "No Data found!");
                return;
            }

            dgvCustomerList.DataSource = lstCustomerList;
        }

        void LoadCustomerByID()
        {
            dgvCustomerList.AutoGenerateColumns = false;
            lstCustomerList = aCustomerBusiness.GetAllCustomerbyID(cmbSearch.Text);
            if (lstCustomerList.Count == 0)
            {
                dgvCustomerList.DataSource = null;
                UtilityBusiness.DisplayAlertMessage('W', "No Data found!");
                return;
            }
            dgvCustomerList.DataSource = lstCustomerList;
        }

        void LoadCustomerByName()
        {
            dgvCustomerList.AutoGenerateColumns = false;
            lstCustomerList = aCustomerBusiness.GetAllCustomerbyName(cmbSearch.Text);
            if (lstCustomerList.Count == 0)
            {
                dgvCustomerList.DataSource = null;
                UtilityBusiness.DisplayAlertMessage('W', "No Data found!");
                return;
            }
            dgvCustomerList.DataSource = lstCustomerList;
        }

        void LoadCustomerByMobile()
        {
            dgvCustomerList.AutoGenerateColumns = false;
            lstCustomerList = aCustomerBusiness.GetAllCustomerbyMobile(cmbSearch.Text);
            if (lstCustomerList.Count == 0)
            {
                dgvCustomerList.DataSource = null;
                UtilityBusiness.DisplayAlertMessage('W', "No Data found!");
                return;
            }
            dgvCustomerList.DataSource = lstCustomerList;
        }

        void LoadCustomerByCountry()
        {
            dgvCustomerList.AutoGenerateColumns = false;
            lstCustomerList = aCustomerBusiness.GetAllCustomerByCountry(cmbSearch.Text).Where(x => x.Customer_Code != "C0001").ToList();
            if (lstCustomerList.Count == 0)
            {
                dgvCustomerList.DataSource = null;
                UtilityBusiness.DisplayAlertMessage('W', "No Data found!");
                return;
            }
            dgvCustomerList.DataSource = lstCustomerList;
        }

        void LoadCustomerByArea()
        {
            int districtId = Convert.ToInt16(cmbSearch.SelectedValue);

            dgvCustomerList.AutoGenerateColumns = false;
            lstCustomerList = aCustomerBusiness.GetAllQryCustomer().Where(x => x.Customer_Code != "C0001" && x.District_SlNo==districtId).ToList();
            if (lstCustomerList.Count == 0)
            {
                dgvCustomerList.DataSource = null;
                UtilityBusiness.DisplayAlertMessage('W', "No Data found!");
                return;
            }
            dgvCustomerList.DataSource = lstCustomerList;
        }

        private void cmbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbSearchBy.Text=="All")
            {
                LoadGrid();
                cmbSearch.Visible = false;
            }
            if(cmbSearchBy.Text=="ID Number")
            {
                cmbSearch.Visible=true;
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
            if (cmbSearchBy.Text == "Area")
            {
                cmbSearch.Visible = true;
                GetDistrictsForComboBox();
            }
            if (cmbSearchBy.Text == "Country")
            {
                cmbSearch.Visible = true;
                GetCountryForComboBox();
            }
        }

        private void btnviewCustomer_Click(object sender, EventArgs e)
        {
            if (cmbSearchBy.Text == "All")
            {
                LoadGrid();
            }
            if (cmbSearchBy.Text == "ID Number")
            {
                LoadCustomerByID();
            }
            if (cmbSearchBy.Text == "Name")
            {
                LoadCustomerByName();
            }
            if (cmbSearchBy.Text == "Mobile No.")
            {
                LoadCustomerByMobile();
            }
            if (cmbSearchBy.Text == "Area")
            {
                LoadCustomerByArea();
            }
            if (cmbSearchBy.Text == "Country")
            {
                LoadCustomerByCountry();
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
                LoadCustomerByID();
            }
            if (cmbSearchBy.Text == "Name")
            {
                LoadCustomerByName();
            }
            if (cmbSearchBy.Text == "Mobile No.")
            {
                LoadCustomerByMobile();
            }
            if (cmbSearchBy.Text == "Area")
            {
                LoadCustomerByArea();
            }
            if (cmbSearchBy.Text == "Country")
            {
                LoadCustomerByCountry();
            }
        }

        private void cmbSearch_MouseDown(object sender, MouseEventArgs e)
        {
            
        }
      
    }
}
