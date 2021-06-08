using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorDesktop
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento invocado quando se clicar no pictureBox_Mysql, para abrir o menu de gerar código para Mysql
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_Mysql_Click(object sender, EventArgs e)
        {
            Gerador_Codigo_Mysql gerador_Codigo_Mysql = new Gerador_Codigo_Mysql();
            gerador_Codigo_Mysql.Show();
        }

        /// <summary>
        /// Evento invocado quando se clicar no panel_Mysql, para abrir o menu de gerar código para Mysql
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel_Mysql_Click(object sender, EventArgs e)
        {
            Gerador_Codigo_Mysql gerador_Codigo_Mysql = new Gerador_Codigo_Mysql();
            gerador_Codigo_Mysql.Show();
        }

        /// <summary>
        /// Evento invocado quando se clicar no label_Mysql, para abrir o menu de gerar código para Mysql
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label_Mysql_Click(object sender, EventArgs e)
        {
            Gerador_Codigo_Mysql gerador_Codigo_Mysql = new Gerador_Codigo_Mysql();
            gerador_Codigo_Mysql.Show();
        }

        /// <summary>
        /// Evento invocado quando se clicar no pictureBox_Sql_Server, para abrir o menu de gerar código para Sql Server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_Sql_Server_Click(object sender, EventArgs e)
        {
            Gerador_Codigo_Sql_Server gerador_Codigo_Sql_Server = new Gerador_Codigo_Sql_Server();
            gerador_Codigo_Sql_Server.Show();
        }

        /// <summary>
        /// Evento invocado quando se clicar no panel_Sql_Server, para abrir o menu de gerar código para Sql Server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel_Sql_Server_Click(object sender, EventArgs e)
        {
            Gerador_Codigo_Sql_Server gerador_Codigo_Sql_Server = new Gerador_Codigo_Sql_Server();
            gerador_Codigo_Sql_Server.Show();
        }

        /// <summary>
        /// Evento invocado quando se clicar no label_Sql_Server, para abrir o menu de gerar código para Sql Server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label_Sql_Server_Click(object sender, EventArgs e)
        {
            Gerador_Codigo_Sql_Server gerador_Codigo_Sql_Server = new Gerador_Codigo_Sql_Server();
            gerador_Codigo_Sql_Server.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Gerador_Codigo_Clean_Architecture clean_Architecture = new Gerador_Codigo_Clean_Architecture();
            clean_Architecture.Show();
        }
    }
}
