/*Gerado no Gerador de Codigo Do Engº Gerson Z. Maiamba
Data: 23/09/2020 22:57:01
Direitos autorais de Engº Gerson Z. Maiamba*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Mayamba.INFO;
using Mayamba;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using Gerador_De_Codigo_Teste;

namespace Mayamba.DAL
{
		public class Tb_Email_DAL
		{
				ConexaoSqlServer connection = new ConexaoSqlServer();

				/// <summary>
				///Metodo para fazer um select de todos os dados existente na tabela Tb_Email
				/// <summary>
				/// <param name="Email" >Objecto Email</param>
				/// <returns></returns>
				public List<Tb_Email> SelectAll(Tb_Email  Email, string _StringConnection)
				{
					try
					{
						SqlCommand command = new SqlCommand("SP_Tb_Email",connection.connectar(_StringConnection));
						command.CommandType = System.Data.CommandType.StoredProcedure;
						command.Parameters.Add(new SqlParameter("@Id_Email",Email.Id_Email));
						command.Parameters.Add(new SqlParameter("@Nome",Email.Nome));
						command.Parameters.Add(new SqlParameter("@Telefone",Email.Telefone));
						command.Parameters.Add(new SqlParameter("@Email_Origem",Email.Email_Origem));
						command.Parameters.Add(new SqlParameter("@Body",Email.Body));
						command.Parameters.Add(new SqlParameter("@Email_Destino",Email.Email_Destino));
						command.Parameters.Add(new SqlParameter("@Estado_Email",Email.Estado_Email));
						command.Parameters.Add(new SqlParameter("@Data_Registo",Email.Data_Registo));
						//command.Parameters.Add(new SqlParameter("@Retorno",Email.Retorno));
						//command.Parameters.Add(new SqlParameter("@Retorno", SqlDbType.VarChar, 800)).Direction = ParameterDirection.Output;
						command.Parameters.Add(new SqlParameter("@Opcao",Email.Opcao));
						SqlDataReader dataReader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
						List<Tb_Email> ListaEmails = new List<Tb_Email>();

						while (dataReader.Read())
						{
							Tb_Email tbEmail = new Tb_Email();
							tbEmail.Id_Email =  Convert.ToString(dataReader["Id_Email"]);
							tbEmail.Nome =  Convert.ToString(dataReader["Nome"]);
							tbEmail.Telefone =  Convert.ToString(dataReader["Telefone"]);
							tbEmail.Email_Origem =  Convert.ToString(dataReader["Email_Origem"]);
							tbEmail.Body =  Convert.ToString(dataReader["Body"]);
							tbEmail.Email_Destino =  Convert.ToString(dataReader["Email_Destino"]);
							tbEmail.Estado_Email =  int.Parse(Convert.ToString(dataReader["Estado_Email"]));
							tbEmail.Data_Registo =  Convert.ToDateTime(dataReader["Data_Registo"]);
							ListaEmails.Add(tbEmail);
						}

							dataReader.Close();
							connection.desconectar(_StringConnection);
							return ListaEmails;
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
				///Metodo para fazer um select de todos os dados existente na tabela de maneira assincrona async Tb_Email
				/// <summary>
				/// <param name="Email" >Objecto Email</param>
				/// <returns></returns>
				public async Task<List<Tb_Email>> SelectAllAsync(Tb_Email  Email, string _StringConnection)
				{
					List <Tb_Email> Result = null;
					await Task.Factory.StartNew(() =>
					{
							Result = SelectAll(Email, _StringConnection);
					});

					return Result;
				}


				/// <summary>
				///Metodo para fazer um select especifico de um elemento existente na tabela Tb_Email
				/// <summary>
				/// <param name="Email" >Objecto Email</param>
				/// <returns></returns>
				public Tb_Email  SelectOne(Tb_Email Email, string _StringConnection)
				{
					try
					{
						SqlCommand command = new SqlCommand("SP_Tb_Email",connection.connectar(_StringConnection));
						command.CommandType = System.Data.CommandType.StoredProcedure;
						command.Parameters.Add(new SqlParameter("@Id_Email",Email.Id_Email));
						command.Parameters.Add(new SqlParameter("@Nome",Email.Nome));
						command.Parameters.Add(new SqlParameter("@Telefone",Email.Telefone));
						command.Parameters.Add(new SqlParameter("@Email_Origem",Email.Email_Origem));
						command.Parameters.Add(new SqlParameter("@Body",Email.Body));
						command.Parameters.Add(new SqlParameter("@Email_Destino",Email.Email_Destino));
						command.Parameters.Add(new SqlParameter("@Estado_Email",Email.Estado_Email));
						command.Parameters.Add(new SqlParameter("@Data_Registo",Email.Data_Registo));
						//command.Parameters.Add(new SqlParameter("@Retorno",Email.Retorno));
						command.Parameters.Add(new SqlParameter("@Opcao",Email.Opcao));
						SqlDataReader dataReader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
						Tb_Email  tbEmail = new Tb_Email();
						while (dataReader.Read())
						{
							tbEmail.Id_Email =  Convert.ToString(dataReader["Id_Email"]);
							tbEmail.Nome =  Convert.ToString(dataReader["Nome"]);
							tbEmail.Telefone =  Convert.ToString(dataReader["Telefone"]);
							tbEmail.Email_Origem =  Convert.ToString(dataReader["Email_Origem"]);
							tbEmail.Body =  Convert.ToString(dataReader["Body"]);
							tbEmail.Email_Destino =  Convert.ToString(dataReader["Email_Destino"]);
							tbEmail.Estado_Email =  int.Parse(Convert.ToString(dataReader["Estado_Email"]));
							tbEmail.Data_Registo =  Convert.ToDateTime(dataReader["Data_Registo"]);
						}

							dataReader.Close();
							connection.desconectar(_StringConnection);
							return tbEmail;
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
				///Metodo para fazer um select especifico de um elemento existente na tabela na tabela de maneira assincrona async Tb_Email
				/// <summary>
				/// <param name="Email" >Objecto Email</param>
				/// <returns></returns>
				public async Task<Tb_Email> SelectOneAsync(Tb_Email  Email, string _StringConnection)
				{
					Tb_Email Result = null;
					await Task.Factory.StartNew(() =>
					{
							Result = SelectOne(Email, _StringConnection);
					});

					return Result;
				}


				/// <summary>
				///Metodo para fazer um Insert na Tabela Tb_Email
				/// <summary>
				/// <param name="Email" >Objecto Email</param>
				/// <returns></returns>
				public string  Insert(Tb_Email Email, string _StringConnection)
				{
					try
					{
						SqlCommand command = new SqlCommand("SP_Tb_Email",connection.connectar(_StringConnection));
						command.CommandType = System.Data.CommandType.StoredProcedure;
						command.Parameters.Add(new SqlParameter("@Id_Email",Email.Id_Email));
						command.Parameters.Add(new SqlParameter("@Nome",Email.Nome));
						command.Parameters.Add(new SqlParameter("@Telefone",Email.Telefone));
						command.Parameters.Add(new SqlParameter("@Email_Origem",Email.Email_Origem));
						command.Parameters.Add(new SqlParameter("@Body",Email.Body));
						command.Parameters.Add(new SqlParameter("@Email_Destino",Email.Email_Destino));
						command.Parameters.Add(new SqlParameter("@Estado_Email",Email.Estado_Email));
						command.Parameters.Add(new SqlParameter("@Data_Registo",Email.Data_Registo));
						//command.Parameters.Add(new SqlParameter("@Retorno",Email.Retorno));
						command.Parameters.Add(new SqlParameter("@Retorno", SqlDbType.VarChar, 800)).Direction = ParameterDirection.Output;
						command.Parameters.Add(new SqlParameter("@Opcao",Email.Opcao));
						//command.ExecuteNonQuery();
						object result = command.ExecuteScalar();
						string Retorno = Convert.ToString(command.Parameters["@Retorno"].Value);
						//_output = Retorno;
						command.Connection.Close();
						return Retorno;
					}
					catch (SqlException ex)
					{
						return ex.Message;
					}
					catch (Exception ex)
					{
						return ex.Message;
					}
				}


				/// <summary>
				///Metodo para fazer um Insert na Tabela de maneira assincrona async Tb_Email
				/// <summary>
				/// <param name="Email" >Objecto Email</param>
				/// <returns></returns>
				public async Task<string> InsertAsync(Tb_Email  Email, string _StringConnection)
				{
					string Result = null;
					await Task.Factory.StartNew(() =>
					{
							Result = Insert(Email, _StringConnection);
					});

					return Result;
				}


				/// <summary>
				///Metodo para fazer Update de um elemento na tabela Tb_Email
				/// <summary>
				/// <param name="Email" >Objecto Email</param>
				/// <returns></returns>
				public string  Delete(Tb_Email Email, string _StringConnection)
				{
					try
					{
						SqlCommand command = new SqlCommand("SP_Tb_Email",connection.connectar(_StringConnection));
						command.CommandType = System.Data.CommandType.StoredProcedure;
						command.Parameters.Add(new SqlParameter("@Id_Email",Email.Id_Email));
						command.Parameters.Add(new SqlParameter("@Nome",Email.Nome));
						command.Parameters.Add(new SqlParameter("@Telefone",Email.Telefone));
						command.Parameters.Add(new SqlParameter("@Email_Origem",Email.Email_Origem));
						command.Parameters.Add(new SqlParameter("@Body",Email.Body));
						command.Parameters.Add(new SqlParameter("@Email_Destino",Email.Email_Destino));
						command.Parameters.Add(new SqlParameter("@Estado_Email",Email.Estado_Email));
						command.Parameters.Add(new SqlParameter("@Data_Registo",Email.Data_Registo));
						//command.Parameters.Add(new SqlParameter("@Retorno",Email.Retorno));
						command.Parameters.Add(new SqlParameter("@Retorno", SqlDbType.VarChar, 800)).Direction = ParameterDirection.Output;
						command.Parameters.Add(new SqlParameter("@Opcao",Email.Opcao));
						//command.ExecuteNonQuery();
						object result = command.ExecuteScalar();
						string Retorno = Convert.ToString(command.Parameters["@Retorno"].Value);
						//_output = Retorno;
						command.Connection.Close();
						return Retorno;
					}
					catch (SqlException ex)
					{
						return ex.Message;
					}
					catch (Exception ex)
					{
						return ex.Message;
					}
				}


				/// <summary>
				///Metodo para fazer Update de um elemento na tabela de maneira assincrona Tb_Email
				/// <summary>
				/// <param name="Email" >Objecto Email</param>
				/// <returns></returns>
				public async Task<string> UpdateAsync(Tb_Email  Email, string _StringConnection)
				{
					string Result = null;
					await Task.Factory.StartNew(() =>
					{
							Result = Update(Email, _StringConnection);
					});

					return Result;
				}


				/// <summary>
				///Metodo para fazer delete de um elemento na tabela Tb_Email
				/// <summary>
				/// <param name="Email" >Objecto Email</param>
				/// <returns></returns>
				public string  Update(Tb_Email Email, string _StringConnection)
				{
					try
					{
						SqlCommand command = new SqlCommand("SP_Tb_Email",connection.connectar(_StringConnection));
						command.CommandType = System.Data.CommandType.StoredProcedure;
						command.Parameters.Add(new SqlParameter("@Id_Email",Email.Id_Email));
						command.Parameters.Add(new SqlParameter("@Nome",Email.Nome));
						command.Parameters.Add(new SqlParameter("@Telefone",Email.Telefone));
						command.Parameters.Add(new SqlParameter("@Email_Origem",Email.Email_Origem));
						command.Parameters.Add(new SqlParameter("@Body",Email.Body));
						command.Parameters.Add(new SqlParameter("@Email_Destino",Email.Email_Destino));
						command.Parameters.Add(new SqlParameter("@Estado_Email",Email.Estado_Email));
						command.Parameters.Add(new SqlParameter("@Data_Registo",Email.Data_Registo));
						//command.Parameters.Add(new SqlParameter("@Retorno",Email.Retorno));
						command.Parameters.Add(new SqlParameter("@Retorno", SqlDbType.VarChar, 800)).Direction = ParameterDirection.Output;
						command.Parameters.Add(new SqlParameter("@Opcao",Email.Opcao));
						//command.ExecuteNonQuery();
						object result = command.ExecuteScalar();
						string Retorno = Convert.ToString(command.Parameters["@Retorno"].Value);
						//_output = Retorno;
						command.Connection.Close();
						return Retorno;
					}
					catch (SqlException ex)
					{
						return ex.Message;
					}
					catch (Exception ex)
					{
						return ex.Message;
					}
				}

				/// <summary>
				///Metodo para fazer delete de um elemento na tabela de maneira assincrona Tb_Email
				/// <summary>
				/// <param name="Email" >Objecto Email</param>
				/// <returns></returns>
				public async Task<string> DeleteAsync(Tb_Email  Email, string _StringConnection)
				{
					string Result = null;
					await Task.Factory.StartNew(() =>
					{
							Result = Delete(Email, _StringConnection);
					});

					return Result;
				}


		}
}
