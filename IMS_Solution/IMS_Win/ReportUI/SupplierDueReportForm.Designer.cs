namespace IMS_Win
{
    partial class SupplierDueReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupplierDueReportForm));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SupplierListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.cmbSearchType = new System.Windows.Forms.ComboBox();
            this.lblname = new System.Windows.Forms.Label();
            this.lblcode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnView = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.dgvSupplierDueList = new System.Windows.Forms.DataGridView();
            this.PurchaseMaster_InvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Supplier_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Supplier_Mobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchaseMaster_DueAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Out_Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblstockamount = new System.Windows.Forms.Label();
            this.lbltaka = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplierDueList)).BeginInit();
            this.SuspendLayout();
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 160;
            // 
            // SupplierListView
            // 
            this.SupplierListView.BackColor = System.Drawing.Color.Azure;
            this.SupplierListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SupplierListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.SupplierListView.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SupplierListView.FullRowSelect = true;
            this.SupplierListView.Location = new System.Drawing.Point(271, 43);
            this.SupplierListView.MultiSelect = false;
            this.SupplierListView.Name = "SupplierListView";
            this.SupplierListView.Size = new System.Drawing.Size(222, 142);
            this.SupplierListView.TabIndex = 119;
            this.SupplierListView.UseCompatibleStateImageBehavior = false;
            this.SupplierListView.View = System.Windows.Forms.View.Details;
            this.SupplierListView.Visible = false;
            this.SupplierListView.Click += new System.EventHandler(this.SupplierListView_Click);
            this.SupplierListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SupplierListView_KeyPress);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 58;
            // 
            // txtName
            // 
            this.txtName.Cursor = System.Windows.Forms.Cursors.No;
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(433, 21);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(180, 23);
            this.txtName.TabIndex = 2;
            this.txtName.Visible = false;
            // 
            // txtCode
            // 
            this.txtCode.BackColor = System.Drawing.Color.MintCream;
            this.txtCode.Location = new System.Drawing.Point(266, 21);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(105, 23);
            this.txtCode.TabIndex = 1;
            this.txtCode.Visible = false;
            this.txtCode.Click += new System.EventHandler(this.txtCode_Click);
            this.txtCode.TextChanged += new System.EventHandler(this.txtCode_TextChanged);
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // cmbSearchType
            // 
            this.cmbSearchType.BackColor = System.Drawing.Color.MintCream;
            this.cmbSearchType.FormattingEnabled = true;
            this.cmbSearchType.Items.AddRange(new object[] {
            "All"});
            this.cmbSearchType.Location = new System.Drawing.Point(82, 20);
            this.cmbSearchType.Name = "cmbSearchType";
            this.cmbSearchType.Size = new System.Drawing.Size(96, 23);
            this.cmbSearchType.TabIndex = 0;
            this.cmbSearchType.Text = "All";
            this.cmbSearchType.SelectedIndexChanged += new System.EventHandler(this.cmbSearchType_SelectedIndexChanged);
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Location = new System.Drawing.Point(392, 25);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(38, 15);
            this.lblname.TabIndex = 2;
            this.lblname.Text = "Name";
            this.lblname.Visible = false;
            // 
            // lblcode
            // 
            this.lblcode.AutoSize = true;
            this.lblcode.Location = new System.Drawing.Point(195, 25);
            this.lblcode.Name = "lblcode";
            this.lblcode.Size = new System.Drawing.Size(68, 15);
            this.lblcode.TabIndex = 1;
            this.lblcode.Text = "Supplier ID";
            this.lblcode.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search Type";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.BackgroundImage = global::IMS_Win.Properties.Resources.back;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.txtCode);
            this.groupBox1.Controls.Add(this.btnView);
            this.groupBox1.Controls.Add(this.cmbSearchType);
            this.groupBox1.Controls.Add(this.btnShow);
            this.groupBox1.Controls.Add(this.lblname);
            this.groupBox1.Controls.Add(this.lblcode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(872, 56);
            this.groupBox1.TabIndex = 118;
            this.groupBox1.TabStop = false;
            // 
            // btnView
            // 
            this.btnView.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Location = new System.Drawing.Point(693, 19);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 28);
            this.btnView.TabIndex = 3;
            this.btnView.Text = "&View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnShow
            // 
            this.btnShow.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(774, 19);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(90, 28);
            this.btnShow.TabIndex = 4;
            this.btnShow.Text = "&Show Report";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // dgvSupplierDueList
            // 
            this.dgvSupplierDueList.AllowUserToAddRows = false;
            this.dgvSupplierDueList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(234)))), ((int)(((byte)(248)))));
            this.dgvSupplierDueList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSupplierDueList.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dgvSupplierDueList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSupplierDueList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvSupplierDueList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(116)))), ((int)(((byte)(165)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSupplierDueList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSupplierDueList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSupplierDueList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PurchaseMaster_InvoiceNo,
            this.Customer_Code,
            this.Supplier_Name,
            this.Supplier_Mobile,
            this.PurchaseMaster_DueAmount,
            this.Out_Amount});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSupplierDueList.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvSupplierDueList.EnableHeadersVisualStyles = false;
            this.dgvSupplierDueList.GridColor = System.Drawing.Color.Azure;
            this.dgvSupplierDueList.Location = new System.Drawing.Point(5, 58);
            this.dgvSupplierDueList.Name = "dgvSupplierDueList";
            this.dgvSupplierDueList.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(227)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSupplierDueList.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvSupplierDueList.RowHeadersWidth = 20;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(227)))), ((int)(((byte)(249)))));
            this.dgvSupplierDueList.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvSupplierDueList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSupplierDueList.Size = new System.Drawing.Size(871, 338);
            this.dgvSupplierDueList.TabIndex = 118;
            // 
            // PurchaseMaster_InvoiceNo
            // 
            this.PurchaseMaster_InvoiceNo.DataPropertyName = "PurchaseMaster_InvoiceNo";
            this.PurchaseMaster_InvoiceNo.HeaderText = "Invoice No.";
            this.PurchaseMaster_InvoiceNo.Name = "PurchaseMaster_InvoiceNo";
            this.PurchaseMaster_InvoiceNo.ReadOnly = true;
            this.PurchaseMaster_InvoiceNo.Width = 120;
            // 
            // Customer_Code
            // 
            this.Customer_Code.DataPropertyName = "Supplier_Code";
            this.Customer_Code.HeaderText = "Supplier ID";
            this.Customer_Code.Name = "Customer_Code";
            this.Customer_Code.ReadOnly = true;
            // 
            // Supplier_Name
            // 
            this.Supplier_Name.DataPropertyName = "Supplier_Name";
            this.Supplier_Name.HeaderText = "Supplier Name";
            this.Supplier_Name.Name = "Supplier_Name";
            this.Supplier_Name.ReadOnly = true;
            this.Supplier_Name.Width = 150;
            // 
            // Supplier_Mobile
            // 
            this.Supplier_Mobile.DataPropertyName = "Supplier_Mobile";
            this.Supplier_Mobile.HeaderText = "Contact No.";
            this.Supplier_Mobile.Name = "Supplier_Mobile";
            this.Supplier_Mobile.ReadOnly = true;
            // 
            // PurchaseMaster_DueAmount
            // 
            this.PurchaseMaster_DueAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PurchaseMaster_DueAmount.DataPropertyName = "PurchaseMaster_DueAmount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.PurchaseMaster_DueAmount.DefaultCellStyle = dataGridViewCellStyle3;
            this.PurchaseMaster_DueAmount.HeaderText = "Due Amount";
            this.PurchaseMaster_DueAmount.Name = "PurchaseMaster_DueAmount";
            this.PurchaseMaster_DueAmount.ReadOnly = true;
            // 
            // Out_Amount
            // 
            this.Out_Amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Out_Amount.DataPropertyName = "Out_Amount";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.Out_Amount.DefaultCellStyle = dataGridViewCellStyle4;
            this.Out_Amount.HeaderText = "Due Payment";
            this.Out_Amount.Name = "Out_Amount";
            this.Out_Amount.ReadOnly = true;
            // 
            // lblstockamount
            // 
            this.lblstockamount.AutoSize = true;
            this.lblstockamount.BackColor = System.Drawing.Color.Transparent;
            this.lblstockamount.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblstockamount.Location = new System.Drawing.Point(540, 407);
            this.lblstockamount.Name = "lblstockamount";
            this.lblstockamount.Size = new System.Drawing.Size(58, 15);
            this.lblstockamount.TabIndex = 121;
            this.lblstockamount.Text = "Total Due";
            // 
            // lbltaka
            // 
            this.lbltaka.AutoSize = true;
            this.lbltaka.BackColor = System.Drawing.Color.Transparent;
            this.lbltaka.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltaka.ForeColor = System.Drawing.Color.Brown;
            this.lbltaka.Location = new System.Drawing.Point(860, 407);
            this.lbltaka.Name = "lbltaka";
            this.lbltaka.Size = new System.Drawing.Size(22, 15);
            this.lbltaka.TabIndex = 122;
            this.lbltaka.Text = "Tk.";
            this.lbltaka.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotal.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(602, 404);
            this.txtTotal.Multiline = true;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(260, 22);
            this.txtTotal.TabIndex = 123;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // SupplierDueReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::IMS_Win.Properties.Resources.back;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(881, 431);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblstockamount);
            this.Controls.Add(this.lbltaka);
            this.Controls.Add(this.SupplierListView);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvSupplierDueList);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SupplierDueReportForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supplier Due Report";
            this.Load += new System.EventHandler(this.SupplierDueReportForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplierDueList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView SupplierListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.ComboBox cmbSearchType;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Label lblcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.DataGridView dgvSupplierDueList;
        private System.Windows.Forms.Label lblstockamount;
        private System.Windows.Forms.Label lbltaka;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaseMaster_InvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Supplier_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Supplier_Mobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaseMaster_DueAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Out_Amount;

    }
}