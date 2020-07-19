using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camada_Info.GeradorInfo
{
   public class Tb_Estrutura_Info
    {
        /// <summary>
        /// Nome da coluna
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Tipo de dados da coluna
        /// </summary>
        public string Tipo { get; set; }
        /// <summary>
        /// Nome da base de dados
        /// </summary>
        public string Base_Dados { get; set; }
        /// <summary>
        /// Estrutura da base de dados
        /// </summary>
        public string Estrutura_Base_Dados { get; set; }

        /// <summary>
        /// Maximo de caracters de um determinado campo
        /// </summary>
        public string Maximo_Caracters { get; set; }

        /// <summary>
        /// Posição actual da coluna
        /// </summary>
        public int ORDINAL_POSITION { get; set; }
    }
}
