using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgenciaCronosPainel.Models
{
    public class Servicos
    {
		public long Id { get; set; }

        public bool Excluido { get; set; } = false;

        public string CodServico { get; set; }

        public string DescServico { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}