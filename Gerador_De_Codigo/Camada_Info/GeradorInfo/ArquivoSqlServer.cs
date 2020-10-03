using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Camada_Info.GeradorInfo
{
   public class ArquivoSqlServer
    {

        /// <summary>
        /// Metodo para gerar o procedimento de uma determinada tabela (Ex: SP_Tb_Curso)
        /// </summary>
        /// <param name="tb_SchemaSqlServer">Estrutura da tabela</param>
        /// <param name="DirectorioAondeSeraGeradoAInfo">Caminho aonde será gerado o arquivo (Ex: C://Documents/Tb_Curso.cs)</param>
        /// <returns></returns>
        public string GerarScriptSqlServer(Tb_SchemaSqlServer tb_SchemaSqlServer, string DirectorioAondeSeraGeradoAInfo)
        {
            try
            {
                Mapeamento mapeamento = new Mapeamento();

                string dr = DirectorioAondeSeraGeradoAInfo + @"\Script";
                string Caminho = DirectorioAondeSeraGeradoAInfo + @"\Script" + @"\SP_" + tb_SchemaSqlServer.TABLE_NAME + ".sql";

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

                    stream.WriteLine("use[" + tb_SchemaSqlServer.TABLE_CATALOG + "]");
                    stream.WriteLine("GO");
                    stream.WriteLine("drop procedure [" + tb_SchemaSqlServer.TABLE_SCHEMA + "].[SP_" + tb_SchemaSqlServer.TABLE_NAME + "]");
                    stream.WriteLine("GO");
                    stream.WriteLine("CREATE PROCEDURE [" + tb_SchemaSqlServer.TABLE_SCHEMA + "].[SP_" + tb_SchemaSqlServer.TABLE_NAME + "]");
                    stream.WriteLine("(");


                    #region "DECLARAÇÃO DE PARAMENTROS DE ENTRA E SAIDA"
                    
                    //ADICIONAR PARAMETROS NO PROCEDIMENTO *BEGIN
                    List<Tb_Estrutura_Info> estrutura_Infos = mapeamento.RetornarEstruturaDaTabelaSqlServer(tb_SchemaSqlServer.TABLE_NAME); //Chama na base de dados a estrutura de uma tabela

                    foreach (var x in estrutura_Infos)
                    {
                        if(x.Nome.ToLower() == "data_registo")
                        {
                            stream.Write("\t--@" + x.Nome + " " + x.Tipo + "," + "\n");
                        }
                        else if (string.IsNullOrEmpty(x.Maximo_Caracters))
                        {
                            stream.Write("\t@" + x.Nome + " " + x.Tipo + "," + "\n");
                        }
                        else if (!string.IsNullOrEmpty(x.Maximo_Caracters))
                        {
                            if(x.Tipo.ToLower() == "text")
                            {
                                stream.Write("\t@" + x.Nome + " " + x.Tipo + "," + "\n");

                            }
                            else
                            {
                                stream.Write("\t@" + x.Nome + " " + x.Tipo + "(" + x.Maximo_Caracters + ") = null" + "," + "\n");

                            }
                           // stream.Write("\t@" + x.Nome + " " + x.Tipo + "(" + x.Maximo_Caracters + ") = null" + "," + "\n");
                        }
                        else
                        {
                            stream.Write("\t@" + x.Nome + " " + x.Tipo + "," + "\n");
                        }
                    }

                    //Variavél de retorno do Sql cometanto
                    stream.WriteLine("\t@Retorno varchar(800) = null output,");
                    stream.WriteLine("\t@Opcao varchar(20)");
                    stream.WriteLine(")\n\n");
                    //ADICIONAR PARAMETROS NO PROCEDIMENTO  *END

                    #endregion

                    stream.WriteLine("as\n");

                    //INICIO DO PROCEDIMENTO
                    stream.WriteLine("\tBEGIN -- *Inicio do procedimento\n");

                    //Declaração do campo da data de registo
                    //Declare @Data_Registo datetime;
                    //set @Data_Registo = GETDATE();
                    stream.WriteLine("\tDeclare @Data_Registo datetime;");
                    stream.WriteLine("\tset @Data_Registo = GETDATE();\n");

                    #region "BLOCO DE CÓDIGO PARA FAZER INSERT"

                    //BLOCO DE CÓDIGO PARA FAZER INSERT
                    stream.WriteLine("\t-- Opção para fazer o insert");
                    stream.WriteLine("\tIF @Opcao = 'Insert'");
                    stream.WriteLine("\tBEGIN\n");
                    stream.WriteLine("\tBegin Try");
                    stream.Write("\tInsert Into " + tb_SchemaSqlServer.TABLE_NAME + " values (\n");

                    //MONTA A INSTRUÇÃO PARA O INSERT
                    foreach (var x in estrutura_Infos)
                    {
                       if(x.ORDINAL_POSITION == estrutura_Infos.Count)
                        {
                           stream.WriteLine("\t@" + x.Nome);                         
                        }
                       else
                        {
                           stream.WriteLine("\t@" + x.Nome + ",");
                        }
                    }
                    stream.WriteLine("\t)\n");

                    stream.WriteLine("\tEnd Try\n");//begin catch
                    stream.WriteLine("\tbegin catch");
                    stream.WriteLine("\tIF @@rowcount = 0 set @Retorno = 'Não foi posivél inserir os dados';");
                    stream.WriteLine("\tTHROW");
                    stream.WriteLine("\tEND catch\n");
                    stream.WriteLine("\tEND\n");
                    //BLOCO DE CÓDIGO PARA FAZER INSERT

                    #endregion

                    #region "BLOCO DE CÓDIGO PARA FAZER O SELECT"

                    //BLOCO DE CÓDIGO PARA FAZER O SELECT
                    stream.WriteLine("\t-- Opção para fazer o select");
                    stream.WriteLine("\tIF @Opcao = 'Select'");
                    stream.WriteLine("\tBEGIN");
                    stream.WriteLine("\tSelect * from " + tb_SchemaSqlServer.TABLE_NAME + ";");
                    stream.WriteLine("\tEND\n");
                    //BLOCO DE CÓDIGO PARA FAZER O SELECT

                    #endregion

                    #region "BLOCO DE CÓDIGO PARA FAZER O SELECT ONE"

                    //BLOCO DE CÓDIGO PARA FAZER O SELECT ONE
                    stream.WriteLine("\t-- Opção para fazer o Select one");
                    stream.WriteLine("\tIF @Opcao = 'Select_One'");
                    stream.WriteLine("\tBEGIN");
                    stream.WriteLine("\tSelect * from " + tb_SchemaSqlServer.TABLE_NAME + " where Id_" + tb_SchemaSqlServer.TABLE_NAME.Substring(3) + " = @Id_" + tb_SchemaSqlServer.TABLE_NAME.Substring(3) + "; ");
                    stream.WriteLine("\tEND\n");
                    //BLOCO DE CÓDIGO PARA FAZER O SELECT ONE

                    #endregion

                    #region "BLOCO DE CÓDIGO PARA FAZER O DELETE"
                    
                    //BLOCO DE CÓDIGO PARA FAZER O DELETE
                    stream.WriteLine("\t-- Opção para fazer o delete");
                    stream.WriteLine("\tIF @Opcao = 'Delete'");
                    stream.WriteLine("\tBEGIN");
                    stream.WriteLine("\tDelete from " + tb_SchemaSqlServer.TABLE_NAME + " where Id_" + tb_SchemaSqlServer.TABLE_NAME.Substring(3) + " = @Id_" + tb_SchemaSqlServer.TABLE_NAME.Substring(3) + "; ");
                    stream.WriteLine("\tEND\n");
                    //BLOCO DE CÓDIGO PARA FAZER O DELETE

                    #endregion

                    #region "BLOCO DE CÓDIGO PARA FAZER O UPDATE"

                    //BLOCO DE CÓDIGO PARA FAZER O UPDATE
                    stream.WriteLine("\t-- Opção para fazer o update");
                    stream.WriteLine("\tIF @Opcao = 'Update'");
                    stream.WriteLine("\tBEGIN\n");
                    stream.WriteLine("\tBegin Try");
                    stream.WriteLine("\tupdate " + tb_SchemaSqlServer.TABLE_NAME + " set ");
                  
                    //Adicionar os campos que devem sofre Update
                    foreach (var x in estrutura_Infos)
                    {
                        if (x.ORDINAL_POSITION == estrutura_Infos.Count)
                        {
                            stream.WriteLine("\t" + x.Nome + " = " + "@"+x.Nome);
                        }
                        else
                        {
                            stream.WriteLine("\t" + x.Nome + " = " + "@" + x.Nome +",");
                        }
                    }
                    stream.WriteLine("\t where Id_" + tb_SchemaSqlServer.TABLE_NAME.Substring(3) + " = @Id_" + tb_SchemaSqlServer.TABLE_NAME.Substring(3) + "; ");
                    stream.WriteLine("\tEnd Try");
                    stream.WriteLine("\tbegin catch");
                    stream.WriteLine("\tIF @@rowcount = 0 set @Retorno = 'Não foi posivél actualizar os dados';");
                    stream.WriteLine("\tTHROW");
                    stream.WriteLine("\tEND catch\n");
                    stream.WriteLine("\tEND\n");
                    //BLOCO DE CÓDIGO PARA FAZER O UPDATE

                    #endregion

                    //FIM DO PROCEDIMENTO
                    stream.WriteLine("\tEND -- *Fim do procedimento");
                    stream.Close();
                }
                //Começa a escrever aqui no arquivo End


                return "Script Gerado com sucesso";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        /// <summary>
        /// Metodo para gerar a INFO de uma determinada tabela (Ex: Tb_Curso)
        /// </summary>
        /// <param name="NomeDaTabela">Nome da tabela que se deseja gerar a sua info</param>
        /// <param name="NameSpaceDoProjecto">Namespace do projecto</param>
        /// <param name="DirectorioAondeSeraGeradoAInfo">Caminho aonde será gerado o arquivo (Ex: C://Documents/Tb_Curso.cs)</param>
        /// <returns></returns>
        public string GerarInfoDaTabelaSqlServer(string NomeDaTabela, string NameSpaceDoProjecto, string DirectorioAondeSeraGeradoAInfo)
        {
            try
            {
                Mapeamento mapeamento = new Mapeamento();

                string dr = DirectorioAondeSeraGeradoAInfo + @"\INFO";
                string Caminho = DirectorioAondeSeraGeradoAInfo + @"\INFO" + @"\" + NomeDaTabela + ".cs";

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
                    stream.WriteLine("namespace " + NameSpaceDoProjecto + ".INFO"); //+ ".INFO"
                    stream.WriteLine("{");
                    stream.WriteLine("\t\tpublic class " + NomeDaTabela);
                    stream.WriteLine("\t\t{");
                    List<Tb_Estrutura_Info> estrutura_Infos = mapeamento.RetornarEstruturaDaTabelaSqlServer(NomeDaTabela);

                    //Prenche aqui o arquivo com as propriedades Begin
                    foreach (var x in estrutura_Infos)
                    {
                        if (x.Tipo.Contains("int"))
                        {
                            x.Tipo = "int";
                            stream.WriteLine("\t\t\tpublic " + x.Tipo + " " + x.Nome + "{ get; set; }");
                        }
                        else if (x.Tipo.Contains("char") || x.Tipo.Contains("varchar") || x.Tipo.Contains("longtext") || x.Tipo.Contains("nvarchar") || x.Tipo.ToLower() == "text")
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
                        else if (x.Tipo.Contains("Date") || x.Tipo.Contains("date") || x.Tipo.Contains("DateTime") || x.Tipo.Contains("datetime"))
                        {
                            x.Tipo = "DateTime";
                            stream.WriteLine("\t\t\tpublic " + x.Tipo + " " + x.Nome + "{ get; set; }");
                        }
                        else
                        {
                            stream.WriteLine("\t\t\tpublic " + x.Tipo + " " + x.Nome + "{ get; set; }");
                        }
                    }
                    //public string Retorno { get; set; }
                    stream.WriteLine("\t\t\tpublic " + "string" + " " + "Retorno" + "{ get; set; }");
                    stream.WriteLine("\t\t\tpublic " + "string" + " " + "Opcao" + "{ get; set; }");
                    //Prenche aqui o arquivo com as propriedades End

                    stream.WriteLine("\t\t}");
                    stream.WriteLine("}");

                    stream.Close();
                }
                //Começa a escrever aqui no arquivo End


                return "Info Gerado Com Sucesso No Diretorio Informado";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// Metodo pra gerar a DAL de uma determinada tabela (Ex: Tb_Curso)
        /// </summary>
        /// <param name="NomeDaTabela">Nome da tabela (Ex: Tb_Curso)</param>
        /// <param name="NameSpaceDoProjecto">Namespace do projecto</param>
        /// <param name="DirectorioAondeSeraGeradoAInfo">Caminho aonde será gerado o arquivo (Ex: C://Documents/Tb_Curso.cs)</param>
        /// <returns></returns>
        public string GerarDALDaTabelaSqlServer(string NomeDaTabela, string NameSpaceDoProjecto, string NameSpaceINFO, string DirectorioAondeSeraGeradoAInfo)
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

                    #region "DECLARAÇÃO DE BIBLOTECA"
                    
                    //Cabeçalho das biblotecas inicio namespaces
                    stream.WriteLine("using System;");
                    stream.WriteLine("using System.Collections.Generic;");
                    stream.WriteLine("using System.Data;");
                    stream.WriteLine("using System.Linq;");
                    stream.WriteLine("using System.Text;");
                    stream.WriteLine("using " + NameSpaceINFO + ".INFO;");// + ".INFO;"
                    stream.WriteLine("using " + NameSpaceDoProjecto + ";");
                    stream.WriteLine("using System.Data.SqlClient;");
                    stream.WriteLine("using System.Threading;");
                    stream.WriteLine("using System.Threading.Tasks;\n\n\n");
                    //Cabeçalho das biblotecas fim namespaces

                    #endregion

                    stream.WriteLine("namespace " + NameSpaceDoProjecto + ".DAL"); // Escreve o namespace do projecto no arquivo
                    stream.WriteLine("{");// adiciona a primeira chaveta após o namespcae
                    stream.WriteLine("\t\tpublic class " + NomeDaTabela + "_DAL"); // Adiciona o nome da classe e os seus atributos
                    stream.WriteLine("\t\t{"); //Abre chaves para escrever todo o codigo que deve existir na classe

                    List<Tb_Estrutura_Info> estrutura_Infos = mapeamento.RetornarEstruturaDaTabelaSqlServer(NomeDaTabela); //Chama na base de dados a estrutura de uma tabela

                    stream.WriteLine("\t\t\t\tConexaoSqlServer connection = new ConexaoSqlServer();\n"); //Adiciona a classe de conexão na classe


                    #region "PRIMEIRO METDO SELECT ALL BEGIN"
                    //------------------------------------------------------------------------------------------------------------------------------
                    //PRIMEIRO METDO SELECT ALL BEGIN
                    //-----------------------------------------------------------------------------------------------------------------------------

                    //Inicio do primeiro metodo select all
                    // stream.WriteLine("\t\t\t\t" + "/*" + "Metodo para fazer um select de todos os dados existenstes na tabela " + NomeDaTabela + "*/");
                    stream.WriteLine("\t\t\t\t/// <summary>");
                    stream.WriteLine("\t\t\t\t///" + "Metodo para fazer um select de todos os dados existente na tabela " + NomeDaTabela);
                    stream.WriteLine("\t\t\t\t/// <summary>");
                    stream.WriteLine("\t\t\t\t/// <param name=" + "\"" + NomeDaTabela.Remove(0, 3) + "\"" + " >" + "Objecto " + NomeDaTabela.Remove(0, 3) + "</param>");
                    stream.WriteLine("\t\t\t\t/// <returns></returns>");
                    stream.WriteLine("\t\t\t\tpublic List<" + NomeDaTabela + "> SelectAll(" + NomeDaTabela  + "  " + NomeDaTabela.Remove(0, 3) + ", string _StringConnection)"); //Declara o metodo que restorna a lista de dados
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\ttry");
                    stream.WriteLine("\t\t\t\t\t{");
                    //Todo Codido Try deve ficar aqui dentro
                    stream.WriteLine("\t\t\t\t\t\tSqlCommand command = new SqlCommand(\"" + "SP_" + NomeDaTabela + "\"," + "connection.connectar(_StringConnection));");
                    stream.WriteLine("\t\t\t\t\t\tcommand.CommandType = System.Data.CommandType.StoredProcedure;");
                    foreach (var x in estrutura_Infos)
                    {
                        stream.WriteLine("\t\t\t\t\t\tcommand.Parameters.Add(new SqlParameter(\"@" + x.Nome + "\"," + NomeDaTabela.Remove(0, 3) + "." + x.Nome + "));");
                    }
                    //command.Parameters.Add(new SqlParameter("@Retorno", null));
                    stream.WriteLine("\t\t\t\t\t\t//command.Parameters.Add(new SqlParameter(\"@Retorno" + "\"," + NomeDaTabela.Remove(0, 3) + "." + "Retorno" + "));");
                    stream.WriteLine("\t\t\t\t\t\t//command.Parameters.Add(new SqlParameter(\"@Retorno\", SqlDbType.VarChar, 800)).Direction = ParameterDirection.Output;");
                    stream.WriteLine("\t\t\t\t\t\tcommand.Parameters.Add(new SqlParameter(\"@Opcao" + "\"," + NomeDaTabela.Remove(0, 3) + "." + "Opcao" + "));");
                    stream.WriteLine("\t\t\t\t\t\tSqlDataReader dataReader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);");
                    stream.WriteLine("\t\t\t\t\t\tList<" + NomeDaTabela + "> " + "Lista" + NomeDaTabela.Remove(0, 3) + "s = new " + "List<" + NomeDaTabela + ">();\n");
                    stream.WriteLine("\t\t\t\t\t\twhile (dataReader.Read())");
                    stream.WriteLine("\t\t\t\t\t\t{"); //Começa o while
                    stream.WriteLine("\t\t\t\t\t\t\t" + NomeDaTabela + " tb" + NomeDaTabela.Remove(0, 3) + " = new " + NomeDaTabela + "();");
                    foreach (var x in estrutura_Infos)
                    {
                        // Convert.ToString(dataReader["Id_Conversao"]);
                        if (x.Tipo.Contains("int"))
                        {
                            stream.WriteLine("\t\t\t\t\t\t\ttb" + NomeDaTabela.Remove(0, 3) + "." + x.Nome + " = " + " int.Parse(Convert.ToString(dataReader[\"" + x.Nome + "\"]));");

                        }
                        else if (x.Tipo.Contains("char") || x.Tipo.Contains("varchar") || x.Tipo.Contains("longtext") || x.Tipo.Contains("nvarchar"))
                        {        
                            stream.WriteLine("\t\t\t\t\t\t\ttb" + NomeDaTabela.Remove(0, 3) + "." + x.Nome + " = " + " Convert.ToString(dataReader[\"" + x.Nome + "\"]);");
                        }
                        else if (x.Tipo.Contains("float"))
                        {
                            x.Tipo = "float";
                            stream.WriteLine("\t\t\tpublic " + x.Tipo + " " + x.Nome + "{ get; set; }");
                        }
                        else if (x.Tipo.Contains("decimal"))
                        {
                            stream.WriteLine("\t\t\t\t\t\t\ttb" + NomeDaTabela.Remove(0, 3) + "." + x.Nome + " = " + " Convert.ToDecimal(dataReader[\"" + x.Nome + "\"]);");
                        }
                        else if (x.Tipo.Contains("Date") || x.Tipo.Contains("date") || x.Tipo.Contains("DateTime") || x.Tipo.Contains("datetime"))
                        {
                            stream.WriteLine("\t\t\t\t\t\t\ttb" + NomeDaTabela.Remove(0, 3) + "." + x.Nome + " = " + " Convert.ToDateTime(dataReader[\"" + x.Nome + "\"]);");

                        }
                        else
                        {
                            stream.WriteLine("\t\t\t\t\t\t\ttb" + NomeDaTabela.Remove(0, 3) + "." + x.Nome + " = " + " Convert.ToString(dataReader[\"" + x.Nome + "\"]);");

                        }
                       // stream.WriteLine("\t\t\t\t\t\t\ttb" + NomeDaTabela.Remove(0, 3) + "." + x.Nome + " = " + " Convert.ToString(dataReader[\"" + x.Nome + "\"]);");
                    }
                    stream.WriteLine("\t\t\t\t\t\t\t" + "Lista" + NomeDaTabela.Remove(0, 3) + "s.Add(" + "tb" + NomeDaTabela.Remove(0, 3) + ");");
                    stream.WriteLine("\t\t\t\t\t\t}\n"); //Termina o while

                    stream.WriteLine("\t\t\t\t\t\t\tdataReader.Close();");  //Fecha o datareader
                    stream.WriteLine("\t\t\t\t\t\t\tconnection.desconectar(_StringConnection);"); //Fecha a conecxão com a Base De Dados
                    stream.WriteLine("\t\t\t\t\t\t\treturn " + "Lista" + NomeDaTabela.Remove(0, 3) + "s;");
                    //Todo Codido Try deve ficar aqui dentro
                    stream.WriteLine("\t\t\t\t\t}");
                    stream.WriteLine("\t\t\t\t\tcatch (SqlException ex)");
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

                    #endregion

                    #region "PRIMEIRO METDO SELECT ALL Async AND"
                    //------------------------------------------------------------------------------------------------------------------------------
                    //PRIMEIRO METDO SELECT ALL Async AND
                    //-----------------------------------------------------------------------------------------------------------------------------
                    //Inicio do primeiro metodo select all
                    // stream.WriteLine("\t\t\t\t" + "/*" + "Metodo para fazer um select de todos os dados existenstes na tabela de maneira assincrona async " + NomeDaTabela + "*/");
                    stream.WriteLine("\t\t\t\t/// <summary>");
                    stream.WriteLine("\t\t\t\t///" + "Metodo para fazer um select de todos os dados existente na tabela de maneira assincrona async " + NomeDaTabela);
                    stream.WriteLine("\t\t\t\t/// <summary>");
                    stream.WriteLine("\t\t\t\t/// <param name=" + "\"" + NomeDaTabela.Remove(0, 3) + "\"" + " >" + "Objecto " + NomeDaTabela.Remove(0, 3) + "</param>");
                    stream.WriteLine("\t\t\t\t/// <returns></returns>");
                    stream.WriteLine("\t\t\t\tpublic async Task<List<" + NomeDaTabela + ">> SelectAllAsync(" + NomeDaTabela + "  " + NomeDaTabela.Remove(0, 3) + ", string _StringConnection)"); //Declara o metodo que restorna a lista de dados
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\tList <"  + NomeDaTabela + "> Result = null;");
                    stream.WriteLine("\t\t\t\t\tawait Task.Factory.StartNew(() =>");
                    stream.WriteLine("\t\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t\t\tResult = SelectAll(" + NomeDaTabela.Remove(0, 3) + ", _StringConnection);");
                    stream.WriteLine("\t\t\t\t\t});\n");
                    stream.WriteLine("\t\t\t\t\treturn Result;");
                    stream.WriteLine("\t\t\t\t}\n\n");
                    //Fim do primeiro metodo select all
                    //------------------------------------------------------------------------------------------------------------------------------
                    //PRIMEIRO METDO SELECT ALL Async AND
                    //-----------------------------------------------------------------------------------------------------------------------------
                    #endregion

                    #region "SEGUNDO METODO SELECT ONE BEGIN"
                    //------------------------------------------------------------------------------------------------------------------------------
                    //SEGUNDO METODO SELECT ONE BEGIN
                    //-----------------------------------------------------------------------------------------------------------------------------

                    //Inicio Do metodo SelectOne
                    //stream.WriteLine("\t\t\t\t" + "/*" + "Metodo para fazer um select especifico de um elemento existente na tabela " + NomeDaTabela + "*/");
                    stream.WriteLine("\t\t\t\t/// <summary>");
                    stream.WriteLine("\t\t\t\t///" + "Metodo para fazer um select especifico de um elemento existente na tabela " + NomeDaTabela);
                    stream.WriteLine("\t\t\t\t/// <summary>");
                    stream.WriteLine("\t\t\t\t/// <param name=" + "\"" + NomeDaTabela.Remove(0, 3) + "\"" + " >" + "Objecto " + NomeDaTabela.Remove(0, 3) + "</param>");
                    stream.WriteLine("\t\t\t\t/// <returns></returns>");
                    stream.WriteLine("\t\t\t\tpublic " + NomeDaTabela + " " + " SelectOne(" + NomeDaTabela + " " + NomeDaTabela.Remove(0, 3) + ", string _StringConnection)"); //Declara o metodo que restorna a lista de dados
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\ttry");
                    stream.WriteLine("\t\t\t\t\t{");
                    //Todo Codido Try deve ficar aqui dentro
                    stream.WriteLine("\t\t\t\t\t\tSqlCommand command = new SqlCommand(\"" + "SP_" + NomeDaTabela + "\"," + "connection.connectar(_StringConnection));");
                    stream.WriteLine("\t\t\t\t\t\tcommand.CommandType = System.Data.CommandType.StoredProcedure;");
                    foreach (var x in estrutura_Infos)
                    {
                        stream.WriteLine("\t\t\t\t\t\tcommand.Parameters.Add(new SqlParameter(\"@" + x.Nome + "\"," + NomeDaTabela.Remove(0, 3) + "." + x.Nome + "));");
                    }
                    stream.WriteLine("\t\t\t\t\t\t//command.Parameters.Add(new SqlParameter(\"@Retorno" + "\"," + NomeDaTabela.Remove(0, 3) + "." + "Retorno" + "));");
                    stream.WriteLine("\t\t\t\t\t\t//command.Parameters.Add(new SqlParameter(\"@Retorno\", SqlDbType.VarChar, 800)).Direction = ParameterDirection.Output;");
                    stream.WriteLine("\t\t\t\t\t\tcommand.Parameters.Add(new SqlParameter(\"@Opcao" + "\"," + NomeDaTabela.Remove(0, 3) + "." + "Opcao" + "));");
                    stream.WriteLine("\t\t\t\t\t\tSqlDataReader dataReader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);");
                    stream.WriteLine("\t\t\t\t\t\t" + NomeDaTabela + "  tb" + NomeDaTabela.Remove(0, 3) + " = new " + NomeDaTabela + "();");
                    stream.WriteLine("\t\t\t\t\t\twhile (dataReader.Read())");
                    stream.WriteLine("\t\t\t\t\t\t{"); //Começa o while
                    // stream.WriteLine("\t\t\t\t\t\t\t" + NomeDaTabela + "_Info tb" + NomeDaTabela.Remove(0, 3) + " = new " + NomeDaTabela + "_Info();");
                    foreach (var x in estrutura_Infos)
                    {
                        //Convert.ToString(dataReader["Id_Conversao"]);
                        //stream.WriteLine("\t\t\t\t\t\t\ttb" + NomeDaTabela.Remove(0, 3) + "." + x.Nome + " = " + " Convert.ToString(dataReader[\"" + x.Nome + "\"]);");
                        // Convert.ToString(dataReader["Id_Conversao"]);
                        if (x.Tipo.Contains("int"))
                        {
                            stream.WriteLine("\t\t\t\t\t\t\ttb" + NomeDaTabela.Remove(0, 3) + "." + x.Nome + " = " + " int.Parse(Convert.ToString(dataReader[\"" + x.Nome + "\"]));");

                        }
                        else if (x.Tipo.Contains("char") || x.Tipo.Contains("varchar") || x.Tipo.Contains("longtext") || x.Tipo.Contains("nvarchar"))
                        {
                            stream.WriteLine("\t\t\t\t\t\t\ttb" + NomeDaTabela.Remove(0, 3) + "." + x.Nome + " = " + " Convert.ToString(dataReader[\"" + x.Nome + "\"]);");
                        }
                        else if (x.Tipo.Contains("float"))
                        {
                            x.Tipo = "float";
                            stream.WriteLine("\t\t\tpublic " + x.Tipo + " " + x.Nome + "{ get; set; }");
                        }
                        else if (x.Tipo.Contains("decimal"))
                        {
                            stream.WriteLine("\t\t\t\t\t\t\ttb" + NomeDaTabela.Remove(0, 3) + "." + x.Nome + " = " + " Convert.ToDecimal(dataReader[\"" + x.Nome + "\"]);");
                        }
                        else if (x.Tipo.Contains("Date") || x.Tipo.Contains("date") || x.Tipo.Contains("DateTime") || x.Tipo.Contains("datetime"))
                        {
                            stream.WriteLine("\t\t\t\t\t\t\ttb" + NomeDaTabela.Remove(0, 3) + "." + x.Nome + " = " + " Convert.ToDateTime(dataReader[\"" + x.Nome + "\"]);");

                        }
                        else
                        {
                            stream.WriteLine("\t\t\t\t\t\t\ttb" + NomeDaTabela.Remove(0, 3) + "." + x.Nome + " = " + " Convert.ToString(dataReader[\"" + x.Nome + "\"]);");

                        }
                    }
                    // stream.WriteLine("\t\t\t\t\t\t\t" + "Lista" + NomeDaTabela.Remove(0, 3) + "s.add(" + "tb" + NomeDaTabela.Remove(0, 3) + ");");
                    stream.WriteLine("\t\t\t\t\t\t}\n"); //Termina o while

                    stream.WriteLine("\t\t\t\t\t\t\tdataReader.Close();");  //Fecha o datareader
                    stream.WriteLine("\t\t\t\t\t\t\tconnection.desconectar(_StringConnection);"); //Fecha a conecxão com a Base De Dados
                    stream.WriteLine("\t\t\t\t\t\t\treturn " + "tb" + NomeDaTabela.Remove(0, 3) + ";");
                    //Todo Codido Try deve ficar aqui dentro
                    stream.WriteLine("\t\t\t\t\t}");
                    stream.WriteLine("\t\t\t\t\tcatch (SqlException ex)");
                    stream.WriteLine("\t\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t\tthrow ex;");
                    stream.WriteLine("\t\t\t\t\t}");
                    stream.WriteLine("\t\t\t\t\tcatch (Exception ex)");
                    stream.WriteLine("\t\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t\tthrow ex;");
                    stream.WriteLine("\t\t\t\t\t}");
                    stream.WriteLine("\t\t\t\t}\n\n");
                    //Fim Do metodo SelectOne

                    //------------------------------------------------------------------------------------------------------------------------------
                    //SEGUNDO METODO SELECT ONE AND
                    //-----------------------------------------------------------------------------------------------------------------------------

                    #endregion "SEGUNDO METODO SELECT ONE AND"

                    #region "PRIMEIRO  METODO SELECT ONE Async AND"
                    //------------------------------------------------------------------------------------------------------------------------------
                    //PRIMEIRO  METODO SELECT ONE Async AND
                    //-----------------------------------------------------------------------------------------------------------------------------
                    //stream.WriteLine("\t\t\t\t" + "/*" + "Metodo para fazer um select especifico de um elemento existente na tabela na tabela de maneira assincrona async " + NomeDaTabela + "*/");
                    stream.WriteLine("\t\t\t\t/// <summary>");
                    stream.WriteLine("\t\t\t\t///" + "Metodo para fazer um select especifico de um elemento existente na tabela na tabela de maneira assincrona async " + NomeDaTabela);
                    stream.WriteLine("\t\t\t\t/// <summary>");
                    stream.WriteLine("\t\t\t\t/// <param name=" + "\"" + NomeDaTabela.Remove(0, 3) + "\"" + " >" + "Objecto " + NomeDaTabela.Remove(0, 3) + "</param>");
                    stream.WriteLine("\t\t\t\t/// <returns></returns>");
                    stream.WriteLine("\t\t\t\tpublic async Task<" + NomeDaTabela + "> SelectOneAsync(" + NomeDaTabela + "  " + NomeDaTabela.Remove(0, 3) + ", string _StringConnection)"); //Declara o metodo que restorna a lista de dados
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t" + NomeDaTabela + " Result = null;");
                    stream.WriteLine("\t\t\t\t\tawait Task.Factory.StartNew(() =>");
                    stream.WriteLine("\t\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t\t\tResult = SelectOne(" + NomeDaTabela.Remove(0, 3) + ", _StringConnection);");
                    stream.WriteLine("\t\t\t\t\t});\n");
                    stream.WriteLine("\t\t\t\t\treturn Result;");
                    stream.WriteLine("\t\t\t\t}\n\n");
                    //------------------------------------------------------------------------------------------------------------------------------
                    //PRIMEIRO  METODO SELECT ONE Async AND
                    //-----------------------------------------------------------------------------------------------------------------------------

                    #endregion

                    #region "TERCEIRO METODO INSERT BEGIN"
                    //------------------------------------------------------------------------------------------------------------------------------
                    //TERCEIRO METODO INSERT BEGIN
                    //-----------------------------------------------------------------------------------------------------------------------------

                    //Inicio Do metodo Insert
                    //stream.WriteLine("\t\t\t\t" + "/*" + "Metodo para fazer um Insert na Tabela " + NomeDaTabela + "*/");
                    stream.WriteLine("\t\t\t\t/// <summary>");
                    stream.WriteLine("\t\t\t\t///" + "Metodo para fazer um Insert na Tabela " + NomeDaTabela);
                    stream.WriteLine("\t\t\t\t/// <summary>");
                    stream.WriteLine("\t\t\t\t/// <param name=" + "\"" + NomeDaTabela.Remove(0, 3) + "\"" + " >" + "Objecto " + NomeDaTabela.Remove(0, 3) + "</param>");
                    stream.WriteLine("\t\t\t\t/// <returns></returns>");
                    stream.WriteLine("\t\t\t\tpublic string " + " Insert(" + NomeDaTabela + " " + NomeDaTabela.Remove(0, 3) + ", string _StringConnection)"); //Declara o metodo que restorna a lista de dados
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\ttry");
                    stream.WriteLine("\t\t\t\t\t{");
                    //Todo Codido Try deve ficar aqui dentro
                    stream.WriteLine("\t\t\t\t\t\tSqlCommand command = new SqlCommand(\"" + "SP_" + NomeDaTabela + "\"," + "connection.connectar(_StringConnection));");
                    stream.WriteLine("\t\t\t\t\t\tcommand.CommandType = System.Data.CommandType.StoredProcedure;");
                    //Add parametros Sql
                    foreach (var x in estrutura_Infos)
                    {
                        stream.WriteLine("\t\t\t\t\t\tcommand.Parameters.Add(new SqlParameter(\"@" + x.Nome + "\"," + NomeDaTabela.Remove(0, 3) + "." + x.Nome + "));");
                    }
                    stream.WriteLine("\t\t\t\t\t\t//command.Parameters.Add(new SqlParameter(\"@Retorno" + "\"," + NomeDaTabela.Remove(0, 3) + "." + "Retorno" + "));");
                    stream.WriteLine("\t\t\t\t\t\tcommand.Parameters.Add(new SqlParameter(\"@Retorno\", SqlDbType.VarChar, 800)).Direction = ParameterDirection.Output;");
                    stream.WriteLine("\t\t\t\t\t\tcommand.Parameters.Add(new SqlParameter(\"@Opcao" + "\"," + NomeDaTabela.Remove(0, 3) + "." + "Opcao" + "));");
                    //command.ExecuteNonQuery();
                    //object result = command.ExecuteScalar();
                    //command.Connection.Close();
                    //return result.ToString();
                    stream.WriteLine("\t\t\t\t\t\t//command.ExecuteNonQuery();");  //Executar a Query
                    stream.WriteLine("\t\t\t\t\t\tobject result = command.ExecuteScalar();"); //Le o resultado que a base de ados retorna
                    stream.WriteLine("\t\t\t\t\t\tstring Retorno = Convert.ToString(command.Parameters[\"@Retorno\"].Value);"); //Le o resultado que a base de ados retorna
                    stream.WriteLine("\t\t\t\t\t\t//_output = Retorno;"); //Le o resultado que a base de ados retorna
                    stream.WriteLine("\t\t\t\t\t\tcommand.Connection.Close();"); //Fecha a conecxão com a Base De Dados
                    stream.WriteLine("\t\t\t\t\t\treturn Retorno;"); //Retorno da função
                    //Todo Codido Try deve ficar aqui dentro
                    stream.WriteLine("\t\t\t\t\t}");
                    stream.WriteLine("\t\t\t\t\tcatch (SqlException ex)");
                    stream.WriteLine("\t\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t\treturn ex.Message;");
                    stream.WriteLine("\t\t\t\t\t}");
                    stream.WriteLine("\t\t\t\t\tcatch (Exception ex)");
                    stream.WriteLine("\t\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t\treturn ex.Message;");
                    stream.WriteLine("\t\t\t\t\t}");
                    stream.WriteLine("\t\t\t\t}\n\n");

                    //Fim Do metodo Insert
                    #endregion

                    #region "TERCEIRO METODO INSERT AND"
                    
                    //------------------------------------------------------------------------------------------------------------------------------
                    //TERCEIRO METODO INSERT AND
                    //-----------------------------------------------------------------------------------------------------------------------------


                    //------------------------------------------------------------------------------------------------------------------------------
                    //TERCEIRO METODO INSERT ASYNC BEGIN
                    //-----------------------------------------------------------------------------------------------------------------------------
                    //stream.WriteLine("\t\t\t\t" + "/*" + "Metodo para fazer um Insert na Tabela de maneira assincrona async " + NomeDaTabela + "*/");
                    stream.WriteLine("\t\t\t\t/// <summary>");
                    stream.WriteLine("\t\t\t\t///" + "Metodo para fazer um Insert na Tabela de maneira assincrona async " + NomeDaTabela);
                    stream.WriteLine("\t\t\t\t/// <summary>");
                    stream.WriteLine("\t\t\t\t/// <param name=" + "\"" + NomeDaTabela.Remove(0, 3) + "\"" + " >" + "Objecto " + NomeDaTabela.Remove(0, 3) + "</param>");
                    stream.WriteLine("\t\t\t\t/// <returns></returns>");
                    stream.WriteLine("\t\t\t\tpublic async Task<string> InsertAsync(" + NomeDaTabela + "  " + NomeDaTabela.Remove(0, 3) + ", string _StringConnection)"); //Declara o metodo que restorna a lista de dados
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\tstring Result = null;");
                    stream.WriteLine("\t\t\t\t\tawait Task.Factory.StartNew(() =>");
                    stream.WriteLine("\t\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t\t\tResult = Insert(" + NomeDaTabela.Remove(0, 3) + ", _StringConnection);");
                    stream.WriteLine("\t\t\t\t\t});\n");
                    stream.WriteLine("\t\t\t\t\treturn Result;");
                    stream.WriteLine("\t\t\t\t}\n\n");
                    //------------------------------------------------------------------------------------------------------------------------------
                    //TERCEIRO METODO INSERT ASYNC AND
                    //-----------------------------------------------------------------------------------------------------------------------------

                    #endregion

                    #region "QUARTO METODO UPDATE BEGIN"
                    
                    //------------------------------------------------------------------------------------------------------------------------------
                    //QUARTO METODO UPDATE BEGIN
                    //-----------------------------------------------------------------------------------------------------------------------------

                    //Inicio Do metodo Update
                    // stream.WriteLine("\t\t\t\t" + "/*" + "Metodo para fazer Update de um elemento na tabela " + NomeDaTabela + "*/");
                    stream.WriteLine("\t\t\t\t/// <summary>");
                    stream.WriteLine("\t\t\t\t///" + "Metodo para fazer Update de um elemento na tabela " + NomeDaTabela);
                    stream.WriteLine("\t\t\t\t/// <summary>");
                    stream.WriteLine("\t\t\t\t/// <param name=" + "\"" + NomeDaTabela.Remove(0, 3) + "\"" + " >" + "Objecto " + NomeDaTabela.Remove(0, 3) + "</param>");
                    stream.WriteLine("\t\t\t\t/// <returns></returns>");
                    stream.WriteLine("\t\t\t\tpublic string " + " Delete(" + NomeDaTabela + " " + NomeDaTabela.Remove(0, 3) + ", string _StringConnection)"); //Declara o metodo que restorna a lista de dados
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\ttry");
                    stream.WriteLine("\t\t\t\t\t{");
                    //Todo Codido Try deve ficar aqui dentro
                    stream.WriteLine("\t\t\t\t\t\tSqlCommand command = new SqlCommand(\"" + "SP_" + NomeDaTabela + "\"," + "connection.connectar(_StringConnection));");
                    stream.WriteLine("\t\t\t\t\t\tcommand.CommandType = System.Data.CommandType.StoredProcedure;");
                    //Add parametros Sql
                    foreach (var x in estrutura_Infos)
                    {
                        stream.WriteLine("\t\t\t\t\t\tcommand.Parameters.Add(new SqlParameter(\"@" + x.Nome + "\"," + NomeDaTabela.Remove(0, 3) + "." + x.Nome + "));");
                    }
                    stream.WriteLine("\t\t\t\t\t\t//command.Parameters.Add(new SqlParameter(\"@Retorno" + "\"," + NomeDaTabela.Remove(0, 3) + "." + "Retorno" + "));");
                    stream.WriteLine("\t\t\t\t\t\tcommand.Parameters.Add(new SqlParameter(\"@Retorno\", SqlDbType.VarChar, 800)).Direction = ParameterDirection.Output;");
                    stream.WriteLine("\t\t\t\t\t\tcommand.Parameters.Add(new SqlParameter(\"@Opcao" + "\"," + NomeDaTabela.Remove(0, 3) + "." + "Opcao" + "));");
                    //command.ExecuteNonQuery();
                    //object result = command.ExecuteScalar();
                    //command.Connection.Close();
                    //return result.ToString();
                    stream.WriteLine("\t\t\t\t\t\t//command.ExecuteNonQuery();");  //Executar a Query
                    stream.WriteLine("\t\t\t\t\t\tobject result = command.ExecuteScalar();"); //Le o resultado que a base de ados retorna
                    stream.WriteLine("\t\t\t\t\t\tstring Retorno = Convert.ToString(command.Parameters[\"@Retorno\"].Value);"); //Le o resultado que a base de ados retorna
                    stream.WriteLine("\t\t\t\t\t\t//_output = Retorno;"); //Le o resultado que a base de ados retorna
                    stream.WriteLine("\t\t\t\t\t\tcommand.Connection.Close();"); //Fecha a conecxão com a Base De Dados
                    stream.WriteLine("\t\t\t\t\t\treturn Retorno;"); //Retorno da função
                    //Todo Codido Try deve ficar aqui dentro
                    stream.WriteLine("\t\t\t\t\t}");
                    stream.WriteLine("\t\t\t\t\tcatch (SqlException ex)");
                    stream.WriteLine("\t\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t\treturn ex.Message;");
                    stream.WriteLine("\t\t\t\t\t}");
                    stream.WriteLine("\t\t\t\t\tcatch (Exception ex)");
                    stream.WriteLine("\t\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t\treturn ex.Message;");
                    stream.WriteLine("\t\t\t\t\t}");
                    stream.WriteLine("\t\t\t\t}\n\n");
                    //Fim Do metodo Update

                    //------------------------------------------------------------------------------------------------------------------------------
                    //QUARTO METODO UPDATE AND
                    //-----------------------------------------------------------------------------------------------------------------------------

                    #endregion

                    #region "QUARTO METODO UPDATE ASYNC BEGIN"
                    //------------------------------------------------------------------------------------------------------------------------------
                    //QUARTO METODO UPDATE ASYNC BEGIN
                    //-----------------------------------------------------------------------------------------------------------------------------
                    //stream.WriteLine("\t\t\t\t" + "/*" + "Metodo para fazer Update de um elemento na tabela de maneira assincrona " + NomeDaTabela + "*/");
                    stream.WriteLine("\t\t\t\t/// <summary>");
                    stream.WriteLine("\t\t\t\t///" + "Metodo para fazer Update de um elemento na tabela de maneira assincrona " + NomeDaTabela);
                    stream.WriteLine("\t\t\t\t/// <summary>");
                    stream.WriteLine("\t\t\t\t/// <param name=" + "\"" + NomeDaTabela.Remove(0, 3) + "\"" + " >" + "Objecto " + NomeDaTabela.Remove(0, 3) + "</param>");
                    stream.WriteLine("\t\t\t\t/// <returns></returns>");
                    stream.WriteLine("\t\t\t\tpublic async Task<string> UpdateAsync(" + NomeDaTabela + "  " + NomeDaTabela.Remove(0, 3) + ", string _StringConnection)"); //Declara o metodo que restorna a lista de dados
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\tstring Result = null;");
                    stream.WriteLine("\t\t\t\t\tawait Task.Factory.StartNew(() =>");
                    stream.WriteLine("\t\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t\t\tResult = Update(" + NomeDaTabela.Remove(0, 3) + ", _StringConnection);");
                    stream.WriteLine("\t\t\t\t\t});\n");
                    stream.WriteLine("\t\t\t\t\treturn Result;");
                    stream.WriteLine("\t\t\t\t}\n\n");
                    //------------------------------------------------------------------------------------------------------------------------------
                    //QUARTO METODO UPDATE ASYNC AND
                    //-----------------------------------------------------------------------------------------------------------------------------

                    #endregion

                    #region "QUINTO METODO DELETE BEGIN"
                    //------------------------------------------------------------------------------------------------------------------------------
                    //QUINTO METODO DELETE BEGIN
                    //-----------------------------------------------------------------------------------------------------------------------------

                    //Inicio Do metodo Delete
                    // stream.WriteLine("\t\t\t\t" + "/*" + "Metodo para fazer delete de um elemento na tabela" + NomeDaTabela + "*/");
                    stream.WriteLine("\t\t\t\t/// <summary>");
                    stream.WriteLine("\t\t\t\t///" + "Metodo para fazer delete de um elemento na tabela " + NomeDaTabela);
                    stream.WriteLine("\t\t\t\t/// <summary>");
                    stream.WriteLine("\t\t\t\t/// <param name=" + "\"" + NomeDaTabela.Remove(0, 3) + "\"" + " >" + "Objecto " + NomeDaTabela.Remove(0, 3) + "</param>");
                    stream.WriteLine("\t\t\t\t/// <returns></returns>");
                    stream.WriteLine("\t\t\t\tpublic string " + " Update(" + NomeDaTabela + " " + NomeDaTabela.Remove(0, 3) + ", string _StringConnection)"); //Declara o metodo que restorna a lista de dados
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\ttry");
                    stream.WriteLine("\t\t\t\t\t{");
                    //Todo Codido Try deve ficar aqui dentro
                    stream.WriteLine("\t\t\t\t\t\tSqlCommand command = new SqlCommand(\"" + "SP_" + NomeDaTabela + "\"," + "connection.connectar(_StringConnection));");
                    stream.WriteLine("\t\t\t\t\t\tcommand.CommandType = System.Data.CommandType.StoredProcedure;");
                    //Add parametros Sql
                    foreach (var x in estrutura_Infos)
                    {
                        stream.WriteLine("\t\t\t\t\t\tcommand.Parameters.Add(new SqlParameter(\"@" + x.Nome + "\"," + NomeDaTabela.Remove(0, 3) + "." + x.Nome + "));");
                    }
                    stream.WriteLine("\t\t\t\t\t\t//command.Parameters.Add(new SqlParameter(\"@Retorno" + "\"," + NomeDaTabela.Remove(0, 3) + "." + "Retorno" + "));");
                    stream.WriteLine("\t\t\t\t\t\tcommand.Parameters.Add(new SqlParameter(\"@Retorno\", SqlDbType.VarChar, 800)).Direction = ParameterDirection.Output;");
                    stream.WriteLine("\t\t\t\t\t\tcommand.Parameters.Add(new SqlParameter(\"@Opcao" + "\"," + NomeDaTabela.Remove(0, 3) + "." + "Opcao" + "));");
                    //command.ExecuteNonQuery();
                    //object result = command.ExecuteScalar();
                    //command.Connection.Close();
                    //return result.ToString();
                    stream.WriteLine("\t\t\t\t\t\t//command.ExecuteNonQuery();");  //Executar a Query
                    stream.WriteLine("\t\t\t\t\t\tobject result = command.ExecuteScalar();"); //Le o resultado que a base de ados retorna
                    stream.WriteLine("\t\t\t\t\t\tstring Retorno = Convert.ToString(command.Parameters[\"@Retorno\"].Value);"); //Le o resultado que a base de ados retorna
                    stream.WriteLine("\t\t\t\t\t\t//_output = Retorno;"); //Le o resultado que a base de ados retorna
                    stream.WriteLine("\t\t\t\t\t\tcommand.Connection.Close();"); //Fecha a conecxão com a Base De Dados
                    stream.WriteLine("\t\t\t\t\t\treturn Retorno;"); //Retorno da função
                    //Todo Codido Try deve ficar aqui dentro
                    stream.WriteLine("\t\t\t\t\t}");
                    stream.WriteLine("\t\t\t\t\tcatch (SqlException ex)");
                    stream.WriteLine("\t\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t\treturn ex.Message;");
                    stream.WriteLine("\t\t\t\t\t}");
                    stream.WriteLine("\t\t\t\t\tcatch (Exception ex)");
                    stream.WriteLine("\t\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t\treturn ex.Message;");
                    stream.WriteLine("\t\t\t\t\t}");
                    stream.WriteLine("\t\t\t\t}\n");
                    //Fim Do metodo Delete
                    //------------------------------------------------------------------------------------------------------------------------------
                    //QUINTO METODO DELETE AND
                    //-----------------------------------------------------------------------------------------------------------------------------
                    #endregion

                    #region "QUINTO METODO DELETE ASYNC BEGIN"
                    //------------------------------------------------------------------------------------------------------------------------------
                    //QUINTO METODO DELETE ASYNC BEGIN
                    //-----------------------------------------------------------------------------------------------------------------------------
                    //stream.WriteLine("\t\t\t\t" + "/*" + "Metodo para fazer delete de um elemento na tabela de maneira assincrona " + NomeDaTabela + "*/");
                    stream.WriteLine("\t\t\t\t/// <summary>");
                    stream.WriteLine("\t\t\t\t///" + "Metodo para fazer delete de um elemento na tabela de maneira assincrona " + NomeDaTabela);
                    stream.WriteLine("\t\t\t\t/// <summary>");
                    stream.WriteLine("\t\t\t\t/// <param name=" + "\"" + NomeDaTabela.Remove(0, 3) + "\"" + " >" + "Objecto " + NomeDaTabela.Remove(0, 3) + "</param>");
                    stream.WriteLine("\t\t\t\t/// <returns></returns>");
                    stream.WriteLine("\t\t\t\tpublic async Task<string> DeleteAsync(" + NomeDaTabela + "  " + NomeDaTabela.Remove(0, 3) + ", string _StringConnection)"); //Declara o metodo que restorna a lista de dados
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\tstring Result = null;");
                    stream.WriteLine("\t\t\t\t\tawait Task.Factory.StartNew(() =>");
                    stream.WriteLine("\t\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t\t\tResult = Delete(" + NomeDaTabela.Remove(0, 3) + ", _StringConnection);");
                    stream.WriteLine("\t\t\t\t\t});\n");
                    stream.WriteLine("\t\t\t\t\treturn Result;");
                    stream.WriteLine("\t\t\t\t}\n\n");
                    //------------------------------------------------------------------------------------------------------------------------------
                    //QUINTO METODO DELETE ASYNC AND
                    //-----------------------------------------------------------------------------------------------------------------------------

                    #endregion

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

        /// <summary>
        /// Método para gerar a classe de controlador da web api
        /// </summary>
        /// <param name="NomeDaTabela">Nome da tabela que deseja gerar a seu controlador</param>
        /// <param name="NameSpaceDoProjecto">Nome do projecto</param>
        /// <param name="DirectorioAondeSeraGeradoAInfo">Caminho onde será gerado a classe (Ex: C://Documents/ClinteController.cs)</param>
        /// <param name="NameSpaceDAL_INFO">Nome do projecto da INFO</param>
        /// <returns></returns>
        public string GerarControllerAPIDaTabelaSqlServer(string NomeDaTabela, string NameSpaceDoProjecto, string DirectorioAondeSeraGeradoAInfo, string NameSpaceDAL_INFO)
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

                    #region "Declaração das namespace no projecto"

                    //Cabeçalho das biblotecas inicio namespaces
                    stream.WriteLine("using System;");
                    stream.WriteLine("using System.Collections.Generic;");
                    stream.WriteLine("using System.Net;");
                    stream.WriteLine("using System.Net.Http;");
                    stream.WriteLine("using " + NameSpaceDAL_INFO + ".INFO;");
                    stream.WriteLine("using " + NameSpaceDAL_INFO + ".DAL;");
                    stream.WriteLine("using System.Linq;");
                    stream.WriteLine("using System.Threading.Tasks;");
                    stream.WriteLine("//using Auth;");
                    stream.WriteLine("//using Microsoft.AspNetCore.Authentication.JwtBearer;");
                    stream.WriteLine("//using Microsoft.AspNetCore.Authorization;");
                    stream.WriteLine("//using Microsoft.AspNetCore.Cors;");
                    stream.WriteLine("//using Microsoft.AspNetCore.Identity;");
                    stream.WriteLine("using Microsoft.AspNetCore.Mvc;");
                    stream.WriteLine("using Microsoft.Extensions.Configuration;\n\n\n");
                    //Cabeçalho das biblotecas fim namespaces

                    #endregion

                    stream.WriteLine("namespace " + NameSpaceDoProjecto + ".Controllers"); // Escreve o namespace do projecto no arquivo
                    stream.WriteLine("{\n\n");// adiciona a primeira chaveta após o namespcae
                    stream.WriteLine("\t\t//[EnableCors(\"CORSPolicy\")]"); // Adiciona o nome da classe e os seus atributos
                    stream.WriteLine("\t\t//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]"); // Adiciona o nome da classe e os seus atributos
                    stream.WriteLine("\t\t//[Route(\"api/[controller]\")]"); // Adiciona o nome da classe e os seus atributos
                    stream.WriteLine("\t\tpublic class " + NomeDaTabela.Substring(3) + "Controller : Controller"); // Adiciona o nome da classe e os seus atributos
                    stream.WriteLine("\t\t{"); //Abre chaves para escrever todo o codigo que deve existir na classe
                                               //Todo codigo da classe

                    #region "Action get para trazer todos os registos";

                    stream.WriteLine("\t\t\t //GET: api/" + NomeDaTabela.Substring(3));
                    //METODO GET DA CLASS COMEÇA AQUI
                    stream.WriteLine("\t\t\t[HttpGet]");
                    stream.WriteLine("\t\t\t public IActionResult Get()");
                    stream.WriteLine("\t\t\t{");
                    stream.WriteLine("\t\t\t\ttry");
                    stream.WriteLine("\t\t\t\t{");
                    string NomeDaClasse = NomeDaTabela + "_INFO";
                    stream.WriteLine("\t\t\t\t\t " + NomeDaTabela + "_INFO " + NomeDaClasse.ToLower() + " = new " + NomeDaTabela + "_INFO();");
                    stream.WriteLine("\t\t\t\t\t " + NomeDaClasse.ToLower() + ".Opcao = " + "\"" + "Select" + "\";");
                    stream.WriteLine("\t\t\t\t\t List<" + NomeDaTabela + "_INFO> " + NomeDaTabela.Substring(3) + "s" + " = new " + NomeDaTabela + "_DAL().SelectAll(" + NomeDaClasse.ToLower() + ");");
                    stream.WriteLine("\n\t\t\t\t if (" + NomeDaTabela.Substring(3) + "s" + " == null)");
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\treturn NotFound(\"Não existe registo na tabela para a requisição feita\");");
                    stream.WriteLine("\t\t\t\t}else");
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\treturn Ok(" + NomeDaTabela.Substring(3) + "s" + ");");
                    stream.WriteLine("\t\t\t\t}");
                    stream.WriteLine("\t\t\t\t}"); //Aqui fecha o código do try
                    stream.WriteLine("\t\t\t\tcatch (Exception ex)");
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t return StatusCode(500, ex.Message);");
                    stream.WriteLine("\t\t\t\t}"); //Aqui fecha o códigodo catch
                    stream.WriteLine("\t\t\t}");//Aqui fecha o código da função Get
                                                //METODO GET DO CONTROLLE TERMINA AQUI

                    #endregion


                    #region "Action Post para poder inserir registo"

                    //METODO POST DO CONTROLLER COMEÇA AQUI 
                    stream.WriteLine("\n\n\t\t\t // POST: api/" + NomeDaTabela.Substring(3));
                    stream.WriteLine("\t\t\t[HttpPost]");
                    stream.WriteLine("\t\t\t public IActionResult Post([FromBody]" + NomeDaTabela + "_INFO " + NomeDaTabela.Substring(3).ToLower() + ")");
                    stream.WriteLine("\t\t\t{");//Aqui começa co código da função POST
                    stream.WriteLine("\t\t\t\tstring erro = null;");
                    stream.WriteLine("\t\t\t\ttry"); //Aqui começa o try
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t " + NomeDaTabela.Substring(3).ToLower() + ".Opcao = " + "\"" + "Insert" + "\";");
                    stream.WriteLine("\t\t\t\t\t// " + NomeDaTabela.Substring(3) + ".Id = " + "Guid.NewGuid().ToString();");
                    stream.WriteLine("\t\t\t\t\t erro = new " + NomeDaTabela + "_DAL()" + ".Insert" + "(" + NomeDaTabela.Substring(3).ToLower() + ");");
                    stream.WriteLine("\t\t\t\t\t return Ok(erro);");
                    stream.WriteLine("\t\t\t\t}"); //Aqui fecha o código do try
                    stream.WriteLine("\t\t\t\tcatch (Exception ex)");
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t return BadRequest(ex.Message);");
                    stream.WriteLine("\t\t\t\t}"); //Aqui fecha o códigodo catch
                    stream.WriteLine("\t\t\t}");//Aqui fecha o código da função POST

                    #endregion

                    #region "Action Put para poder alterar um registo"
                  
                    //METODO PUT DO CONTROLLER COMEÇA AQUI
                    stream.WriteLine("\n\n\t\t\t // Put: api/" + NomeDaTabela.Substring(3));
                    stream.WriteLine("\t\t\t[HttpPut]");
                    stream.WriteLine("\t\t\t public IActionResult Put([FromBody]" + NomeDaTabela + "_INFO " + NomeDaTabela.Substring(3).ToLower() + ")");
                    stream.WriteLine("\t\t\t{");//Aqui começa co código da função Put
                    stream.WriteLine("\t\t\t\ttry"); //Aqui começa o try
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t " + NomeDaTabela.Substring(3).ToLower() + ".Opcao = " + "\"" + "Update" + "\";");
                    stream.WriteLine("\t\t\t\t\t var response = new " + NomeDaTabela + "_DAL()" + ".Update" + "(" + NomeDaTabela.Substring(3).ToLower() + ");");
                    stream.WriteLine("\t\t\t\t\t return Ok(response);");
                    stream.WriteLine("\t\t\t\t}"); //Aqui fecha o código do try
                    stream.WriteLine("\t\t\t\tcatch (Exception ex)");
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t return BadRequest(ex.Message);");
                    stream.WriteLine("\t\t\t\t}"); //Aqui fecha o códigodo catch
                    stream.WriteLine("\t\t\t}");//Aqui fecha o código da função Put

                    #endregion


                    #region "Action Delete para poder eliminar um registo"

                    //METODO DELETE DO CONTROLLER COMEÇA AQUI
                    stream.WriteLine("\n\n\t\t\t // DELETE: api/" + NomeDaTabela.Substring(3));
                    stream.WriteLine("\t\t\t[HttpDelete(\"{id}\")]");
                    stream.WriteLine("\t\t\t public IActionResult Delete(string id)");
                    stream.WriteLine("\t\t\t{");//Aqui começa co código da função Delete
                    stream.WriteLine("\t\t\t\ttry"); //Aqui começa o try
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t" + NomeDaTabela + "_INFO " + NomeDaTabela.Substring(3) + " = new " + NomeDaTabela + "_INFO();");
                    stream.WriteLine("\t\t\t\t\t" + NomeDaTabela.Substring(3) + ".Opcao = " + "\"" + "Delete" + "\";");
                    stream.WriteLine("\t\t\t\t\t//" + NomeDaTabela.Substring(3) + ".id = id;");
                    stream.WriteLine("\t\t\t\t\tvar response = new " + NomeDaTabela + "_DAL().Delete" + "(" + NomeDaTabela.Substring(3) + ");");
                    stream.WriteLine("\t\t\t\t\treturn Ok(response);");
                    stream.WriteLine("\t\t\t\t}"); //Aqui fecha o código do try
                    stream.WriteLine("\t\t\t\tcatch (Exception ex)");
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t return BadRequest(ex.Message);");
                    stream.WriteLine("\t\t\t\t}"); //Aqui fecha o códigodo catch
                    stream.WriteLine("\t\t\t}");//Aqui fecha o código da função Delete
                   
                    #endregion

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

        /// <summary>
        /// Método para gerar as classs que consome a API no C#
        /// </summary>
        /// <param name="NomeDaTabela">Nome da tabela</param>
        /// <param name="NameSpaceDoProjecto">Nome do projecto</param>
        /// <param name="DirectorioAondeSeraGeradoAInfo">Caminho onde será gerado a classe (Ex: C://Documents/ClinteController.cs)</param>
        /// <returns></returns>
        public string GerarClasseConsumirAPI_CsharpAPIDaTabelaSqlServer(string NomeDaTabela, string NameSpaceDoProjecto, string DirectorioAondeSeraGeradoAInfo)
        {

            try
            {
               // Mapeamento mapeamento = new Mapeamento();

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

                    #region "Metodo para fazer POST na tabela"

                    //METODO API/POST DA CLASS COMEÇA AQUI
                    stream.WriteLine("\t\t\t public async Task<string> POST" + NomeDaTabela.Substring(3) + "(" + NomeDaTabela + "_INFO " + NomeDaTabela.Substring(3) + ")");
                    stream.WriteLine("\t\t\t{"); //Aqui fica todo código da função POST
                    stream.WriteLine("\t\t\t\tvar json = JsonConvert.SerializeObject(" + NomeDaTabela.Substring(3) + ");");
                    stream.WriteLine("\t\t\t\tvar content = new StringContent(json, Encoding.UTF8," + "\"" + "application/json" + "\");");
                    stream.WriteLine("\t\t\t\tusing (var client = new HttpClient())");
                    stream.WriteLine("\t\t\t\t{");//Aqui começa o using
                    stream.WriteLine("\t\t\t\t\tstring URL = string.Concat(ConfigSystem.URLAPI," + "\"" + "/" + NomeDaTabela.Substring(3) + "\");");
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

                    #endregion

                    #region "Método pra fazer GET na tabela, listar todos os dados"
                  
                    //METODO API/GET DA CLASS COMEÇA AQUI
                    stream.WriteLine("\n\n\t\t\t public async Task<List<" + NomeDaTabela + "_INFO>>" + " GET" + NomeDaTabela.Substring(3) + "()");
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
                  //  stream.WriteLine("\t\t\t\t\treturn new List<" +  NomeDaTabela + "_INFO>();");
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
                    #endregion

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
