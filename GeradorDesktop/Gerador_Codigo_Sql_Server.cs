using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Camada_Info.GeradorInfo;

namespace GeradorDesktop
{
    public partial class Gerador_Codigo_Sql_Server : Form
    {
        Mapeamento mapeamento = new Mapeamento();
        Arquivo Arquivo = new Arquivo();
        ArquivoSqlServer ArquivoSqlServer = new ArquivoSqlServer();

        public Gerador_Codigo_Sql_Server()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento invocado quando clicar bo botão carregar tabelas do Sql Server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Carregar_Tabelas_SqlServer_Click(object sender, EventArgs e)
        {
            try
            {
                ConectionLocal.URL = "server = " + textBox_Servidor.Text + ";User Id = " + textBox_User.Text + "; database = " + textBox_BD.Text + "; password = " + textBox_Senha.Text;
                List<Tb_SchemaSqlServer> Lista = mapeamento.RetornarTabelasSqlServer();
                listBox_Tabelas.DataSource = Lista;
                listBox_Tabelas.DisplayMember = "TABLE_NAME";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Evento invocado quando se clicar no botão gerar, para gerar os código dos arquivos selecionado Ex: DAL, INFO, Sql...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Gerar_Codigo_Click(object sender, EventArgs e)
        {
            var ItemSelecionado = listBox_Tabelas.SelectedItem as Tb_SchemaSqlServer;

            try
            {

                if (checkBox_INFO.Checked == false && checkBox_DAL.Checked == false && checkBox_API.Checked == false && checkBox_ScriptSql.Checked == false)
                {
                    MessageBox.Show("Tem de habilitar por apenas um dos itens que deseja gerar!");
                }
                else
                {
                    if (checkBox_INFO.Checked == true)
                    {
                        //GERAR INFO
                        string retorno = ArquivoSqlServer.GerarInfoDaTabelaSqlServer(ItemSelecionado.TABLE_NAME, Lb_NameSpace.Text, folderBrowserDialog1.SelectedPath);
                        //MessageBox.Show(retorno);
                    }

                    if (checkBox_DAL.Checked == true)
                    {
                        //GERAR DAL
                        string retorno2 = ArquivoSqlServer.GerarDALDaTabelaSqlServer(ItemSelecionado.TABLE_NAME, Lb_NameSpace.Text, folderBrowserDialog1.SelectedPath);
                        //MessageBox.Show(retorno2);
                    }

                    if (checkBox_ScriptSql.Checked == true)
                    {
                        //GERAR SCRIPT SQL
                        string retorno3 = ArquivoSqlServer.GerarScriptSqlServer(ItemSelecionado, folderBrowserDialog1.SelectedPath);
                        //MessageBox.Show(retorno3);
                    }

                    if (checkBox_API.Checked == true)
                    {
                        //GERAR CONTROLLER API
                        //string retorno4 = Arquivo.GerarControllerAPI(ItemSelecionado.ToString(), textBox_NameSpace_API_Project.Text, folderBrowserDialog1.SelectedPath, Lb_NameSpace.Text);
                        //MessageBox.Show(retorno4);
                    }

                    if (checkBox_ConsumirAPI.Checked == true)
                    {
                        //GERAR Classe Consumo Da API No C# 
                       // string retorno5 = Arquivo.GerarClasseConsumirAPI_Csharp(ItemSelecionado.ToString(), textBox_NameSpaceConsumirAPI.Text, folderBrowserDialog1.SelectedPath);
                        //MessageBox.Show(retorno5);
                    }

                    MessageBox.Show("Todos Item Foram Gerados Com Sucesso INFO, DAL, API, SCRIP SQL e Classe De Consumo da API no C#");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Evento invocado quando se clicar no botão de selecionar o directorio em que os arquivos serão selecionados
        /// Ex: c://Mayamba/Flis/App.cs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Diretorio_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
        }
    }
}
