﻿namespace GeradorDesktop
{
    partial class Gerador_Codigo_Mysql
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Carregar_Tabelas = new System.Windows.Forms.Button();
            this.listBox_Tabelas = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Servidor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Porta = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_User = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_BD = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_Senha = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btn_Diretorio = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.Lb_NameSpace = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_NameSpace_API_Project = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_NameSpaceConsumirAPI = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBox_API = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox_ConsumirAPI = new System.Windows.Forms.CheckBox();
            this.checkBox_ScriptSql = new System.Windows.Forms.CheckBox();
            this.checkBox_INFO = new System.Windows.Forms.CheckBox();
            this.checkBox_DAL = new System.Windows.Forms.CheckBox();
            this.button_All = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Carregar_Tabelas
            // 
            this.btn_Carregar_Tabelas.Location = new System.Drawing.Point(414, 112);
            this.btn_Carregar_Tabelas.Name = "btn_Carregar_Tabelas";
            this.btn_Carregar_Tabelas.Size = new System.Drawing.Size(166, 28);
            this.btn_Carregar_Tabelas.TabIndex = 0;
            this.btn_Carregar_Tabelas.Text = "Carregar Tabelas";
            this.btn_Carregar_Tabelas.UseVisualStyleBackColor = true;
            this.btn_Carregar_Tabelas.Click += new System.EventHandler(this.btn_Carregar_Tabelas_Click);
            // 
            // listBox_Tabelas
            // 
            this.listBox_Tabelas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_Tabelas.FormattingEnabled = true;
            this.listBox_Tabelas.ItemHeight = 15;
            this.listBox_Tabelas.Location = new System.Drawing.Point(694, 27);
            this.listBox_Tabelas.Name = "listBox_Tabelas";
            this.listBox_Tabelas.Size = new System.Drawing.Size(258, 319);
            this.listBox_Tabelas.TabIndex = 1;
            this.listBox_Tabelas.SelectedIndexChanged += new System.EventHandler(this.listBox_Tabelas_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(705, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tabelas";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(312, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Porta";
            // 
            // textBox_Porta
            // 
            this.textBox_Porta.Location = new System.Drawing.Point(350, 28);
            this.textBox_Porta.Name = "textBox_Porta";
            this.textBox_Porta.Size = new System.Drawing.Size(230, 20);
            this.textBox_Porta.TabIndex = 5;
            this.textBox_Porta.Text = "3306";
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
            // textBox_User
            // 
            this.textBox_User.Location = new System.Drawing.Point(78, 58);
            this.textBox_User.Name = "textBox_User";
            this.textBox_User.Size = new System.Drawing.Size(217, 20);
            this.textBox_User.TabIndex = 7;
            this.textBox_User.Text = "root";
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
            // textBox_BD
            // 
            this.textBox_BD.Location = new System.Drawing.Point(350, 54);
            this.textBox_BD.Name = "textBox_BD";
            this.textBox_BD.Size = new System.Drawing.Size(230, 20);
            this.textBox_BD.TabIndex = 9;
            this.textBox_BD.Text = "daterrakambio";
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
            // textBox_Senha
            // 
            this.textBox_Senha.Location = new System.Drawing.Point(78, 86);
            this.textBox_Senha.Name = "textBox_Senha";
            this.textBox_Senha.PasswordChar = '*';
            this.textBox_Senha.Size = new System.Drawing.Size(502, 20);
            this.textBox_Senha.TabIndex = 11;
            this.textBox_Senha.Text = "Luseymayamba123#";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.SelectedPath = "C:\\Users\\Gerson Mayamba\\Pictures\\Teste #Gerador De Codigo";
            // 
            // btn_Diretorio
            // 
            this.btn_Diretorio.Location = new System.Drawing.Point(236, 121);
            this.btn_Diretorio.Name = "btn_Diretorio";
            this.btn_Diretorio.Size = new System.Drawing.Size(166, 30);
            this.btn_Diretorio.TabIndex = 13;
            this.btn_Diretorio.Text = "Escolher Diretorio";
            this.btn_Diretorio.UseVisualStyleBackColor = true;
            this.btn_Diretorio.Click += new System.EventHandler(this.btn_Diretorio_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "DAL/INFO";
            // 
            // Lb_NameSpace
            // 
            this.Lb_NameSpace.Location = new System.Drawing.Point(123, 31);
            this.Lb_NameSpace.Name = "Lb_NameSpace";
            this.Lb_NameSpace.Size = new System.Drawing.Size(279, 20);
            this.Lb_NameSpace.TabIndex = 14;
            this.Lb_NameSpace.Text = "Mayamba";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_Servidor);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_Porta);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_Senha);
            this.groupBox1.Controls.Add(this.btn_Carregar_Tabelas);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox_BD);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox_User);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(47, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(612, 156);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Autenticação Servidor";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = " API";
            // 
            // textBox_NameSpace_API_Project
            // 
            this.textBox_NameSpace_API_Project.Location = new System.Drawing.Point(123, 62);
            this.textBox_NameSpace_API_Project.Name = "textBox_NameSpace_API_Project";
            this.textBox_NameSpace_API_Project.Size = new System.Drawing.Size(279, 20);
            this.textBox_NameSpace_API_Project.TabIndex = 17;
            this.textBox_NameSpace_API_Project.Text = "Mayamba";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_NameSpaceConsumirAPI);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.textBox_NameSpace_API_Project);
            this.groupBox2.Controls.Add(this.btn_Diretorio);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.Lb_NameSpace);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(47, 174);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(408, 163);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Namespace Projectos";
            // 
            // textBox_NameSpaceConsumirAPI
            // 
            this.textBox_NameSpaceConsumirAPI.Location = new System.Drawing.Point(123, 93);
            this.textBox_NameSpaceConsumirAPI.Name = "textBox_NameSpaceConsumirAPI";
            this.textBox_NameSpaceConsumirAPI.Size = new System.Drawing.Size(279, 20);
            this.textBox_NameSpaceConsumirAPI.TabIndex = 19;
            this.textBox_NameSpaceConsumirAPI.Text = "Mayamba";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Consumo/API C#";
            // 
            // checkBox_API
            // 
            this.checkBox_API.AutoSize = true;
            this.checkBox_API.Checked = true;
            this.checkBox_API.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_API.Location = new System.Drawing.Point(6, 62);
            this.checkBox_API.Name = "checkBox_API";
            this.checkBox_API.Size = new System.Drawing.Size(43, 17);
            this.checkBox_API.TabIndex = 19;
            this.checkBox_API.Text = "API";
            this.checkBox_API.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox_ConsumirAPI);
            this.groupBox3.Controls.Add(this.checkBox_ScriptSql);
            this.groupBox3.Controls.Add(this.checkBox_INFO);
            this.groupBox3.Controls.Add(this.checkBox_DAL);
            this.groupBox3.Controls.Add(this.checkBox_API);
            this.groupBox3.Location = new System.Drawing.Point(471, 174);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(188, 163);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Gerar";
            // 
            // checkBox_ConsumirAPI
            // 
            this.checkBox_ConsumirAPI.AutoSize = true;
            this.checkBox_ConsumirAPI.Checked = true;
            this.checkBox_ConsumirAPI.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_ConsumirAPI.Location = new System.Drawing.Point(6, 129);
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
            this.checkBox_ScriptSql.Location = new System.Drawing.Point(6, 96);
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
            this.checkBox_INFO.Location = new System.Drawing.Point(6, 27);
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
            this.checkBox_DAL.Location = new System.Drawing.Point(135, 27);
            this.checkBox_DAL.Name = "checkBox_DAL";
            this.checkBox_DAL.Size = new System.Drawing.Size(47, 17);
            this.checkBox_DAL.TabIndex = 20;
            this.checkBox_DAL.Text = "DAL";
            this.checkBox_DAL.UseVisualStyleBackColor = true;
            // 
            // button_All
            // 
            this.button_All.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_All.Location = new System.Drawing.Point(432, 365);
            this.button_All.Name = "button_All";
            this.button_All.Size = new System.Drawing.Size(227, 32);
            this.button_All.TabIndex = 21;
            this.button_All.Text = "Gerar ";
            this.button_All.UseVisualStyleBackColor = true;
            this.button_All.Click += new System.EventHandler(this.button_All_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 409);
            this.Controls.Add(this.button_All);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox_Tabelas);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerador De Código Mysql";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Carregar_Tabelas;
        private System.Windows.Forms.ListBox listBox_Tabelas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Servidor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Porta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_User;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_BD;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_Senha;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btn_Diretorio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Lb_NameSpace;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_NameSpace_API_Project;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox_API;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBox_INFO;
        private System.Windows.Forms.CheckBox checkBox_DAL;
        private System.Windows.Forms.Button button_All;
        private System.Windows.Forms.CheckBox checkBox_ScriptSql;
        private System.Windows.Forms.TextBox textBox_NameSpaceConsumirAPI;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBox_ConsumirAPI;
    }
}

