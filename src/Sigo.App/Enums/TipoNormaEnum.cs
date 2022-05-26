using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sigo.Enums
{
    public enum TipoNormaEnum
    {
        [Display(Name = "Operacional")]
        Operacional = 1,

        [Display(Name = "Interna")]
        Interna = 2
    }
}
