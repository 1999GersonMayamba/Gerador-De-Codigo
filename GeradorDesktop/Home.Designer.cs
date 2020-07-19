namespace GeradorDesktop
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox_Mysql = new System.Windows.Forms.PictureBox();
            this.panel_Mysql = new System.Windows.Forms.Panel();
            this.label_Mysql = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox_Sql_Server = new System.Windows.Forms.PictureBox();
            this.panel_Sql_Server = new System.Windows.Forms.Panel();
            this.label_Sql_Server = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Mysql)).BeginInit();
            this.panel_Mysql.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Sql_Server)).BeginInit();
            this.panel_Sql_Server.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox_Mysql);
            this.panel1.Controls.Add(this.panel_Mysql);
            this.panel1.Location = new System.Drawing.Point(119, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 203);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox_Mysql
            // 
            this.pictureBox_Mysql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_Mysql.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Mysql.Image")));
            this.pictureBox_Mysql.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_Mysql.Name = "pictureBox_Mysql";
            this.pictureBox_Mysql.Size = new System.Drawing.Size(200, 162);
            this.pictureBox_Mysql.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Mysql.TabIndex = 3;
            this.pictureBox_Mysql.TabStop = false;
            this.pictureBox_Mysql.Click += new System.EventHandler(this.pictureBox_Mysql_Click);
            // 
            // panel_Mysql
            // 
            this.panel_Mysql.BackColor = System.Drawing.Color.Indigo;
            this.panel_Mysql.Controls.Add(this.label_Mysql);
            this.panel_Mysql.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_Mysql.Location = new System.Drawing.Point(0, 162);
            this.panel_Mysql.Name = "panel_Mysql";
            this.panel_Mysql.Size = new System.Drawing.Size(200, 41);
            this.panel_Mysql.TabIndex = 1;
            this.panel_Mysql.Click += new System.EventHandler(this.panel_Mysql_Click);
            // 
            // label_Mysql
            // 
            this.label_Mysql.AutoSize = true;
            this.label_Mysql.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Mysql.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_Mysql.Location = new System.Drawing.Point(72, 11);
            this.label_Mysql.Name = "label_Mysql";
            this.label_Mysql.Size = new System.Drawing.Size(49, 20);
            this.label_Mysql.TabIndex = 0;
            this.label_Mysql.Text = "Mysql";
            this.label_Mysql.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_Mysql.Click += new System.EventHandler(this.label_Mysql_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pictureBox_Sql_Server);
            this.panel3.Controls.Add(this.panel_Sql_Server);
            this.panel3.Location = new System.Drawing.Point(401, 48);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 203);
            this.panel3.TabIndex = 2;
            // 
            // pictureBox_Sql_Server
            // 
            this.pictureBox_Sql_Server.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_Sql_Server.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Sql_Server.Image")));
            this.pictureBox_Sql_Server.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_Sql_Server.Name = "pictureBox_Sql_Server";
            this.pictureBox_Sql_Server.Size = new System.Drawing.Size(200, 162);
            this.pictureBox_Sql_Server.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Sql_Server.TabIndex = 2;
            this.pictureBox_Sql_Server.TabStop = false;
            this.pictureBox_Sql_Server.Click += new System.EventHandler(this.pictureBox_Sql_Server_Click);
            // 
            // panel_Sql_Server
            // 
            this.panel_Sql_Server.BackColor = System.Drawing.Color.Indigo;
            this.panel_Sql_Server.Controls.Add(this.label_Sql_Server);
            this.panel_Sql_Server.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_Sql_Server.Location = new System.Drawing.Point(0, 162);
            this.panel_Sql_Server.Name = "panel_Sql_Server";
            this.panel_Sql_Server.Size = new System.Drawing.Size(200, 41);
            this.panel_Sql_Server.TabIndex = 1;
            this.panel_Sql_Server.Click += new System.EventHandler(this.panel_Sql_Server_Click);
            // 
            // label_Sql_Server
            // 
            this.label_Sql_Server.AutoSize = true;
            this.label_Sql_Server.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Sql_Server.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_Sql_Server.Location = new System.Drawing.Point(56, 11);
            this.label_Sql_Server.Name = "label_Sql_Server";
            this.label_Sql_Server.Size = new System.Drawing.Size(82, 20);
            this.label_Sql_Server.TabIndex = 1;
            this.label_Sql_Server.Text = "Sql Server";
            this.label_Sql_Server.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_Sql_Server.Click += new System.EventHandler(this.label_Sql_Server_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 307);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Mysql)).EndInit();
            this.panel_Mysql.ResumeLayout(false);
            this.panel_Mysql.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Sql_Server)).EndInit();
            this.panel_Sql_Server.ResumeLayout(false);
            this.panel_Sql_Server.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox_Mysql;
        private System.Windows.Forms.Panel panel_Mysql;
        private System.Windows.Forms.Label label_Mysql;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox_Sql_Server;
        private System.Windows.Forms.Panel panel_Sql_Server;
        private System.Windows.Forms.Label label_Sql_Server;
    }
}