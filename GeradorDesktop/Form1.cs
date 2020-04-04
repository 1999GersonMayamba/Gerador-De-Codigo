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
    public partial class Form1 : Form
    {
        Mapeamento mapeamento = new Mapeamento();
        Arquivo Arquivo = new Arquivo();

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Carregar_Tabelas_Click(object sender, EventArgs e)
        {
            //"server=localhost;port=3306;User Id=root; database = AppEvent; password = Luseymayamba123#";
            ConectionLocal.URL = "server = " + textBox_Servidor.Text + "; port = " + textBox_Porta.Text + ";User Id = " + textBox_User.Text + "; database = " + textBox_BD.Text + "; password = " + textBox_Senha.Text;
           // ConectionLocal.URL = "server=localhost;port=3306;User Id=root; database = DaTerraKambio; password = Luseymayamba123#";
            List<string> Lista =  mapeamento.RetornarTabelas();
            listBox_Tabelas.DataSource = Lista;
        }

        private void listBox_Tabelas_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    DialogResult result = MessageBox.Show("Deseja Gerar: Info, DAL, Buisenes, Procedimentos Sql´e Controller Da API Desta Tabela ?", "", MessageBoxButtons.YesNo);
            //    if (result == DialogResult.Yes)
            //    {

            //        object ItemSelecionado = listBox_Tabelas.SelectedItem;
            //        string retorno = Arquivo.GerarInfoDaTabela(ItemSelecionado.ToString(), Lb_NameSpace.Text, folderBrowserDialog1.SelectedPath);
            //        MessageBox.Show(retorno);
            //        string retorno2 = Arquivo.GerarDALDaTabela(ItemSelecionado.ToString(), Lb_NameSpace.Text, folderBrowserDialog1.SelectedPath);
            //        MessageBox.Show(retorno2);

            //        string retorno3 = Arquivo.GerarScriptSql(ItemSelecionado.ToString(), folderBrowserDialog1.SelectedPath);
            //        MessageBox.Show(retorno3);

            //        string retorno4 = Arquivo.GerarControllerAPI(ItemSelecionado.ToString(), textBox_NameSpace_API_Project.Text, folderBrowserDialog1.SelectedPath);
            //        MessageBox.Show(retorno4);
            //    }
            //    else
            //    {

            //    }

            //}catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

        }

        private void btn_Diretorio_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Quando clicar em gerar
        private void button_All_Click(object sender, EventArgs e)
        {
            object ItemSelecionado = listBox_Tabelas.SelectedItem;

            try
            {

                if(checkBox_INFO.Checked == false && checkBox_DAL.Checked == false && checkBox_API.Checked == false && checkBox_ScriptSql.Checked == false)
                {
                    MessageBox.Show("Tem de habilitar por apenas um dos itens que deseja gerar!");
                }
                else
                {
                    if (checkBox_INFO.Checked == true)
                    {
                        //GERAR INFO
                        string retorno = Arquivo.GerarInfoDaTabela(ItemSelecionado.ToString(), Lb_NameSpace.Text, folderBrowserDialog1.SelectedPath);
                        //MessageBox.Show(retorno);
                    }

                    if (checkBox_DAL.Checked == true)
                    {
                        //GERAR DAL
                        string retorno2 = Arquivo.GerarDALDaTabela(ItemSelecionado.ToString(), Lb_NameSpace.Text, folderBrowserDialog1.SelectedPath);
                        //MessageBox.Show(retorno2);
                    }

                    if (checkBox_API.Checked == true)
                    {
                        //GERAR SCRIPT SQL
                        string retorno3 = Arquivo.GerarScriptSql(ItemSelecionado.ToString(), folderBrowserDialog1.SelectedPath);
                        //MessageBox.Show(retorno3);
                    }

                    if (checkBox_ScriptSql.Checked == true)
                    {
                        //GERAR CONTROLLER API
                        string retorno4 = Arquivo.GerarControllerAPI(ItemSelecionado.ToString(), textBox_NameSpace_API_Project.Text, folderBrowserDialog1.SelectedPath);
                        //MessageBox.Show(retorno4);
                    }

                    if(checkBox_ConsumirAPI.Checked == true)
                    {
                        //GERAR Classe Consumo Da API No C# 
                        string retorno5 = Arquivo.GerarClasseConsumirAPI_Csharp(ItemSelecionado.ToString(), textBox_NameSpaceConsumirAPI.Text, folderBrowserDialog1.SelectedPath);
                        //MessageBox.Show(retorno5);
                    }

                    MessageBox.Show("Todos Item Foram Gerados Com Sucesso INFO, DAL, API, SCRIP SQL e Classe De Consumo da API no C#");
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
