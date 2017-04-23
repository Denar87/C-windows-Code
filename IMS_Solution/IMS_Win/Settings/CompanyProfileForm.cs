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
using Utility;
using System.IO;

namespace IMS_Win
{
    public partial class CompanyProfileForm : Form
    {
        CompanyBusiness aCompanyBusiness = new CompanyBusiness();
        List<Tbl_Company> lstCompanyList = new List<Tbl_Company>();
        byte[] picbyte1 = new byte[] { };
        public CompanyProfileForm()
        {
            InitializeComponent();
        }

        private string imagePath = "";

        private void txtCompanyName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtReportHeading.Focus();
            }
            if (e.KeyChar == (char)Keys.Escape)
            {
                Close();
            }
        }

        private void txtCompanyName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                txtReportHeading.Focus();
            }
        }

        private void txtReportHeading_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                txtCompanyName.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            try
            {
                FileDialog fldlg = new OpenFileDialog();
                fldlg.InitialDirectory = @":D\";
                fldlg.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif";
                if (fldlg.ShowDialog() == DialogResult.OK)
                {
                    imagePath = fldlg.FileName;
                    Bitmap newimg = new Bitmap(imagePath);
                    logoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    logoPictureBox.Image = (Image)newimg;
                    picbyte1 = UtilityBusiness.GetByteArrayFromFile(imagePath);
                }
                fldlg = null;
            }
            catch (System.ArgumentException ae)
            {
                imagePath = UtilityBusiness.DefaultNoImagePath;
                MessageBox.Show(ae.Message.ToString());
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void lblClearImage_Click(object sender, EventArgs e)
        {
            try
            {
                imagePath = UtilityBusiness.DefaultNoImagePath;
                Bitmap newimg = new Bitmap(imagePath);
                logoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                logoPictureBox.Image = (Image)newimg;
                picbyte1 = UtilityBusiness.GetByteArrayFromFile(imagePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadCurrentInfo()
        {
            try
            {
                lstCompanyList = aCompanyBusiness.GetAllCompany();
                if (lstCompanyList.Any())
                {
                    txtCompanyName.Text = lstCompanyList[0].Company_Name;
                    txtReportHeading.Text = lstCompanyList[0].Repot_Heading;
                    txtCurrency.Text = lstCompanyList[0].Currency_Name;
                    txtCurrencySymbol.Text = lstCompanyList[0].Currency_Symbol;

                    if (lstCompanyList[0].Invoice_Type == 1)
                    {
                        A4RadioButton.Checked = true;
                    }
                    else if (lstCompanyList[0].Invoice_Type == 2)
                    {
                        halfA4radioButton.Checked = true;
                    }
                    else if (lstCompanyList[0].Invoice_Type == 3)
                    {
                        A4withDue_radioButton.Checked = true;
                    }
                    else if (lstCompanyList[0].Invoice_Type == 4)
                    {
                        A4half_withDue_radioButton.Checked = true;
                    }
                    else if (lstCompanyList[0].Invoice_Type == 5)
                    {
                        halfA4_RightradioButton.Checked = true;
                    }
                    else if (lstCompanyList[0].Invoice_Type == 6)
                    {
                        halfA4_Righ_withduetradioButton.Checked = true;
                    }
                    else if (lstCompanyList[0].Invoice_Type == 7)
                    {
                        rdbPOS_Exchange.Checked = true;
                    }
                    else if (lstCompanyList[0].Invoice_Type == 8)
                    {
                        rdbA4Bangla.Checked = true;
                    }
                    else if (lstCompanyList[0].Invoice_Type == 9)
                    {
                        rdbA4halfBangla.Checked = true;
                    }

                    else if (lstCompanyList[0].Invoice_Type == 0)
                    {
                        PP6900RadioButton.Checked = true;
                    }

                    if (lstCompanyList[0].AutoInvoicePrint == true)
                    {
                        chkAutoInvoicePrint.Checked = true;
                    }
                    else
                    {
                        chkAutoInvoicePrint.Checked = false;
                    }

                    byte[] storedimg = (byte[])lstCompanyList[0].Company_Logo;
                    picbyte1 = storedimg;
                    Image newimg;
                    using (MemoryStream stream = new MemoryStream(storedimg))
                    {
                        newimg = Image.FromStream(stream);
                        logoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        logoPictureBox.Image = newimg;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Tbl_Company aTbl_Company = new Tbl_Company();

            try
            {
                if (lstCompanyList.Any())
                {
                    aTbl_Company = lstCompanyList[0];
                }
                aTbl_Company.Company_Name = txtCompanyName.Text;
                aTbl_Company.Repot_Heading = txtReportHeading.Text;

                aTbl_Company.Currency_Name = txtCurrency.Text;
                aTbl_Company.Currency_Symbol = txtCurrencySymbol.Text;

                if (A4RadioButton.Checked == true)
                {
                    aTbl_Company.Invoice_Type = 1;
                }
                else if (halfA4radioButton.Checked == true)
                {
                    aTbl_Company.Invoice_Type = 2;
                }
                else if (A4withDue_radioButton.Checked == true)
                {
                    aTbl_Company.Invoice_Type = 3;
                }
                else if (A4half_withDue_radioButton.Checked == true)
                {
                    aTbl_Company.Invoice_Type = 4;
                }
                else if (halfA4_RightradioButton.Checked == true)
                {
                    aTbl_Company.Invoice_Type = 5;
                }
                else if (halfA4_Righ_withduetradioButton.Checked == true)
                {
                    aTbl_Company.Invoice_Type = 6;
                }
                else if (rdbPOS_Exchange.Checked == true)
                {
                    aTbl_Company.Invoice_Type = 7;
                }

                else if (rdbA4Bangla.Checked == true)
                {
                    aTbl_Company.Invoice_Type = 8;
                }

                else if (rdbA4halfBangla.Checked == true)
                {
                    aTbl_Company.Invoice_Type = 9;
                }

                else if (PP6900RadioButton.Checked == true)
                {
                    aTbl_Company.Invoice_Type = 0;
                }
                aTbl_Company.Company_Logo = picbyte1;

                if (chkAutoInvoicePrint.Checked == true)
                {
                    aTbl_Company.AutoInvoicePrint = true;
                }
                else
                {
                    aTbl_Company.AutoInvoicePrint = false;
                }

                string msg = aCompanyBusiness.validateOnSave(aTbl_Company);
                if (msg != string.Empty)
                {
                    UtilityBusiness.DisplayAlertMessage('W', msg);
                    return;
                }
                bool res = aCompanyBusiness.InsertorUpdate(aTbl_Company);
                if (res)
                {
                    UtilityBusiness.DisplayAlertMessage('S', "Saved Successfully");
                }
                else
                {
                    UtilityBusiness.DisplayAlertMessage('E', "Save Failed");
                }
            }
            catch (Exception ex)
            {
                UtilityBusiness.DisplayAlertMessage('E', ex.Message);
            }
            finally
            {
                aTbl_Company = null;
                LoadCurrentInfo();
            }
        }

        ToolTip TP = new ToolTip();

        private void CompanyProfileForm_Load(object sender, EventArgs e)
        {
            TP.ShowAlways = true;
            TP.SetToolTip(txtCompanyName, "Give Company Name");
            TP.SetToolTip(txtCurrency, "Give Company Address & Contact Info for Report Header");
            TP.SetToolTip(txtCurrency, "Give Currency Name i.e. BDT,Taka,Tk.,Dollar");
            TP.SetToolTip(txtCurrencySymbol, "Give Currency Symbol i.e. ৳,£,$,€,¥");

            LoadCurrentInfo();
        }

        private void pictureBoxclear_Click(object sender, EventArgs e)
        {
            try
            {
                imagePath = UtilityBusiness.DefaultNoImagePath;
                Bitmap newimg = new Bitmap(imagePath);
                logoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                logoPictureBox.Image = (Image)newimg;
                picbyte1 = UtilityBusiness.GetByteArrayFromFile(imagePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            txtCompanyName.Text = "";
            txtReportHeading.Text = "";

            imagePath = UtilityBusiness.DefaultNoImagePath;
            Bitmap newimg = new Bitmap(imagePath);
            logoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            logoPictureBox.Image = (Image)newimg;
            picbyte1 = UtilityBusiness.GetByteArrayFromFile(imagePath);
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            try
            {
                imagePath = UtilityBusiness.DefaultNoImagePath;
                Bitmap newimg = new Bitmap(imagePath);
                logoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                logoPictureBox.Image = (Image)newimg;
                picbyte1 = UtilityBusiness.GetByteArrayFromFile(imagePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCurrency_TextChanged(object sender, EventArgs e)
        {
            if (txtCurrency.Text == "BDT" || txtCurrency.Text == "Taka" || txtCurrency.Text == "Tk.")
            {
                txtCurrencySymbol.Text = "৳";
            }
            else
            {
                txtCurrencySymbol.Text = "";
            }
        }


    }
}
