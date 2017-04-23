namespace IMS_Win
{
    partial class ChallanListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChallanListForm));
            this.btnShow = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.dtpfrom = new System.Windows.Forms.DateTimePicker();
            this.dtpto = new System.Windows.Forms.DateTimePicker();
            this.btnView = new System.Windows.Forms.Button();
            this.dgvChallanList = new System.Windows.Forms.DataGridView();
            this.SaleChallanNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleMaster_SaleDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleDetails_TotalQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleDetails_Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleDetails_TotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChallanList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnShow
            // 
            this.btnShow.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(369, 4);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(94, 28);
            this.btnShow.TabIndex = 3;
            this.btnShow.Text = "&Show Report";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Visible = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::IMS_Win.Properties.Resources.back;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.dtpfrom);
            this.panel1.Controls.Add(this.dtpto);
            this.panel1.Controls.Add(this.btnView);
            this.panel1.Controls.Add(this.btnShow);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(942, 35);
            this.panel1.TabIndex = 39;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(8, 10);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(32, 15);
            this.label21.TabIndex = 133;
            this.label21.Text = "Date";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(151, 10);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(18, 15);
            this.label22.TabIndex = 132;
            this.label22.Text = "to";
            // 
            // dtpfrom
            // 
            this.dtpfrom.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpfrom.Location = new System.Drawing.Point(44, 6);
            this.dtpfrom.Name = "dtpfrom";
            this.dtpfrom.Size = new System.Drawing.Size(102, 23);
            this.dtpfrom.TabIndex = 130;
            // 
            // dtpto
            // 
            this.dtpto.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpto.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpto.Location = new System.Drawing.Point(173, 6);
            this.dtpto.Name = "dtpto";
            this.dtpto.Size = new System.Drawing.Size(102, 23);
            this.dtpto.TabIndex = 131;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(285, 4);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(81, 28);
            this.btnView.TabIndex = 2;
            this.btnView.Text = "&View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // dgvChallanList
            // 
            this.dgvChallanList.AllowUserToAddRows = false;
            this.dgvChallanList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(234)))), ((int)(((byte)(248)))));
            this.dgvChallanList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvChallanList.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dgvChallanList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvChallanList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvChallanList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(116)))), ((int)(((byte)(165)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChallanList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvChallanList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChallanList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SaleChallanNo,
            this.SaleMaster_SaleDate,
            this.Customer_Name,
            this.Product_Name,
            this.SaleDetails_TotalQuantity,
            this.Unit_Name,
            this.SaleDetails_Rate,
            this.SaleDetails_TotalAmount});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChallanList.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvChallanList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvChallanList.EnableHeadersVisualStyles = false;
            this.dgvChallanList.GridColor = System.Drawing.Color.Azure;
            this.dgvChallanList.Location = new System.Drawing.Point(0, 35);
            this.dgvChallanList.Name = "dgvChallanList";
            this.dgvChallanList.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(227)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChallanList.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvChallanList.RowHeadersWidth = 20;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(227)))), ((int)(((byte)(249)))));
            this.dgvChallanList.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvChallanList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChallanList.Size = new System.Drawing.Size(942, 436);
            this.dgvChallanList.TabIndex = 40;
            // 
            // SaleChallanNo
            // 
            this.SaleChallanNo.DataPropertyName = "SaleChallanNo";
            this.SaleChallanNo.HeaderText = "Challan No.";
            this.SaleChallanNo.Name = "SaleChallanNo";
            this.SaleChallanNo.ReadOnly = true;
            this.SaleChallanNo.Width = 110;
            // 
            // SaleMaster_SaleDate
            // 
            this.SaleMaster_SaleDate.DataPropertyName = "SaleMaster_SaleDate";
            this.SaleMaster_SaleDate.HeaderText = "Date";
            this.SaleMaster_SaleDate.Name = "SaleMaster_SaleDate";
            this.SaleMaster_SaleDate.ReadOnly = true;
            // 
            // Customer_Name
            // 
            this.Customer_Name.DataPropertyName = "Customer_Name";
            this.Customer_Name.HeaderText = "Customer";
            this.Customer_Name.Name = "Customer_Name";
            this.Customer_Name.ReadOnly = true;
            this.Customer_Name.Width = 150;
            // 
            // Product_Name
            // 
            this.Product_Name.DataPropertyName = "Product_Name";
            this.Product_Name.HeaderText = "Product Name";
            this.Product_Name.Name = "Product_Name";
            this.Product_Name.ReadOnly = true;
            this.Product_Name.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Product_Name.Width = 200;
            // 
            // SaleDetails_TotalQuantity
            // 
            this.SaleDetails_TotalQuantity.DataPropertyName = "SaleDetails_TotalQuantity";
            this.SaleDetails_TotalQuantity.HeaderText = "Qty";
            this.SaleDetails_TotalQuantity.Name = "SaleDetails_TotalQuantity";
            this.SaleDetails_TotalQuantity.ReadOnly = true;
            this.SaleDetails_TotalQuantity.Width = 80;
            // 
            // Unit_Name
            // 
            this.Unit_Name.DataPropertyName = "Unit_Name";
            this.Unit_Name.HeaderText = "Unit";
            this.Unit_Name.Name = "Unit_Name";
            this.Unit_Name.ReadOnly = true;
            this.Unit_Name.Width = 80;
            // 
            // SaleDetails_Rate
            // 
            this.SaleDetails_Rate.DataPropertyName = "SaleDetails_Rate";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.SaleDetails_Rate.DefaultCellStyle = dataGridViewCellStyle3;
            this.SaleDetails_Rate.HeaderText = "Rate";
            this.SaleDetails_Rate.Name = "SaleDetails_Rate";
            this.SaleDetails_Rate.ReadOnly = true;
            // 
            // SaleDetails_TotalAmount
            // 
            this.SaleDetails_TotalAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SaleDetails_TotalAmount.DataPropertyName = "SaleDetails_TotalAmount";
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.SaleDetails_TotalAmount.DefaultCellStyle = dataGridViewCellStyle4;
            this.SaleDetails_TotalAmount.HeaderText = "Amount";
            this.SaleDetails_TotalAmount.Name = "SaleDetails_TotalAmount";
            this.SaleDetails_TotalAmount.ReadOnly = true;
            // 
            // ChallanListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(942, 471);
            this.Controls.Add(this.dgvChallanList);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChallanListForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Challan List";
            this.Load += new System.EventHandler(this.ProductListForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChallanList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.DataGridView dgvChallanList;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DateTimePicker dtpfrom;
        private System.Windows.Forms.DateTimePicker dtpto;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleChallanNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleMaster_SaleDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleDetails_TotalQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleDetails_Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleDetails_TotalAmount;

    }
}