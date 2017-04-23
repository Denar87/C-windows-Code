namespace IMS_Win
{
    partial class ProfitLossBySalesForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfitLossBySalesForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnview = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.btnReport = new System.Windows.Forms.Button();
            this.dgvProfitLossBySale = new System.Windows.Forms.DataGridView();
            this.lblProfitLoss = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblTotalSale = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SaleMaster_SlNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleMaster_InvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleDetails_TotalQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Purchase_Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPurchaseAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleDetails_TotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmProfitLoss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfitLossBySale)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::IMS_Win.Properties.Resources.back;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.btnview);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpStart);
            this.panel1.Controls.Add(this.dtpEnd);
            this.panel1.Controls.Add(this.btnReport);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(868, 37);
            this.panel1.TabIndex = 40;
            // 
            // btnview
            // 
            this.btnview.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnview.Location = new System.Drawing.Point(689, 5);
            this.btnview.Name = "btnview";
            this.btnview.Size = new System.Drawing.Size(69, 28);
            this.btnview.TabIndex = 9;
            this.btnview.Text = "&View";
            this.btnview.UseVisualStyleBackColor = true;
            this.btnview.Click += new System.EventHandler(this.btnview_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(145, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "to";
            // 
            // dtpStart
            // 
            this.dtpStart.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(39, 7);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(102, 23);
            this.dtpStart.TabIndex = 5;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(167, 7);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(102, 23);
            this.dtpEnd.TabIndex = 6;
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Location = new System.Drawing.Point(766, 5);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(94, 28);
            this.btnReport.TabIndex = 0;
            this.btnReport.Text = "&Show Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // dgvProfitLossBySale
            // 
            this.dgvProfitLossBySale.AllowUserToAddRows = false;
            this.dgvProfitLossBySale.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(234)))), ((int)(((byte)(248)))));
            this.dgvProfitLossBySale.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProfitLossBySale.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dgvProfitLossBySale.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProfitLossBySale.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvProfitLossBySale.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(116)))), ((int)(((byte)(165)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProfitLossBySale.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProfitLossBySale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProfitLossBySale.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SaleMaster_SlNo,
            this.SaleMaster_InvoiceNo,
            this.Product_Code,
            this.Product_Name,
            this.SaleDetails_TotalQuantity,
            this.Unit_Name,
            this.Purchase_Rate,
            this.clmPurchaseAmount,
            this.SaleDetails_TotalAmount,
            this.clmProfitLoss});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProfitLossBySale.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvProfitLossBySale.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvProfitLossBySale.EnableHeadersVisualStyles = false;
            this.dgvProfitLossBySale.GridColor = System.Drawing.Color.Azure;
            this.dgvProfitLossBySale.Location = new System.Drawing.Point(0, 37);
            this.dgvProfitLossBySale.Name = "dgvProfitLossBySale";
            this.dgvProfitLossBySale.ReadOnly = true;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(227)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProfitLossBySale.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvProfitLossBySale.RowHeadersVisible = false;
            this.dgvProfitLossBySale.RowHeadersWidth = 20;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(227)))), ((int)(((byte)(249)))));
            this.dgvProfitLossBySale.RowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvProfitLossBySale.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProfitLossBySale.Size = new System.Drawing.Size(868, 420);
            this.dgvProfitLossBySale.TabIndex = 132;
            // 
            // lblProfitLoss
            // 
            this.lblProfitLoss.BackColor = System.Drawing.Color.Transparent;
            this.lblProfitLoss.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProfitLoss.ForeColor = System.Drawing.Color.Maroon;
            this.lblProfitLoss.Location = new System.Drawing.Point(784, 464);
            this.lblProfitLoss.Name = "lblProfitLoss";
            this.lblProfitLoss.Size = new System.Drawing.Size(82, 18);
            this.lblProfitLoss.TabIndex = 150;
            this.lblProfitLoss.Text = "0";
            this.lblProfitLoss.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(685, 465);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(100, 18);
            this.label18.TabIndex = 149;
            this.label18.Text = "Net Profit/Loss";
            // 
            // lblTotalSale
            // 
            this.lblTotalSale.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalSale.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSale.ForeColor = System.Drawing.Color.Navy;
            this.lblTotalSale.Location = new System.Drawing.Point(583, 465);
            this.lblTotalSale.Name = "lblTotalSale";
            this.lblTotalSale.Size = new System.Drawing.Size(82, 18);
            this.lblTotalSale.TabIndex = 152;
            this.lblTotalSale.Text = "0";
            this.lblTotalSale.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(517, 465);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 18);
            this.label4.TabIndex = 151;
            this.label4.Text = "Total Sale";
            // 
            // SaleMaster_SlNo
            // 
            this.SaleMaster_SlNo.DataPropertyName = "SaleMaster_SlNo";
            this.SaleMaster_SlNo.HeaderText = "SaleMaster_SlNo";
            this.SaleMaster_SlNo.Name = "SaleMaster_SlNo";
            this.SaleMaster_SlNo.ReadOnly = true;
            this.SaleMaster_SlNo.Visible = false;
            // 
            // SaleMaster_InvoiceNo
            // 
            this.SaleMaster_InvoiceNo.DataPropertyName = "SaleMaster_InvoiceNo";
            this.SaleMaster_InvoiceNo.HeaderText = "Invoice No.";
            this.SaleMaster_InvoiceNo.Name = "SaleMaster_InvoiceNo";
            this.SaleMaster_InvoiceNo.ReadOnly = true;
            this.SaleMaster_InvoiceNo.Width = 103;
            // 
            // Product_Code
            // 
            this.Product_Code.DataPropertyName = "Product_Code";
            this.Product_Code.HeaderText = "Product ID";
            this.Product_Code.Name = "Product_Code";
            this.Product_Code.ReadOnly = true;
            this.Product_Code.Width = 70;
            // 
            // Product_Name
            // 
            this.Product_Name.DataPropertyName = "Product_Name";
            this.Product_Name.HeaderText = "Product Name";
            this.Product_Name.Name = "Product_Name";
            this.Product_Name.ReadOnly = true;
            this.Product_Name.Width = 160;
            // 
            // SaleDetails_TotalQuantity
            // 
            this.SaleDetails_TotalQuantity.DataPropertyName = "SaleDetails_TotalQuantity";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.SaleDetails_TotalQuantity.DefaultCellStyle = dataGridViewCellStyle3;
            this.SaleDetails_TotalQuantity.HeaderText = "Quantity";
            this.SaleDetails_TotalQuantity.Name = "SaleDetails_TotalQuantity";
            this.SaleDetails_TotalQuantity.ReadOnly = true;
            this.SaleDetails_TotalQuantity.ToolTipText = "Total Purchased Quantity";
            this.SaleDetails_TotalQuantity.Width = 60;
            // 
            // Unit_Name
            // 
            this.Unit_Name.DataPropertyName = "Unit_Name";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Unit_Name.DefaultCellStyle = dataGridViewCellStyle4;
            this.Unit_Name.HeaderText = "Unit";
            this.Unit_Name.Name = "Unit_Name";
            this.Unit_Name.ReadOnly = true;
            this.Unit_Name.Width = 50;
            // 
            // Purchase_Rate
            // 
            this.Purchase_Rate.DataPropertyName = "Purchase_Rate";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.Purchase_Rate.DefaultCellStyle = dataGridViewCellStyle5;
            this.Purchase_Rate.HeaderText = "Purchase Rate";
            this.Purchase_Rate.Name = "Purchase_Rate";
            this.Purchase_Rate.ReadOnly = true;
            this.Purchase_Rate.Width = 110;
            // 
            // clmPurchaseAmount
            // 
            this.clmPurchaseAmount.DataPropertyName = "clmPurchaseAmount";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.clmPurchaseAmount.DefaultCellStyle = dataGridViewCellStyle6;
            this.clmPurchaseAmount.HeaderText = "Purchase Amount";
            this.clmPurchaseAmount.Name = "clmPurchaseAmount";
            this.clmPurchaseAmount.ReadOnly = true;
            this.clmPurchaseAmount.Width = 130;
            // 
            // SaleDetails_TotalAmount
            // 
            this.SaleDetails_TotalAmount.DataPropertyName = "SaleDetails_TotalAmount";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.SaleDetails_TotalAmount.DefaultCellStyle = dataGridViewCellStyle7;
            this.SaleDetails_TotalAmount.HeaderText = "Sale Amount";
            this.SaleDetails_TotalAmount.Name = "SaleDetails_TotalAmount";
            this.SaleDetails_TotalAmount.ReadOnly = true;
            // 
            // clmProfitLoss
            // 
            this.clmProfitLoss.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmProfitLoss.DataPropertyName = "clmProfitLoss";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.clmProfitLoss.DefaultCellStyle = dataGridViewCellStyle8;
            this.clmProfitLoss.HeaderText = "Profit/Loss";
            this.clmProfitLoss.Name = "clmProfitLoss";
            this.clmProfitLoss.ReadOnly = true;
            // 
            // ProfitLossBySalesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::IMS_Win.Properties.Resources.back;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(868, 490);
            this.Controls.Add(this.lblTotalSale);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblProfitLoss);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.dgvProfitLossBySale);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProfitLossBySalesForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Profit / Loss";
            this.Load += new System.EventHandler(this.ProfitLossBySalesForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfitLossBySale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Button btnview;
        private System.Windows.Forms.DataGridView dgvProfitLossBySale;
        private System.Windows.Forms.Label lblProfitLoss;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblTotalSale;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleMaster_SlNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleMaster_InvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleDetails_TotalQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Purchase_Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPurchaseAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleDetails_TotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmProfitLoss;

    }
}