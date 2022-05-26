using Norma.Business.Models;
using System;

namespace Sigo.Business.Models
{
    public class ConsultoriaAcessoria : Entity
    {
        public string RazaoSocial { get; set; }

        public string NomeFantasia { get; set; }

        public string Cnpj { get; set; }

        public int Periodo { get; set; }

        public string Setor { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public int TipoDepartamento { get; set; }

        public string Descricao { get; set; }

        public Guid IdTipoNormaExterna { get; set; }

        public bool Ativo { get; set; }
    }
}
