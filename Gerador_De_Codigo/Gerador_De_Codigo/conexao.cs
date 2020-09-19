using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Camada_Info.GeradorInfo;
using MySql.Data.MySqlClient;

namespace Gerador_De_Codigo
{
  public  class conexao
    {
        MySqlConnection Connection = new MySqlConnection();

        public conexao()
        {
            Connection.ConnectionString = ConectionLocal.URL;//"server=localhost;port=3306;User Id=root; database = DaTerraKambio; password = Luseymayamba123#";
        }

        public MySqlConnection connectar()
        {
            if(Connection.State == System.Data.ConnectionState.Closed)
            {
                Connection.Open();
            }

            return Connection;
        }

        public MySqlConnection desconectar()
        {
            if (Connection.State == System.Data.ConnectionState.Open)
            {
                Connection.Close();
            }

            return Connection;
        }
    }

}
