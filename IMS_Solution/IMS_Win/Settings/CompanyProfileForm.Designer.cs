namespace IMS_Win
{
    partial class CompanyProfileForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompanyProfileForm));
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.txtReportHeading = new System.Windows.Forms.TextBox();
            this.btnclear = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.A4RadioButton = new System.Windows.Forms.RadioButton();
            this.PP6900RadioButton = new System.Windows.Forms.RadioButton();
            this.halfA4radioButton = new System.Windows.Forms.RadioButton();
            this.A4withDue_radioButton = new System.Windows.Forms.RadioButton();
            this.A4half_withDue_radioButton = new System.Windows.Forms.RadioButton();
            this.halfA4_RightradioButton = new System.Windows.Forms.RadioButton();
            this.halfA4_Righ_withduetradioButton = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCurrency = new System.Windows.Forms.TextBox();
            this.txtCurrencySymbol = new System.Windows.Forms.TextBox();
            this.rdbPOS_Exchange = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.chkAutoInvoicePrint = new System.Windows.Forms.CheckBox();
            this.rdbA4Bangla = new System.Windows.Forms.RadioButton();
            this.rdbA4halfBangla = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.Azure;
            this.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(449, 263);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(73, 25);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "&Save";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(188, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 79;
            this.label2.Text = "Description";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(166, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 15);
            this.label1.TabIndex = 78;
            this.label1.Text = "Company Name";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.BackColor = System.Drawing.Color.MintCream;
            this.txtCompanyName.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompanyName.Location = new System.Drawing.Point(260, 21);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(262, 23);
            this.txtCompanyName.TabIndex = 0;
            this.txtCompanyName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCompanyName_KeyDown);
            this.txtCompanyName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCompanyName_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.logoPictureBox);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Teal;
            this.groupBox1.Location = new System.Drawing.Point(9, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(137, 150);
            this.groupBox1.TabIndex = 77;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Company Logo";
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.logoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("logoPictureBox.Image")));
            this.logoPictureBox.Location = new System.Drawing.Point(8, 18);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(120, 122);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPictureBox.TabIndex = 67;
            this.logoPictureBox.TabStop = false;
            // 
            // browseButton
            // 
            this.browseButton.BackColor = System.Drawing.Color.PaleTurquoise;
            this.browseButton.FlatAppearance.BorderColor = System.Drawing.Color.Azure;
            this.browseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.browseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browseButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browseButton.ForeColor = System.Drawing.Color.Black;
            this.browseButton.Location = new System.Drawing.Point(26, 165);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(81, 25);
            this.browseButton.TabIndex = 2;
            this.browseButton.Text = "&Select Logo";
            this.browseButton.UseVisualStyleBackColor = false;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // txtReportHeading
            // 
            this.txtReportHeading.BackColor = System.Drawing.Color.MintCream;
            this.txtReportHeading.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReportHeading.Location = new System.Drawing.Point(260, 47);
            this.txtReportHeading.Multiline = true;
            this.txtReportHeading.Name = "txtReportHeading";
            this.txtReportHeading.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReportHeading.Size = new System.Drawing.Size(262, 78);
            this.txtReportHeading.TabIndex = 1;
            this.txtReportHeading.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReportHeading_KeyDown);
            // 
            // btnclear
            // 
            this.btnclear.BackColor = System.Drawing.Color.Transparent;
            this.btnclear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnclear.BackgroundImage")));
            this.btnclear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnclear.FlatAppearance.BorderColor = System.Drawing.Color.Azure;
            this.btnclear.FlatAppearance.BorderSize = 0;
            this.btnclear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnclear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclear.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclear.ForeColor = System.Drawing.Color.Black;
            this.btnclear.Location = new System.Drawing.Point(109, 168);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(21, 21);
            this.btnclear.TabIndex = 81;
            this.btnclear.UseVisualStyleBackColor = false;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(154, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 15);
            this.label3.TabIndex = 84;
            this.label3.Text = "Invoice Print Type";
            // 
            // A4RadioButton
            // 
            this.A4RadioButton.AutoSize = true;
            this.A4RadioButton.BackColor = System.Drawing.Color.Transparent;
            this.A4RadioButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.A4RadioButton.ForeColor = System.Drawing.Color.Black;
            this.A4RadioButton.Location = new System.Drawing.Point(263, 201);
            this.A4RadioButton.Name = "A4RadioButton";
            this.A4RadioButton.Size = new System.Drawing.Size(39, 19);
            this.A4RadioButton.TabIndex = 82;
            this.A4RadioButton.Text = "A4";
            this.A4RadioButton.UseVisualStyleBackColor = false;
            // 
            // PP6900RadioButton
            // 
            this.PP6900RadioButton.AutoSize = true;
            this.PP6900RadioButton.BackColor = System.Drawing.Color.Transparent;
            this.PP6900RadioButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PP6900RadioButton.ForeColor = System.Drawing.Color.Black;
            this.PP6900RadioButton.Location = new System.Drawing.Point(263, 183);
            this.PP6900RadioButton.Name = "PP6900RadioButton";
            this.PP6900RadioButton.Size = new System.Drawing.Size(105, 19);
            this.PP6900RadioButton.TabIndex = 83;
            this.PP6900RadioButton.Text = "POS (with due)";
            this.PP6900RadioButton.UseVisualStyleBackColor = false;
            // 
            // halfA4radioButton
            // 
            this.halfA4radioButton.AutoSize = true;
            this.halfA4radioButton.BackColor = System.Drawing.Color.Transparent;
            this.halfA4radioButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.halfA4radioButton.ForeColor = System.Drawing.Color.Black;
            this.halfA4radioButton.Location = new System.Drawing.Point(372, 164);
            this.halfA4radioButton.Name = "halfA4radioButton";
            this.halfA4radioButton.Size = new System.Drawing.Size(75, 19);
            this.halfA4radioButton.TabIndex = 85;
            this.halfA4radioButton.Text = "1/2 of A4";
            this.halfA4radioButton.UseVisualStyleBackColor = false;
            // 
            // A4withDue_radioButton
            // 
            this.A4withDue_radioButton.AutoSize = true;
            this.A4withDue_radioButton.BackColor = System.Drawing.Color.Transparent;
            this.A4withDue_radioButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.A4withDue_radioButton.ForeColor = System.Drawing.Color.Black;
            this.A4withDue_radioButton.Location = new System.Drawing.Point(263, 238);
            this.A4withDue_radioButton.Name = "A4withDue_radioButton";
            this.A4withDue_radioButton.Size = new System.Drawing.Size(94, 19);
            this.A4withDue_radioButton.TabIndex = 86;
            this.A4withDue_radioButton.Text = "A4(with due)";
            this.A4withDue_radioButton.UseVisualStyleBackColor = false;
            // 
            // A4half_withDue_radioButton
            // 
            this.A4half_withDue_radioButton.AutoSize = true;
            this.A4half_withDue_radioButton.BackColor = System.Drawing.Color.Transparent;
            this.A4half_withDue_radioButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.A4half_withDue_radioButton.ForeColor = System.Drawing.Color.Black;
            this.A4half_withDue_radioButton.Location = new System.Drawing.Point(372, 201);
            this.A4half_withDue_radioButton.Name = "A4half_withDue_radioButton";
            this.A4half_withDue_radioButton.Size = new System.Drawing.Size(130, 19);
            this.A4half_withDue_radioButton.TabIndex = 87;
            this.A4half_withDue_radioButton.Text = "1/2 of A4(with due)";
            this.A4half_withDue_radioButton.UseVisualStyleBackColor = false;
            // 
            // halfA4_RightradioButton
            // 
            this.halfA4_RightradioButton.AutoSize = true;
            this.halfA4_RightradioButton.BackColor = System.Drawing.Color.Transparent;
            this.halfA4_RightradioButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.halfA4_RightradioButton.ForeColor = System.Drawing.Color.Black;
            this.halfA4_RightradioButton.Location = new System.Drawing.Point(372, 219);
            this.halfA4_RightradioButton.Name = "halfA4_RightradioButton";
            this.halfA4_RightradioButton.Size = new System.Drawing.Size(114, 19);
            this.halfA4_RightradioButton.TabIndex = 88;
            this.halfA4_RightradioButton.Text = "1/2 of A4 (Right)";
            this.halfA4_RightradioButton.UseVisualStyleBackColor = false;
            // 
            // halfA4_Righ_withduetradioButton
            // 
            this.halfA4_Righ_withduetradioButton.AutoSize = true;
            this.halfA4_Righ_withduetradioButton.BackColor = System.Drawing.Color.Transparent;
            this.halfA4_Righ_withduetradioButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.halfA4_Righ_withduetradioButton.ForeColor = System.Drawing.Color.Black;
            this.halfA4_Righ_withduetradioButton.Location = new System.Drawing.Point(372, 238);
            this.halfA4_Righ_withduetradioButton.Name = "halfA4_Righ_withduetradioButton";
            this.halfA4_Righ_withduetradioButton.Size = new System.Drawing.Size(162, 19);
            this.halfA4_Righ_withduetradioButton.TabIndex = 89;
            this.halfA4_Righ_withduetradioButton.Text = "1/2 of A4-Right(with due)";
            this.halfA4_Righ_withduetradioButton.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(156, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 15);
            this.label4.TabIndex = 91;
            this.label4.Text = "Currency/Symbol";
            // 
            // txtCurrency
            // 
            this.txtCurrency.BackColor = System.Drawing.Color.MintCream;
            this.txtCurrency.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrency.Location = new System.Drawing.Point(260, 128);
            this.txtCurrency.Name = "txtCurrency";
            this.txtCurrency.Size = new System.Drawing.Size(131, 23);
            this.txtCurrency.TabIndex = 90;
            this.txtCurrency.Text = "BDT";
            this.txtCurrency.TextChanged += new System.EventHandler(this.txtCurrency_TextChanged);
            // 
            // txtCurrencySymbol
            // 
            this.txtCurrencySymbol.BackColor = System.Drawing.Color.MintCream;
            this.txtCurrencySymbol.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrencySymbol.Location = new System.Drawing.Point(397, 128);
            this.txtCurrencySymbol.Name = "txtCurrencySymbol";
            this.txtCurrencySymbol.Size = new System.Drawing.Size(125, 23);
            this.txtCurrencySymbol.TabIndex = 92;
            this.txtCurrencySymbol.Text = "৳";
            // 
            // rdbPOS_Exchange
            // 
            this.rdbPOS_Exchange.AutoSize = true;
            this.rdbPOS_Exchange.BackColor = System.Drawing.Color.Transparent;
            this.rdbPOS_Exchange.Checked = true;
            this.rdbPOS_Exchange.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbPOS_Exchange.ForeColor = System.Drawing.Color.Black;
            this.rdbPOS_Exchange.Location = new System.Drawing.Point(263, 164);
            this.rdbPOS_Exchange.Name = "rdbPOS_Exchange";
            this.rdbPOS_Exchange.Size = new System.Drawing.Size(47, 19);
            this.rdbPOS_Exchange.TabIndex = 93;
            this.rdbPOS_Exchange.TabStop = true;
            this.rdbPOS_Exchange.Text = "POS";
            this.rdbPOS_Exchange.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(154, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 15);
            this.label5.TabIndex = 94;
            this.label5.Text = "Auto Invoice Print";
            // 
            // chkAutoInvoicePrint
            // 
            this.chkAutoInvoicePrint.AutoSize = true;
            this.chkAutoInvoicePrint.BackColor = System.Drawing.Color.Transparent;
            this.chkAutoInvoicePrint.Location = new System.Drawing.Point(264, 269);
            this.chkAutoInvoicePrint.Name = "chkAutoInvoicePrint";
            this.chkAutoInvoicePrint.Size = new System.Drawing.Size(15, 14);
            this.chkAutoInvoicePrint.TabIndex = 95;
            this.chkAutoInvoicePrint.UseVisualStyleBackColor = false;
            // 
            // rdbA4Bangla
            // 
            this.rdbA4Bangla.AutoSize = true;
            this.rdbA4Bangla.BackColor = System.Drawing.Color.Transparent;
            this.rdbA4Bangla.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbA4Bangla.ForeColor = System.Drawing.Color.Black;
            this.rdbA4Bangla.Location = new System.Drawing.Point(263, 220);
            this.rdbA4Bangla.Name = "rdbA4Bangla";
            this.rdbA4Bangla.Size = new System.Drawing.Size(88, 19);
            this.rdbA4Bangla.TabIndex = 96;
            this.rdbA4Bangla.Text = "A4 (Bangla)";
            this.rdbA4Bangla.UseVisualStyleBackColor = false;
            // 
            // rdbA4halfBangla
            // 
            this.rdbA4halfBangla.AutoSize = true;
            this.rdbA4halfBangla.BackColor = System.Drawing.Color.Transparent;
            this.rdbA4halfBangla.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbA4halfBangla.ForeColor = System.Drawing.Color.Black;
            this.rdbA4halfBangla.Location = new System.Drawing.Point(372, 183);
            this.rdbA4halfBangla.Name = "rdbA4halfBangla";
            this.rdbA4halfBangla.Size = new System.Drawing.Size(124, 19);
            this.rdbA4halfBangla.TabIndex = 97;
            this.rdbA4halfBangla.Text = "1/2 of A4 (Bangla)";
            this.rdbA4halfBangla.UseVisualStyleBackColor = false;
            // 
            // CompanyProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::IMS_Win.Properties.Resources.back;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(534, 305);
            this.Controls.Add(this.rdbA4halfBangla);
            this.Controls.Add(this.rdbA4Bangla);
            this.Controls.Add(this.chkAutoInvoicePrint);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rdbPOS_Exchange);
            this.Controls.Add(this.txtCurrencySymbol);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCurrency);
            this.Controls.Add(this.halfA4_Righ_withduetradioButton);
            this.Controls.Add(this.halfA4_RightradioButton);
            this.Controls.Add(this.A4half_withDue_radioButton);
            this.Controls.Add(this.A4withDue_radioButton);
            this.Controls.Add(this.halfA4radioButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.A4RadioButton);
            this.Controls.Add(this.PP6900RadioButton);
            this.Controls.Add(this.btnclear);
            this.Controls.Add(this.txtReportHeading);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCompanyName);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CompanyProfileForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Company Profile";
            this.Load += new System.EventHandler(this.CompanyProfileForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.TextBox txtReportHeading;
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.RadioButton A4RadioButton;
        public System.Windows.Forms.RadioButton PP6900RadioButton;
        public System.Windows.Forms.RadioButton halfA4radioButton;
        public System.Windows.Forms.RadioButton A4withDue_radioButton;
        public System.Windows.Forms.RadioButton A4half_withDue_radioButton;
        public System.Windows.Forms.RadioButton halfA4_RightradioButton;
        public System.Windows.Forms.RadioButton halfA4_Righ_withduetradioButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCurrency;
        private System.Windows.Forms.TextBox txtCurrencySymbol;
        public System.Windows.Forms.RadioButton rdbPOS_Exchange;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkAutoInvoicePrint;
        public System.Windows.Forms.RadioButton rdbA4Bangla;
        public System.Windows.Forms.RadioButton rdbA4halfBangla;
    }
}