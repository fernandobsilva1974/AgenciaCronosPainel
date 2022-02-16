using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgenciaCronosPainel.Models
{
    public class Posts
    {
        public long Id { get; set; }

        public bool Excluido { get; set; } = false;

        public int? Numero { get; set; }

        public string Titulo { get; set; }

        public string Descritivo { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}