using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sigo.Models
{
    public class BaseViewModel
    {
        public BaseViewModel()
        {
            DataCadastro = DateTime.Now;
        }

        [Key]
        public Guid Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataCadastro { get; set; }
    }
}
