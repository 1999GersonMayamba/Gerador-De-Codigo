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

                if (checkBox_CONTROLLER.Checked == false && checkBox_DTOs.Checked == false && checkBox_IREPOSITORIES.Checked == false && checkBox_ISERVICES.Checked == false && checkBox_REPOSITORIES.Checked == false && checkBox_SERVICEREGISTRATIONAPPLICATION.Checked == false && checkBox_SERVICEREGISTRATIONPERSISTANCE.Checked == false && checkBox_SERVICE.Checked == false && checkBox_MAPPINGS.Checked == false)
                {
                    MessageBox.Show("Tem de habilitar por apenas um dos itens que deseja gerar!");
                }
                else
                {
                    //Gerar as interface repository
                    string retorno = CleanAchitecture.GerarInterfaceRepository(ItemSelecionado.TABLE_NAME, Lb_NameSpace.Text, folderBrowserDialog1.SelectedPath);
                    //Gerar as interfaces Service
                    string retorno1 = CleanAchitecture.GerarInterfaceService(ItemSelecionado.TABLE_NAME, Lb_NameSpace.Text, folderBrowserDialog1.SelectedPath);
                    //Gerar as DTOs
                    string retorno2 = CleanAchitecture.GerarDTO(ItemSelecionado.TABLE_NAME, Lb_NameSpace.Text, folderBrowserDialog1.SelectedPath);
                    //Gerar as Service
                    string retorno3 = CleanAchitecture.GerarService(ItemSelecionado.TABLE_NAME, Lb_NameSpace.Text, folderBrowserDialog1.SelectedPath);
                    //Gerar as Repository
                    string retorno4 = CleanAchitecture.GerarRepositories(ItemSelecionado.TABLE_NAME, Lb_NameSpace.Text, folderBrowserDialog1.SelectedPath);

                    //Gerar controller
                    string retorno5 = CleanAchitecture.GerarControllerAPI(ItemSelecionado.TABLE_NAME, Lb_NameSpace.Text, folderBrowserDialog1.SelectedPath, null);

                    //Gerar ServiceRegistrationApplication
                    string retorno6 = CleanAchitecture.GerarServiceRegistrationApplication(ItemSelecionado.TABLE_NAME, Lb_NameSpace.Text, folderBrowserDialog1.SelectedPath, null);

                    //Gerar ServiceRegistrationPersistence
                    string retorno7 = CleanAchitecture.GerarServiceRegistrationPersistence(ItemSelecionado.TABLE_NAME, Lb_NameSpace.Text, folderBrowserDialog1.SelectedPath, null);

                    //Gerar ServiceRegistrationPersistence
                    string retorno8 = CleanAchitecture.GerarGeneralProfile(ItemSelecionado.TABLE_NAME, Lb_NameSpace.Text, folderBrowserDialog1.SelectedPath, null);


                    MessageBox.Show("Todos Item Foram Gerados Com Sucesso DTOs, CONTROLLER, IREPOSITORIES, ISERVICES, SERVICE, SERVICEREGISTRATION");
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

        private void btn_Gerar_Tudo_Click(object sender, EventArgs e)
        {
            try
            {

                foreach (var x in listBox_Tabelas.Items)
                {
                    var ItemSelecionado = x as Tb_SchemaSqlServer;

                    if (checkBox_CONTROLLER.Checked == false && checkBox_DTOs.Checked == false && checkBox_IREPOSITORIES.Checked == false && checkBox_ISERVICES.Checked == false && checkBox_REPOSITORIES.Checked == false && checkBox_SERVICEREGISTRATIONAPPLICATION.Checked == false && checkBox_SERVICEREGISTRATIONPERSISTANCE.Checked == false && checkBox_SERVICE.Checked == false && checkBox_MAPPINGS.Checked == false)
                    {
                        MessageBox.Show("Tem de habilitar por apenas um dos itens que deseja gerar!");
                        return;
                    }
                    else
                    {
                        if (checkBox_CONTROLLER.Checked == true)
                        {
                            //Gerar controller
                            string retorno5 = CleanAchitecture.GerarControllerAPI(ItemSelecionado.TABLE_NAME, Lb_NameSpace.Text, folderBrowserDialog1.SelectedPath, null);
                        }

                        if (checkBox_DTOs.Checked == true)
                        {
                            //Gerar as DTOs
                            string retorno2 = CleanAchitecture.GerarDTO(ItemSelecionado.TABLE_NAME, Lb_NameSpace.Text, folderBrowserDialog1.SelectedPath);
                        }

                        if (checkBox_IREPOSITORIES.Checked == true)
                        {
                            //Gerar as interface repository
                            string retorno = CleanAchitecture.GerarInterfaceRepository(ItemSelecionado.TABLE_NAME, Lb_NameSpace.Text, folderBrowserDialog1.SelectedPath);
                        }

                        if (checkBox_ISERVICES.Checked == true)
                        {
                            //Gerar as interfaces Service
                            string retorno1 = CleanAchitecture.GerarInterfaceService(ItemSelecionado.TABLE_NAME, Lb_NameSpace.Text, folderBrowserDialog1.SelectedPath);
                        }

                        if (checkBox_REPOSITORIES.Checked == true)
                        {
                            //Gerar as Repository
                            string retorno4 = CleanAchitecture.GerarRepositories(ItemSelecionado.TABLE_NAME, Lb_NameSpace.Text, folderBrowserDialog1.SelectedPath);
                        }


                        if (checkBox_SERVICEREGISTRATIONAPPLICATION.Checked == true)
                        {
                            //Gerar ServiceRegistrationApplication
                            string retorno6 = CleanAchitecture.GerarServiceRegistrationApplication(ItemSelecionado.TABLE_NAME, Lb_NameSpace.Text, folderBrowserDialog1.SelectedPath, null);
                        }


                        if (checkBox_SERVICEREGISTRATIONPERSISTANCE.Checked == true)
                        {
                            //Gerar ServiceRegistrationPersistence
                            string retorno7 = CleanAchitecture.GerarServiceRegistrationPersistence(ItemSelecionado.TABLE_NAME, Lb_NameSpace.Text, folderBrowserDialog1.SelectedPath, null);
                        }

                        if (checkBox_SERVICE.Checked == true)
                        {
                            //Gerar as Service
                            string retorno3 = CleanAchitecture.GerarService(ItemSelecionado.TABLE_NAME, Lb_NameSpace.Text, folderBrowserDialog1.SelectedPath);
                        }

                        if (checkBox_MAPPINGS.Checked == true)
                        {
                            //Gerar ServiceRegistrationPersistence
                            string retorno8 = CleanAchitecture.GerarGeneralProfile(ItemSelecionado.TABLE_NAME, Lb_NameSpace.Text, folderBrowserDialog1.SelectedPath, null);

                        }

                        // MessageBox.Show("Todos Item Foram Gerados Com Sucesso INFO, DAL, API, SCRIP SQL e Classe De Consumo da API no C#");
                    }
                }


                MessageBox.Show("Todos Item Foram Gerados Com Sucesso DTOs, CONTROLLER, IREPOSITORIES, ISERVICES, SERVICE, SERVICEREGISTRATION");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
