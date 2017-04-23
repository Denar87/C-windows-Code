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

namespace IMS_Win
{
    public partial class ResetForm : Form
    {
        ResetBusiness aResetBusiness = new ResetBusiness();
        public ResetForm()
        {
            InitializeComponent();
        }

        private void btnResetData_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Are You Sure To Restore Database? ", "RESTORE ", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) == DialogResult.No)
            {
                return;
            }
            bool res = aResetBusiness.deleteall();
            if (res)
            {
                UtilityBusiness.DisplayAlertMessage('S', "Restored Successfully");
            }
            else
            {
                UtilityBusiness.DisplayAlertMessage('E', "Restored Failed");
            }
        }
    }
}
