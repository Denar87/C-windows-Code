namespace IMS_Win
{
    partial class PurchaseStockListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PurchaseStockListForm));
            this.dgvPurchaseStock = new System.Windows.Forms.DataGridView();
            this.ProductCategory_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchaseInventory_TotalQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchaseInventory_ReceiveQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchaseInventory_ReturnQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchaseInventory_DamageQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseStock)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPurchaseStock
            // 
            this.dgvPurchaseStock.AllowUserToAddRows = false;
            this.dgvPurchaseStock.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(234)))), ((int)(((byte)(248)))));
            this.dgvPurchaseStock.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPurchaseStock.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dgvPurchaseStock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPurchaseStock.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvPurchaseStock.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(116)))), ((int)(((byte)(165)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPurchaseStock.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPurchaseStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurchaseStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductCategory_Name,
            this.Product_Code,
            this.Product_Name,
            this.PurchaseInventory_TotalQuantity,
            this.PurchaseInventory_ReceiveQuantity,
            this.PurchaseInventory_ReturnQuantity,
            this.PurchaseInventory_DamageQuantity,
            this.Unit_Name});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPurchaseStock.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPurchaseStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPurchaseStock.EnableHeadersVisualStyles = false;
            this.dgvPurchaseStock.GridColor = System.Drawing.Color.Azure;
            this.dgvPurchaseStock.Location = new System.Drawing.Point(0, 0);
            this.dgvPurchaseStock.Name = "dgvPurchaseStock";
            this.dgvPurchaseStock.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(227)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPurchaseStock.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPurchaseStock.RowHeadersWidth = 20;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(227)))), ((int)(((byte)(249)))));
            this.dgvPurchaseStock.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPurchaseStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPurchaseStock.Size = new System.Drawing.Size(789, 474);
            this.dgvPurchaseStock.TabIndex = 30;
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
            this.Product_Name.Width = 180;
            // 
            // PurchaseInventory_TotalQuantity
            // 
            this.PurchaseInventory_TotalQuantity.DataPropertyName = "PurchaseInventory_TotalQuantity";
            this.PurchaseInventory_TotalQuantity.HeaderText = "Purchase Qty";
            this.PurchaseInventory_TotalQuantity.Name = "PurchaseInventory_TotalQuantity";
            this.PurchaseInventory_TotalQuantity.ReadOnly = true;
            this.PurchaseInventory_TotalQuantity.Width = 120;
            // 
            // PurchaseInventory_ReceiveQuantity
            // 
            this.PurchaseInventory_ReceiveQuantity.DataPropertyName = "PurchaseInventory_ReceiveQuantity";
            this.PurchaseInventory_ReceiveQuantity.HeaderText = "Receive Qty";
            this.PurchaseInventory_ReceiveQuantity.Name = "PurchaseInventory_ReceiveQuantity";
            this.PurchaseInventory_ReceiveQuantity.ReadOnly = true;
            this.PurchaseInventory_ReceiveQuantity.Visible = false;
            // 
            // PurchaseInventory_ReturnQuantity
            // 
            this.PurchaseInventory_ReturnQuantity.DataPropertyName = "PurchaseInventory_ReturnQuantity";
            this.PurchaseInventory_ReturnQuantity.HeaderText = "Return Qty";
            this.PurchaseInventory_ReturnQuantity.Name = "PurchaseInventory_ReturnQuantity";
            this.PurchaseInventory_ReturnQuantity.ReadOnly = true;
            this.PurchaseInventory_ReturnQuantity.Width = 90;
            // 
            // PurchaseInventory_DamageQuantity
            // 
            this.PurchaseInventory_DamageQuantity.DataPropertyName = "PurchaseInventory_DamageQuantity";
            this.PurchaseInventory_DamageQuantity.HeaderText = "Damage Qty";
            this.PurchaseInventory_DamageQuantity.Name = "PurchaseInventory_DamageQuantity";
            this.PurchaseInventory_DamageQuantity.ReadOnly = true;
            // 
            // Unit_Name
            // 
            this.Unit_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Unit_Name.DataPropertyName = "Unit_Name";
            this.Unit_Name.HeaderText = "Unit";
            this.Unit_Name.Name = "Unit_Name";
            this.Unit_Name.ReadOnly = true;
            // 
            // PurchaseStockListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 474);
            this.Controls.Add(this.dgvPurchaseStock);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PurchaseStockListForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purchase Stock List";
            this.Load += new System.EventHandler(this.PurchaseStockListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseStock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPurchaseStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductCategory_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaseInventory_TotalQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaseInventory_ReceiveQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaseInventory_ReturnQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaseInventory_DamageQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit_Name;

    }
}