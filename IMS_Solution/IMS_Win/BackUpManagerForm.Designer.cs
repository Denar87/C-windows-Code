namespace IMS_Win
{
    partial class BackUpManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackUpManagerForm));
            this.tabBackup = new System.Windows.Forms.TabPage();
            this.btnRestore = new VistaButtonTest.VistaButton();
            this.btnBackup = new VistaButtonTest.VistaButton();
            this.BackupProgress = new System.Windows.Forms.ProgressBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tmrBackup = new System.Windows.Forms.Timer(this.components);
            this.tmrRestore = new System.Windows.Forms.Timer(this.components);
            this.tabBackup.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabBackup
            // 
            this.tabBackup.BackColor = System.Drawing.Color.Transparent;
            this.tabBackup.BackgroundImage = global::IMS_Win.Properties.Resources.back;
            this.tabBackup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabBackup.Controls.Add(this.btnRestore);
            this.tabBackup.Controls.Add(this.btnBackup);
            this.tabBackup.Controls.Add(this.BackupProgress);
            this.tabBackup.Location = new System.Drawing.Point(4, 23);
            this.tabBackup.Name = "tabBackup";
            this.tabBackup.Padding = new System.Windows.Forms.Padding(3);
            this.tabBackup.Size = new System.Drawing.Size(331, 149);
            this.tabBackup.TabIndex = 0;
            this.tabBackup.Text = "Backup";
            // 
            // btnRestore
            // 
            this.btnRestore.BackColor = System.Drawing.Color.Transparent;
            this.btnRestore.BaseColor = System.Drawing.Color.Transparent;
            this.btnRestore.ButtonColor = System.Drawing.Color.Teal;
            this.btnRestore.ButtonText = "Restore";
            this.btnRestore.CornerRadius = 5;
            this.btnRestore.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestore.GlowColor = System.Drawing.Color.Aquamarine;
            this.btnRestore.HighlightColor = System.Drawing.Color.Transparent;
            this.btnRestore.Location = new System.Drawing.Point(119, 83);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(93, 30);
            this.btnRestore.TabIndex = 4;
            this.btnRestore.Visible = false;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.BackColor = System.Drawing.Color.Transparent;
            this.btnBackup.BaseColor = System.Drawing.Color.Transparent;
            this.btnBackup.ButtonColor = System.Drawing.Color.Teal;
            this.btnBackup.ButtonText = "Backup";
            this.btnBackup.CornerRadius = 5;
            this.btnBackup.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackup.GlowColor = System.Drawing.Color.Aquamarine;
            this.btnBackup.HighlightColor = System.Drawing.Color.Transparent;
            this.btnBackup.Location = new System.Drawing.Point(119, 47);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(93, 30);
            this.btnBackup.TabIndex = 3;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // BackupProgress
            // 
            this.BackupProgress.Location = new System.Drawing.Point(5, 130);
            this.BackupProgress.Name = "BackupProgress";
            this.BackupProgress.Size = new System.Drawing.Size(319, 15);
            this.BackupProgress.Step = 5;
            this.BackupProgress.TabIndex = 2;
            this.BackupProgress.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabBackup);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(339, 176);
            this.tabControl1.TabIndex = 2;
            // 
            // tmrBackup
            // 
            this.tmrBackup.Tick += new System.EventHandler(this.tmrBackup_Tick);
            // 
            // tmrRestore
            // 
            this.tmrRestore.Interval = 2;
            // 
            // BackUpManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(339, 176);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BackUpManagerForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database Backup";
            this.tabBackup.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabBackup;
        private VistaButtonTest.VistaButton btnBackup;
        private System.Windows.Forms.ProgressBar BackupProgress;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Timer tmrBackup;
        private System.Windows.Forms.Timer tmrRestore;
        private VistaButtonTest.VistaButton btnRestore;
    }
}