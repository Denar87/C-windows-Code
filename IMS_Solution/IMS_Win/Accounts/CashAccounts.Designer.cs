namespace IMS_Win
{
    partial class CashAccounts
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CashAccounts));
            this.cmbTrType = new System.Windows.Forms.ComboBox();
            this.cmbAccType = new System.Windows.Forms.ComboBox();
            this.txtTrID = new System.Windows.Forms.TextBox();
            this.txtAccID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.dgvCashAccount = new System.Windows.Forms.DataGridView();
            this.Tr_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tr_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tr_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tr_Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.In_Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Out_Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rectangleShape2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lblDue = new System.Windows.Forms.Label();
            this.groupboxDue = new System.Windows.Forms.GroupBox();
            this.txtAccName = new System.Windows.Forms.TextBox();
            this.AccountListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddAccount = new System.Windows.Forms.Button();
            this.cmsCashTransaction = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashAccount)).BeginInit();
            this.groupboxDue.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbTrType
            // 
            this.cmbTrType.BackColor = System.Drawing.Color.MintCream;
            this.cmbTrType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrType.FormattingEnabled = true;
            this.cmbTrType.Items.AddRange(new object[] {
            "Cash Receive",
            "Cash Payment",
            "Deposit To Bank",
            "Withdraw from Bank"});
            this.cmbTrType.Location = new System.Drawing.Point(99, 36);
            this.cmbTrType.Name = "cmbTrType";
            this.cmbTrType.Size = new System.Drawing.Size(172, 23);
            this.cmbTrType.TabIndex = 0;
            this.cmbTrType.SelectedIndexChanged += new System.EventHandler(this.cmbTrType_SelectedIndexChanged);
            // 
            // cmbAccType
            // 
            this.cmbAccType.BackColor = System.Drawing.Color.MintCream;
            this.cmbAccType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccType.FormattingEnabled = true;
            this.cmbAccType.Items.AddRange(new object[] {
            "Customer",
            "Official",
            "Supplier"});
            this.cmbAccType.Location = new System.Drawing.Point(99, 61);
            this.cmbAccType.Name = "cmbAccType";
            this.cmbAccType.Size = new System.Drawing.Size(172, 23);
            this.cmbAccType.TabIndex = 1;
            this.cmbAccType.SelectedIndexChanged += new System.EventHandler(this.cmbAccType_SelectedIndexChanged);
            // 
            // txtTrID
            // 
            this.txtTrID.Cursor = System.Windows.Forms.Cursors.No;
            this.txtTrID.Enabled = false;
            this.txtTrID.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrID.Location = new System.Drawing.Point(99, 11);
            this.txtTrID.Name = "txtTrID";
            this.txtTrID.ReadOnly = true;
            this.txtTrID.Size = new System.Drawing.Size(172, 23);
            this.txtTrID.TabIndex = 5;
            // 
            // txtAccID
            // 
            this.txtAccID.BackColor = System.Drawing.Color.MintCream;
            this.txtAccID.Location = new System.Drawing.Point(99, 86);
            this.txtAccID.Name = "txtAccID";
            this.txtAccID.Size = new System.Drawing.Size(146, 23);
            this.txtAccID.TabIndex = 2;
            this.txtAccID.Click += new System.EventHandler(this.txtAccID_Click);
            this.txtAccID.TextChanged += new System.EventHandler(this.txtAccID_TextChanged);
            this.txtAccID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAccID_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Transaction ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(10, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Tr Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(10, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Account Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(10, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Account Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(410, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(394, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Amount";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(10, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "Account ID";
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.Color.MintCream;
            this.txtAmount.Location = new System.Drawing.Point(446, 110);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(171, 23);
            this.txtAmount.TabIndex = 6;
            this.txtAmount.Text = "0";
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(541, 136);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(76, 28);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(373, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 15);
            this.label9.TabIndex = 19;
            this.label9.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.MintCream;
            this.txtDescription.Location = new System.Drawing.Point(446, 87);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(171, 21);
            this.txtDescription.TabIndex = 5;
            // 
            // dtpDate
            // 
            this.dtpDate.CalendarMonthBackground = System.Drawing.Color.MintCream;
            this.dtpDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(445, 11);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(172, 23);
            this.dtpDate.TabIndex = 4;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // dgvCashAccount
            // 
            this.dgvCashAccount.AllowUserToAddRows = false;
            this.dgvCashAccount.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(234)))), ((int)(((byte)(248)))));
            this.dgvCashAccount.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCashAccount.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dgvCashAccount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCashAccount.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvCashAccount.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(116)))), ((int)(((byte)(165)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCashAccount.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCashAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCashAccount.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tr_Id,
            this.Tr_date,
            this.Tr_Type,
            this.Tr_Description,
            this.In_Amount,
            this.Out_Amount});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCashAccount.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCashAccount.EnableHeadersVisualStyles = false;
            this.dgvCashAccount.GridColor = System.Drawing.Color.Azure;
            this.dgvCashAccount.Location = new System.Drawing.Point(3, 172);
            this.dgvCashAccount.Name = "dgvCashAccount";
            this.dgvCashAccount.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(227)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCashAccount.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCashAccount.RowHeadersWidth = 20;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(227)))), ((int)(((byte)(249)))));
            this.dgvCashAccount.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvCashAccount.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCashAccount.Size = new System.Drawing.Size(623, 215);
            this.dgvCashAccount.TabIndex = 175;
            this.dgvCashAccount.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCashAccount_CellClick);
            this.dgvCashAccount.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvCashAccount_MouseDown);
            // 
            // Tr_Id
            // 
            this.Tr_Id.DataPropertyName = "Tr_Id";
            this.Tr_Id.HeaderText = "Tr Id";
            this.Tr_Id.Name = "Tr_Id";
            this.Tr_Id.ReadOnly = true;
            this.Tr_Id.Width = 80;
            // 
            // Tr_date
            // 
            this.Tr_date.DataPropertyName = "Tr_date";
            this.Tr_date.HeaderText = "Date";
            this.Tr_date.Name = "Tr_date";
            this.Tr_date.ReadOnly = true;
            this.Tr_date.Width = 90;
            // 
            // Tr_Type
            // 
            this.Tr_Type.DataPropertyName = "Tr_Type";
            this.Tr_Type.HeaderText = "Tr. Type";
            this.Tr_Type.Name = "Tr_Type";
            this.Tr_Type.ReadOnly = true;
            // 
            // Tr_Description
            // 
            this.Tr_Description.DataPropertyName = "Tr_Description";
            this.Tr_Description.HeaderText = "Description";
            this.Tr_Description.Name = "Tr_Description";
            this.Tr_Description.ReadOnly = true;
            this.Tr_Description.Width = 125;
            // 
            // In_Amount
            // 
            this.In_Amount.DataPropertyName = "In_Amount";
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.In_Amount.DefaultCellStyle = dataGridViewCellStyle3;
            this.In_Amount.HeaderText = "In Amount";
            this.In_Amount.Name = "In_Amount";
            this.In_Amount.ReadOnly = true;
            this.In_Amount.Width = 102;
            // 
            // Out_Amount
            // 
            this.Out_Amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Out_Amount.DataPropertyName = "Out_Amount";
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.Out_Amount.DefaultCellStyle = dataGridViewCellStyle4;
            this.Out_Amount.HeaderText = "Out Amount";
            this.Out_Amount.Name = "Out_Amount";
            this.Out_Amount.ReadOnly = true;
            // 
            // rectangleShape2
            // 
            this.rectangleShape2.BackColor = System.Drawing.Color.Transparent;
            this.rectangleShape2.BorderColor = System.Drawing.Color.LightGray;
            this.rectangleShape2.Location = new System.Drawing.Point(4, 6);
            this.rectangleShape2.Name = "rectangleShape2";
            this.rectangleShape2.Size = new System.Drawing.Size(621, 162);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape2});
            this.shapeContainer1.Size = new System.Drawing.Size(630, 390);
            this.shapeContainer1.TabIndex = 176;
            this.shapeContainer1.TabStop = false;
            // 
            // lblDue
            // 
            this.lblDue.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDue.ForeColor = System.Drawing.Color.Teal;
            this.lblDue.Location = new System.Drawing.Point(11, 18);
            this.lblDue.Name = "lblDue";
            this.lblDue.Size = new System.Drawing.Size(150, 16);
            this.lblDue.TabIndex = 177;
            this.lblDue.Text = "0";
            this.lblDue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDue.Visible = false;
            // 
            // groupboxDue
            // 
            this.groupboxDue.BackColor = System.Drawing.Color.Transparent;
            this.groupboxDue.Controls.Add(this.lblDue);
            this.groupboxDue.ForeColor = System.Drawing.Color.Teal;
            this.groupboxDue.Location = new System.Drawing.Point(444, 35);
            this.groupboxDue.Name = "groupboxDue";
            this.groupboxDue.Size = new System.Drawing.Size(172, 44);
            this.groupboxDue.TabIndex = 178;
            this.groupboxDue.TabStop = false;
            this.groupboxDue.Text = "Due";
            this.groupboxDue.Visible = false;
            // 
            // txtAccName
            // 
            this.txtAccName.BackColor = System.Drawing.Color.MintCream;
            this.txtAccName.Cursor = System.Windows.Forms.Cursors.No;
            this.txtAccName.Enabled = false;
            this.txtAccName.Location = new System.Drawing.Point(99, 111);
            this.txtAccName.Name = "txtAccName";
            this.txtAccName.ReadOnly = true;
            this.txtAccName.Size = new System.Drawing.Size(172, 23);
            this.txtAccName.TabIndex = 3;
            // 
            // AccountListView
            // 
            this.AccountListView.BackColor = System.Drawing.Color.Azure;
            this.AccountListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AccountListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.AccountListView.FullRowSelect = true;
            this.AccountListView.Location = new System.Drawing.Point(99, 109);
            this.AccountListView.MultiSelect = false;
            this.AccountListView.Name = "AccountListView";
            this.AccountListView.Size = new System.Drawing.Size(262, 140);
            this.AccountListView.TabIndex = 181;
            this.AccountListView.UseCompatibleStateImageBehavior = false;
            this.AccountListView.View = System.Windows.Forms.View.Details;
            this.AccountListView.Visible = false;
            this.AccountListView.Click += new System.EventHandler(this.AccountListView_Click);
            this.AccountListView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AccountListView_KeyPress);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 180;
            // 
            // btnAddAccount
            // 
            this.btnAddAccount.BackColor = System.Drawing.Color.Transparent;
            this.btnAddAccount.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddAccount.BackgroundImage")));
            this.btnAddAccount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddAccount.FlatAppearance.BorderColor = System.Drawing.Color.Azure;
            this.btnAddAccount.FlatAppearance.BorderSize = 0;
            this.btnAddAccount.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAddAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAccount.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAccount.ForeColor = System.Drawing.Color.Black;
            this.btnAddAccount.Location = new System.Drawing.Point(247, 86);
            this.btnAddAccount.Name = "btnAddAccount";
            this.btnAddAccount.Size = new System.Drawing.Size(22, 23);
            this.btnAddAccount.TabIndex = 231;
            this.btnAddAccount.UseVisualStyleBackColor = false;
            this.btnAddAccount.Click += new System.EventHandler(this.btnAddAccount_Click);
            // 
            // cmsCashTransaction
            // 
            this.cmsCashTransaction.Name = "cmsCashTransaction";
            this.cmsCashTransaction.Size = new System.Drawing.Size(61, 4);
            this.cmsCashTransaction.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmsCashTransaction_ItemClicked);
            // 
            // btnReset
            // 
            this.btnReset.ForeColor = System.Drawing.Color.Maroon;
            this.btnReset.Location = new System.Drawing.Point(479, 136);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(56, 28);
            this.btnReset.TabIndex = 232;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // CashAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::IMS_Win.Properties.Resources.back;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(630, 390);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnAddAccount);
            this.Controls.Add(this.AccountListView);
            this.Controls.Add(this.txtAccName);
            this.Controls.Add(this.groupboxDue);
            this.Controls.Add(this.dgvCashAccount);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAccID);
            this.Controls.Add(this.txtTrID);
            this.Controls.Add(this.cmbAccType);
            this.Controls.Add(this.cmbTrType);
            this.Controls.Add(this.shapeContainer1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CashAccounts";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cash Transaction";
            this.Load += new System.EventHandler(this.CashAccounts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCashAccount)).EndInit();
            this.groupboxDue.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTrType;
        private System.Windows.Forms.ComboBox cmbAccType;
        private System.Windows.Forms.TextBox txtTrID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.DataGridView dgvCashAccount;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape2;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private System.Windows.Forms.Label lblDue;
        private System.Windows.Forms.GroupBox groupboxDue;
        private System.Windows.Forms.TextBox txtAccName;
        public System.Windows.Forms.TextBox txtAccID;
        private System.Windows.Forms.ListView AccountListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnAddAccount;
        private System.Windows.Forms.ContextMenuStrip cmsCashTransaction;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tr_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tr_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tr_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tr_Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn In_Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Out_Amount;
    }
}