using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camada_Info.GeradorInfo
{
    /// <summary>
    /// Tabelas contida numa base de dados SqlServer
    /// </summary>
   public class Tb_SchemaSqlServer
    {
        /// <summary>
        /// Nome da base de dados
        /// </summary>
        public string TABLE_CATALOG { get; set; }
        /// <summary>
        /// Estrutura da tabela (Ex: dbo)
        /// </summary>
        public string TABLE_SCHEMA { get; set; }
        /// <summary>
        /// Nome da tabela
        /// </summary>
        public string TABLE_NAME { get; set; }
    }
}
