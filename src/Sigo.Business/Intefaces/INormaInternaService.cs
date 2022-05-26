using System;
using System.Threading.Tasks;
using Norma.Business.Models;

namespace Norma.Business.Intefaces
{
    public interface INormaInternaService : IDisposable
    {
        Task Adicionar(NormaInterna normaInterna);
        Task Atualizar(NormaInterna normaInterna);
        Task Remover(NormaInterna normaInterna);
    }
}