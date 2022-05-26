using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sigo.Models
{
    public class NormaExternaViewModel : BaseViewModel
    {
        [DisplayName("Código")]
        public string Codigo { get; set; }

        [DisplayName("Título")]
        public string Titulo { get; set; }

        [DisplayName("Comitê")]
        public string Comite { get; set; }

        [DisplayName("Idioma")]
        public string Idioma { get; set; }

        [DisplayName("Tipo Norma")]
        public int TipoNorma { get; set; }

        [DisplayName("Data Publicacao")]
        [DataType(DataType.Date)]
        public DateTime DataPublicacao { get; set; }

        [DisplayName("Data Início Validade")]
        [DataType(DataType.Date)]
        public DateTime DataInicioValidade { get; set; }

        [DisplayName("Ativo")]
        public bool Ativo { get; set; }
    }
}
