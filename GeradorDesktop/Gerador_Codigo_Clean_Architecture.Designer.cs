
namespace GeradorDesktop
{
    partial class Gerador_Codigo_Clean_Architecture
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
            this.btn_Gerar_Tudo = new System.Windows.Forms.Button();
            this.button_Gerar_Codigo = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Lb_NameSpace_DAL = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox_NameSpaceConsumirAPI = new System.Windows.Forms.TextBox();
            this.btn_Diretorio = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_NameSpace_API_Project = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkBox_MAPPINGS = new System.Windows.Forms.CheckBox();
            this.checkBox_SERVICE = new System.Windows.Forms.CheckBox();
            this.checkBox_SERVICEREGISTRATIONPERSISTANCE = new System.Windows.Forms.CheckBox();
            this.checkBox_SERVICEREGISTRATIONAPPLICATION = new System.Windows.Forms.CheckBox();
            this.checkBox_ISERVICES = new System.Windows.Forms.CheckBox();
            this.checkBox_IREPOSITORIES = new System.Windows.Forms.CheckBox();
            this.checkBox_DTOs = new System.Windows.Forms.CheckBox();
            this.checkBox_REPOSITORIES = new System.Windows.Forms.CheckBox();
            this.checkBox_CONTROLLER = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Gerar_Tudo
            // 
            this.btn_Gerar_Tudo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Gerar_Tudo.Location = new System.Drawing.Point(325, 755);
            this.btn_Gerar_Tudo.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Gerar_Tudo.Name = "btn_Gerar_Tudo";
            this.btn_Gerar_Tudo.Size = new System.Drawing.Size(259, 39);
            this.btn_Gerar_Tudo.TabIndex = 35;
            this.btn_Gerar_Tudo.Text = "Gerar Tudo";
            this.btn_Gerar_Tudo.UseVisualStyleBackColor = true;
            this.btn_Gerar_Tudo.Click += new System.EventHandler(this.btn_Gerar_Tudo_Click);
            // 
            // button_Gerar_Codigo
            // 
            this.button_Gerar_Codigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Gerar_Codigo.Location = new System.Drawing.Point(40, 755);
            this.button_Gerar_Codigo.Margin = new System.Windows.Forms.Padding(4);
            this.button_Gerar_Codigo.Name = "button_Gerar_Codigo";
            this.button_Gerar_Codigo.Size = new System.Drawing.Size(250, 39);
            this.button_Gerar_Codigo.TabIndex = 34;
            this.button_Gerar_Codigo.Text = "Gerar  Selecionado";
            this.button_Gerar_Codigo.UseVisualStyleBackColor = true;
            this.button_Gerar_Codigo.Click += new System.EventHandler(this.button_Gerar_Codigo_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.Lb_NameSpace_DAL);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.textBox_NameSpaceConsumirAPI);
            this.groupBox2.Controls.Add(this.btn_Diretorio);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.textBox_NameSpace_API_Project);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.Lb_NameSpace);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(40, 233);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(544, 514);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Namespace Projectos";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(21, 328);
            this.textBox4.Margin = new System.Windows.Forms.Padding(4);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(491, 23);
            this.textBox4.TabIndex = 28;
            this.textBox4.Text = "Application.Mappings";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(19, 307);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 17);
            this.label14.TabIndex = 27;
            this.label14.Text = "MAPPINGS";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(21, 277);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(491, 23);
            this.textBox3.TabIndex = 26;
            this.textBox3.Text = "Application.Features.services";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(19, 250);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 17);
            this.label13.TabIndex = 25;
            this.label13.Text = "SERVICES";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(22, 435);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(491, 23);
            this.textBox2.TabIndex = 24;
            this.textBox2.Text = "Infrastructure.Persistence";
            // 
            // Lb_NameSpace_DAL
            // 
            this.Lb_NameSpace_DAL.Location = new System.Drawing.Point(21, 110);
            this.Lb_NameSpace_DAL.Margin = new System.Windows.Forms.Padding(4);
            this.Lb_NameSpace_DAL.Name = "Lb_NameSpace_DAL";
            this.Lb_NameSpace_DAL.Size = new System.Drawing.Size(491, 23);
            this.Lb_NameSpace_DAL.TabIndex = 21;
            this.Lb_NameSpace_DAL.Text = " WebApi.Controllers";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 89);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 17);
            this.label10.TabIndex = 20;
            this.label10.Text = "CONTROLLER";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 414);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(264, 17);
            this.label12.TabIndex = 23;
            this.label12.Text = "SERVICEREGISTRATIONPERSISTANCE";
            // 
            // textBox_NameSpaceConsumirAPI
            // 
            this.textBox_NameSpaceConsumirAPI.Location = new System.Drawing.Point(21, 216);
            this.textBox_NameSpaceConsumirAPI.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_NameSpaceConsumirAPI.Name = "textBox_NameSpaceConsumirAPI";
            this.textBox_NameSpaceConsumirAPI.Size = new System.Drawing.Size(491, 23);
            this.textBox_NameSpaceConsumirAPI.TabIndex = 19;
            this.textBox_NameSpaceConsumirAPI.Text = "Application.Interfaces.Services";
            // 
            // btn_Diretorio
            // 
            this.btn_Diretorio.Location = new System.Drawing.Point(292, 469);
            this.btn_Diretorio.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Diretorio.Name = "btn_Diretorio";
            this.btn_Diretorio.Size = new System.Drawing.Size(221, 37);
            this.btn_Diretorio.TabIndex = 13;
            this.btn_Diretorio.Text = "Escolher Diretorio";
            this.btn_Diretorio.UseVisualStyleBackColor = true;
            this.btn_Diretorio.Click += new System.EventHandler(this.btn_Diretorio_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(19, 357);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(258, 17);
            this.label11.TabIndex = 22;
            this.label11.Text = "SERVICEREGISTRATIONAPPLICATION";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 189);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 17);
            this.label9.TabIndex = 18;
            this.label9.Text = "ISERVICES";
            // 
            // textBox_NameSpace_API_Project
            // 
            this.textBox_NameSpace_API_Project.Location = new System.Drawing.Point(21, 161);
            this.textBox_NameSpace_API_Project.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_NameSpace_API_Project.Name = "textBox_NameSpace_API_Project";
            this.textBox_NameSpace_API_Project.Size = new System.Drawing.Size(491, 23);
            this.textBox_NameSpace_API_Project.TabIndex = 17;
            this.textBox_NameSpace_API_Project.Text = "Application.Interfaces.Repositories";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(21, 378);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(491, 23);
            this.textBox1.TabIndex = 22;
            this.textBox1.Text = "Application";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 139);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "IREPOSITORIES";
            // 
            // Lb_NameSpace
            // 
            this.Lb_NameSpace.Location = new System.Drawing.Point(21, 52);
            this.Lb_NameSpace.Margin = new System.Windows.Forms.Padding(4);
            this.Lb_NameSpace.Name = "Lb_NameSpace";
            this.Lb_NameSpace.Size = new System.Drawing.Size(491, 23);
            this.Lb_NameSpace.TabIndex = 14;
            this.Lb_NameSpace.Text = "Application.DTOs";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 31);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "DTOs";
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
            this.groupBox1.Location = new System.Drawing.Point(40, 22);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(857, 192);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Autenticação Servidor";
            // 
            // textBox_Servidor
            // 
            this.textBox_Servidor.Location = new System.Drawing.Point(104, 34);
            this.textBox_Servidor.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Servidor.Name = "textBox_Servidor";
            this.textBox_Servidor.Size = new System.Drawing.Size(288, 23);
            this.textBox_Servidor.TabIndex = 3;
            this.textBox_Servidor.Text = "10.11.1.68";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Servidor";
            // 
            // textBox_Porta
            // 
            this.textBox_Porta.Location = new System.Drawing.Point(467, 34);
            this.textBox_Porta.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Porta.Name = "textBox_Porta";
            this.textBox_Porta.Size = new System.Drawing.Size(305, 23);
            this.textBox_Porta.TabIndex = 5;
            this.textBox_Porta.Text = "3306";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(416, 37);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Porta";
            // 
            // textBox_Senha
            // 
            this.textBox_Senha.Location = new System.Drawing.Point(104, 106);
            this.textBox_Senha.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Senha.Name = "textBox_Senha";
            this.textBox_Senha.PasswordChar = '*';
            this.textBox_Senha.Size = new System.Drawing.Size(668, 23);
            this.textBox_Senha.TabIndex = 11;
            this.textBox_Senha.Text = "teste";
            // 
            // btn_Carregar_Tabelas_SqlServer
            // 
            this.btn_Carregar_Tabelas_SqlServer.Location = new System.Drawing.Point(552, 138);
            this.btn_Carregar_Tabelas_SqlServer.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Carregar_Tabelas_SqlServer.Name = "btn_Carregar_Tabelas_SqlServer";
            this.btn_Carregar_Tabelas_SqlServer.Size = new System.Drawing.Size(221, 34);
            this.btn_Carregar_Tabelas_SqlServer.TabIndex = 0;
            this.btn_Carregar_Tabelas_SqlServer.Text = "Carregar Tabelas";
            this.btn_Carregar_Tabelas_SqlServer.UseVisualStyleBackColor = true;
            this.btn_Carregar_Tabelas_SqlServer.Click += new System.EventHandler(this.btn_Carregar_Tabelas_SqlServer_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 110);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Senha";
            // 
            // textBox_BD
            // 
            this.textBox_BD.Location = new System.Drawing.Point(467, 66);
            this.textBox_BD.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_BD.Name = "textBox_BD";
            this.textBox_BD.Size = new System.Drawing.Size(305, 23);
            this.textBox_BD.TabIndex = 9;
            this.textBox_BD.Text = "UtoolHelpDeskDB";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(416, 70);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "BD";
            // 
            // textBox_User
            // 
            this.textBox_User.Location = new System.Drawing.Point(104, 71);
            this.textBox_User.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_User.Name = "textBox_User";
            this.textBox_User.Size = new System.Drawing.Size(288, 23);
            this.textBox_User.TabIndex = 7;
            this.textBox_User.Text = "teste";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 75);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "User";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(916, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 30;
            this.label1.Text = "Tabelas";
            // 
            // listBox_Tabelas
            // 
            this.listBox_Tabelas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_Tabelas.FormattingEnabled = true;
            this.listBox_Tabelas.ItemHeight = 15;
            this.listBox_Tabelas.Location = new System.Drawing.Point(920, 33);
            this.listBox_Tabelas.Margin = new System.Windows.Forms.Padding(4);
            this.listBox_Tabelas.Name = "listBox_Tabelas";
            this.listBox_Tabelas.Size = new System.Drawing.Size(363, 709);
            this.listBox_Tabelas.TabIndex = 29;
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.SelectedPath = "C:\\Users\\gmayamba\\Documents\\Gerador#Codigo";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBox_MAPPINGS);
            this.groupBox4.Controls.Add(this.checkBox_SERVICE);
            this.groupBox4.Controls.Add(this.checkBox_SERVICEREGISTRATIONPERSISTANCE);
            this.groupBox4.Controls.Add(this.checkBox_SERVICEREGISTRATIONAPPLICATION);
            this.groupBox4.Controls.Add(this.checkBox_ISERVICES);
            this.groupBox4.Controls.Add(this.checkBox_IREPOSITORIES);
            this.groupBox4.Controls.Add(this.checkBox_DTOs);
            this.groupBox4.Controls.Add(this.checkBox_REPOSITORIES);
            this.groupBox4.Controls.Add(this.checkBox_CONTROLLER);
            this.groupBox4.Location = new System.Drawing.Point(605, 233);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(292, 514);
            this.groupBox4.TabIndex = 36;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Gerar";
            // 
            // checkBox_MAPPINGS
            // 
            this.checkBox_MAPPINGS.AutoSize = true;
            this.checkBox_MAPPINGS.Checked = true;
            this.checkBox_MAPPINGS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_MAPPINGS.Location = new System.Drawing.Point(6, 250);
            this.checkBox_MAPPINGS.Name = "checkBox_MAPPINGS";
            this.checkBox_MAPPINGS.Size = new System.Drawing.Size(98, 21);
            this.checkBox_MAPPINGS.TabIndex = 27;
            this.checkBox_MAPPINGS.Text = "MAPPINGS";
            this.checkBox_MAPPINGS.UseVisualStyleBackColor = true;
            // 
            // checkBox_SERVICE
            // 
            this.checkBox_SERVICE.AutoSize = true;
            this.checkBox_SERVICE.Checked = true;
            this.checkBox_SERVICE.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_SERVICE.Location = new System.Drawing.Point(6, 225);
            this.checkBox_SERVICE.Name = "checkBox_SERVICE";
            this.checkBox_SERVICE.Size = new System.Drawing.Size(85, 21);
            this.checkBox_SERVICE.TabIndex = 26;
            this.checkBox_SERVICE.Text = "SERVICE";
            this.checkBox_SERVICE.UseVisualStyleBackColor = true;
            // 
            // checkBox_SERVICEREGISTRATIONPERSISTANCE
            // 
            this.checkBox_SERVICEREGISTRATIONPERSISTANCE.AutoSize = true;
            this.checkBox_SERVICEREGISTRATIONPERSISTANCE.Checked = true;
            this.checkBox_SERVICEREGISTRATIONPERSISTANCE.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_SERVICEREGISTRATIONPERSISTANCE.Location = new System.Drawing.Point(6, 304);
            this.checkBox_SERVICEREGISTRATIONPERSISTANCE.Name = "checkBox_SERVICEREGISTRATIONPERSISTANCE";
            this.checkBox_SERVICEREGISTRATIONPERSISTANCE.Size = new System.Drawing.Size(283, 21);
            this.checkBox_SERVICEREGISTRATIONPERSISTANCE.TabIndex = 25;
            this.checkBox_SERVICEREGISTRATIONPERSISTANCE.Text = "SERVICEREGISTRATIONPERSISTANCE";
            this.checkBox_SERVICEREGISTRATIONPERSISTANCE.UseVisualStyleBackColor = true;
            // 
            // checkBox_SERVICEREGISTRATIONAPPLICATION
            // 
            this.checkBox_SERVICEREGISTRATIONAPPLICATION.AutoSize = true;
            this.checkBox_SERVICEREGISTRATIONAPPLICATION.Checked = true;
            this.checkBox_SERVICEREGISTRATIONAPPLICATION.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_SERVICEREGISTRATIONAPPLICATION.Location = new System.Drawing.Point(6, 277);
            this.checkBox_SERVICEREGISTRATIONAPPLICATION.Name = "checkBox_SERVICEREGISTRATIONAPPLICATION";
            this.checkBox_SERVICEREGISTRATIONAPPLICATION.Size = new System.Drawing.Size(277, 21);
            this.checkBox_SERVICEREGISTRATIONAPPLICATION.TabIndex = 24;
            this.checkBox_SERVICEREGISTRATIONAPPLICATION.Text = "SERVICEREGISTRATIONAPPLICATION";
            this.checkBox_SERVICEREGISTRATIONAPPLICATION.UseVisualStyleBackColor = true;
            // 
            // checkBox_ISERVICES
            // 
            this.checkBox_ISERVICES.AutoSize = true;
            this.checkBox_ISERVICES.Checked = true;
            this.checkBox_ISERVICES.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_ISERVICES.Location = new System.Drawing.Point(6, 183);
            this.checkBox_ISERVICES.Name = "checkBox_ISERVICES";
            this.checkBox_ISERVICES.Size = new System.Drawing.Size(97, 21);
            this.checkBox_ISERVICES.TabIndex = 23;
            this.checkBox_ISERVICES.Text = "ISERVICES";
            this.checkBox_ISERVICES.UseVisualStyleBackColor = true;
            // 
            // checkBox_IREPOSITORIES
            // 
            this.checkBox_IREPOSITORIES.AutoSize = true;
            this.checkBox_IREPOSITORIES.Checked = true;
            this.checkBox_IREPOSITORIES.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_IREPOSITORIES.Location = new System.Drawing.Point(6, 163);
            this.checkBox_IREPOSITORIES.Name = "checkBox_IREPOSITORIES";
            this.checkBox_IREPOSITORIES.Size = new System.Drawing.Size(132, 21);
            this.checkBox_IREPOSITORIES.TabIndex = 22;
            this.checkBox_IREPOSITORIES.Text = "IREPOSITORIES";
            this.checkBox_IREPOSITORIES.UseVisualStyleBackColor = true;
            // 
            // checkBox_DTOs
            // 
            this.checkBox_DTOs.AutoSize = true;
            this.checkBox_DTOs.Checked = true;
            this.checkBox_DTOs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_DTOs.Location = new System.Drawing.Point(6, 123);
            this.checkBox_DTOs.Name = "checkBox_DTOs";
            this.checkBox_DTOs.Size = new System.Drawing.Size(64, 21);
            this.checkBox_DTOs.TabIndex = 21;
            this.checkBox_DTOs.Text = "DTOs";
            this.checkBox_DTOs.UseVisualStyleBackColor = true;
            // 
            // checkBox_REPOSITORIES
            // 
            this.checkBox_REPOSITORIES.AutoSize = true;
            this.checkBox_REPOSITORIES.Checked = true;
            this.checkBox_REPOSITORIES.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_REPOSITORIES.Location = new System.Drawing.Point(6, 206);
            this.checkBox_REPOSITORIES.Name = "checkBox_REPOSITORIES";
            this.checkBox_REPOSITORIES.Size = new System.Drawing.Size(129, 21);
            this.checkBox_REPOSITORIES.TabIndex = 20;
            this.checkBox_REPOSITORIES.Text = "REPOSITORIES";
            this.checkBox_REPOSITORIES.UseVisualStyleBackColor = true;
            // 
            // checkBox_CONTROLLER
            // 
            this.checkBox_CONTROLLER.AutoSize = true;
            this.checkBox_CONTROLLER.Checked = true;
            this.checkBox_CONTROLLER.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_CONTROLLER.Location = new System.Drawing.Point(6, 143);
            this.checkBox_CONTROLLER.Name = "checkBox_CONTROLLER";
            this.checkBox_CONTROLLER.Size = new System.Drawing.Size(122, 21);
            this.checkBox_CONTROLLER.TabIndex = 19;
            this.checkBox_CONTROLLER.Text = "CONTROLLER";
            this.checkBox_CONTROLLER.UseVisualStyleBackColor = true;
            // 
            // Gerador_Codigo_Clean_Architecture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1317, 749);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btn_Gerar_Tudo);
            this.Controls.Add(this.button_Gerar_Codigo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox_Tabelas);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Gerador_Codigo_Clean_Architecture";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerador_Codigo_Clean_Architecture";
            this.Load += new System.EventHandler(this.Gerador_Codigo_Clean_Architecture_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Gerar_Tudo;
        private System.Windows.Forms.Button button_Gerar_Codigo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox Lb_NameSpace_DAL;
        private System.Windows.Forms.Label label10;
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
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox checkBox_SERVICEREGISTRATIONAPPLICATION;
        private System.Windows.Forms.CheckBox checkBox_ISERVICES;
        private System.Windows.Forms.CheckBox checkBox_IREPOSITORIES;
        private System.Windows.Forms.CheckBox checkBox_DTOs;
        private System.Windows.Forms.CheckBox checkBox_REPOSITORIES;
        private System.Windows.Forms.CheckBox checkBox_CONTROLLER;
        private System.Windows.Forms.CheckBox checkBox_SERVICEREGISTRATIONPERSISTANCE;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkBox_SERVICE;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox checkBox_MAPPINGS;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label14;
    }
}