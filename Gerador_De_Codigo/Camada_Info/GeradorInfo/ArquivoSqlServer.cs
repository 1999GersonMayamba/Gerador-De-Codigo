﻿using System;
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


                    //ADICIONAR PARAMETROS NO PROCEDIMENTO *BEGIN
                    List<Tb_Estrutura_Info> estrutura_Infos = mapeamento.RetornarEstruturaDaTabelaSqlServer(tb_SchemaSqlServer.TABLE_NAME); //Chama na base de dados a estrutura de uma tabela

                    foreach (var x in estrutura_Infos)
                    {
                         if (string.IsNullOrEmpty(x.Maximo_Caracters))
                        {
                            stream.Write("\t@" + x.Nome + " " + x.Tipo + "," + "\n");
                        }
                        else if (!string.IsNullOrEmpty(x.Maximo_Caracters))
                        {
                            stream.Write("\t@" + x.Nome + " " + x.Tipo + "(" + x.Maximo_Caracters + ") = null" + "," + "\n");
                        }
                        else
                        {
                            stream.Write("\t@" + x.Nome + " " + x.Tipo + "," + "\n");
                        }
                    }

                    //Variavél de retorno do Sql cometanto
                    stream.WriteLine("\t@Retorno varchar(100) = null output,");
                    stream.WriteLine("\t@Opcao varchar(20)");
                    stream.WriteLine(")\n\n");
                    //ADICIONAR PARAMETROS NO PROCEDIMENTO  *END

        

                    stream.WriteLine("as\n");

                    //INICIO DO PROCEDIMENTO
                    stream.WriteLine("\tBEGIN -- *Inicio do procedimento\n");


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


                    //BLOCO DE CÓDIGO PARA FAZER O SELECT
                    stream.WriteLine("\t-- Opção para fazer o select");
                    stream.WriteLine("\tIF @Opcao = 'Select'");
                    stream.WriteLine("\tBEGIN");
                    stream.WriteLine("\tSelect * from " + tb_SchemaSqlServer.TABLE_NAME + ";");
                    stream.WriteLine("\tEND\n");
                    //BLOCO DE CÓDIGO PARA FAZER O SELECT

                    //BLOCO DE CÓDIGO PARA FAZER O SELECT ONE
                    stream.WriteLine("\t-- Opção para fazer o Select one");
                    stream.WriteLine("\tIF @Opcao = 'Select_One'");
                    stream.WriteLine("\tBEGIN");
                    stream.WriteLine("\tSelect * from " + tb_SchemaSqlServer.TABLE_NAME + " where Id_" + tb_SchemaSqlServer.TABLE_NAME.Substring(3) + " = @Id_" + tb_SchemaSqlServer.TABLE_NAME.Substring(3) + "; ");
                    stream.WriteLine("\tEND\n");
                    //BLOCO DE CÓDIGO PARA FAZER O SELECT ONE


                    //BLOCO DE CÓDIGO PARA FAZER O DELETE
                    stream.WriteLine("\t-- Opção para fazer o delete");
                    stream.WriteLine("\tIF @Opcao = 'Delete'");
                    stream.WriteLine("\tBEGIN");
                    stream.WriteLine("\tDelete from " + tb_SchemaSqlServer.TABLE_NAME + " where Id_" + tb_SchemaSqlServer.TABLE_NAME.Substring(3) + " = @Id_" + tb_SchemaSqlServer.TABLE_NAME.Substring(3) + "; ");
                    stream.WriteLine("\tEND\n");
                    //BLOCO DE CÓDIGO PARA FAZER O DELETE

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
                    stream.WriteLine("namespace " + NameSpaceDoProjecto + ".INFO");
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
                        else if (x.Tipo.Contains("char") || x.Tipo.Contains("varchar") || x.Tipo.Contains("longtext") || x.Tipo.Contains("nvarchar"))
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
        public string GerarDALDaTabelaSqlServer(string NomeDaTabela, string NameSpaceDoProjecto, string DirectorioAondeSeraGeradoAInfo)
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
                    //Cabeçalho das biblotecas inicio namespaces
                    stream.WriteLine("using System;");
                    stream.WriteLine("using System.Collections.Generic;");
                    stream.WriteLine("using System.Data;");
                    stream.WriteLine("using System.Linq;");
                    stream.WriteLine("using System.Text;");
                    stream.WriteLine("using " + NameSpaceDoProjecto + ".INFO;");
                    stream.WriteLine("using " + NameSpaceDoProjecto + ";");
                    stream.WriteLine("using System.Data.SqlClient;");
                    stream.WriteLine("using System.Threading;");
                    stream.WriteLine("using System.Threading.Tasks;\n\n\n");
                    //Cabeçalho das biblotecas fim namespaces
                    stream.WriteLine("namespace " + NameSpaceDoProjecto + ".DAL"); // Escreve o namespace do projecto no arquivo
                    stream.WriteLine("{");// adiciona a primeira chaveta após o namespcae
                    stream.WriteLine("\t\tpublic class " + NomeDaTabela + "_DAL"); // Adiciona o nome da classe e os seus atributos
                    stream.WriteLine("\t\t{"); //Abre chaves para escrever todo o codigo que deve existir na classe

                    List<Tb_Estrutura_Info> estrutura_Infos = mapeamento.RetornarEstruturaDaTabelaSqlServer(NomeDaTabela); //Chama na base de dados a estrutura de uma tabela

                    stream.WriteLine("\t\t\t\tConexaoSqlServer connection = new ConexaoSqlServer();\n"); //Adiciona a classe de conexão na classe


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
                    stream.WriteLine("\t\t\t\tpublic List<" + NomeDaTabela + "> SelectAll(" + NomeDaTabela  + "  " + NomeDaTabela.Remove(0, 3) + ")"); //Declara o metodo que restorna a lista de dados
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\ttry");
                    stream.WriteLine("\t\t\t\t\t{");
                    //Todo Codido Try deve ficar aqui dentro
                    stream.WriteLine("\t\t\t\t\t\tSqlCommand command = new SqlCommand(\"" + "SP_" + NomeDaTabela + "\"," + "connection.connectar());");
                    stream.WriteLine("\t\t\t\t\t\tcommand.CommandType = System.Data.CommandType.StoredProcedure;");
                    foreach (var x in estrutura_Infos)
                    {
                        stream.WriteLine("\t\t\t\t\t\tcommand.Parameters.Add(new SqlParameter(\"@" + x.Nome + "\"," + NomeDaTabela.Remove(0, 3) + "." + x.Nome + "));");
                    }
                    //command.Parameters.Add(new SqlParameter("@Retorno", null));
                    stream.WriteLine("\t\t\t\t\t\t//command.Parameters.Add(new SqlParameter(\"@Retorno" + "\"," + NomeDaTabela.Remove(0, 3) + "." + "Retorno" + "));");
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
                    stream.WriteLine("\t\t\t\t\t\t\tconnection.desconectar();"); //Fecha a conecxão com a Base De Dados
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
                    stream.WriteLine("\t\t\t\tpublic async Task<List<" + NomeDaTabela + ">> SelectAllAsync(" + NomeDaTabela + "  " + NomeDaTabela.Remove(0, 3) + ")"); //Declara o metodo que restorna a lista de dados
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\tList <"  + NomeDaTabela + "> Result = null;");
                    stream.WriteLine("\t\t\t\t\tawait Task.Factory.StartNew(() =>");
                    stream.WriteLine("\t\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t\t\tResult = SelectAll(" + NomeDaTabela.Remove(0, 3) + ");");
                    stream.WriteLine("\t\t\t\t\t});\n");
                    stream.WriteLine("\t\t\t\t\treturn Result;");
                    stream.WriteLine("\t\t\t\t}\n\n");
                    //Fim do primeiro metodo select all
                    //------------------------------------------------------------------------------------------------------------------------------
                    //PRIMEIRO METDO SELECT ALL Async AND
                    //-----------------------------------------------------------------------------------------------------------------------------


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
                    stream.WriteLine("\t\t\t\tpublic " + NomeDaTabela + " " + " SelectOne(" + NomeDaTabela + " " + NomeDaTabela.Remove(0, 3) + ")"); //Declara o metodo que restorna a lista de dados
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\ttry");
                    stream.WriteLine("\t\t\t\t\t{");
                    //Todo Codido Try deve ficar aqui dentro
                    stream.WriteLine("\t\t\t\t\t\tSqlCommand command = new SqlCommand(\"" + "SP_" + NomeDaTabela + "\"," + "connection.connectar());");
                    stream.WriteLine("\t\t\t\t\t\tcommand.CommandType = System.Data.CommandType.StoredProcedure;");
                    foreach (var x in estrutura_Infos)
                    {
                        stream.WriteLine("\t\t\t\t\t\tcommand.Parameters.Add(new SqlParameter(\"@" + x.Nome + "\"," + NomeDaTabela.Remove(0, 3) + "." + x.Nome + "));");
                    }
                    stream.WriteLine("\t\t\t\t\t\t//command.Parameters.Add(new SqlParameter(\"@Retorno" + "\"," + NomeDaTabela.Remove(0, 3) + "." + "Retorno" + "));");
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
                    stream.WriteLine("\t\t\t\t\t\t\tconnection.desconectar();"); //Fecha a conecxão com a Base De Dados
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

                    //------------------------------------------------------------------------------------------------------------------------------
                    //PRIMEIRO  METODO SELECT ONE Async AND
                    //-----------------------------------------------------------------------------------------------------------------------------
                   //stream.WriteLine("\t\t\t\t" + "/*" + "Metodo para fazer um select especifico de um elemento existente na tabela na tabela de maneira assincrona async " + NomeDaTabela + "*/");
                    stream.WriteLine("\t\t\t\t/// <summary>");
                    stream.WriteLine("\t\t\t\t///" + "Metodo para fazer um select especifico de um elemento existente na tabela na tabela de maneira assincrona async " + NomeDaTabela);
                    stream.WriteLine("\t\t\t\t/// <summary>");
                    stream.WriteLine("\t\t\t\t/// <param name=" + "\"" + NomeDaTabela.Remove(0, 3) + "\"" + " >" + "Objecto " + NomeDaTabela.Remove(0, 3) + "</param>");
                    stream.WriteLine("\t\t\t\t/// <returns></returns>");
                    stream.WriteLine("\t\t\t\tpublic async Task<" + NomeDaTabela + "> SelectOneAsync(" + NomeDaTabela + "  " + NomeDaTabela.Remove(0, 3) + ")"); //Declara o metodo que restorna a lista de dados
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t" + NomeDaTabela + " Result = null;");
                    stream.WriteLine("\t\t\t\t\tawait Task.Factory.StartNew(() =>");
                    stream.WriteLine("\t\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t\t\tResult = SelectOne(" + NomeDaTabela.Remove(0, 3) + ");");
                    stream.WriteLine("\t\t\t\t\t});\n");
                    stream.WriteLine("\t\t\t\t\treturn Result;");
                    stream.WriteLine("\t\t\t\t}\n\n");
                    //------------------------------------------------------------------------------------------------------------------------------
                    //PRIMEIRO  METODO SELECT ONE Async AND
                    //-----------------------------------------------------------------------------------------------------------------------------



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
                    stream.WriteLine("\t\t\t\tpublic string " + " Insert(" + NomeDaTabela + " " + NomeDaTabela.Remove(0, 3) + ")"); //Declara o metodo que restorna a lista de dados
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\ttry");
                    stream.WriteLine("\t\t\t\t\t{");
                    //Todo Codido Try deve ficar aqui dentro
                    stream.WriteLine("\t\t\t\t\t\tSqlCommand command = new SqlCommand(\"" + "SP_" + NomeDaTabela + "\"," + "connection.connectar());");
                    stream.WriteLine("\t\t\t\t\t\tcommand.CommandType = System.Data.CommandType.StoredProcedure;");
                    //Add parametros Sql
                    foreach (var x in estrutura_Infos)
                    {
                        stream.WriteLine("\t\t\t\t\t\tcommand.Parameters.Add(new SqlParameter(\"@" + x.Nome + "\"," + NomeDaTabela.Remove(0, 3) + "." + x.Nome + "));");
                    }
                    stream.WriteLine("\t\t\t\t\t\t//command.Parameters.Add(new SqlParameter(\"@Retorno" + "\"," + NomeDaTabela.Remove(0, 3) + "." + "Retorno" + "));");
                    stream.WriteLine("\t\t\t\t\t\tcommand.Parameters.Add(new SqlParameter(\"@Opcao" + "\"," + NomeDaTabela.Remove(0, 3) + "." + "Opcao" + "));");
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
                    stream.WriteLine("\t\t\t\tpublic async Task<string> InsertAsync(" + NomeDaTabela + "  " + NomeDaTabela.Remove(0, 3) + ")"); //Declara o metodo que restorna a lista de dados
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\tstring Result = null;");
                    stream.WriteLine("\t\t\t\t\tawait Task.Factory.StartNew(() =>");
                    stream.WriteLine("\t\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t\t\tResult = Insert(" + NomeDaTabela.Remove(0, 3) + ");");
                    stream.WriteLine("\t\t\t\t\t});\n");
                    stream.WriteLine("\t\t\t\t\treturn Result;");
                    stream.WriteLine("\t\t\t\t}\n\n");
                    //------------------------------------------------------------------------------------------------------------------------------
                    //TERCEIRO METODO INSERT ASYNC AND
                    //-----------------------------------------------------------------------------------------------------------------------------



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
                    stream.WriteLine("\t\t\t\tpublic string " + " Delete(" + NomeDaTabela + " " + NomeDaTabela.Remove(0, 3) + ")"); //Declara o metodo que restorna a lista de dados
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\ttry");
                    stream.WriteLine("\t\t\t\t\t{");
                    //Todo Codido Try deve ficar aqui dentro
                    stream.WriteLine("\t\t\t\t\t\tSqlCommand command = new SqlCommand(\"" + "SP_" + NomeDaTabela + "\"," + "connection.connectar());");
                    stream.WriteLine("\t\t\t\t\t\tcommand.CommandType = System.Data.CommandType.StoredProcedure;");
                    //Add parametros Sql
                    foreach (var x in estrutura_Infos)
                    {
                        stream.WriteLine("\t\t\t\t\t\tcommand.Parameters.Add(new SqlParameter(\"@" + x.Nome + "\"," + NomeDaTabela.Remove(0, 3) + "." + x.Nome + "));");
                    }
                    stream.WriteLine("\t\t\t\t\t\t//command.Parameters.Add(new SqlParameter(\"@Retorno" + "\"," + NomeDaTabela.Remove(0, 3) + "." + "Retorno" + "));");
                    stream.WriteLine("\t\t\t\t\t\tcommand.Parameters.Add(new SqlParameter(\"@Opcao" + "\"," + NomeDaTabela.Remove(0, 3) + "." + "Opcao" + "));");
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

                    //------------------------------------------------------------------------------------------------------------------------------
                    //QUARTO METODO UPDATE ASYNC BEGIN
                    //-----------------------------------------------------------------------------------------------------------------------------
                    //stream.WriteLine("\t\t\t\t" + "/*" + "Metodo para fazer Update de um elemento na tabela de maneira assincrona " + NomeDaTabela + "*/");
                    stream.WriteLine("\t\t\t\t/// <summary>");
                    stream.WriteLine("\t\t\t\t///" + "Metodo para fazer Update de um elemento na tabela de maneira assincrona " + NomeDaTabela);
                    stream.WriteLine("\t\t\t\t/// <summary>");
                    stream.WriteLine("\t\t\t\t/// <param name=" + "\"" + NomeDaTabela.Remove(0, 3) + "\"" + " >" + "Objecto " + NomeDaTabela.Remove(0, 3) + "</param>");
                    stream.WriteLine("\t\t\t\t/// <returns></returns>");
                    stream.WriteLine("\t\t\t\tpublic async Task<string> UpdateAsync(" + NomeDaTabela + "  " + NomeDaTabela.Remove(0, 3) + ")"); //Declara o metodo que restorna a lista de dados
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\tstring Result = null;");
                    stream.WriteLine("\t\t\t\t\tawait Task.Factory.StartNew(() =>");
                    stream.WriteLine("\t\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t\t\tResult = Update(" + NomeDaTabela.Remove(0, 3) + ");");
                    stream.WriteLine("\t\t\t\t\t});\n");
                    stream.WriteLine("\t\t\t\t\treturn Result;");
                    stream.WriteLine("\t\t\t\t}\n\n");
                    //------------------------------------------------------------------------------------------------------------------------------
                    //QUARTO METODO UPDATE ASYNC AND
                    //-----------------------------------------------------------------------------------------------------------------------------


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
                    stream.WriteLine("\t\t\t\tpublic string " + " Update(" + NomeDaTabela + " " + NomeDaTabela.Remove(0, 3) + ")"); //Declara o metodo que restorna a lista de dados
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\ttry");
                    stream.WriteLine("\t\t\t\t\t{");
                    //Todo Codido Try deve ficar aqui dentro
                    stream.WriteLine("\t\t\t\t\t\tSqlCommand command = new SqlCommand(\"" + "SP_" + NomeDaTabela + "\"," + "connection.connectar());");
                    stream.WriteLine("\t\t\t\t\t\tcommand.CommandType = System.Data.CommandType.StoredProcedure;");
                    //Add parametros Sql
                    foreach (var x in estrutura_Infos)
                    {
                        stream.WriteLine("\t\t\t\t\t\tcommand.Parameters.Add(new SqlParameter(\"@" + x.Nome + "\"," + NomeDaTabela.Remove(0, 3) + "." + x.Nome + "));");
                    }
                    stream.WriteLine("\t\t\t\t\t\t//command.Parameters.Add(new SqlParameter(\"@Retorno" + "\"," + NomeDaTabela.Remove(0, 3) + "." + "Retorno" + "));");
                    stream.WriteLine("\t\t\t\t\t\tcommand.Parameters.Add(new SqlParameter(\"@Opcao" + "\"," + NomeDaTabela.Remove(0, 3) + "." + "Opcao" + "));");
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

                    //------------------------------------------------------------------------------------------------------------------------------
                    //QUINTO METODO DELETE ASYNC BEGIN
                    //-----------------------------------------------------------------------------------------------------------------------------
                    //stream.WriteLine("\t\t\t\t" + "/*" + "Metodo para fazer delete de um elemento na tabela de maneira assincrona " + NomeDaTabela + "*/");
                    stream.WriteLine("\t\t\t\t/// <summary>");
                    stream.WriteLine("\t\t\t\t///" + "Metodo para fazer delete de um elemento na tabela de maneira assincrona " + NomeDaTabela);
                    stream.WriteLine("\t\t\t\t/// <summary>");
                    stream.WriteLine("\t\t\t\t/// <param name=" + "\"" + NomeDaTabela.Remove(0, 3) + "\"" + " >" + "Objecto " + NomeDaTabela.Remove(0, 3) + "</param>");
                    stream.WriteLine("\t\t\t\t/// <returns></returns>");
                    stream.WriteLine("\t\t\t\tpublic async Task<string> DeleteAsync(" + NomeDaTabela + "  " + NomeDaTabela.Remove(0, 3) + ")"); //Declara o metodo que restorna a lista de dados
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\tstring Result = null;");
                    stream.WriteLine("\t\t\t\t\tawait Task.Factory.StartNew(() =>");
                    stream.WriteLine("\t\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t\t\tResult = Delete(" + NomeDaTabela.Remove(0, 3) + ");");
                    stream.WriteLine("\t\t\t\t\t});\n");
                    stream.WriteLine("\t\t\t\t\treturn Result;");
                    stream.WriteLine("\t\t\t\t}\n\n");
                    //------------------------------------------------------------------------------------------------------------------------------
                    //QUINTO METODO DELETE ASYNC AND
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

    }
}
