namespace GeradorDesktop
{
    partial class Gerador_Codigo_Sql_Server
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
            this.button_Gerar_Codigo = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox_ConsumirAPI = new System.Windows.Forms.CheckBox();
            this.checkBox_ScriptSql = new System.Windows.Forms.CheckBox();
            this.checkBox_INFO = new System.Windows.Forms.CheckBox();
            this.checkBox_DAL = new System.Windows.Forms.CheckBox();
            this.checkBox_API = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_NameSpaceConsumirAPI = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_NameSpace_API_Project = new System.Windows.Forms.TextBox();
            this.btn_Diretorio = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.Lb_NameSpace = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_Servidor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Porta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Senha = new System.Windows.Forms.TextBox();
            this.btn_Carregar_Tabelas_SqlServer = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_BD = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_User = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox_Tabelas = new System.Windows.Forms.ListBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label10 = new System.Windows.Forms.Label();
            this.Lb_NameSpace_DAL = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Gerar_Codigo
            // 
            this.button_Gerar_Codigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Gerar_Codigo.Location = new System.Drawing.Point(435, 461);
            this.button_Gerar_Codigo.Name = "button_Gerar_Codigo";
            this.button_Gerar_Codigo.Size = new System.Drawing.Size(227, 32);
            this.button_Gerar_Codigo.TabIndex = 27;
            this.button_Gerar_Codigo.Text = "Gerar ";
            this.button_Gerar_Codigo.UseVisualStyleBackColor = true;
            this.button_Gerar_Codigo.Click += new System.EventHandler(this.button_Gerar_Codigo_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox_ConsumirAPI);
            this.groupBox3.Controls.Add(this.checkBox_ScriptSql);
            this.groupBox3.Controls.Add(this.checkBox_INFO);
            this.groupBox3.Controls.Add(this.checkBox_DAL);
            this.groupBox3.Controls.Add(this.checkBox_API);
            this.groupBox3.Location = new System.Drawing.Point(474, 232);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(188, 203);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Gerar";
            // 
            // checkBox_ConsumirAPI
            // 
            this.checkBox_ConsumirAPI.AutoSize = true;
            this.checkBox_ConsumirAPI.Checked = true;
            this.checkBox_ConsumirAPI.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_ConsumirAPI.Location = new System.Drawing.Point(6, 147);
            this.checkBox_ConsumirAPI.Name = "checkBox_ConsumirAPI";
            this.checkBox_ConsumirAPI.Size = new System.Drawing.Size(109, 17);
            this.checkBox_ConsumirAPI.TabIndex = 23;
            this.checkBox_ConsumirAPI.Text = "Consumo/API C#";
            this.checkBox_ConsumirAPI.UseVisualStyleBackColor = true;
            // 
            // checkBox_ScriptSql
            // 
            this.checkBox_ScriptSql.AutoSize = true;
            this.checkBox_ScriptSql.Checked = true;
            this.checkBox_ScriptSql.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_ScriptSql.Location = new System.Drawing.Point(6, 114);
            this.checkBox_ScriptSql.Name = "checkBox_ScriptSql";
            this.checkBox_ScriptSql.Size = new System.Drawing.Size(71, 17);
            this.checkBox_ScriptSql.TabIndex = 22;
            this.checkBox_ScriptSql.Text = "Script Sql";
            this.checkBox_ScriptSql.UseVisualStyleBackColor = true;
            // 
            // checkBox_INFO
            // 
            this.checkBox_INFO.AutoSize = true;
            this.checkBox_INFO.Checked = true;
            this.checkBox_INFO.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_INFO.Location = new System.Drawing.Point(6, 45);
            this.checkBox_INFO.Name = "checkBox_INFO";
            this.checkBox_INFO.Size = new System.Drawing.Size(51, 17);
            this.checkBox_INFO.TabIndex = 21;
            this.checkBox_INFO.Text = "INFO";
            this.checkBox_INFO.UseVisualStyleBackColor = true;
            // 
            // checkBox_DAL
            // 
            this.checkBox_DAL.AutoSize = true;
            this.checkBox_DAL.Checked = true;
            this.checkBox_DAL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_DAL.Location = new System.Drawing.Point(135, 45);
            this.checkBox_DAL.Name = "checkBox_DAL";
            this.checkBox_DAL.Size = new System.Drawing.Size(47, 17);
            this.checkBox_DAL.TabIndex = 20;
            this.checkBox_DAL.Text = "DAL";
            this.checkBox_DAL.UseVisualStyleBackColor = true;
            // 
            // checkBox_API
            // 
            this.checkBox_API.AutoSize = true;
            this.checkBox_API.Checked = true;
            this.checkBox_API.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_API.Location = new System.Drawing.Point(6, 80);
            this.checkBox_API.Name = "checkBox_API";
            this.checkBox_API.Size = new System.Drawing.Size(43, 17);
            this.checkBox_API.TabIndex = 19;
            this.checkBox_API.Text = "API";
            this.checkBox_API.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Lb_NameSpace_DAL);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.textBox_NameSpaceConsumirAPI);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.textBox_NameSpace_API_Project);
            this.groupBox2.Controls.Add(this.btn_Diretorio);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.Lb_NameSpace);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(50, 232);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(408, 203);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Namespace Projectos";
            // 
            // textBox_NameSpaceConsumirAPI
            // 
            this.textBox_NameSpaceConsumirAPI.Location = new System.Drawing.Point(123, 132);
            this.textBox_NameSpaceConsumirAPI.Name = "textBox_NameSpaceConsumirAPI";
            this.textBox_NameSpaceConsumirAPI.Size = new System.Drawing.Size(279, 20);
            this.textBox_NameSpaceConsumirAPI.TabIndex = 19;
            this.textBox_NameSpaceConsumirAPI.Text = "Mayamba";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 135);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Consumo/API C#";
            // 
            // textBox_NameSpace_API_Project
            // 
            this.textBox_NameSpace_API_Project.Location = new System.Drawing.Point(123, 101);
            this.textBox_NameSpace_API_Project.Name = "textBox_NameSpace_API_Project";
            this.textBox_NameSpace_API_Project.Size = new System.Drawing.Size(279, 20);
            this.textBox_NameSpace_API_Project.TabIndex = 17;
            this.textBox_NameSpace_API_Project.Text = "Mayamba";
            // 
            // btn_Diretorio
            // 
            this.btn_Diretorio.Location = new System.Drawing.Point(236, 160);
            this.btn_Diretorio.Name = "btn_Diretorio";
            this.btn_Diretorio.Size = new System.Drawing.Size(166, 30);
            this.btn_Diretorio.TabIndex = 13;
            this.btn_Diretorio.Text = "Escolher Diretorio";
            this.btn_Diretorio.UseVisualStyleBackColor = true;
            this.btn_Diretorio.Click += new System.EventHandler(this.btn_Diretorio_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = " API";
            // 
            // Lb_NameSpace
            // 
            this.Lb_NameSpace.Location = new System.Drawing.Point(123, 31);
            this.Lb_NameSpace.Name = "Lb_NameSpace";
            this.Lb_NameSpace.Size = new System.Drawing.Size(279, 20);
            this.Lb_NameSpace.TabIndex = 14;
            this.Lb_NameSpace.Text = "Mayamba";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "INFO";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_Servidor);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_Porta);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_Senha);
            this.groupBox1.Controls.Add(this.btn_Carregar_Tabelas_SqlServer);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox_BD);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox_User);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(50, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(612, 156);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Autenticação Servidor";
            // 
            // textBox_Servidor
            // 
            this.textBox_Servidor.Location = new System.Drawing.Point(78, 28);
            this.textBox_Servidor.Name = "textBox_Servidor";
            this.textBox_Servidor.Size = new System.Drawing.Size(217, 20);
            this.textBox_Servidor.TabIndex = 3;
            this.textBox_Servidor.Text = "localhost";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Servidor";
            // 
            // textBox_Porta
            // 
            this.textBox_Porta.Location = new System.Drawing.Point(350, 28);
            this.textBox_Porta.Name = "textBox_Porta";
            this.textBox_Porta.Size = new System.Drawing.Size(230, 20);
            this.textBox_Porta.TabIndex = 5;
            this.textBox_Porta.Text = "3306";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(312, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Porta";
            // 
            // textBox_Senha
            // 
            this.textBox_Senha.Location = new System.Drawing.Point(78, 86);
            this.textBox_Senha.Name = "textBox_Senha";
            this.textBox_Senha.PasswordChar = '*';
            this.textBox_Senha.Size = new System.Drawing.Size(502, 20);
            this.textBox_Senha.TabIndex = 11;
            this.textBox_Senha.Text = "123";
            // 
            // btn_Carregar_Tabelas_SqlServer
            // 
            this.btn_Carregar_Tabelas_SqlServer.Location = new System.Drawing.Point(414, 112);
            this.btn_Carregar_Tabelas_SqlServer.Name = "btn_Carregar_Tabelas_SqlServer";
            this.btn_Carregar_Tabelas_SqlServer.Size = new System.Drawing.Size(166, 28);
            this.btn_Carregar_Tabelas_SqlServer.TabIndex = 0;
            this.btn_Carregar_Tabelas_SqlServer.Text = "Carregar Tabelas";
            this.btn_Carregar_Tabelas_SqlServer.UseVisualStyleBackColor = true;
            this.btn_Carregar_Tabelas_SqlServer.Click += new System.EventHandler(this.btn_Carregar_Tabelas_SqlServer_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Senha";
            // 
            // textBox_BD
            // 
            this.textBox_BD.Location = new System.Drawing.Point(350, 54);
            this.textBox_BD.Name = "textBox_BD";
            this.textBox_BD.Size = new System.Drawing.Size(230, 20);
            this.textBox_BD.TabIndex = 9;
            this.textBox_BD.Text = "TecnoGest";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(312, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "BD";
            // 
            // textBox_User
            // 
            this.textBox_User.Location = new System.Drawing.Point(78, 58);
            this.textBox_User.Name = "textBox_User";
            this.textBox_User.Size = new System.Drawing.Size(217, 20);
            this.textBox_User.TabIndex = 7;
            this.textBox_User.Text = "Mayamba";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "User";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(708, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "Tabelas";
            // 
            // listBox_Tabelas
            // 
            this.listBox_Tabelas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_Tabelas.FormattingEnabled = true;
            this.listBox_Tabelas.ItemHeight = 15;
            this.listBox_Tabelas.Location = new System.Drawing.Point(697, 85);
            this.listBox_Tabelas.Name = "listBox_Tabelas";
            this.listBox_Tabelas.Size = new System.Drawing.Size(258, 349);
            this.listBox_Tabelas.TabIndex = 22;
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.SelectedPath = "C:\\Users\\Gerson Mayamba\\Pictures\\Teste #Gerador De Codigo";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 66);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "DAL";
            // 
            // Lb_NameSpace_DAL
            // 
            this.Lb_NameSpace_DAL.Location = new System.Drawing.Point(123, 66);
            this.Lb_NameSpace_DAL.Name = "Lb_NameSpace_DAL";
            this.Lb_NameSpace_DAL.Size = new System.Drawing.Size(279, 20);
            this.Lb_NameSpace_DAL.TabIndex = 21;
            this.Lb_NameSpace_DAL.Text = "Mayamba";
            // 
            // Gerador_Codigo_Sql_Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 521);
            this.Controls.Add(this.button_Gerar_Codigo);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox_Tabelas);
            this.MaximizeBox = false;
            this.Name = "Gerador_Codigo_Sql_Server";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerador Codigo SqlServer";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Gerar_Codigo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBox_ConsumirAPI;
        private System.Windows.Forms.CheckBox checkBox_ScriptSql;
        private System.Windows.Forms.CheckBox checkBox_INFO;
        private System.Windows.Forms.CheckBox checkBox_DAL;
        private System.Windows.Forms.CheckBox checkBox_API;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_NameSpaceConsumirAPI;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_NameSpace_API_Project;
        private System.Windows.Forms.Button btn_Diretorio;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Lb_NameSpace;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_Servidor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Porta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Senha;
        private System.Windows.Forms.Button btn_Carregar_Tabelas_SqlServer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_BD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_User;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox_Tabelas;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox Lb_NameSpace_DAL;
        private System.Windows.Forms.Label label10;
    }
}