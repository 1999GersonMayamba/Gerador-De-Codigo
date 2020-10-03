using Camada_Info.GeradorInfo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerador_De_Codigo_Teste
{
  public  class ConexaoSqlServer
    {
        SqlConnection Connection = new SqlConnection();

        public ConexaoSqlServer()
        {
           // Connection.ConnectionString = ConectionLocal.URL;//"server=localhost;User Id=Mayamba; database = TecnoGest; password = 123";
        }

        public SqlConnection connectar(string  _ConnectionString)
        {
            Connection.ConnectionString = _ConnectionString;

            if (Connection.State == System.Data.ConnectionState.Closed)
            {
                Connection.Open();
            }

            return Connection;
        }

        public SqlConnection desconectar(string _ConnectionString)
        {

            Connection.ConnectionString = _ConnectionString;

            if (Connection.State == System.Data.ConnectionState.Open)
            {
                Connection.Close();
            }

            return Connection;
        }
    }
}
