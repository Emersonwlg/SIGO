using Sigo.Enums;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sigo.Models
{
    public class NormaInternaViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Código")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Título")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Tipo Norma")]
        public int TipoNorma { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Data Publicação")]
        [DataType(DataType.Date)]
        public DateTime DataPublicacao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Autor")]
        public string Autor { get; set; }

        [DisplayName("Ativo?")]
        public bool Ativo { get; set; }
    }
}
