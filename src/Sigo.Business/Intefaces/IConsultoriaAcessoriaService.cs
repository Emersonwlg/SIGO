using Sigo.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sigo.Business.Intefaces
{
    public interface IConsultoriaAcessoriaService : IDisposable
    {
        Task Adicionar(ConsultoriaAcessoria consultoriaAcessoria);
        Task Atualizar(ConsultoriaAcessoria consultoriaAcessoria);
        Task Remover(ConsultoriaAcessoria consultoriaAcessoria);
    }
}
