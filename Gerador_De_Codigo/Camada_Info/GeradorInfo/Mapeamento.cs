using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camada_Info.GeradorInfo
{
  public  class Mapeamento
    {

        /// <summary>
        /// Método para trazer a estrutura de uma determinada tabela no Mysql
        /// </summary>
        /// <param name="NomeDaTabela"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Método para trazer a lista de tabelas de uma base de dados do Mysql
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Método para trazer a lista de tabelas de uma base de dados do Sql Server
        /// </summary>
        /// <returns></returns>
        public List<Tb_SchemaSqlServer> RetornarTabelasSqlServer()
        {
            try
            {
                ConexaoSqlServer connection = new ConexaoSqlServer();

                string query = "SELECT * FROM INFORMATION_SCHEMA.TABLES;";
                SqlCommand command = new SqlCommand(query, connection.connectar());
                SqlDataReader dataReader = command.ExecuteReader();
                List<Tb_SchemaSqlServer>  tb_SchemaSqlServers  = new List<Tb_SchemaSqlServer>();
                while (dataReader.Read())
                {
                    Tb_SchemaSqlServer tb_SchemaSqlServer = new Tb_SchemaSqlServer();
                    tb_SchemaSqlServer.TABLE_CATALOG = Convert.ToString(dataReader["TABLE_CATALOG"]);
                    tb_SchemaSqlServer.TABLE_NAME = Convert.ToString(dataReader["TABLE_NAME"]);
                    tb_SchemaSqlServer.TABLE_SCHEMA = Convert.ToString(dataReader["TABLE_SCHEMA"]);
                    tb_SchemaSqlServers.Add(tb_SchemaSqlServer);
                }

                connection.desconectar();
                return tb_SchemaSqlServers;
            }
            catch (SqlException ex)
            {
                throw ex;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método para trazer a estrutura de uma determinada tabela do SqlServer
        /// </summary>
        /// <param name="NomeDaTabela"></param>
        /// <returns></returns>
        public List<Tb_Estrutura_Info> RetornarEstruturaDaTabelaSqlServer(string NomeDaTabela)
        {
            try
            {
                //select * FROM   INFORMATION_SCHEMA.Columns where table_name = 'Tb_Classe';
                ConexaoSqlServer connection = new ConexaoSqlServer();
                string query = "select * FROM   INFORMATION_SCHEMA.Columns where table_name = '" + NomeDaTabela + "'";
                SqlCommand command = new SqlCommand(query, connection.connectar());
                SqlDataReader dataReader = command.ExecuteReader();
                List<Tb_Estrutura_Info> estrutura_Infos = new List<Tb_Estrutura_Info>();
                while (dataReader.Read())
                {
                    Tb_Estrutura_Info tb_Estrutura = new Tb_Estrutura_Info();
                    tb_Estrutura.Nome = Convert.ToString(dataReader["COLUMN_NAME"]);
                    tb_Estrutura.Tipo = Convert.ToString(dataReader["DATA_TYPE"]);
                    tb_Estrutura.Base_Dados= Convert.ToString(dataReader["TABLE_CATALOG"]);
                    tb_Estrutura.Estrutura_Base_Dados = Convert.ToString(dataReader["TABLE_SCHEMA"]);
                    tb_Estrutura.Maximo_Caracters = Convert.ToString(dataReader["CHARACTER_MAXIMUM_LENGTH"]);
                    tb_Estrutura.ORDINAL_POSITION = Convert.ToInt16(dataReader["ORDINAL_POSITION"]);
                    estrutura_Infos.Add(tb_Estrutura);
                }

                connection.desconectar();
                return estrutura_Infos;
            }
            catch (SqlException ex)
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
