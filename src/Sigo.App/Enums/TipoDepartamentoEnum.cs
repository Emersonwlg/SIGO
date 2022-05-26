using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sigo.Enums
{
    public enum TipoDepartamentoEnum
    {
        [Display(Name = "Segurança")]
        Seguranca = 1,

        [Display(Name = "Qualidade")]
        Interna = 2
    }
}
