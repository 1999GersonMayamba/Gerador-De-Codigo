using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerador_De_Codigo
{
  public  class TesteSchema
    {

        public  List<string> GetTables()
            {
                List<string> TableNames = new List<string>();
                try
                {
                    using (MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;User Id=root; database = daterrakambio; password = Luseymayamba123#"))
                    {
                        connection.Open();
                        DataTable schema = connection.GetSchema("Tables");

                        foreach (DataRow row in schema.Rows)
                        {
                            TableNames.Add(row[2].ToString());
                        }
                      connection.Close();
                    }

                   
                }
                catch (Exception ex)
                {
                     Console.WriteLine(ex.Message);
                }

                 return TableNames;
            }

        /// <summary> 
        /// 查询数据库中的所有数据类型信息 
        /// </summary> 
        /// <returns></returns> 
        public DataTable GetSchema()
        {
            using (MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;User Id=root; database = AppEvent; password = Luseymayamba123#"))
            {
                connection.Open();
                DataTable data = connection.GetSchema("TABLES", new string[0]);
                connection.Close();
                return data;
            }
        }

        public void ListDatabases()
        {
            var connectionString = "server=localhost;port=3306;User Id=root; database = AppEvent; password = Luseymayamba123#";
            using (var connection = new MySqlConnection(connectionString))
            {
                Console.WriteLine("Databases:");
                var databases = connection.GetSchema("Tables");
                foreach (DataRow database in databases.Rows)
                {
                    Console.WriteLine("Name: {0}", database["database_name"]);
                }
            }
        }

        public List<string> GetProcedures()
        {
            List<string> TableNames = new List<string>();
            try
            {
                using (MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;User Id=root; database = daterrakambio; password = Luseymayamba123#"))
                {
                    connection.Open();
                    DataTable schema = connection.GetSchema("procedures");

                    foreach (DataRow row in schema.Rows)
                    {
                        TableNames.Add(row[2].ToString());
                    }
                    connection.Close();
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return TableNames;
        }

        
    }
}

