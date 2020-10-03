/*Gerado no Gerador de Codigo Do Engº Gerson Z. Maiamba
Data: 23/09/2020 22:57:01
Direitos autorais de Engº Gerson Z. Maiamba*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Mayamba.INFO
{
		public class Tb_Email
		{
			public string Id_Email{ get; set; }
			public string Nome{ get; set; }
			public string Telefone{ get; set; }
			public string Email_Origem{ get; set; }
			public string Body{ get; set; }
			public string Email_Destino{ get; set; }
			public int Estado_Email{ get; set; }
			public DateTime Data_Registo{ get; set; }
			public string Retorno{ get; set; }
			public string Opcao{ get; set; }
		}
}
