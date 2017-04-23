namespace IMS_Win
{
    partial class SalesStockListForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesStockListForm));
            this.dgvSalesStock = new System.Windows.Forms.DataGridView();
            this.ProductCategory_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleInventory_TotalQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleInventory_ReceiveQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleInventory_ReturnQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleInventory_DamageQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesStock)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSalesStock
            // 
            this.dgvSalesStock.AllowUserToAddRows = false;
            this.dgvSalesStock.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(234)))), ((int)(((byte)(248)))));
            this.dgvSalesStock.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSalesStock.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dgvSalesStock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSalesStock.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(116)))), ((int)(((byte)(165)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalesStock.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSalesStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductCategory_Name,
            this.Product_Code,
            this.Product_Name,
            this.SaleInventory_TotalQuantity,
            this.SaleInventory_ReceiveQuantity,
            this.SaleInventory_ReturnQuantity,
            this.SaleInventory_DamageQuantity,
            this.Unit_Name});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSalesStock.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSalesStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSalesStock.EnableHeadersVisualStyles = false;
            this.dgvSalesStock.GridColor = System.Drawing.Color.Azure;
            this.dgvSalesStock.Location = new System.Drawing.Point(0, 0);
            this.dgvSalesStock.Name = "dgvSalesStock";
            this.dgvSalesStock.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(227)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalesStock.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSalesStock.RowHeadersWidth = 20;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(227)))), ((int)(((byte)(249)))));
            this.dgvSalesStock.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvSalesStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSalesStock.Size = new System.Drawing.Size(833, 472);
            this.dgvSalesStock.TabIndex = 32;
            // 
            // ProductCategory_Name
            // 
            this.ProductCategory_Name.DataPropertyName = "ProductCategory_Name";
            this.ProductCategory_Name.HeaderText = "Category";
            this.ProductCategory_Name.Name = "ProductCategory_Name";
            this.ProductCategory_Name.ReadOnly = true;
            // 
            // Product_Code
            // 
            this.Product_Code.DataPropertyName = "Product_Code";
            this.Product_Code.HeaderText = "ID";
            this.Product_Code.Name = "Product_Code";
            this.Product_Code.ReadOnly = true;
            // 
            // Product_Name
            // 
            this.Product_Name.DataPropertyName = "Product_Name";
            this.Product_Name.HeaderText = "Product Name";
            this.Product_Name.Name = "Product_Name";
            this.Product_Name.ReadOnly = true;
            this.Product_Name.Width = 200;
            // 
            // SaleInventory_TotalQuantity
            // 
            this.SaleInventory_TotalQuantity.DataPropertyName = "SaleInventory_TotalQuantity";
            this.SaleInventory_TotalQuantity.HeaderText = "Sales Qty";
            this.SaleInventory_TotalQuantity.Name = "SaleInventory_TotalQuantity";
            this.SaleInventory_TotalQuantity.ReadOnly = true;
            // 
            // SaleInventory_ReceiveQuantity
            // 
            this.SaleInventory_ReceiveQuantity.DataPropertyName = "SaleInventory_ReceiveQuantity";
            this.SaleInventory_ReceiveQuantity.HeaderText = "Receive Qty";
            this.SaleInventory_ReceiveQuantity.Name = "SaleInventory_ReceiveQuantity";
            this.SaleInventory_ReceiveQuantity.ReadOnly = true;
            this.SaleInventory_ReceiveQuantity.Visible = false;
            this.SaleInventory_ReceiveQuantity.Width = 120;
            // 
            // SaleInventory_ReturnQuantity
            // 
            this.SaleInventory_ReturnQuantity.DataPropertyName = "SaleInventory_ReturnQuantity";
            this.SaleInventory_ReturnQuantity.HeaderText = "Return Qty";
            this.SaleInventory_ReturnQuantity.Name = "SaleInventory_ReturnQuantity";
            this.SaleInventory_ReturnQuantity.ReadOnly = true;
            this.SaleInventory_ReturnQuantity.Width = 110;
            // 
            // SaleInventory_DamageQuantity
            // 
            this.SaleInventory_DamageQuantity.DataPropertyName = "SaleInventory_DamageQuantity";
            this.SaleInventory_DamageQuantity.HeaderText = "Damage Qty";
            this.SaleInventory_DamageQuantity.Name = "SaleInventory_DamageQuantity";
            this.SaleInventory_DamageQuantity.ReadOnly = true;
            this.SaleInventory_DamageQuantity.Width = 120;
            // 
            // Unit_Name
            // 
            this.Unit_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Unit_Name.DataPropertyName = "Unit_Name";
            this.Unit_Name.HeaderText = "Unit";
            this.Unit_Name.Name = "Unit_Name";
            this.Unit_Name.ReadOnly = true;
            // 
            // SalesStockListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 472);
            this.Controls.Add(this.dgvSalesStock);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SalesStockListForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Stock List";
            this.Load += new System.EventHandler(this.SalesStockListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesStock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSalesStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductCategory_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleInventory_TotalQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleInventory_ReceiveQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleInventory_ReturnQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleInventory_DamageQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit_Name;
    }
}