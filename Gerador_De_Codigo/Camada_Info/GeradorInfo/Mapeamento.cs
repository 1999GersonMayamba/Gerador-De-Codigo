using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camada_Info.GeradorInfo
{
  public  class Mapeamento
    {
        public List<Tb_Estrutura_Info> RetornarEstruturaDaTabela(string NomeDaTabela)
        {
            try
            {
                conexao connection = new conexao();
                string query = "describe " + NomeDaTabela + ";";
                MySqlCommand command = new MySqlCommand(query, connection.connectar());
                MySqlDataReader dataReader = command.ExecuteReader();
                List<Tb_Estrutura_Info> estrutura_Infos = new List<Tb_Estrutura_Info>();
                while (dataReader.Read())
                {
                    Tb_Estrutura_Info tb_Estrutura = new Tb_Estrutura_Info();
                    tb_Estrutura.Nome = Convert.ToString(dataReader["Field"]);
                    tb_Estrutura.Tipo = Convert.ToString(dataReader["Type"]);
                    estrutura_Infos.Add(tb_Estrutura);
                }

                connection.desconectar();
                return estrutura_Infos;
            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<string> RetornarTabelas()
        {
            try
            {
                conexao connection = new conexao();

                string query = "show tables;";
                MySqlCommand command = new MySqlCommand(query, connection.connectar());
                MySqlDataReader dataReader = command.ExecuteReader();
                List<string> tabelas = new List<string>();
                while (dataReader.Read())
                {
                    //Tb_Estrutura_Info tb_Estrutura = new Tb_Estrutura_Info();
                    string NomeDaTabela = Convert.ToString(dataReader[0]);
                    //tb_Estrutura.Tipo = Convert.ToString(dataReader["Type"]);
                    tabelas.Add(NomeDaTabela);
                }

                connection.desconectar();
                return tabelas;
            }
            catch (MySqlException ex)
            {
                throw ex;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
