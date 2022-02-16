using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgenciaCronosPainel.Models
{
    public class Integrantes
    {
        public long Id { get; set; }

        public bool Excluido { get; set; } = false;

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public string Email { get; set; }

        public string Celular { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}