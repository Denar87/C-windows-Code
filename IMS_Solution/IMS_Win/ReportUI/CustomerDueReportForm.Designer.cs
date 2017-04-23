namespace IMS_Win
{
    partial class CustomerDueReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerDueReportForm));
            this.btnView = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.dgvCustomerDueList = new System.Windows.Forms.DataGridView();
            this.SaleMaster_InvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer_Mobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleMaster_DueAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.In_Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtCustomerCode = new System.Windows.Forms.TextBox();
            this.cmbSearchType = new System.Windows.Forms.ComboBox();
            this.lblname = new System.Windows.Forms.Label();
            this.lblcode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.customerListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblstockamount = new System.Windows.Forms.Label();
            this.lbltaka = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerDueList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnView
            // 
            this.btnView.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Location = new System.Drawing.Point(704, 19);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(80, 28);
            this.btnView.TabIndex = 3;
            this.btnView.Text = "&View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnShow
            // 
            this.btnShow.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(792, 19);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(90, 28);
            this.btnShow.TabIndex = 4;
            this.btnShow.Text = "&Show Report";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // dgvCustomerDueList
            // 
            this.dgvCustomerDueList.AllowUserToAddRows = false;
            this.dgvCustomerDueList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(234)))), ((int)(((byte)(248)))));
            this.dgvCustomerDueList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCustomerDueList.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dgvCustomerDueList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCustomerDueList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvCustomerDueList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(116)))), ((int)(((byte)(165)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCustomerDueList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCustomerDueList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomerDueList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SaleMaster_InvoiceNo,
            this.Customer_Code,
            this.Customer_Name,
            this.Customer_Mobile,
            this.SaleMaster_DueAmount,
            this.In_Amount});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCustomerDueList.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCustomerDueList.EnableHeadersVisualStyles = false;
            this.dgvCustomerDueList.GridColor = System.Drawing.Color.Azure;
            this.dgvCustomerDueList.Location = new System.Drawing.Point(6, 59);
            this.dgvCustomerDueList.Name = "dgvCustomerDueList";
            this.dgvCustomerDueList.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(227)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCustomerDueList.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCustomerDueList.RowHeadersWidth = 20;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(227)))), ((int)(((byte)(249)))));
            this.dgvCustomerDueList.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvCustomerDueList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomerDueList.Size = new System.Drawing.Size(888, 330);
            this.dgvCustomerDueList.TabIndex = 36;
            // 
            // SaleMaster_InvoiceNo
            // 
            this.SaleMaster_InvoiceNo.DataPropertyName = "SaleMaster_InvoiceNo";
            this.SaleMaster_InvoiceNo.HeaderText = "Invoice No";
            this.SaleMaster_InvoiceNo.Name = "SaleMaster_InvoiceNo";
            this.SaleMaster_InvoiceNo.ReadOnly = true;
            this.SaleMaster_InvoiceNo.Width = 120;
            // 
            // Customer_Code
            // 
            this.Customer_Code.DataPropertyName = "Customer_Code";
            this.Customer_Code.HeaderText = "Customer ID";
            this.Customer_Code.Name = "Customer_Code";
            this.Customer_Code.ReadOnly = true;
            // 
            // Customer_Name
            // 
            this.Customer_Name.DataPropertyName = "Customer_Name";
            this.Customer_Name.HeaderText = "Customer Name";
            this.Customer_Name.Name = "Customer_Name";
            this.Customer_Name.ReadOnly = true;
            this.Customer_Name.Width = 150;
            // 
            // Customer_Mobile
            // 
            this.Customer_Mobile.DataPropertyName = "Customer_Mobile";
            this.Customer_Mobile.HeaderText = "Contact No.";
            this.Customer_Mobile.Name = "Customer_Mobile";
            this.Customer_Mobile.ReadOnly = true;
            // 
            // SaleMaster_DueAmount
            // 
            this.SaleMaster_DueAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SaleMaster_DueAmount.DataPropertyName = "SaleMaster_DueAmount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.SaleMaster_DueAmount.DefaultCellStyle = dataGridViewCellStyle3;
            this.SaleMaster_DueAmount.HeaderText = "Due Amount";
            this.SaleMaster_DueAmount.Name = "SaleMaster_DueAmount";
            this.SaleMaster_DueAmount.ReadOnly = true;
            // 
            // In_Amount
            // 
            this.In_Amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.In_Amount.DataPropertyName = "In_Amount";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.In_Amount.DefaultCellStyle = dataGridViewCellStyle4;
            this.In_Amount.HeaderText = "Due Recieve";
            this.In_Amount.Name = "In_Amount";
            this.In_Amount.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.BackgroundImage = global::IMS_Win.Properties.Resources.back;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.txtCustomerName);
            this.groupBox1.Controls.Add(this.txtCustomerCode);
            this.groupBox1.Controls.Add(this.btnView);
            this.groupBox1.Controls.Add(this.cmbSearchType);
            this.groupBox1.Controls.Add(this.btnShow);
            this.groupBox1.Controls.Add(this.lblname);
            this.groupBox1.Controls.Add(this.lblcode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(5, -2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(889, 58);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Cursor = System.Windows.Forms.Cursors.No;
            this.txtCustomerName.Enabled = false;
            this.txtCustomerName.Location = new System.Drawing.Point(434, 22);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(172, 23);
            this.txtCustomerName.TabIndex = 2;
            this.txtCustomerName.Visible = false;
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.BackColor = System.Drawing.Color.MintCream;
            this.txtCustomerCode.Location = new System.Drawing.Point(280, 22);
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(105, 23);
            this.txtCustomerCode.TabIndex = 1;
            this.txtCustomerCode.Visible = false;
            this.txtCustomerCode.Click += new System.EventHandler(this.txtCustomerCode_Click);
            this.txtCustomerCode.TextChanged += new System.EventHandler(this.txtCustomerCode_TextChanged);
            this.txtCustomerCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomerCode_KeyDown);
            // 
            // cmbSearchType
            // 
            this.cmbSearchType.BackColor = System.Drawing.Color.MintCream;
            this.cmbSearchType.FormattingEnabled = true;
            this.cmbSearchType.Items.AddRange(new object[] {
            "All"});
            this.cmbSearchType.Location = new System.Drawing.Point(83, 22);
            this.cmbSearchType.Name = "cmbSearchType";
            this.cmbSearchType.Size = new System.Drawing.Size(96, 23);
            this.cmbSearchType.TabIndex = 0;
            this.cmbSearchType.Text = "All";
            this.cmbSearchType.SelectedIndexChanged += new System.EventHandler(this.cmbSearchType_SelectedIndexChanged);
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Location = new System.Drawing.Point(393, 26);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(38, 15);
            this.lblname.TabIndex = 2;
            this.lblname.Text = "Name";
            this.lblname.Visible = false;
            // 
            // lblcode
            // 
            this.lblcode.AutoSize = true;
            this.lblcode.Location = new System.Drawing.Point(203, 26);
            this.lblcode.Name = "lblcode";
            this.lblcode.Size = new System.Drawing.Size(74, 15);
            this.lblcode.TabIndex = 1;
            this.lblcode.Text = "Customer ID";
            this.lblcode.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search Type";
            // 
            // customerListView
            // 
            this.customerListView.BackColor = System.Drawing.Color.Azure;
            this.customerListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.customerListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.customerListView.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerListView.FullRowSelect = true;
            this.customerListView.Location = new System.Drawing.Point(286, 43);
            this.customerListView.MultiSelect = false;
            this.customerListView.Name = "customerListView";
            this.customerListView.Size = new System.Drawing.Size(224, 117);
            this.customerListView.TabIndex = 116;
            this.customerListView.UseCompatibleStateImageBehavior = false;
            this.customerListView.View = System.Windows.Forms.View.Details;
            this.customerListView.Visible = false;
            this.customerListView.Click += new System.EventHandler(this.customerListView_Click);
            this.customerListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.customerListView_KeyPress);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 160;
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotal.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(617, 396);
            this.txtTotal.Multiline = true;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(260, 22);
            this.txtTotal.TabIndex = 126;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblstockamount
            // 
            this.lblstockamount.AutoSize = true;
            this.lblstockamount.BackColor = System.Drawing.Color.Transparent;
            this.lblstockamount.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblstockamount.Location = new System.Drawing.Point(556, 400);
            this.lblstockamount.Name = "lblstockamount";
            this.lblstockamount.Size = new System.Drawing.Size(58, 15);
            this.lblstockamount.TabIndex = 124;
            this.lblstockamount.Text = "Total Due";
            // 
            // lbltaka
            // 
            this.lbltaka.AutoSize = true;
            this.lbltaka.BackColor = System.Drawing.Color.Transparent;
            this.lbltaka.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltaka.ForeColor = System.Drawing.Color.Brown;
            this.lbltaka.Location = new System.Drawing.Point(877, 399);
            this.lbltaka.Name = "lbltaka";
            this.lbltaka.Size = new System.Drawing.Size(22, 15);
            this.lbltaka.TabIndex = 125;
            this.lbltaka.Text = "Tk.";
            this.lbltaka.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CustomerDueReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::IMS_Win.Properties.Resources.back;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(900, 425);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblstockamount);
            this.Controls.Add(this.lbltaka);
            this.Controls.Add(this.customerListView);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvCustomerDueList);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomerDueReportForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Due Report";
            this.Load += new System.EventHandler(this.CustomerDueReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomerDueList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.DataGridView dgvCustomerDueList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCustomerCode;
        private System.Windows.Forms.ComboBox cmbSearchType;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Label lblcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.ListView customerListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblstockamount;
        private System.Windows.Forms.Label lbltaka;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleMaster_InvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer_Mobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleMaster_DueAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn In_Amount;

    }
}