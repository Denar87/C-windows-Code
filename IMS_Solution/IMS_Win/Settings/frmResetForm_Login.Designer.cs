namespace IMS_Win
{
    partial class frmResetForm_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmResetForm_Login));
            this.label1 = new System.Windows.Forms.Label();
            this.btn_restoreLogin = new System.Windows.Forms.Button();
            this.tmrRestore = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtRestorepassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(72, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Password";
            // 
            // btn_restoreLogin
            // 
            this.btn_restoreLogin.Location = new System.Drawing.Point(202, 86);
            this.btn_restoreLogin.Name = "btn_restoreLogin";
            this.btn_restoreLogin.Size = new System.Drawing.Size(64, 24);
            this.btn_restoreLogin.TabIndex = 1;
            this.btn_restoreLogin.Text = "Log In";
            this.btn_restoreLogin.UseVisualStyleBackColor = true;
            this.btn_restoreLogin.Click += new System.EventHandler(this.btn_restoreLogin_Click);
            // 
            // tmrRestore
            // 
            this.tmrRestore.Interval = 2;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtRestorepassword
            // 
            this.txtRestorepassword.BackColor = System.Drawing.Color.LightCyan;
            this.txtRestorepassword.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.txtRestorepassword.Location = new System.Drawing.Point(128, 54);
            this.txtRestorepassword.Name = "txtRestorepassword";
            this.txtRestorepassword.PasswordChar = '';
            this.txtRestorepassword.Size = new System.Drawing.Size(138, 20);
            this.txtRestorepassword.TabIndex = 0;
            this.txtRestorepassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmResetForm_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(339, 176);
            this.Controls.Add(this.txtRestorepassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_restoreLogin);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmResetForm_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log In";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_restoreLogin;
        private System.Windows.Forms.Timer tmrRestore;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Windows.Forms.TextBox txtRestorepassword;
    }
}