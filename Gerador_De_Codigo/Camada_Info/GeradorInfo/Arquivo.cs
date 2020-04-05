using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camada_Info.GeradorInfo
{
   public class Arquivo
    {
        public string GerarInfoDaTabela(string NomeDaTabela, string NameSpaceDoProjecto, string DirectorioAondeSeraGeradoAInfo)
        {
            try
            {
                Mapeamento mapeamento = new Mapeamento();

                string dr = DirectorioAondeSeraGeradoAInfo + @"\INFO";
                string Caminho = DirectorioAondeSeraGeradoAInfo + @"\INFO" + @"\" + NomeDaTabela + "_INFO.cs";

                if (Directory.Exists(dr) == false)
                {
                    Directory.CreateDirectory(dr);

                    if (File.Exists(Caminho) == true)
                    {
                        File.Delete(Caminho);
                    }
                    else
                    {
                        FileStream file = File.Create(Caminho);
                        file.Close();
                    }
                }
                else
                {
                    if (File.Exists(Caminho) == true)
                    {
                        File.Delete(Caminho);
                    }
                    else
                    {
                        FileStream file = File.Create(Caminho);
                        file.Close();
                    }
                }

                //Começa a escrever aqui no arquivo Begin
                using (StreamWriter stream = new StreamWriter(Caminho, true))
                {
                    stream.WriteLine("/*Gerado no Gerador de Codigo Do Engº Gerson Z. Maiamba");
                    stream.WriteLine("Data: " + DateTime.Now);
                    stream.WriteLine("Direitos autorais de Engº Gerson Z. Maiamba*/\n");
                    stream.WriteLine("using System;");
                    stream.WriteLine("using System.Collections.Generic;");
                    stream.WriteLine("using System.Data;");
                    stream.WriteLine("using System.Linq;");
                    stream.WriteLine("using System.Text;");
                    stream.WriteLine("using System.Threading.Tasks;\n\n\n");
                    stream.WriteLine("namespace " + NameSpaceDoProjecto + ".INFO");
                    stream.WriteLine("{");
                    stream.WriteLine("\tpublic class " + NomeDaTabela + "_INFO");
                    stream.WriteLine("\t\t{");
                    List<Tb_Estrutura_Info> estrutura_Infos = mapeamento.RetornarEstruturaDaTabela(NomeDaTabela);

                    //Prenche aqui o arquivo com as propriedades Begin
                    foreach (var x in estrutura_Infos)
                    {
                        if (x.Tipo.Contains("int"))
                        {
                            x.Tipo = "int";
                            stream.WriteLine("\t\t\tpublic " + x.Tipo + " " + x.Nome + "{ get; set; }");
                        }
                        else if (x.Tipo.Contains("char"))
                        {
                            x.Tipo = "string";
                            stream.WriteLine("\t\t\tpublic " + x.Tipo + " " + x.Nome + "{ get; set; }");
                        }
                        else if (x.Tipo.Contains("varchar"))
                        {
                            x.Tipo = "string";
                            stream.WriteLine("\t\t\tpublic " + x.Tipo + " " + x.Nome + "{ get; set; }");
                        }
                        else if (x.Tipo.Contains("longtext"))
                        {
                            x.Tipo = "string";
                            stream.WriteLine("\t\t\tpublic " + x.Tipo + " " + x.Nome + "{ get; set; }");
                        }
                        else if (x.Tipo.Contains("float"))
                        {
                            x.Tipo = "float";
                            stream.WriteLine("\t\t\tpublic " + x.Tipo + " " + x.Nome + "{ get; set; }");
                        }
                        else if (x.Tipo.Contains("decimal"))
                        {
                            x.Tipo = "decimal";
                            stream.WriteLine("\t\t\tpublic " + x.Tipo + " " + x.Nome + "{ get; set; }");
                        }
                        else
                        {
                            stream.WriteLine("\t\t\tpublic " + x.Tipo + " " + x.Nome + "{ get; set; }");
                        }
                    }
                    stream.WriteLine("\t\t\tpublic " + "string" + " " + "Opcao" + "{ get; set; }");
                    //Prenche aqui o arquivo com as propriedades End

                    stream.WriteLine("\t\t}");
                    stream.WriteLine("}");

                    stream.Close();
                }
                //Começa a escrever aqui no arquivo End


                return "Info Gerado Com Sucesso No Diretorio Informado";

            }catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public string GerarDALDaTabela(string NomeDaTabela, string NameSpaceDoProjecto, string DirectorioAondeSeraGeradoAInfo)
        {
            try
            {
                Mapeamento mapeamento = new Mapeamento();

                string dr = DirectorioAondeSeraGeradoAInfo + @"\DAL";
                string Caminho = DirectorioAondeSeraGeradoAInfo + @"\DAL" + @"\" + NomeDaTabela + "_DAL.cs";

                if (Directory.Exists(dr) == false)
                {
                    Directory.CreateDirectory(dr);

                    if (File.Exists(Caminho) == true)
                    {
                        File.Delete(Caminho);
                    }
                    else
                    {
                        FileStream file = File.Create(Caminho);
                        file.Close();
                    }
                }else
                {
                    if (File.Exists(Caminho) == true)
                    {
                        File.Delete(Caminho);
                    }
                    else
                    {
                        FileStream file = File.Create(Caminho);
                        file.Close();
                    }
                }


                //Começa a escrever aqui no arquivo Begin
                using (StreamWriter stream = new StreamWriter(Caminho, true))
                {
                    stream.WriteLine("/*Gerado no Gerador de Codigo Do Engº Gerson Z. Maiamba");
                    stream.WriteLine("Data: " + DateTime.Now );
                    stream.WriteLine("Direitos autorais de Engº Gerson Z. Maiamba*/\n");
                    //Cabeçalho das biblotecas inicio namespaces
                    stream.WriteLine("using System;");
                    stream.WriteLine("using System.Collections.Generic;");
                    stream.WriteLine("using System.Data;");
                    stream.WriteLine("using System.Linq;");
                    stream.WriteLine("using System.Text;");
                    stream.WriteLine("using " + NameSpaceDoProjecto + ".INFO;");
                    stream.WriteLine("using " + NameSpaceDoProjecto + ";");
                    stream.WriteLine("using MySql.Data.MySqlClient;");
                    stream.WriteLine("using System.Threading.Tasks;\n\n\n");
                    //Cabeçalho das biblotecas fim namespaces
                    stream.WriteLine("namespace " + NameSpaceDoProjecto + ".DAL"); // Escreve o namespace do projecto no arquivo
                    stream.WriteLine("{");// adiciona a primeira chaveta após o namespcae
                    stream.WriteLine("\tpublic class " + NomeDaTabela + "_DAL"); // Adiciona o nome da classe e os seus atributos
                    stream.WriteLine("\t\t{"); //Abre chaves para escrever todo o codigo que deve existir na classe

                    List<Tb_Estrutura_Info> estrutura_Infos = mapeamento.RetornarEstruturaDaTabela(NomeDaTabela); //Chama na base de dados a estrutura de uma tabela

                    stream.WriteLine("\t\t\tconexao connection = new conexao();"); //Adiciona a classe de conexão na classe
                    stream.WriteLine("\t\t\t" + "/*" + "Metodo para fazer um select de todos os dados existenstes na tabela " + NomeDaTabela + "*/");
//------------------------------------------------------------------------------------------------------------------------------
//PRIMEIRO METDO SELECT ALL BEGIN
//-----------------------------------------------------------------------------------------------------------------------------
                   
                    //Inicio do primeiro metodo select all
                    stream.WriteLine("\t\t\tpublic List<" + NomeDaTabela + "_INFO> SelectAll(" + NomeDaTabela + "_INFO " + NomeDaTabela.Remove(0,3) + ")"); //Declara o metodo que restorna a lista de dados
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\ttry");
                    stream.WriteLine("\t\t\t\t\t{");
                    //Todo Codido Try deve ficar aqui dentro
                    stream.WriteLine("\t\t\t\t\t\tMySqlCommand command = new MySqlCommand(\"" + "PR_" + NomeDaTabela +"\"," + "connection.connectar());");
                    stream.WriteLine("\t\t\t\t\t\tcommand.CommandType = System.Data.CommandType.StoredProcedure;");
                    foreach (var x in estrutura_Infos)
                    {
                        stream.WriteLine("\t\t\t\t\t\tcommand.Parameters.Add(new MySqlParameter(\"_" + x.Nome.ToLower() + "\"," + NomeDaTabela.Remove(0, 3) + "." + x.Nome +"));");
                    }
                    stream.WriteLine("\t\t\t\t\t\tcommand.Parameters.Add(new MySqlParameter(\"opcao" + "\"," + NomeDaTabela.Remove(0, 3) + "." + "Opcao" + "));");
                    stream.WriteLine("\t\t\t\t\t\tMySqlDataReader dataReader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);");
                    stream.WriteLine("\t\t\t\t\t\tList<" + NomeDaTabela + "_INFO> " + "Lista" + NomeDaTabela.Remove(0, 3) + "s = new " + "List<" + NomeDaTabela + "_INFO>();\n");
                    stream.WriteLine("\t\t\t\t\t\twhile (dataReader.Read())");
                    stream.WriteLine("\t\t\t\t\t\t{"); //Começa o while
                    stream.WriteLine("\t\t\t\t\t\t\t"  + NomeDaTabela + "_INFO tb" + NomeDaTabela.Remove(0, 3) + " = new " + NomeDaTabela + "_INFO();");
                    foreach (var x in estrutura_Infos)
                    {
                       // Convert.ToString(dataReader["Id_Conversao"]);
                        stream.WriteLine("\t\t\t\t\t\t\ttb" + NomeDaTabela.Remove(0, 3) + "." + x.Nome + " = " + " Convert.ToString(dataReader[\"" + x.Nome + "\"]);");
                    }
                    stream.WriteLine("\t\t\t\t\t\t\t" + "Lista" + NomeDaTabela.Remove(0, 3) + "s.Add(" + "tb" + NomeDaTabela.Remove(0, 3) + ");");
                    stream.WriteLine("\t\t\t\t\t\t}\n"); //Termina o while

                    stream.WriteLine("\t\t\t\t\t\t\tdataReader.Close();");  //Fecha o datareader
                    stream.WriteLine("\t\t\t\t\t\t\tconnection.desconectar();"); //Fecha a conecxão com a Base De Dados
                    stream.WriteLine("\t\t\t\t\t\t\treturn " + "Lista" + NomeDaTabela.Remove(0, 3) + "s;");
                    //Todo Codido Try deve ficar aqui dentro
                    stream.WriteLine("\t\t\t\t\t}");
                    stream.WriteLine("\t\t\t\t\tcatch (MySqlException ex)");
                    stream.WriteLine("\t\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t\tthrow ex;");
                    stream.WriteLine("\t\t\t\t\t}");
                    stream.WriteLine("\t\t\t\t\tcatch (Exception ex)");
                    stream.WriteLine("\t\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t\tthrow ex;");
                    stream.WriteLine("\t\t\t\t\t}");
                    stream.WriteLine("\t\t\t\t}\n\n");
                    //Fim do primeiro metodo select all

//------------------------------------------------------------------------------------------------------------------------------
//PRIMEIRO METDO SELECT ALL AND
//-----------------------------------------------------------------------------------------------------------------------------


//------------------------------------------------------------------------------------------------------------------------------
//SEGUNDO METODO SELECT ONE BEGIN
//-----------------------------------------------------------------------------------------------------------------------------

                    //Inicio Do metodo SelectOne
                    stream.WriteLine("\t\t\t" + "/*" + "Metodo para fazer um select especifico de um elemento existente na tabela." + NomeDaTabela + "*/");
                    stream.WriteLine("\t\t\tpublic " + NomeDaTabela + "_INFO" + " SelectOne(" + NomeDaTabela + "_INFO " + NomeDaTabela.Remove(0, 3) + ")"); //Declara o metodo que restorna a lista de dados
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\ttry");
                    stream.WriteLine("\t\t\t\t\t{");
                    //Todo Codido Try deve ficar aqui dentro
                    stream.WriteLine("\t\t\t\t\t\tMySqlCommand command = new MySqlCommand(\"" + "PR_" + NomeDaTabela + "\"," + "connection.connectar());");
                    stream.WriteLine("\t\t\t\t\t\tcommand.CommandType = System.Data.CommandType.StoredProcedure;");
                    foreach (var x in estrutura_Infos)
                    {
                        stream.WriteLine("\t\t\t\t\t\tcommand.Parameters.Add(new MySqlParameter(\"_" + x.Nome.ToLower() + "\"," + NomeDaTabela.Remove(0, 3) + "." + x.Nome + "));");
                    }
                    stream.WriteLine("\t\t\t\t\t\tcommand.Parameters.Add(new MySqlParameter(\"opcao" + "\"," + NomeDaTabela.Remove(0, 3) + "." + "Opcao" + "));");
                    stream.WriteLine("\t\t\t\t\t\tMySqlDataReader dataReader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);");
                    stream.WriteLine("\t\t\t\t\t\t" + NomeDaTabela + "_INFO tb" + NomeDaTabela.Remove(0, 3) + " = new " + NomeDaTabela + "_INFO();"); 
                    stream.WriteLine("\t\t\t\t\t\twhile (dataReader.Read())");
                    stream.WriteLine("\t\t\t\t\t\t{"); //Começa o while
                   // stream.WriteLine("\t\t\t\t\t\t\t" + NomeDaTabela + "_Info tb" + NomeDaTabela.Remove(0, 3) + " = new " + NomeDaTabela + "_Info();");
                    foreach (var x in estrutura_Infos)
                    {
                        //Convert.ToString(dataReader["Id_Conversao"]);
                        stream.WriteLine("\t\t\t\t\t\t\ttb" + NomeDaTabela.Remove(0, 3) + "." + x.Nome + " = " + " Convert.ToString(dataReader[\"" + x.Nome + "\"]);");
                    }
                   // stream.WriteLine("\t\t\t\t\t\t\t" + "Lista" + NomeDaTabela.Remove(0, 3) + "s.add(" + "tb" + NomeDaTabela.Remove(0, 3) + ");");
                    stream.WriteLine("\t\t\t\t\t\t}\n"); //Termina o while

                    stream.WriteLine("\t\t\t\t\t\t\tdataReader.Close();");  //Fecha o datareader
                    stream.WriteLine("\t\t\t\t\t\t\tconnection.desconectar();"); //Fecha a conecxão com a Base De Dados
                    stream.WriteLine("\t\t\t\t\t\t\treturn " + "tb" + NomeDaTabela.Remove(0, 3) + ";");
                    //Todo Codido Try deve ficar aqui dentro
                    stream.WriteLine("\t\t\t\t\t}");
                    stream.WriteLine("\t\t\t\t\tcatch (MySqlException ex)");
                    stream.WriteLine("\t\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t\tthrow ex;");
                    stream.WriteLine("\t\t\t\t\t}");
                    stream.WriteLine("\t\t\t\t\tcatch (Exception ex)");
                    stream.WriteLine("\t\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t\tthrow ex;");
                    stream.WriteLine("\t\t\t\t\t}");
                    stream.WriteLine("\t\t\t\t}");
                    //Fim Do metodo SelectOne

//------------------------------------------------------------------------------------------------------------------------------
//SEGUNDO METODO SELECT ONE AND
//-----------------------------------------------------------------------------------------------------------------------------


//------------------------------------------------------------------------------------------------------------------------------
//TERCEIRO METODO INSERT BEGIN
//-----------------------------------------------------------------------------------------------------------------------------

                    //Inicio Do metodo Insert
                    stream.WriteLine("\t\t\t" + "/*" + "Metodo para fazer um Insert na Tabela" + NomeDaTabela + "*/");
                    stream.WriteLine("\t\t\tpublic string " + " Insert(" + NomeDaTabela + "_INFO " + NomeDaTabela.Remove(0, 3) + ")"); //Declara o metodo que restorna a lista de dados
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\ttry");
                    stream.WriteLine("\t\t\t\t\t{");
                    //Todo Codido Try deve ficar aqui dentro
                    stream.WriteLine("\t\t\t\t\t\tMySqlCommand command = new MySqlCommand(\"" + "PR_" + NomeDaTabela + "\"," + "connection.connectar());");
                    stream.WriteLine("\t\t\t\t\t\tcommand.CommandType = System.Data.CommandType.StoredProcedure;");
                    foreach (var x in estrutura_Infos)
                    {
                        stream.WriteLine("\t\t\t\t\t\tcommand.Parameters.Add(new MySqlParameter(\"_" + x.Nome.ToLower() + "\"," + NomeDaTabela.Remove(0, 3) + "." + x.Nome + "));");
                    }
                    stream.WriteLine("\t\t\t\t\t\tcommand.Parameters.Add(new MySqlParameter(\"opcao" + "\"," + NomeDaTabela.Remove(0, 3) + "." + "Opcao" + "));");
                    //command.ExecuteNonQuery();
                    //object result = command.ExecuteScalar();
                    //command.Connection.Close();
                    //return result.ToString();
                    stream.WriteLine("\t\t\t\t\t\t//command.ExecuteNonQuery();");  //Executar a Query
                    stream.WriteLine("\t\t\t\t\t\tobject result = command.ExecuteScalar();"); //Le o resultado que a base de ados retorna
                    stream.WriteLine("\t\t\t\t\t\tcommand.Connection.Close();"); //Fecha a conecxão com a Base De Dados
                    stream.WriteLine("\t\t\t\t\t\treturn result.ToString();"); //Retorno da função
                    //Todo Codido Try deve ficar aqui dentro
                    stream.WriteLine("\t\t\t\t\t}");
                    stream.WriteLine("\t\t\t\t\tcatch (MySqlException ex)");
                    stream.WriteLine("\t\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t\treturn ex.Message;");
                    stream.WriteLine("\t\t\t\t\t}");
                    stream.WriteLine("\t\t\t\t\tcatch (Exception ex)");
                    stream.WriteLine("\t\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t\treturn ex.Message;");
                    stream.WriteLine("\t\t\t\t\t}");
                    stream.WriteLine("\t\t\t\t}");

                    //Fim Do metodo Insert

//------------------------------------------------------------------------------------------------------------------------------
//TERCEIRO METODO INSERT AND
//-----------------------------------------------------------------------------------------------------------------------------

//------------------------------------------------------------------------------------------------------------------------------
//QUARTO METODO UPDATE BEGIN
//-----------------------------------------------------------------------------------------------------------------------------
                    
                    //Inicio Do metodo Update
                    stream.WriteLine("\t\t\t" + "/*" + "Metodo para fazer Update de um elemto na tabela" + NomeDaTabela + "*/");
                    stream.WriteLine("\t\t\tpublic string " + " Update(" + NomeDaTabela + "_INFO " + NomeDaTabela.Remove(0, 3) + ")"); //Declara o metodo que restorna a lista de dados
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\ttry");
                    stream.WriteLine("\t\t\t\t\t{");
                    //Todo Codido Try deve ficar aqui dentro
                    stream.WriteLine("\t\t\t\t\t\tMySqlCommand command = new MySqlCommand(\"" + "PR_" + NomeDaTabela + "\"," + "connection.connectar());");
                    stream.WriteLine("\t\t\t\t\t\tcommand.CommandType = System.Data.CommandType.StoredProcedure;");
                    foreach (var x in estrutura_Infos)
                    {
                        stream.WriteLine("\t\t\t\t\t\tcommand.Parameters.Add(new MySqlParameter(\"_" + x.Nome.ToLower() + "\"," + NomeDaTabela.Remove(0, 3) + "." + x.Nome + "));");
                    }
                    stream.WriteLine("\t\t\t\t\t\tcommand.Parameters.Add(new MySqlParameter(\"opcao" + "\"," + NomeDaTabela.Remove(0, 3) + "." + "Opcao" + "));");
                    //command.ExecuteNonQuery();
                    //object result = command.ExecuteScalar();
                    //command.Connection.Close();
                    //return result.ToString();
                    stream.WriteLine("\t\t\t\t\t\t//command.ExecuteNonQuery();");  //Executar a Query
                    stream.WriteLine("\t\t\t\t\t\tobject result = command.ExecuteScalar();"); //Le o resultado que a base de ados retorna
                    stream.WriteLine("\t\t\t\t\t\tcommand.Connection.Close();"); //Fecha a conecxão com a Base De Dados
                    stream.WriteLine("\t\t\t\t\t\treturn result.ToString();"); //Retorno da função
                    //Todo Codido Try deve ficar aqui dentro
                    stream.WriteLine("\t\t\t\t\t}");
                    stream.WriteLine("\t\t\t\t\tcatch (MySqlException ex)");
                    stream.WriteLine("\t\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t\treturn ex.Message;");
                    stream.WriteLine("\t\t\t\t\t}");
                    stream.WriteLine("\t\t\t\t\tcatch (Exception ex)");
                    stream.WriteLine("\t\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t\treturn ex.Message;");
                    stream.WriteLine("\t\t\t\t\t}");
                    stream.WriteLine("\t\t\t\t}");
                    //Fim Do metodo Update

//------------------------------------------------------------------------------------------------------------------------------
//QUARTO METODO UPDATE AND
//-----------------------------------------------------------------------------------------------------------------------------

//------------------------------------------------------------------------------------------------------------------------------
//QUINTO METODO DELETE BEGIN
//-----------------------------------------------------------------------------------------------------------------------------

                    //Inicio Do metodo Delete
                    stream.WriteLine("\t\t\t" + "/*" + "Metodo para fazer delete de um elemento na tabela" + NomeDaTabela + "*/");
                    stream.WriteLine("\t\t\tpublic string " + " Delete(" + NomeDaTabela + "_INFO " + NomeDaTabela.Remove(0, 3) + ")"); //Declara o metodo que restorna a lista de dados
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\ttry");
                    stream.WriteLine("\t\t\t\t\t{");
                    //Todo Codido Try deve ficar aqui dentro
                    stream.WriteLine("\t\t\t\t\t\tMySqlCommand command = new MySqlCommand(\"" + "PR_" + NomeDaTabela + "\"," + "connection.connectar());");
                    stream.WriteLine("\t\t\t\t\t\tcommand.CommandType = System.Data.CommandType.StoredProcedure;");
                    foreach (var x in estrutura_Infos)
                    {
                        stream.WriteLine("\t\t\t\t\t\tcommand.Parameters.Add(new MySqlParameter(\"_" + x.Nome.ToLower() + "\"," + NomeDaTabela.Remove(0, 3) + "." + x.Nome + "));");
                    }
                    stream.WriteLine("\t\t\t\t\t\tcommand.Parameters.Add(new MySqlParameter(\"opcao" + "\"," + NomeDaTabela.Remove(0, 3) + "." + "Opcao" + "));");
                    //command.ExecuteNonQuery();
                    //object result = command.ExecuteScalar();
                    //command.Connection.Close();
                    //return result.ToString();
                    stream.WriteLine("\t\t\t\t\t\t//command.ExecuteNonQuery();");  //Executar a Query
                    stream.WriteLine("\t\t\t\t\t\tobject result = command.ExecuteScalar();"); //Le o resultado que a base de ados retorna
                    stream.WriteLine("\t\t\t\t\t\tcommand.Connection.Close();"); //Fecha a conecxão com a Base De Dados
                    stream.WriteLine("\t\t\t\t\t\treturn result.ToString();"); //Retorno da função
                    //Todo Codido Try deve ficar aqui dentro
                    stream.WriteLine("\t\t\t\t\t}");
                    stream.WriteLine("\t\t\t\t\tcatch (MySqlException ex)");
                    stream.WriteLine("\t\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t\treturn ex.Message;");
                    stream.WriteLine("\t\t\t\t\t}");
                    stream.WriteLine("\t\t\t\t\tcatch (Exception ex)");
                    stream.WriteLine("\t\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t\treturn ex.Message;");
                    stream.WriteLine("\t\t\t\t\t}");
                    stream.WriteLine("\t\t\t\t}");
                    //Fim Do metodo Delete
//------------------------------------------------------------------------------------------------------------------------------
//QUINTO METODO DELETE AND
//-----------------------------------------------------------------------------------------------------------------------------

                    stream.WriteLine("\t\t}");
                    stream.WriteLine("}");

                    stream.Close();
                }
                //Começa a escrever aqui no arquivo End


                return "DAL Gerado com sucesso";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string GerarScriptSql(string NomeDaTabela, string DirectorioAondeSeraGeradoAInfo)
        {
            try
            {
                Mapeamento mapeamento = new Mapeamento();

                string dr = DirectorioAondeSeraGeradoAInfo + @"\Srcipt";
                string Caminho = DirectorioAondeSeraGeradoAInfo + @"\Srcipt" + @"\PR_" + NomeDaTabela + ".sql";

                if (Directory.Exists(dr) == false)
                {
                    Directory.CreateDirectory(dr);

                    if (File.Exists(Caminho) == true)
                    {
                        File.Delete(Caminho);
                    }
                    else
                    {
                        FileStream file = File.Create(Caminho);
                        file.Close();
                    }
                }
                else
                {
                    if (File.Exists(Caminho) == true)
                    {
                        File.Delete(Caminho);
                    }
                    else
                    {
                        FileStream file = File.Create(Caminho);
                        file.Close();
                    }
                }

                //Começa a escrever aqui no arquivo Begin
                using (StreamWriter stream = new StreamWriter(Caminho, true))
                {
                    stream.WriteLine("-- Gerado no Gerador de Codigo Do Engº Gerson Z. Maiamba");
                    stream.WriteLine("-- Data: " + DateTime.Now);
                    stream.WriteLine("-- Direitos autorais de Engº Gerson Z. Maiamba\n");
                    //Cabeçalho das biblotecas inicio namespaces
                    stream.WriteLine("#Procedimemto da Tabela " + NomeDaTabela + " Begin");
                    stream.WriteLine("Delimiter $$");
                    stream.WriteLine("drop procedure if exists PR_" + NomeDaTabela + " $$");
                    stream.WriteLine("create procedure PR_" + NomeDaTabela + "(");

                    List<Tb_Estrutura_Info> estrutura_Infos = mapeamento.RetornarEstruturaDaTabela(NomeDaTabela); //Chama na base de dados a estrutura de uma tabela

                    foreach(var x in estrutura_Infos)
                    {
                        stream.Write("in _" + x.Nome.ToLower() + " " + x.Tipo + ",");
                    }

                    stream.Write("in opcao varchar(20)");
                    stream.WriteLine(")\n\n");
                    stream.WriteLine("Begin");
                   // -- Declaração das variaves aonde vão ficar armazenado as informações de erro e exito que vier acontecer no insert

                    stream.WriteLine(" -- Declaração das variaves aonde vão ficar armazenado as informações de erro e exito que vier acontecer no insert");
                    stream.WriteLine("declare code char(5) default '00000';");
                    stream.WriteLine("declare msg Text; -- Variavél que armazena a mensagem de retorno do Sql");
                    stream.WriteLine("declare linha int; -- Variavél que armazena o numero de linhas afectadas");
                    stream.WriteLine("declare result Text; -- Varaiavél que armazena a mensagem completa de retorno");
                    stream.WriteLine(" DECLARE done INT DEFAULT 0;\n\n");


                    stream.WriteLine("-- Declare exception handler for failid insert");
                    stream.WriteLine("declare continue handler for sqlexception");
                    stream.WriteLine("Begin");
                    stream.WriteLine("Get Diagnostics Condition 1");
                    stream.WriteLine("code = Returned_sqlstate, msg = Message_Text;");
                    stream.WriteLine(" End;\n\n");


                    stream.WriteLine("-- Opção para inserir moeda na tabela Tb_Moeda");
                    stream.WriteLine("if (opcao = 'Insert') then");
                    stream.Write("Insert Into " + NomeDaTabela + " values (");
                    foreach (var x in estrutura_Infos)
                    {
                        stream.Write("_" + x.Nome.ToLower() + ",");
                    }
                    stream.Write(");\n");
                    stream.WriteLine("-- Verifica se o insert correu com exito");
                    stream.WriteLine("if code = '00000' then");
                    stream.WriteLine("Get diagnostics linha = row_count;");
                    stream.WriteLine("set result = concat('Insert succeeded, row count = ', linha);");
                    stream.WriteLine("else");
                    stream.WriteLine("set result = concat('Insert failed, error = ', code, ', message = ', msg);");
                    stream.WriteLine("end if;");
                    stream.WriteLine("-- Mostra o resultado na tela");
                    stream.WriteLine("select result;");
                    stream.WriteLine("-- select 'A moeda foi cadastrado com sucesso' as SUCESSO, 'Sucesso de cadastro' as SUCESSO;");
                    stream.WriteLine(" end if;\n\n");


                    stream.WriteLine("-- Opção Para Eliminar Moeda Na Tabela Tb_Moeda Apartir Do Seu ID");
                    stream.WriteLine("if (opcao = 'Delete') then");
                    stream.WriteLine("delete from " + NomeDaTabela + " where Id_Moeda = _id_moeda;");
                    stream.WriteLine("end if;\n\n");

                    stream.WriteLine("-- opção Para fazer um get sem parametro para trazer todos os dados");
                    stream.WriteLine("if (opcao = 'Get_SP') then");
                    stream.WriteLine("select * from " + NomeDaTabela +";");
                    stream.WriteLine("end if;\n\n");
                    stream.WriteLine("end $$");
                    stream.WriteLine("Delimiter $$ ");
                    stream.WriteLine("#Procedimemto da Tabela " + NomeDaTabela + " End");
                    stream.Close();
                }
                //Começa a escrever aqui no arquivo End


                return "Script Gerado com sucesso";

            }
            catch(Exception ex)
            {
                return ex.Message;
            }

        }

        public string GerarControllerAPI(string NomeDaTabela, string NameSpaceDoProjecto, string DirectorioAondeSeraGeradoAInfo, string NameSpaceDAL_INFO)
        {

            try
            {
                Mapeamento mapeamento = new Mapeamento();

                string dr = DirectorioAondeSeraGeradoAInfo + @"\Controllers";
                string Caminho = DirectorioAondeSeraGeradoAInfo + @"\Controllers" + @"\" + NomeDaTabela.Substring(3) + "Controller.cs";

                if (Directory.Exists(dr) == false)
                {
                    Directory.CreateDirectory(dr);

                    if (File.Exists(Caminho) == true)
                    {
                        File.Delete(Caminho);
                    }
                    else
                    {
                        FileStream file = File.Create(Caminho);
                        file.Close();
                    }
                }
                else
                {
                    if (File.Exists(Caminho) == true)
                    {
                        File.Delete(Caminho);
                    }
                    else
                    {
                        FileStream file = File.Create(Caminho);
                        file.Close();
                    }
                }

                //Começa a escrever aqui no arquivo Begin
                using (StreamWriter stream = new StreamWriter(Caminho, true))
                {
                    stream.WriteLine("/*Gerado no Gerador de Codigo Do Engº Gerson Z. Maiamba");
                    stream.WriteLine("Data: " + DateTime.Now);
                    stream.WriteLine("Direitos autorais de Engº Gerson Z. Maiamba*/\n");
                    //Cabeçalho das biblotecas inicio namespaces
                    stream.WriteLine("using System;");
                    stream.WriteLine("using System.Collections.Generic;");
                    stream.WriteLine("using System.Net;");
                    stream.WriteLine("using System.Net.Http;");
                    stream.WriteLine("using " + NameSpaceDAL_INFO + ".INFO;");
                    stream.WriteLine("using " + NameSpaceDAL_INFO + ".DAL;");
                    stream.WriteLine("using System.Web.Http;\n\n\n");
                    //Cabeçalho das biblotecas fim namespaces

                    stream.WriteLine("namespace " + NameSpaceDoProjecto + ".Controllers"); // Escreve o namespace do projecto no arquivo
                    stream.WriteLine("{");// adiciona a primeira chaveta após o namespcae
                    stream.WriteLine("\t\tpublic class " + NomeDaTabela.Substring(3) + "Controller : ApiController"); // Adiciona o nome da classe e os seus atributos
                    stream.WriteLine("\t\t{"); //Abre chaves para escrever todo o codigo que deve existir na classe
                    //Todo codigo da classe
                    stream.WriteLine("\t\t\t //GET: api/" + NomeDaTabela.Substring(3));
                    //METODO GET DA CLASS COMEÇA AQUI
                    stream.WriteLine("\t\t\t public HttpResponseMessage Get()");
                    stream.WriteLine("\t\t\t{");
                    stream.WriteLine("\t\t\t\ttry");
                    stream.WriteLine("\t\t\t\t{");
                    string NomeDaClasse = NomeDaTabela + "_INFO";
                    stream.WriteLine("\t\t\t\t\t " + NomeDaTabela + "_INFO " + NomeDaClasse.ToLower() + " = new " + NomeDaTabela + "_INFO();");
                    stream.WriteLine("\t\t\t\t\t " + NomeDaClasse.ToLower() + ".Opcao = "+ "\"" + "Get_SP" + "\";");
                    stream.WriteLine("\t\t\t\t\t List<" + NomeDaTabela + "_INFO> " + NomeDaTabela.Substring(3) + "s"  + " = new " + NomeDaTabela + "_DAL().SelectAll(" + NomeDaClasse.ToLower() + ");");
                    stream.WriteLine("\n\t\t\t\t if (" + NomeDaTabela.Substring(3) + "s" + " == null)");
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\treturn Request.CreateErrorResponse(HttpStatusCode.NotFound, new HttpError(" + "\"" + NomeDaTabela.Substring(3) +" Não Encontrado" + "\"" + "));");
                    stream.WriteLine("\t\t\t\t}else");
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\treturn Request.CreateResponse(HttpStatusCode.OK," + NomeDaTabela.Substring(3) + "s" + ");");
                    stream.WriteLine("\t\t\t\t}");
                    stream.WriteLine("\t\t\t\t}"); //Aqui fecha o código do try
                    stream.WriteLine("\t\t\t\tcatch (Exception ex)");
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);");
                    stream.WriteLine("\t\t\t\t}"); //Aqui fecha o códigodo catch
                    stream.WriteLine("\t\t\t}");//Aqui fecha o código da função Get
                    //METODO GET DO CONTROLLE TERMINA AQUI

                    //METODO POST DO CONTROLLER COMEÇA AQUI 
                    stream.WriteLine("\n\n\t\t\t // POST: api/" + NomeDaTabela.Substring(3));
                    stream.WriteLine("\t\t\t public HttpResponseMessage Post([FromBody]" + NomeDaTabela + "_INFO " + NomeDaTabela.Substring(3).ToLower() + ")");
                    stream.WriteLine("\t\t\t{");//Aqui começa co código da função POST
                    stream.WriteLine("\t\t\t\tstring erro = null;");
                    stream.WriteLine("\t\t\t\ttry"); //Aqui começa o try
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t " + NomeDaTabela.Substring(3) + ".Opcao = " + "\"" + "Insert" + "\";" );
                    stream.WriteLine("\t\t\t\t\t// " + NomeDaTabela.Substring(3) + ".Id = " + "Guid.NewGuid().ToString();");
                    stream.WriteLine("\t\t\t\t\t erro = new " + NomeDaTabela + "_DAL()" + ".Insert" + "(" + NomeDaTabela.Substring(3).ToLower() + ");");
                    stream.WriteLine("\t\t\t\t\t return Request.CreateResponse(HttpStatusCode.OK, erro);");
                    stream.WriteLine("\t\t\t\t}"); //Aqui fecha o código do try
                    stream.WriteLine("\t\t\t\tcatch (Exception ex)");
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);");
                    stream.WriteLine("\t\t\t\t}"); //Aqui fecha o códigodo catch
                    stream.WriteLine("\t\t\t}");//Aqui fecha o código da função POST


                    //METODO PUT DO CONTROLLER COMEÇA AQUI
                    stream.WriteLine("\n\n\t\t\t // Put: api/" + NomeDaTabela.Substring(3));
                    stream.WriteLine("\t\t\t public HttpResponseMessage Put([FromBody]" + NomeDaTabela + "_INFO " + NomeDaTabela.Substring(3).ToLower() + ")");
                    stream.WriteLine("\t\t\t{");//Aqui começa co código da função Put
                    stream.WriteLine("\t\t\t\ttry"); //Aqui começa o try
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t " + NomeDaTabela.Substring(3) + ".Opcao = " + "\"" + "Update" + "\";");
                    stream.WriteLine("\t\t\t\t\t var response = new " + NomeDaTabela + "_DAL()" + ".Update" +  "(" + NomeDaTabela.Substring(3).ToLower() + ");");
                    stream.WriteLine("\t\t\t\t\t return Request.CreateErrorResponse(HttpStatusCode.OK, response);");
                    stream.WriteLine("\t\t\t\t}"); //Aqui fecha o código do try
                    stream.WriteLine("\t\t\t\tcatch (Exception ex)");
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);");
                    stream.WriteLine("\t\t\t\t}"); //Aqui fecha o códigodo catch
                    stream.WriteLine("\t\t\t}");//Aqui fecha o código da função Put

                    //METODO DELETE DO CONTROLLER COMEÇA AQUI
                    stream.WriteLine("\n\n\t\t\t // DELETE: api/" + NomeDaTabela.Substring(3));
                    stream.WriteLine("\t\t\t public HttpResponseMessage Delete(string id)");
                    stream.WriteLine("\t\t\t{");//Aqui começa co código da função Delete
                    stream.WriteLine("\t\t\t\ttry"); //Aqui começa o try
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t" + NomeDaTabela + "_INFO " + NomeDaTabela.Substring(3) + " = new " + NomeDaTabela + "_INFO();");
                    stream.WriteLine("\t\t\t\t\t" + NomeDaTabela.Substring(3) + ".Opcao = " + "\"" + "Delete" + "\";");
                    stream.WriteLine("\t\t\t\t\t//" + NomeDaTabela.Substring(3) + ".id = id;");
                    stream.WriteLine("\t\t\t\t\tvar response = new " + NomeDaTabela + "_DAL().Delete"  + "(" + NomeDaTabela.Substring(3) + ");");
                    stream.WriteLine("\t\t\t\t\treturn Request.CreateErrorResponse(HttpStatusCode.OK, response);");
                    stream.WriteLine("\t\t\t\t}"); //Aqui fecha o código do try
                    stream.WriteLine("\t\t\t\tcatch (Exception ex)");
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);");
                    stream.WriteLine("\t\t\t\t}"); //Aqui fecha o códigodo catch
                    stream.WriteLine("\t\t\t}");//Aqui fecha o código da função Delete

                    stream.WriteLine("\t\t}");//Aqui fecha o código da classe
                    stream.WriteLine("}"); //Aqui fecha o código no namespace
                    stream.Close();
                    //Aqui termina o código do controller

                }
                    return "Controller da API Gerado com sucesso";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string GerarClasseConsumirAPI_Csharp(string NomeDaTabela, string NameSpaceDoProjecto, string DirectorioAondeSeraGeradoAInfo)
        {

            try
            {
                Mapeamento mapeamento = new Mapeamento();

                string dr = DirectorioAondeSeraGeradoAInfo + @"\Consumir_API_C#";
                string Caminho = DirectorioAondeSeraGeradoAInfo + @"\Consumir_API_C#" + @"\" + "API_" + NomeDaTabela.Substring(3) + ".cs";

                if (Directory.Exists(dr) == false)
                {
                    Directory.CreateDirectory(dr);

                    if (File.Exists(Caminho) == true)
                    {
                        File.Delete(Caminho);
                    }
                    else
                    {
                        FileStream file = File.Create(Caminho);
                        file.Close();
                    }
                }
                else
                {
                    if (File.Exists(Caminho) == true)
                    {
                        File.Delete(Caminho);
                    }
                    else
                    {
                        FileStream file = File.Create(Caminho);
                        file.Close();
                    }
                }
                //Começa a escrever aqui no arquivo Begin
                using (StreamWriter stream = new StreamWriter(Caminho, true))
                {
                    stream.WriteLine("/*Gerado no Gerador de Codigo Do Engº Gerson Z. Maiamba");
                    stream.WriteLine("Data: " + DateTime.Now);
                    stream.WriteLine("Direitos autorais de Engº Gerson Z. Maiamba*/\n");
                    //Cabeçalho das biblotecas inicio namespaces
                    stream.WriteLine("using System;");
                    stream.WriteLine("using System.Collections.Generic;");
                    stream.WriteLine("using System.Text;");
                    stream.WriteLine("using System.Linq;");
                    stream.WriteLine("using System.Net.Http;");
                    stream.WriteLine("using " + NameSpaceDoProjecto + ".INFO;");
                    stream.WriteLine("using Newtonsoft.Json;");
                    stream.WriteLine("using System.Threading.Tasks;\n\n\n");
                    //Cabeçalho das biblotecas fim namespaces

                    stream.WriteLine("namespace " + NameSpaceDoProjecto + ".API");// Aqui começa o namesapce do file
                    stream.WriteLine("{");// adiciona a primeira chaveta após o namespcae
                    stream.WriteLine("\t\tpublic class API_" + NomeDaTabela.Substring(3)); // Adiciona o nome da classe e os seus atributos
                    stream.WriteLine("\t\t{"); //Abre chaves para escrever todo o codigo que deve existir na classe
                    //Todo codigo da classe

                    //METODO API/POST DA CLASS COMEÇA AQUI
                    stream.WriteLine("\t\t\t public async Task<string> POST" + NomeDaTabela.Substring(3) + "(" + NomeDaTabela + "_INFO " + NomeDaTabela.Substring(3) + ")");
                    stream.WriteLine("\t\t\t{"); //Aqui fica todo código da função POST
                    stream.WriteLine("\t\t\t\tvar json = JsonConvert.SerializeObject(" + NomeDaTabela.Substring(3) + ");");
                    stream.WriteLine("\t\t\t\tvar content = new StringContent(json, Encoding.UTF8," + "\"" + "application/json" + "\");");
                    stream.WriteLine("\t\t\t\tusing (var client = new HttpClient())");
                    stream.WriteLine("\t\t\t\t{");//Aqui começa o using
                    stream.WriteLine("\t\t\t\t\tstring URL = string.Concat(ConfigSystem.URLAPI," + "\"" + "/" + NomeDaTabela.Substring(3)  + "\");");
                    stream.WriteLine("\t\t\t\t\t//client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(" + "\"" + "Bearer" + "\"" + ",ConfigSystem.Token);");
                    stream.WriteLine("\t\t\t\t\tvar result = await client.PostAsync(URL, content);");
                    stream.WriteLine("\t\t\t\t\tif (result.StatusCode == System.Net.HttpStatusCode.Created)");

                    stream.WriteLine("\t\t\t\t\t{");//Aqui começa o IF 1
                    stream.WriteLine("\t\t\t\t\t\tvar error = await result.Content.ReadAsStringAsync();");
                    stream.WriteLine("\t\t\t\t\t\treturn error;");
                    stream.WriteLine("\t\t\t\t\t}");//Aqui termina o IF 2

                    stream.WriteLine("\t\t\t\t\telse if (result.StatusCode == System.Net.HttpStatusCode.OK)");
                    stream.WriteLine("\t\t\t\t\t{"); //Aqui começa o else if 1
                    stream.WriteLine("\t\t\t\t\t\tvar error = await result.Content.ReadAsStringAsync();");
                    stream.WriteLine("\t\t\t\t\t\treturn error;");
                    stream.WriteLine("\t\t\t\t\t}");//Aqui termina o else if 1

                    stream.WriteLine("\t\t\t\t\telse if (result.StatusCode == System.Net.HttpStatusCode.InternalServerError)");
                    stream.WriteLine("\t\t\t\t\t{"); //Aqui começa o else if 2
                    stream.WriteLine("\t\t\t\t\t\tvar error = await result.Content.ReadAsStringAsync();");
                    stream.WriteLine("\t\t\t\t\t\treturn " + "\"" + "Servidor indisponivel." + "\";");
                    stream.WriteLine("\t\t\t\t\t}");//Aqui termina o else if 2

                    stream.WriteLine("\t\t\t\t\telse");
                    stream.WriteLine("\t\t\t\t\t{"); //Aqui começa o else
                    stream.WriteLine("\t\t\t\t\t\tvar error = await result.Content.ReadAsStringAsync();");
                    stream.WriteLine("\t\t\t\t\t\treturn error;");
                    stream.WriteLine("\t\t\t\t\t}");//Aqui termina o else 

                    stream.WriteLine("\t\t\t\t};");//Aqui termina o using
                    stream.WriteLine("\t\t\t}");//Aqui fecha o código da função POST
                    //METODO API/POST DA CLASS TERMINA AQUI


                    //METODO API/GET DA CLASS COMEÇA AQUI
                    stream.WriteLine("\n\n\t\t\t public async Task<List<" + NomeDaTabela + "_INFO>>" +  " GET" +  NomeDaTabela.Substring(3) + "()");
                    stream.WriteLine("\t\t\t{"); //Aqui fica todo código da função GET
                    stream.WriteLine("\t\t\t\tList<" + NomeDaTabela + "_INFO> " + NomeDaTabela.Substring(3) + " = null;");
                    stream.WriteLine("\t\t\t\ttry");
                    stream.WriteLine("\t\t\t\t{"); //Aqui começa o try
                    stream.WriteLine("\t\t\t\t\tvar client = new HttpClient();");
                    stream.WriteLine("\t\t\t\t\tstring URL = string.Concat(ConfigSystem.URLAPI," + "\"" + "/" + NomeDaTabela.Substring(3) + "\");");
                    stream.WriteLine("\t\t\t\t\t//client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(" + "\"" + "Bearer" + "\"" + ",ConfigSystem.Token);");
                    stream.WriteLine("\t\t\t\t\tvar uri = new Uri(URL);");
                    stream.WriteLine("\t\t\t\t\tHttpResponseMessage response = await client.GetAsync(uri);");
                    stream.WriteLine("\t\t\t\t\tvar responseString = response.Content.ReadAsStringAsync().Result;\n");
                    stream.WriteLine("\t\t\t\t\tvar json = JsonConvert.DeserializeObject<List<" + NomeDaTabela + "_INFO>>" + "(responseString);");
                    stream.WriteLine("\t\t\t\t\treturn json;");
                    stream.WriteLine("\t\t\t\t}");//Aqui termina o try

                    stream.WriteLine("\t\t\t\tcatch (JsonException ex)"); //Aqui começa o cath 1
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\tstring ERRO = ex.Message;");
                    stream.WriteLine("\t\t\t\t\treturn " + NomeDaTabela.Substring(3));
                    stream.WriteLine("\t\t\t\t}");//Aqui começa termina o cath 1

                    stream.WriteLine("\t\t\t\tcatch (HttpRequestException ex)"); //Aqui começa o cath 2
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\tstring ERRO = ex.Message;");
                    stream.WriteLine("\t\t\t\t\treturn " + NomeDaTabela.Substring(3));
                    stream.WriteLine("\t\t\t\t}");//Aqui começa termina o cath 2

                    stream.WriteLine("\t\t\t\tcatch (Exception ex)"); //Aqui começa o cath 3
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\tstring ERRO = ex.Message;");
                    stream.WriteLine("\t\t\t\t\treturn " + NomeDaTabela.Substring(3));
                    stream.WriteLine("\t\t\t\t}");//Aqui começa termina o cath 3


                    stream.WriteLine("\t\t\t\tfinally"); //Aqui começa o finaly
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t}");//Aqui começa termina finaly

                    stream.WriteLine("\t\t\t}");//Aqui fecha o código da função GET
                    //METODO API/GET DA CLASS TERMINA AQUI


                    stream.WriteLine("\t\t}");//Aqui fecha o código da classe
                    stream.WriteLine("}"); //Aqui fecha o código no namespace
                    stream.Close();


                }

                return "Classe para consumir API no C# gerados com sucesso";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
