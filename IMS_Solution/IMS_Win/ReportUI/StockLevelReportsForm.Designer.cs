namespace IMS_Win
{
    partial class StockLevelReportsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockLevelReportsForm));
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            this.btnView = new System.Windows.Forms.Button();
            this.cmbStockType = new System.Windows.Forms.ComboBox();
            this.btnReport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblstockamount = new System.Windows.Forms.Label();
            this.dgvTotalStock = new System.Windows.Forms.DataGridView();
            this.clmTotal_Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmProduct_Purchase_Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmUnit_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm_CurrentQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCurrentInventory_CurrentQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSaleInventory_ReturnQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSaleInventory_TotalQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPurchaseInventory_DamageQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPurchaseInventory_ReturnQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPurchaseInventory_TotalQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmProduct_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmProduct_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmProductCategory_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalStock)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbProduct
            // 
            this.cmbProduct.BackColor = System.Drawing.Color.MintCream;
            this.cmbProduct.FormattingEnabled = true;
            this.cmbProduct.Location = new System.Drawing.Point(300, 12);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new System.Drawing.Size(239, 23);
            this.cmbProduct.TabIndex = 1;
            this.cmbProduct.Visible = false;
            this.cmbProduct.SelectedIndexChanged += new System.EventHandler(this.cmbProduct_SelectedIndexChanged);
            this.cmbProduct.Click += new System.EventHandler(this.cmbProduct_Click);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(638, 10);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(81, 28);
            this.btnView.TabIndex = 2;
            this.btnView.Text = "&View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // cmbStockType
            // 
            this.cmbStockType.AutoCompleteCustomSource.AddRange(new string[] {
            "Purchase Stock",
            "Sales Stock",
            "Current Stock"});
            this.cmbStockType.BackColor = System.Drawing.Color.MintCream;
            this.cmbStockType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStockType.FormattingEnabled = true;
            this.cmbStockType.Items.AddRange(new object[] {
            "Total Stock",
            "Current Stock",
            "Categorywise Stock",
            "Productwise Stock"});
            this.cmbStockType.Location = new System.Drawing.Point(72, 12);
            this.cmbStockType.Name = "cmbStockType";
            this.cmbStockType.Size = new System.Drawing.Size(213, 23);
            this.cmbStockType.TabIndex = 0;
            this.cmbStockType.SelectedIndexChanged += new System.EventHandler(this.cmbStockType_SelectedIndexChanged);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(728, 10);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(94, 28);
            this.btnReport.TabIndex = 3;
            this.btnReport.Text = "&Show Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(5, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stock Type";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Ivory;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.txtTotal);
            this.panel2.Controls.Add(this.lblstockamount);
            this.panel2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(530, 476);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(299, 23);
            this.panel2.TabIndex = 100030;
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotal.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTotal.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtTotal.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(133, 0);
            this.txtTotal.Multiline = true;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(162, 19);
            this.txtTotal.TabIndex = 32;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblstockamount
            // 
            this.lblstockamount.AutoSize = true;
            this.lblstockamount.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblstockamount.Location = new System.Drawing.Point(15, 2);
            this.lblstockamount.Name = "lblstockamount";
            this.lblstockamount.Size = new System.Drawing.Size(113, 15);
            this.lblstockamount.TabIndex = 6;
            this.lblstockamount.Text = "Total Stock Amount";
            // 
            // dgvTotalStock
            // 
            this.dgvTotalStock.AllowUserToAddRows = false;
            this.dgvTotalStock.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(234)))), ((int)(((byte)(248)))));
            this.dgvTotalStock.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTotalStock.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dgvTotalStock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTotalStock.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvTotalStock.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(116)))), ((int)(((byte)(165)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTotalStock.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTotalStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTotalStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmProductCategory_Name,
            this.clmProduct_Code,
            this.clmProduct_Name,
            this.clmPurchaseInventory_TotalQuantity,
            this.clmPurchaseInventory_ReturnQuantity,
            this.clmPurchaseInventory_DamageQuantity,
            this.clmSaleInventory_TotalQuantity,
            this.clmSaleInventory_ReturnQuantity,
            this.clmCurrentInventory_CurrentQuantity,
            this.clm_CurrentQuantity,
            this.clmUnit_Name,
            this.clmProduct_Purchase_Rate,
            this.clmTotal_Amount});
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTotalStock.DefaultCellStyle = dataGridViewCellStyle16;
            this.dgvTotalStock.EnableHeadersVisualStyles = false;
            this.dgvTotalStock.GridColor = System.Drawing.Color.Azure;
            this.dgvTotalStock.Location = new System.Drawing.Point(0, 49);
            this.dgvTotalStock.Name = "dgvTotalStock";
            this.dgvTotalStock.ReadOnly = true;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(227)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTotalStock.RowHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dgvTotalStock.RowHeadersVisible = false;
            this.dgvTotalStock.RowHeadersWidth = 20;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(227)))), ((int)(((byte)(249)))));
            this.dgvTotalStock.RowsDefaultCellStyle = dataGridViewCellStyle18;
            this.dgvTotalStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTotalStock.Size = new System.Drawing.Size(830, 420);
            this.dgvTotalStock.TabIndex = 0;
            // 
            // clmTotal_Amount
            // 
            this.clmTotal_Amount.DataPropertyName = "price";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.Format = "N2";
            dataGridViewCellStyle15.NullValue = null;
            this.clmTotal_Amount.DefaultCellStyle = dataGridViewCellStyle15;
            this.clmTotal_Amount.HeaderText = "Total Amount";
            this.clmTotal_Amount.Name = "clmTotal_Amount";
            this.clmTotal_Amount.ReadOnly = true;
            this.clmTotal_Amount.Width = 150;
            // 
            // clmProduct_Purchase_Rate
            // 
            this.clmProduct_Purchase_Rate.DataPropertyName = "Product_Purchase_Rate";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "N2";
            dataGridViewCellStyle14.NullValue = null;
            this.clmProduct_Purchase_Rate.DefaultCellStyle = dataGridViewCellStyle14;
            this.clmProduct_Purchase_Rate.HeaderText = "Purchase Rate";
            this.clmProduct_Purchase_Rate.Name = "clmProduct_Purchase_Rate";
            this.clmProduct_Purchase_Rate.ReadOnly = true;
            this.clmProduct_Purchase_Rate.Width = 110;
            // 
            // clmUnit_Name
            // 
            this.clmUnit_Name.DataPropertyName = "Unit_Name";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmUnit_Name.DefaultCellStyle = dataGridViewCellStyle13;
            this.clmUnit_Name.HeaderText = "Unit";
            this.clmUnit_Name.Name = "clmUnit_Name";
            this.clmUnit_Name.ReadOnly = true;
            this.clmUnit_Name.Width = 63;
            // 
            // clm_CurrentQuantity
            // 
            this.clm_CurrentQuantity.DataPropertyName = "CurrentInventory_CurrentQuantity";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clm_CurrentQuantity.DefaultCellStyle = dataGridViewCellStyle12;
            this.clm_CurrentQuantity.HeaderText = "Current Qty";
            this.clm_CurrentQuantity.Name = "clm_CurrentQuantity";
            this.clm_CurrentQuantity.ReadOnly = true;
            // 
            // clmCurrentInventory_CurrentQuantity
            // 
            this.clmCurrentInventory_CurrentQuantity.DataPropertyName = "CurrentInventory";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clmCurrentInventory_CurrentQuantity.DefaultCellStyle = dataGridViewCellStyle11;
            this.clmCurrentInventory_CurrentQuantity.HeaderText = "Current Qty";
            this.clmCurrentInventory_CurrentQuantity.Name = "clmCurrentInventory_CurrentQuantity";
            this.clmCurrentInventory_CurrentQuantity.ReadOnly = true;
            // 
            // clmSaleInventory_ReturnQuantity
            // 
            this.clmSaleInventory_ReturnQuantity.DataPropertyName = "SaleInventory_ReturnQuantity";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmSaleInventory_ReturnQuantity.DefaultCellStyle = dataGridViewCellStyle10;
            this.clmSaleInventory_ReturnQuantity.HeaderText = "Sales Return Qty";
            this.clmSaleInventory_ReturnQuantity.Name = "clmSaleInventory_ReturnQuantity";
            this.clmSaleInventory_ReturnQuantity.ReadOnly = true;
            this.clmSaleInventory_ReturnQuantity.Width = 95;
            // 
            // clmSaleInventory_TotalQuantity
            // 
            this.clmSaleInventory_TotalQuantity.DataPropertyName = "SaleInventory_TotalQuantity";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmSaleInventory_TotalQuantity.DefaultCellStyle = dataGridViewCellStyle9;
            this.clmSaleInventory_TotalQuantity.HeaderText = "Sales Qty";
            this.clmSaleInventory_TotalQuantity.Name = "clmSaleInventory_TotalQuantity";
            this.clmSaleInventory_TotalQuantity.ReadOnly = true;
            this.clmSaleInventory_TotalQuantity.Width = 60;
            // 
            // clmPurchaseInventory_DamageQuantity
            // 
            this.clmPurchaseInventory_DamageQuantity.DataPropertyName = "PurchaseInventory_DamageQuantity";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmPurchaseInventory_DamageQuantity.DefaultCellStyle = dataGridViewCellStyle8;
            this.clmPurchaseInventory_DamageQuantity.HeaderText = "Damage Qty";
            this.clmPurchaseInventory_DamageQuantity.Name = "clmPurchaseInventory_DamageQuantity";
            this.clmPurchaseInventory_DamageQuantity.ReadOnly = true;
            this.clmPurchaseInventory_DamageQuantity.Width = 60;
            // 
            // clmPurchaseInventory_ReturnQuantity
            // 
            this.clmPurchaseInventory_ReturnQuantity.DataPropertyName = "PurchaseInventory_ReturnQuantity";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmPurchaseInventory_ReturnQuantity.DefaultCellStyle = dataGridViewCellStyle7;
            this.clmPurchaseInventory_ReturnQuantity.HeaderText = "Purchase Return Qty";
            this.clmPurchaseInventory_ReturnQuantity.Name = "clmPurchaseInventory_ReturnQuantity";
            this.clmPurchaseInventory_ReturnQuantity.ReadOnly = true;
            this.clmPurchaseInventory_ReturnQuantity.Width = 95;
            // 
            // clmPurchaseInventory_TotalQuantity
            // 
            this.clmPurchaseInventory_TotalQuantity.DataPropertyName = "PurchaseInventory_TotalQuantity";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmPurchaseInventory_TotalQuantity.DefaultCellStyle = dataGridViewCellStyle6;
            this.clmPurchaseInventory_TotalQuantity.HeaderText = "Purchase Qty";
            this.clmPurchaseInventory_TotalQuantity.Name = "clmPurchaseInventory_TotalQuantity";
            this.clmPurchaseInventory_TotalQuantity.ReadOnly = true;
            this.clmPurchaseInventory_TotalQuantity.Width = 70;
            // 
            // clmProduct_Name
            // 
            this.clmProduct_Name.DataPropertyName = "Product_Name";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.clmProduct_Name.DefaultCellStyle = dataGridViewCellStyle5;
            this.clmProduct_Name.HeaderText = "Name";
            this.clmProduct_Name.Name = "clmProduct_Name";
            this.clmProduct_Name.ReadOnly = true;
            this.clmProduct_Name.Width = 200;
            // 
            // clmProduct_Code
            // 
            this.clmProduct_Code.DataPropertyName = "Product_Code";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmProduct_Code.DefaultCellStyle = dataGridViewCellStyle4;
            this.clmProduct_Code.HeaderText = "ID";
            this.clmProduct_Code.Name = "clmProduct_Code";
            this.clmProduct_Code.ReadOnly = true;
            this.clmProduct_Code.Width = 50;
            // 
            // clmProductCategory_Name
            // 
            this.clmProductCategory_Name.DataPropertyName = "ProductCategory_Name";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.clmProductCategory_Name.DefaultCellStyle = dataGridViewCellStyle3;
            this.clmProductCategory_Name.HeaderText = "Category";
            this.clmProductCategory_Name.Name = "clmProductCategory_Name";
            this.clmProductCategory_Name.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::IMS_Win.Properties.Resources.back;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.cmbProduct);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnReport);
            this.panel1.Controls.Add(this.btnView);
            this.panel1.Controls.Add(this.cmbStockType);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(830, 49);
            this.panel1.TabIndex = 100031;
            // 
            // StockLevelReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::IMS_Win.Properties.Resources.back;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(830, 506);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvTotalStock);
            this.Controls.Add(this.panel2);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StockLevelReportsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Reports";
            this.Load += new System.EventHandler(this.StockLevelReportsForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalStock)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbStockType;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbProduct;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label lblstockamount;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvTotalStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmProductCategory_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmProduct_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmProduct_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPurchaseInventory_TotalQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPurchaseInventory_ReturnQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPurchaseInventory_DamageQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSaleInventory_TotalQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSaleInventory_ReturnQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCurrentInventory_CurrentQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm_CurrentQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUnit_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmProduct_Purchase_Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTotal_Amount;
        private System.Windows.Forms.Panel panel1;
    }
}