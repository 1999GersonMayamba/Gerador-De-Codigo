using Camada_Info.GeradorInfo;
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
    public partial class Gerador_Codigo_Clean_Architecture : Form
    {

        Mapeamento mapeamento = new Mapeamento();
        ArquivoCleanAchitecture CleanAchitecture = new ArquivoCleanAchitecture();
        ArquivoSqlServer ArquivoSqlServer = new ArquivoSqlServer();

        public Gerador_Codigo_Clean_Architecture()
        {
            InitializeComponent();
        }

        private void Gerador_Codigo_Clean_Architecture_Load(object sender, EventArgs e)
        {
           // folderBrowserDialog1.ShowDialog();
        }

        private void btn_Diretorio_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
        }

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
                    //Gerar as interface repository
                    string retorno = CleanAchitecture.GerarInterfaceRepository(ItemSelecionado.TABLE_NAME, Lb_NameSpace.Text, folderBrowserDialog1.SelectedPath);
                    //Gerar as interfaces Service
                    string retorno1 = CleanAchitecture.GerarInterfaceService(ItemSelecionado.TABLE_NAME, Lb_NameSpace.Text, folderBrowserDialog1.SelectedPath);

                    MessageBox.Show("Todos Item Foram Gerados Com Sucesso INFO, DAL, API, SCRIP SQL e Classe De Consumo da API no C#");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Carregar_Tabelas_SqlServer_Click(object sender, EventArgs e)
        {
            try
            {
                ConectionLocal.URL = "server = " + textBox_Servidor.Text + ";User Id = " + textBox_User.Text + "; database = " + textBox_BD.Text + "; password = " + textBox_Senha.Text;
                List<Tb_SchemaSqlServer> Lista = mapeamento.RetornarTabelasSqlServer();
                listBox_Tabelas.DataSource = Lista;
                listBox_Tabelas.DisplayMember = "TABLE_NAME";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
