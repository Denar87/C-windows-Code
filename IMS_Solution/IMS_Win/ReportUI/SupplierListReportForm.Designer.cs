namespace IMS_Win
{
    partial class SupplierListReportForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupplierListReportForm));
            this.btnShow = new System.Windows.Forms.Button();
            this.dgvSupplierList = new System.Windows.Forms.DataGridView();
            this.Supplier_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Supplier_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Supplier_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Supplier_Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Supplier_Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Supplier_Mobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Supplier_Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchaseMaster_TotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbSearch = new System.Windows.Forms.ComboBox();
            this.btnviewSupplier = new System.Windows.Forms.Button();
            this.cmbSearchBy = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplierList)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(794, 5);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(94, 28);
            this.btnShow.TabIndex = 3;
            this.btnShow.Text = "&Show Report";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // dgvSupplierList
            // 
            this.dgvSupplierList.AllowUserToAddRows = false;
            this.dgvSupplierList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(234)))), ((int)(((byte)(248)))));
            this.dgvSupplierList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSupplierList.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dgvSupplierList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSupplierList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvSupplierList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(116)))), ((int)(((byte)(165)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSupplierList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSupplierList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSupplierList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Supplier_Code,
            this.Supplier_Name,
            this.Supplier_Type,
            this.Supplier_Address,
            this.Supplier_Phone,
            this.Supplier_Mobile,
            this.Supplier_Email,
            this.PurchaseMaster_TotalAmount});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSupplierList.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSupplierList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvSupplierList.EnableHeadersVisualStyles = false;
            this.dgvSupplierList.GridColor = System.Drawing.Color.Azure;
            this.dgvSupplierList.Location = new System.Drawing.Point(0, 37);
            this.dgvSupplierList.Name = "dgvSupplierList";
            this.dgvSupplierList.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(227)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSupplierList.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvSupplierList.RowHeadersWidth = 20;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(227)))), ((int)(((byte)(249)))));
            this.dgvSupplierList.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvSupplierList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSupplierList.Size = new System.Drawing.Size(897, 446);
            this.dgvSupplierList.TabIndex = 38;
            // 
            // Supplier_Code
            // 
            this.Supplier_Code.DataPropertyName = "Supplier_Code";
            this.Supplier_Code.HeaderText = "ID";
            this.Supplier_Code.Name = "Supplier_Code";
            this.Supplier_Code.ReadOnly = true;
            this.Supplier_Code.Width = 70;
            // 
            // Supplier_Name
            // 
            this.Supplier_Name.DataPropertyName = "Supplier_Name";
            this.Supplier_Name.HeaderText = "Supplier Name";
            this.Supplier_Name.Name = "Supplier_Name";
            this.Supplier_Name.ReadOnly = true;
            this.Supplier_Name.Width = 150;
            // 
            // Supplier_Type
            // 
            this.Supplier_Type.DataPropertyName = "Supplier_Type";
            this.Supplier_Type.HeaderText = "Type";
            this.Supplier_Type.Name = "Supplier_Type";
            this.Supplier_Type.ReadOnly = true;
            this.Supplier_Type.Width = 70;
            // 
            // Supplier_Address
            // 
            this.Supplier_Address.DataPropertyName = "Supplier_Address";
            this.Supplier_Address.HeaderText = "Address";
            this.Supplier_Address.Name = "Supplier_Address";
            this.Supplier_Address.ReadOnly = true;
            this.Supplier_Address.Width = 150;
            // 
            // Supplier_Phone
            // 
            this.Supplier_Phone.DataPropertyName = "Supplier_Phone";
            this.Supplier_Phone.HeaderText = "Phone";
            this.Supplier_Phone.Name = "Supplier_Phone";
            this.Supplier_Phone.ReadOnly = true;
            // 
            // Supplier_Mobile
            // 
            this.Supplier_Mobile.DataPropertyName = "Supplier_Mobile";
            this.Supplier_Mobile.HeaderText = "Mobile";
            this.Supplier_Mobile.Name = "Supplier_Mobile";
            this.Supplier_Mobile.ReadOnly = true;
            // 
            // Supplier_Email
            // 
            this.Supplier_Email.DataPropertyName = "Supplier_Email";
            this.Supplier_Email.HeaderText = "Email";
            this.Supplier_Email.Name = "Supplier_Email";
            this.Supplier_Email.ReadOnly = true;
            this.Supplier_Email.Width = 120;
            // 
            // PurchaseMaster_TotalAmount
            // 
            this.PurchaseMaster_TotalAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PurchaseMaster_TotalAmount.DataPropertyName = "Expr1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.PurchaseMaster_TotalAmount.DefaultCellStyle = dataGridViewCellStyle3;
            this.PurchaseMaster_TotalAmount.HeaderText = "Total Purchase";
            this.PurchaseMaster_TotalAmount.Name = "PurchaseMaster_TotalAmount";
            this.PurchaseMaster_TotalAmount.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::IMS_Win.Properties.Resources.back;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.cmbSearch);
            this.panel1.Controls.Add(this.btnviewSupplier);
            this.panel1.Controls.Add(this.cmbSearchBy);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnShow);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(897, 37);
            this.panel1.TabIndex = 39;
            // 
            // cmbSearch
            // 
            this.cmbSearch.BackColor = System.Drawing.Color.MintCream;
            this.cmbSearch.FormattingEnabled = true;
            this.cmbSearch.Location = new System.Drawing.Point(253, 8);
            this.cmbSearch.Name = "cmbSearch";
            this.cmbSearch.Size = new System.Drawing.Size(190, 23);
            this.cmbSearch.TabIndex = 1;
            this.cmbSearch.Visible = false;
            this.cmbSearch.SelectedIndexChanged += new System.EventHandler(this.cmbSearch_SelectedIndexChanged);
            // 
            // btnviewSupplier
            // 
            this.btnviewSupplier.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnviewSupplier.Location = new System.Drawing.Point(715, 5);
            this.btnviewSupplier.Name = "btnviewSupplier";
            this.btnviewSupplier.Size = new System.Drawing.Size(69, 28);
            this.btnviewSupplier.TabIndex = 2;
            this.btnviewSupplier.Text = "&View";
            this.btnviewSupplier.UseVisualStyleBackColor = true;
            this.btnviewSupplier.Click += new System.EventHandler(this.btnviewSupplier_Click);
            // 
            // cmbSearchBy
            // 
            this.cmbSearchBy.BackColor = System.Drawing.Color.MintCream;
            this.cmbSearchBy.FormattingEnabled = true;
            this.cmbSearchBy.Items.AddRange(new object[] {
            "All",
            "ID Number",
            "Name",
            "Mobile No.",
            "District",
            "Country"});
            this.cmbSearchBy.Location = new System.Drawing.Point(74, 8);
            this.cmbSearchBy.Name = "cmbSearchBy";
            this.cmbSearchBy.Size = new System.Drawing.Size(153, 23);
            this.cmbSearchBy.TabIndex = 0;
            this.cmbSearchBy.Text = "All";
            this.cmbSearchBy.SelectedIndexChanged += new System.EventHandler(this.cmbSearchBy_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(11, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 132;
            this.label4.Text = "Search By";
            // 
            // SupplierListReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(897, 483);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvSupplierList);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SupplierListReportForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supplier List";
            this.Load += new System.EventHandler(this.SupplierListReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplierList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.DataGridView dgvSupplierList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbSearch;
        private System.Windows.Forms.Button btnviewSupplier;
        private System.Windows.Forms.ComboBox cmbSearchBy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Supplier_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Supplier_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Supplier_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Supplier_Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Supplier_Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Supplier_Mobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn Supplier_Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaseMaster_TotalAmount;

    }
}