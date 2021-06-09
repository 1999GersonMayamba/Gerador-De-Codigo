using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camada_Info.GeradorInfo
{
   public class ArquivoCleanAchitecture
    {

        #region Gerar INTERFACES

        //Gerar INTERFACE DA REPOSITORIE
        public string GerarInterfaceRepository(string NomeDaTabela, string NameSpaceDoProjecto, string DirectorioAondeSeraGeradoAInfo)
        {
            try
            {
                Mapeamento mapeamento = new Mapeamento();

                string dr = DirectorioAondeSeraGeradoAInfo + @"\IRepositories";
                string Caminho = dr + @"\I"  + NomeDaTabela + "Repository.cs";

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
                    stream.WriteLine("/*Gerado no Gerador de Codigo UCALL");
                    stream.WriteLine("Data: " + DateTime.Now);
                    stream.WriteLine("*/\n");
                    stream.WriteLine("using System;");
                    stream.WriteLine("using Domain.Entities;");
                    stream.WriteLine("using System.Collections.Generic;");
                    stream.WriteLine("using System.Data;");
                    stream.WriteLine("using System.Linq;");
                    stream.WriteLine("using System.Text;");
                    stream.WriteLine("using System.Threading.Tasks;\n\n\n");
                    stream.WriteLine("namespace Application.Interfaces.Repositories"); //NameSpace do projecto
                    stream.WriteLine("{");
                    stream.WriteLine("\tpublic interface I" + NomeDaTabela + "Repository : IGenericRepositoryAsync<" + NomeDaTabela +">");
                    stream.WriteLine("\t\t{");

                    //Prenche aqui o arquivo com as propriedades Begin
                    stream.WriteLine("\n\n");
                    //Prenche aqui o arquivo com as propriedades End

                    stream.WriteLine("\t\t}");
                    stream.WriteLine("}");

                    stream.Close();
                }
                //Começa a escrever aqui no arquivo End


                return "Interface Repositories Gerado Com Sucesso No Diretorio Informado";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        //Gerar a interface da service
        public string GerarInterfaceService(string NomeDaTabela, string NameSpaceDoProjecto, string DirectorioAondeSeraGeradoAInfo)
        {
            try
            {
                Mapeamento mapeamento = new Mapeamento();

                string dr = DirectorioAondeSeraGeradoAInfo + @"\IServices";
                string Caminho = dr + @"\I"  + NomeDaTabela + "Service.cs";

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
                    stream.WriteLine("/*Gerado no Gerador de Codigo UCALL");
                    stream.WriteLine("Data: " + DateTime.Now);
                    stream.WriteLine("*/\n");
                    stream.WriteLine("using System;");
                    stream.WriteLine("using Application.DTOs;");
                    stream.WriteLine("using Application.Wrappers;");
                    stream.WriteLine("using System.Collections.Generic;");
                    stream.WriteLine("using System.Data;");
                    stream.WriteLine("using System.Linq;");
                    stream.WriteLine("using System.Text;");
                    stream.WriteLine("using System.Threading.Tasks;\n\n\n");
                    stream.WriteLine("namespace Application.Interfaces.Services"); //NameSpace do projecto
                    stream.WriteLine("{");
                    stream.WriteLine("\tpublic interface I" + NomeDaTabela + "Service");
                    stream.WriteLine("\t\t{");

                    //Prenche aqui o arquivo com as propriedades Begin
                    stream.WriteLine("\t\t\tTask<Response<Guid>> RegisterAsync(" + NomeDaTabela + "DTO " + NomeDaTabela.ToLower() + "DTO);");                 
                    stream.WriteLine("\t\t\tTask<Response<Guid>> RemoveAsync(" + NomeDaTabela + "DTO " + NomeDaTabela.ToLower() + "DTO);");
                    stream.WriteLine("\t\t\tTask<Response<Guid>> UpdateAsync(" + NomeDaTabela + "DTO " +  NomeDaTabela.ToLower() + "DTO);");
                    stream.WriteLine("\t\t\tTask<Response<" + NomeDaTabela + "DTO>>" + " GetById(Guid id);");
                    stream.WriteLine("\t\t\tTask<Response<List<" + NomeDaTabela + "DTO>>>" + " GetAll();");

                    //Prenche aqui o arquivo com as propriedades End

                    stream.WriteLine("\t\t}");
                    stream.WriteLine("}");

                    stream.Close();
                }
                //Começa a escrever aqui no arquivo End


                return "Interface Services Gerado Com Sucesso No Diretorio Informado";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        #endregion

        #region Gerar DTOs
        //Gerar a DTOs
        public string GerarDTO(string NomeDaTabela, string NameSpaceDoProjecto, string DirectorioAondeSeraGeradoAInfo)
        {
            try
            {
                Mapeamento mapeamento = new Mapeamento();

                string dr = DirectorioAondeSeraGeradoAInfo + @"\DTOs\";
                string Caminho = dr + @"\" + NomeDaTabela + "DTO.cs";

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

                    stream.WriteLine("/*Gerado no Gerador de Codigo UCALL");
                    stream.WriteLine("Data: " + DateTime.Now);
                    stream.WriteLine("*/\n");
                    stream.WriteLine("using System;");
                    stream.WriteLine("using System.Collections.Generic;");
                    stream.WriteLine("using System.Text;");
                    stream.WriteLine("using System.Threading.Tasks;\n\n\n");
                    stream.WriteLine("namespace Application.DTOs" ); //+ ".INFO"
                    stream.WriteLine("{");
                    stream.WriteLine("\t\tpublic class " + NomeDaTabela + "DTO");
                    stream.WriteLine("\t\t{");
                    List<Tb_Estrutura_Info> estrutura_Infos = mapeamento.RetornarEstruturaDaTabelaSqlServer(NomeDaTabela);

                    //Prenche aqui o arquivo com as propriedades Begin
                    foreach (var x in estrutura_Infos)
                    {
                        if (x.Tipo.Contains("int"))
                        {
                            x.Tipo = "int";
                            stream.WriteLine("\t\t\tpublic " + x.Tipo + " " + x.Nome + " { get; set; }");
                        }
                        else if (x.Tipo.Contains("char") || x.Tipo.Contains("varchar") || x.Tipo.Contains("longtext") || x.Tipo.Contains("nvarchar") || x.Tipo.ToLower() == "text")
                        {
                            x.Tipo = "string";
                            stream.WriteLine("\t\t\tpublic " + x.Tipo + " " + x.Nome + " { get; set; }");
                        }
                        else if (x.Tipo.Contains("float"))
                        {
                            x.Tipo = "float";
                            stream.WriteLine("\t\t\tpublic " + x.Tipo + " " + x.Nome + " { get; set; }");
                        }
                        else if (x.Tipo.Contains("decimal"))
                        {
                            x.Tipo = "decimal";
                            stream.WriteLine("\t\t\tpublic " + x.Tipo + " " + x.Nome + " { get; set; }");
                        }
                        else if (x.Tipo.Contains("Date") || x.Tipo.Contains("date") || x.Tipo.Contains("DateTime") || x.Tipo.Contains("datetime"))
                        {
                            x.Tipo = "DateTime";
                            stream.WriteLine("\t\t\tpublic " + x.Tipo + " " + x.Nome + " { get; set; }");
                        }
                        else if (x.Tipo.Contains("uniqueidentifier"))
                        {
                            x.Tipo = "DateTime";
                            stream.WriteLine("\t\t\tpublic Guid" + " " + x.Nome + " { get; set; }");
                        }
                        else if (x.Tipo.Contains("bit"))
                        {
                            stream.WriteLine("\t\t\tpublic bool" + " " + x.Nome + " { get; set; }");
                        }
                        else
                        {
                            stream.WriteLine("\t\t\tpublic " + x.Tipo + " " + x.Nome + " { get; set; }");
                        }
                    }

                    stream.WriteLine("\t\t}");
                    stream.WriteLine("}");

                    stream.Close();
                }
                //Começa a escrever aqui no arquivo End


                return "DTO Gerado Com Sucesso No Diretorio Informado";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        #endregion

        #region Gerar a implementação da service
        public string GerarService(string NomeDaTabela, string NameSpaceDoProjecto, string DirectorioAondeSeraGeradoAInfo)
        {
            try
            {
                Mapeamento mapeamento = new Mapeamento();

                string dr = DirectorioAondeSeraGeradoAInfo + @"\Features\Services";
                string Caminho = dr  + @"\" + NomeDaTabela + "Service.cs";

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




                    stream.WriteLine("/*Gerado no Gerador de Codigo UCALL");
                    stream.WriteLine("Data: " + DateTime.Now);
                    stream.WriteLine("*/\n");
                    //Cabeçalho das biblotecas inicio namespaces
                    stream.WriteLine("using Application.DTOs;");
                    stream.WriteLine("using Application.Exceptions;");
                    stream.WriteLine("using Application.Interfaces;");
                    stream.WriteLine("using Application.Interfaces.NLog;");
                    stream.WriteLine("using Application.Interfaces.Repositories;");
                    stream.WriteLine("using Application.Interfaces.Services;");
                    stream.WriteLine("using Application.Wrappers;");
                    stream.WriteLine("using AutoMapper;");
                    stream.WriteLine("using Domain.Entities;");
                    stream.WriteLine("using System;");
                    stream.WriteLine("using System.Collections.Generic;");
                    stream.WriteLine("using System.Data;");
                    stream.WriteLine("using System.Linq;");
                    stream.WriteLine("using System.Text;");
                    stream.WriteLine("using System.Threading.Tasks;\n\n\n");
                    //Cabeçalho das biblotecas fim namespaces
                    stream.WriteLine("namespace Application.Features.services"); // Escreve o namespace do projecto no arquivo
                    stream.WriteLine("{");// adiciona a primeira chaveta após o namespcae
                    stream.WriteLine("\t\tpublic class " + NomeDaTabela + "Service : I" + NomeDaTabela + "Service"); // Adiciona o nome da classe e os seus atributos
                    stream.WriteLine("\t\t{"); //Abre chaves para escrever todo o codigo que deve existir na classe

                    /*List<Tb_Estrutura_Info> estrutura_Infos = mapeamento.RetornarEstruturaDaTabela(NomeDaTabela); *///Chama na base de dados a estrutura de uma tabela

                    #region DECLARACAO DA INJECAO DE INDEPENDENCIA

                    //Declaracao da inhejão de independencia
                    stream.WriteLine("\t\t\t\tprivate readonly IFileService _fileService;"); //Adiciona a classe de conexão na classe
                    stream.WriteLine("\t\t\t\tprivate readonly IMapper _mapper;");
                    stream.WriteLine("\t\t\t\tprivate readonly I" + NomeDaTabela + "Repository _" + NomeDaTabela.ToLower() + "Repository;\n\n");
                    stream.WriteLine("\t\t\t\tprivate ILog logger;");

                    #endregion

                    #region CONSTRUTOR DA CLASSE

                    //GERAR O CONSTRUTOR 
                    stream.WriteLine("\t\t\t\tpublic " + NomeDaTabela + "Service(I" + NomeDaTabela + "Repository " + NomeDaTabela.ToLower() + "Repository, IMapper mapper, ILog logger, IFileService fileService)"); //Declara o metodo que restorna a lista de dados
                    stream.WriteLine("\t\t\t\t{");

                    stream.WriteLine("\t\t\t\t\t\t_mapper = mapper;");
                    stream.WriteLine("\t\t\t\t\t\tthis._" + NomeDaTabela.ToLower() + "Repository = " + NomeDaTabela.ToLower() + "Repository;");
                    stream.WriteLine("\t\t\t\t\t\tthis.logger = logger;");
                    stream.WriteLine("\t\t\t\t\t\tthis._fileService = fileService;");

                    stream.WriteLine("\t\t\t\t}\n\n");


                    #endregion

                    #region METODO GetAll

                    stream.WriteLine("\t\t\t\tpublic async Task<Response<List<" + NomeDaTabela + "DTO>>> GetAll()"); 
                    stream.WriteLine("\t\t\t\t{");

                    stream.WriteLine("\t\t\t\t\ttry");
                    stream.WriteLine("\t\t\t\t\t{");

                    stream.WriteLine("\t\t\t\t\t\t return new Response<List<" + NomeDaTabela  + "DTO>>");
                    stream.WriteLine("\t\t\t\t\t\t(_mapper.Map<List<" + NomeDaTabela + "DTO>>(await this._" + NomeDaTabela.ToLower() +"Repository.GetAllAsync()));");

                    stream.WriteLine("\t\t\t\t\t}");
                    stream.WriteLine("\t\t\t\t\tcatch (System.Exception ex)");
                    stream.WriteLine("\t\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t\tthis.logger.Error(ex.Message);");
                    stream.WriteLine("\t\t\t\t\t\tthrow new ApiException(ex.Message);");
                    stream.WriteLine("\t\t\t\t\t}");
                    stream.WriteLine("\t\t\t\t}\n\n");

                    #endregion

                    #region METODO GetById

                    stream.WriteLine("\t\t\t\tpublic async Task<Response<" + NomeDaTabela + "DTO>> GetById(Guid id)");
                    stream.WriteLine("\t\t\t\t{");

                    stream.WriteLine("\t\t\t\t\ttry");
                    stream.WriteLine("\t\t\t\t\t{");

                    stream.WriteLine("\t\t\t\t\t\t return new Response<" + NomeDaTabela + "DTO>");
                    stream.WriteLine("\t\t\t\t\t\t(_mapper.Map<" + NomeDaTabela + "DTO>(await this._" + NomeDaTabela.ToLower() + "Repository.GetByGUIDAsync(id)));");

                    stream.WriteLine("\t\t\t\t\t}");
                    stream.WriteLine("\t\t\t\t\tcatch (System.Exception ex)");
                    stream.WriteLine("\t\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t\tthis.logger.Error(ex.Message);");
                    stream.WriteLine("\t\t\t\t\t\tthrow new ApiException(ex.Message);");
                    stream.WriteLine("\t\t\t\t\t}");
                    stream.WriteLine("\t\t\t\t}\n\n");

                    #endregion


                    #region METODO RegisterAsync

                    stream.WriteLine("\t\t\t\tpublic async Task<Response<Guid>> RegisterAsync(" + NomeDaTabela + "DTO " + NomeDaTabela.ToLower() + "DTO)");
                    stream.WriteLine("\t\t\t\t{");

                    stream.WriteLine("\t\t\t\t\ttry");
                    stream.WriteLine("\t\t\t\t\t{");

                    stream.WriteLine("\t\t\t\t\t\tvar result = _mapper.Map<" + NomeDaTabela + ">(" + NomeDaTabela.ToLower() + "DTO);");
                    stream.WriteLine("\t\t\t\t\t\tresult.Id" + NomeDaTabela + " = Guid.NewGuid();");
                    stream.WriteLine("\t\t\t\t\t\tawait _" + NomeDaTabela.ToLower() +  "Repository.AddAsync(result);");
                    stream.WriteLine("\t\t\t\t\t\treturn new Response<Guid>(result.Id" + NomeDaTabela + ", Constantes.Constantes.RegistoSalvo);");

                    stream.WriteLine("\t\t\t\t\t}");
                    stream.WriteLine("\t\t\t\t\tcatch (System.Exception ex)");
                    stream.WriteLine("\t\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t\tthis.logger.Error(ex.Message);");
                    stream.WriteLine("\t\t\t\t\t\tthrow new ApiException(ex.Message);");
                    stream.WriteLine("\t\t\t\t\t}");
                    stream.WriteLine("\t\t\t\t}\n\n");

                    #endregion


                    #region METODO RemoveAsync

                    stream.WriteLine("\t\t\t\tpublic async Task<Response<Guid>> RemoveAsync(" + NomeDaTabela + "DTO " + NomeDaTabela.ToLower() + "DTO)");
                    stream.WriteLine("\t\t\t\t{");

                    stream.WriteLine("\t\t\t\t\ttry");
                    stream.WriteLine("\t\t\t\t\t{");

                    stream.WriteLine("\t\t\t\t\t\tvar result = _mapper.Map<" + NomeDaTabela + ">(" + NomeDaTabela.ToLower() + "DTO);");
                    stream.WriteLine("\t\t\t\t\t\tawait _" + NomeDaTabela.ToLower() + "Repository.DeleteAsync(result);");
                    stream.WriteLine("\t\t\t\t\t\treturn new Response<Guid>(result.Id" + NomeDaTabela + ", Constantes.Constantes.RegistoEliminado);");

                    stream.WriteLine("\t\t\t\t\t}");
                    stream.WriteLine("\t\t\t\t\tcatch (System.Exception ex)");
                    stream.WriteLine("\t\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t\tthis.logger.Error(ex.Message);");
                    stream.WriteLine("\t\t\t\t\t\tthrow new ApiException(ex.Message);");
                    stream.WriteLine("\t\t\t\t\t}");
                    stream.WriteLine("\t\t\t\t}\n\n");

                    #endregion

                    #region METODO UpdateAsync

                    stream.WriteLine("\t\t\t\tpublic async Task<Response<Guid>> UpdateAsync(" + NomeDaTabela + "DTO " + NomeDaTabela.ToLower() + "DTO)");
                    stream.WriteLine("\t\t\t\t{");

                    stream.WriteLine("\t\t\t\t\ttry");
                    stream.WriteLine("\t\t\t\t\t{");

                    stream.WriteLine("\t\t\t\t\t\tvar result = _mapper.Map<" + NomeDaTabela + ">(" + NomeDaTabela.ToLower() + "DTO);");
                    stream.WriteLine("\t\t\t\t\t\tawait _" + NomeDaTabela.ToLower() + "Repository.UpdateAsync(result);");
                    stream.WriteLine("\t\t\t\t\t\treturn new Response<Guid>(result.Id" + NomeDaTabela + ",  Constantes.Constantes.RegistoActualizado);");

                    stream.WriteLine("\t\t\t\t\t}");
                    stream.WriteLine("\t\t\t\t\tcatch (System.Exception ex)");
                    stream.WriteLine("\t\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t\tthis.logger.Error(ex.Message);");
                    stream.WriteLine("\t\t\t\t\t\tthrow new ApiException(ex.Message);");
                    stream.WriteLine("\t\t\t\t\t}");
                    stream.WriteLine("\t\t\t\t}\n\n");

                    #endregion

                    stream.WriteLine("\t\t}");
                    stream.WriteLine("}");

                    stream.Close();
                }
                //Começa a escrever aqui no arquivo End


                return "Service Gerado com sucesso";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion

        #region Repositories
        public string GerarRepositories(string NomeDaTabela, string NameSpaceDoProjecto, string DirectorioAondeSeraGeradoAInfo)
        {
            try
            {
                Mapeamento mapeamento = new Mapeamento();

                string dr = DirectorioAondeSeraGeradoAInfo + @"\Repositories";
                string Caminho = dr + @"\" + NomeDaTabela + "Repository.cs";

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


                    stream.WriteLine("/*Gerado no Gerador de Codigo UCALL");
                    stream.WriteLine("Data: " + DateTime.Now);
                    stream.WriteLine("*/\n");
                    //Cabeçalho das biblotecas inicio namespaces
                    stream.WriteLine("using Application.Interfaces.Repositories;");
                    stream.WriteLine("using Domain.Entities;");
                    stream.WriteLine("using Infrastructure.Persistence.Contexts;");
                    stream.WriteLine("using Infrastructure.Persistence.Repository;");
                    stream.WriteLine("using Microsoft.EntityFrameworkCore;");
                    stream.WriteLine("using System;");
                    stream.WriteLine("using System.Collections.Generic;");
                    stream.WriteLine("using System.Data;");
                    stream.WriteLine("using System.Linq;");
                    stream.WriteLine("using System.Text;");
                    stream.WriteLine("using System.Threading.Tasks;\n\n\n");
                    //Cabeçalho das biblotecas fim namespaces
                    stream.WriteLine("namespace Infrastructure.Persistence.Repositories"); // Escreve o namespace do projecto no arquivo
                    stream.WriteLine("{");// adiciona a primeira chaveta após o namespcae
                    
                    stream.WriteLine("\t\tpublic class " + NomeDaTabela + "Repository : GenericRepositoryAsync<" + NomeDaTabela +">, I" + NomeDaTabela +"Repository"); // Adiciona o nome da classe e os seus atributos
                    stream.WriteLine("\t\t{"); //Abre chaves para escrever todo o codigo que deve existir na classe

                    /*List<Tb_Estrutura_Info> estrutura_Infos = mapeamento.RetornarEstruturaDaTabela(NomeDaTabela); *///Chama na base de dados a estrutura de uma tabela

                    #region DECLARACAO DA INJECAO DE INDEPENDENCIA

                    //Declaracao da inhejão de independencia
                    //private readonly DbSet<ItemTipoTarefa> _accaoCategoria;
                    stream.WriteLine("\t\t\t\tprivate readonly DbSet<" + NomeDaTabela + "> _" + NomeDaTabela.ToLower() + ";\n\n");

                    #endregion

                    #region CONSTRUTOR DA CLASSE

                    //GERAR O CONSTRUTOR 
                    stream.WriteLine("\t\t\t\tpublic " + NomeDaTabela + "Repository(ApplicationDbContext dbContext) : base(dbContext)"); //Declara o metodo que restorna a lista de dados
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t\tthis._" + NomeDaTabela.ToLower() + " = dbContext.Set<" + NomeDaTabela + ">();");
                    stream.WriteLine("\t\t\t\t}\n\n");

                    #endregion

                    stream.WriteLine("\t\t}");
                    stream.WriteLine("}");

                    stream.Close();
                }
                //Começa a escrever aqui no arquivo End


                return "Service Gerado com sucesso";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion

        #region Gerar o controller da web api
        public string GerarControllerAPI(string NomeDaTabela, string NameSpaceDoProjecto, string DirectorioAondeSeraGeradoAInfo, string NameSpaceDAL_INFO)
        {

            try
            {
                Mapeamento mapeamento = new Mapeamento();

                string dr = DirectorioAondeSeraGeradoAInfo + @"\Controllers";
                string Caminho = dr + @"\" + NomeDaTabela + "Controller.cs";

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
                    stream.WriteLine("/*Gerado no Gerador de Codigo UCALL");
                    stream.WriteLine("Data: " + DateTime.Now);
                    stream.WriteLine("*/\n");
                    //Cabeçalho das biblotecas inicio namespaces
                    stream.WriteLine("using Application.DTOs;");
                    stream.WriteLine("using Application.Interfaces.Services;");
                    stream.WriteLine("using Microsoft.AspNetCore.Http;");
                    stream.WriteLine("using Microsoft.AspNetCore.Mvc;");
                    stream.WriteLine("using System;");
                    stream.WriteLine("using System.Collections.Generic;");
                    stream.WriteLine("using System.Linq;");
                    stream.WriteLine("using System.Threading.Tasks;\n\n");
                    //Cabeçalho das biblotecas fim namespaces

                    stream.WriteLine("namespace WebApi.Controllers\n\n"); // Escreve o namespace do projecto no arquivo
                    stream.WriteLine("{");// adiciona a primeira chaveta após o namespcae
                    stream.WriteLine("\t\t[Route(" + "\"" + "api/[controller]" + "\"" + ")]");
                    stream.WriteLine("\t\t[ApiController]");
                    stream.WriteLine("\t\tpublic class " + NomeDaTabela + "Controller : BaseApiController"); // Adiciona o nome da classe e os seus atributos
                    stream.WriteLine("\t\t{"); //Abre chaves para escrever todo o codigo que deve existir na classe


                    #region DECLARACAO DA INJECAO DE INDEPENDENCIA

                    //Declaracao da inhejão de independencia
                    stream.WriteLine("\t\t\t\tprivate readonly I"+ NomeDaTabela+ "Service _" +  NomeDaTabela.ToLower() + "Service;\n\n"); //Adiciona a classe de conexão na classe
                    #endregion

                    #region CONSTRUTOR DA CLASSE

                    //GERAR O CONSTRUTOR 
                    stream.WriteLine("\t\t\t\tpublic " + NomeDaTabela + "Controller(I" + NomeDaTabela + "Service " + NomeDaTabela.ToLower() + "Service)"); //Declara o metodo que restorna a lista de dados
                    stream.WriteLine("\t\t\t\t{");
                
                    stream.WriteLine("\t\t\t\t\tthis._" + NomeDaTabela.ToLower() + "Service = " + NomeDaTabela.ToLower() + "Service;");
                    stream.WriteLine("\t\t\t\t}\n\n");


                    #endregion


                    #region ACTION GetAll

                    stream.WriteLine("\n\n\t\t\t\t[HttpGet]");
                    stream.WriteLine("\t\t\t\tpublic async Task<IActionResult> GetAll()");
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t\treturn Ok(await _" + NomeDaTabela.ToLower() + "Service.GetAll());");
                    stream.WriteLine("\t\t\t\t}\n\n");

                    #endregion


                    #region ACTION GetById

                    stream.WriteLine("\n\n\t\t\t\t[HttpGet(" + "\"" + "{id}" + "\"" + ")]");
                    stream.WriteLine("\t\t\t\tpublic async Task<IActionResult> GetById(Guid id)");
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t\treturn Ok(await _" + NomeDaTabela.ToLower() + "Service.GetById(id));");
                    stream.WriteLine("\t\t\t\t}\n\n");

                    #endregion


                    #region ACTION RegisterAsync

                    stream.WriteLine("\n\n\t\t\t\t[HttpPost(" + "\"" + "register" + "\"" + ")]");
                    stream.WriteLine("\t\t\t\tpublic async Task<IActionResult> RegisterAsync(" + NomeDaTabela + "DTO request)");
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t\treturn Ok(await _" + NomeDaTabela.ToLower() + "Service.RegisterAsync(request));");
                    stream.WriteLine("\t\t\t\t}\n\n");

                    #endregion

                    #region ACTION DeleyteAsync

                    stream.WriteLine("\n\n\t\t\t\t[HttpDelete(" + "\"" + "delete" + "\"" + ")]");
                    stream.WriteLine("\t\t\t\tpublic async Task<IActionResult> DeleyteAsync(" + NomeDaTabela + "DTO request)");
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t\treturn Ok(await _" + NomeDaTabela.ToLower() + "Service.RemoveAsync(request));");
                    stream.WriteLine("\t\t\t\t}\n\n");

                    #endregion



                    #region ACTION DeleyteAsync

                    stream.WriteLine("\n\n\t\t\t\t[HttpPut(" + "\"" + "update" + "\"" + ")]");
                    stream.WriteLine("\t\t\t\tpublic async Task<IActionResult> UpdateteAsync(" + NomeDaTabela + "DTO request)");
                    stream.WriteLine("\t\t\t\t{");
                    stream.WriteLine("\t\t\t\t\t\treturn Ok(await _" + NomeDaTabela.ToLower() + "Service.UpdateAsync(request));");
                    stream.WriteLine("\t\t\t\t}\n\n");

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
        #endregion


        #region Gerar ServiceRegistrationApplication
        public string GerarServiceRegistrationApplication(string NomeDaTabela, string NameSpaceDoProjecto, string DirectorioAondeSeraGeradoAInfo, string NameSpaceDAL_INFO)
        {

            try
            {
                Mapeamento mapeamento = new Mapeamento();

                string dr = DirectorioAondeSeraGeradoAInfo + @"\ServiceRegistrationApplication";
                string Caminho = dr + @"\"  + "ServiceRegistration.cs";

                if (Directory.Exists(dr) == false)
                {
                    Directory.CreateDirectory(dr); //CRIAR O DIRETORIO SE NÃO EXISTIR

                    if (File.Exists(Caminho) == true)
                    {
                        //File.CreateText(Caminho);
                        ServiceRegistrationEditFile(Caminho, NomeDaTabela);
                    }
                    else
                    {
                        FileStream file = File.Create(Caminho);
                        file.Close();
                        ServiceRegistrationNewFile(Caminho, NomeDaTabela);
                    }
                }
                else
                {
                    if (File.Exists(Caminho) == true)
                    {
                        //File.CreateText(Caminho);
                        ServiceRegistrationEditFile(Caminho, NomeDaTabela);
                    }
                    else
                    {
                        FileStream file = File.Create(Caminho);
                        file.Close();
                        ServiceRegistrationNewFile(Caminho, NomeDaTabela);
                    }
                }



                return "Controller da API Gerado com sucesso";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        /// <summary>
        /// Método para escrever num ficheiro novo
        /// </summary>
        /// <param name="caminho"></param>
        /// <param name="NomeDaTabela"></param>
        private void ServiceRegistrationNewFile(string caminho, string NomeDaTabela)
        {
            //Começa a escrever aqui no arquivo Begin
            using (StreamWriter stream = new StreamWriter(caminho, true))
            {


                stream.WriteLine("/*Gerado no Gerador de Codigo UCALL");
                stream.WriteLine("Data: " + DateTime.Now);
                stream.WriteLine("*/\n");
                //Cabeçalho das biblotecas inicio namespaces
                stream.WriteLine("using Application.Behaviours;");
                stream.WriteLine("using Application.Features.services;");
                stream.WriteLine("using Application.Interfaces.Services;");
                stream.WriteLine("using AutoMapper;");
                stream.WriteLine("using FluentValidation;");
                stream.WriteLine("using MediatR;");
                stream.WriteLine("using Microsoft.Extensions.DependencyInjection;");
                stream.WriteLine("using System.Reflection;");
                stream.WriteLine("using MediatR;");
                stream.WriteLine("using System;");
                stream.WriteLine("using System.Collections.Generic;");
                stream.WriteLine("using System.Linq;");
                stream.WriteLine("using System.Text;\n\n");
                //Cabeçalho das biblotecas fim namespaces

                stream.WriteLine("namespace Application\n\n"); // Escreve o namespace do projecto no arquivo
                stream.WriteLine("{");// adiciona a primeira chaveta após o namespcae
                stream.WriteLine("\t\tpublic static class ServiceExtensions"); // Adiciona o nome da classe e os seus atributos
                stream.WriteLine("\t\t{"); //Abre chaves para escrever todo o codigo que deve existir na classe




                #region CONSTRUTOR DA CLASSE

                //GERAR O CONSTRUTOR 
                stream.WriteLine("\t\t\t\tpublic static void AddApplicationLayer(this IServiceCollection services)"); //Declara o metodo que restorna a lista de dados
                stream.WriteLine("\t\t\t\t{");

                stream.WriteLine("\t\t\t\t\tservices.AddAutoMapper(Assembly.GetExecutingAssembly());");
                stream.WriteLine("\t\t\t\t\tservices.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());");
                stream.WriteLine("\t\t\t\t\tservices.AddMediatR(Assembly.GetExecutingAssembly());");
                stream.WriteLine("\t\t\t\t\tservices.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));");


                stream.WriteLine("\t\t\t\t\tservices.AddTransient<I" + NomeDaTabela + "Service," + NomeDaTabela + "Service>();");
                stream.WriteLine("\t\t\t\t}\n\n");


                #endregion


                stream.WriteLine("\t\t}");//Aqui fecha o código da classe
                stream.WriteLine("}"); //Aqui fecha o código no namespace
                stream.Close();
                //Aqui termina o código do controller

            }

        }

        /// <summary>
        /// Método para editar o ficheciro já existente
        /// </summary>
        /// <param name="caminho"></param>
        /// <param name="NomeDaTabela"></param>
        private void ServiceRegistrationEditFile(string caminho, string NomeDaTabela)
        {
            //Começa a escrever aqui no arquivo Begin
            using (StreamWriter stream = new StreamWriter(caminho, true))
            {

                #region REGISTAR A DEPENDECIA

                stream.WriteLine("\t\t\t\t\tservices.AddTransient<I" + NomeDaTabela + "Service," + NomeDaTabela + "Service>();");
                
                #endregion
                stream.Close();
                

            }
        }
        #endregion

        #region Gerar ServiceRegistrationPersistence
        public string GerarServiceRegistrationPersistence(string NomeDaTabela, string NameSpaceDoProjecto, string DirectorioAondeSeraGeradoAInfo, string NameSpaceDAL_INFO)
        {

            try
            {
                Mapeamento mapeamento = new Mapeamento();

                string dr = DirectorioAondeSeraGeradoAInfo + @"\ServiceRegistrationPersistence";
                string Caminho = dr + @"\" + "ServiceRegistration.cs";

                if (Directory.Exists(dr) == false)
                {
                    Directory.CreateDirectory(dr); //CRIAR O DIRETORIO SE NÃO EXISTIR

                    if (File.Exists(Caminho) == true)
                    {
                        //File.CreateText(Caminho);
                        ServiceRegistrationEditFile(Caminho, NomeDaTabela);
                    }
                    else
                    {
                        FileStream file = File.Create(Caminho);
                        file.Close();
                        ServiceRegistrationPersistenceNewFile(Caminho, NomeDaTabela);
                    }
                }
                else
                {
                    if (File.Exists(Caminho) == true)
                    {
                        //File.CreateText(Caminho);
                        ServiceRegistrationPersistenceEditFile(Caminho, NomeDaTabela);
                    }
                    else
                    {
                        FileStream file = File.Create(Caminho);
                        file.Close();
                        ServiceRegistrationPersistenceNewFile(Caminho, NomeDaTabela);
                    }
                }



                return "Controller da API Gerado com sucesso";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="caminho"></param>
        /// <param name="nomeDaTabela"></param>
        private void ServiceRegistrationPersistenceEditFile(string caminho, string nomeDaTabela)
        {
            //Começa a escrever aqui no arquivo Begin
            using (StreamWriter stream = new StreamWriter(caminho, true))
            {

                #region REGISTAR A DEPENDECIA

                stream.WriteLine("\t\t\t\t\tservices.AddTransient<I" + nomeDaTabela + "Repository, " + nomeDaTabela + "Repository>();\n");

                #endregion
                stream.Close();


            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caminho"></param>
        /// <param name="nomeDaTabela"></param>
        private void ServiceRegistrationPersistenceNewFile(string caminho, string nomeDaTabela)
        {
            //Começa a escrever aqui no arquivo Begin
            using (StreamWriter stream = new StreamWriter(caminho, true))
            {



                stream.WriteLine("/*Gerado no Gerador de Codigo UCALL");
                stream.WriteLine("Data: " + DateTime.Now);
                stream.WriteLine("*/\n");


                //Cabeçalho das biblotecas inicio namespaces
                stream.WriteLine("using Application.Interfaces;");
                stream.WriteLine("using Application.Interfaces.Repositories;");
                stream.WriteLine("using Infrastructure.Persistence.Contexts;");
                stream.WriteLine("using Infrastructure.Persistence.Repositories;");
                stream.WriteLine("using Infrastructure.Persistence.Repository;");
                stream.WriteLine("using Microsoft.EntityFrameworkCore;");
                stream.WriteLine("using Microsoft.Extensions.Configuration;");
                stream.WriteLine("using Microsoft.Extensions.DependencyInjection;");
                stream.WriteLine("using System;");
                stream.WriteLine("using System.Collections.Generic;");
                stream.WriteLine("using System.Text;\n\n");
                //Cabeçalho das biblotecas fim namespaces

                stream.WriteLine("namespace Infrastructure.Persistence\n\n"); // Escreve o namespace do projecto no arquivo
                stream.WriteLine("{");// adiciona a primeira chaveta após o namespcae
                stream.WriteLine("\t\tpublic static class ServiceExtensions"); // Adiciona o nome da classe e os seus atributos
                stream.WriteLine("\t\t{"); //Abre chaves para escrever todo o codigo que deve existir na classe




                #region METODO AddPersistenceInfrastructure

                //GERAR O CONSTRUTOR 
                stream.WriteLine("\t\t\t\tpublic static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)"); //Declara o metodo que restorna a lista de dados
                stream.WriteLine("\t\t\t\t{");


                stream.WriteLine("\t\t\t\t\tif (configuration.GetValue<bool>(" + "\"" + "UseInMemoryDatabase" + "\"" +"))");
                stream.WriteLine("\t\t\t\t\t{");
                stream.WriteLine("\t\t\t\t\t\tservices.AddDbContext<ApplicationDbContext>(options =>");
                stream.WriteLine("\t\t\t\t\t\t\toptions.UseInMemoryDatabase(" + "\"" + "CleanArq" + "\"" +"));");
                stream.WriteLine("\t\t\t\t\t}");

                stream.WriteLine("\t\t\t\t\telse");
                stream.WriteLine("\t\t\t\t\t{");
                stream.WriteLine("\t\t\t\t\t\tservices.AddDbContext<ApplicationDbContext>(options =>");
                stream.WriteLine("\t\t\t\t\t\toptions.UseSqlServer(");
                stream.WriteLine("\t\t\t\t\t\tconfiguration.GetConnectionString(" + "\"" + "DefaultConnection" + "\"" + "),");
                stream.WriteLine("\t\t\t\t\t\tb => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));");
                stream.WriteLine("\t\t\t\t\t}\n");




                stream.WriteLine("\t\t\t\t\t#region Repositories\n");
                stream.WriteLine("\t\t\t\t\tservices.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));");
                stream.WriteLine("\t\t\t\t\tservices.AddTransient<I" + nomeDaTabela + "Repository, " + nomeDaTabela + "Repository>();\n");

                stream.WriteLine("\t\t\t\t\t#endregion\n");
                stream.WriteLine("\t\t\t\t}\n\n");


                #endregion


                stream.WriteLine("\t\t}");//Aqui fecha o código da classe
                stream.WriteLine("}"); //Aqui fecha o código no namespace
                stream.Close();
                //Aqui termina o código do controller

            }
        }


        #endregion


        #region Gerar Mappings
        public string GerarGeneralProfile(string NomeDaTabela, string NameSpaceDoProjecto, string DirectorioAondeSeraGeradoAInfo, string NameSpaceDAL_INFO)
        {

            try
            {
                Mapeamento mapeamento = new Mapeamento();

                string dr = DirectorioAondeSeraGeradoAInfo + @"\Mappings";
                string Caminho = dr + @"\" + "GeneralProfile.cs";

                if (Directory.Exists(dr) == false)
                {
                    Directory.CreateDirectory(dr); //CRIAR O DIRETORIO SE NÃO EXISTIR

                    if (File.Exists(Caminho) == true)
                    {
                        //File.CreateText(Caminho);
                        ServiceRegistrationEditFile(Caminho, NomeDaTabela);
                    }
                    else
                    {
                        FileStream file = File.Create(Caminho);
                        file.Close();
                        ServiceGeneralProfileNewFile(Caminho, NomeDaTabela);
                    }
                }
                else
                {
                    if (File.Exists(Caminho) == true)
                    {
                        //File.CreateText(Caminho);
                        ServiceGeneralProfileEditFile(Caminho, NomeDaTabela);
                    }
                    else
                    {
                        FileStream file = File.Create(Caminho);
                        file.Close();
                        ServiceGeneralProfileNewFile(Caminho, NomeDaTabela);
                    }
                }



                return "Mappings Gerado com sucesso";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private void ServiceGeneralProfileEditFile(string caminho, string nomeDaTabela)
        {
            //Começa a escrever aqui no arquivo Begin
            using (StreamWriter stream = new StreamWriter(caminho, true))
            {

                #region REGISTAR A DEPENDECIA

                stream.WriteLine("\t\t\t\t\t\tCreateMap<" + nomeDaTabela + "DTO, " + nomeDaTabela + ">().ReverseMap();");

                #endregion
                stream.Close();


            }
        }

        private void ServiceGeneralProfileNewFile(string caminho, string nomeDaTabela)
        {
            //Começa a escrever aqui no arquivo Begin
            using (StreamWriter stream = new StreamWriter(caminho, true))
            {


                stream.WriteLine("/*Gerado no Gerador de Codigo UCALL");
                stream.WriteLine("Data: " + DateTime.Now);
                stream.WriteLine("*/\n");


                //Cabeçalho das biblotecas inicio namespaces
                stream.WriteLine("using Application.DTOs;");
                stream.WriteLine("using AutoMapper;");
                stream.WriteLine("using Domain.Entities;");
                stream.WriteLine("using System;");
                stream.WriteLine("using System.Collections.Generic;");
                stream.WriteLine("using System.Text;\n\n");
                //Cabeçalho das biblotecas fim namespaces

                stream.WriteLine("namespace Application.Mappings\n\n"); // Escreve o namespace do projecto no arquivo
                stream.WriteLine("{");// adiciona a primeira chaveta após o namespcae
                stream.WriteLine("\t\tpublic class GeneralProfile : Profile"); // Adiciona o nome da classe e os seus atributos
                stream.WriteLine("\t\t{"); //Abre chaves para escrever todo o codigo que deve existir na classe




                #region METODO GeneralProfile

                //GERAR O CONSTRUTOR 
                stream.WriteLine("\t\t\t\tpublic GeneralProfile()"); //Declara o metodo que restorna a lista de dados
                stream.WriteLine("\t\t\t\t{");

                stream.WriteLine("\t\t\t\t\t\tCreateMap<" + nomeDaTabela + "DTO, " +  nomeDaTabela + ">().ReverseMap();");


                stream.WriteLine("\t\t\t\t}\n\n");


                #endregion


                stream.WriteLine("\t\t}");//Aqui fecha o código da classe
                stream.WriteLine("}"); //Aqui fecha o código no namespace
                stream.Close();
                //Aqui termina o código do controller

            }
        }


        #endregion
    }
}
