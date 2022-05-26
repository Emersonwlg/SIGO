using System;

namespace Norma.Business.Models
{
    public class NormaInterna : Entity
    {
        public string Codigo { get; set; }  

        public string Titulo { get; set; }

        public int TipoNorma { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataPublicacao { get; set; }

        public string Autor { get; set; }

        public bool Ativo { get; set; }
    }
}