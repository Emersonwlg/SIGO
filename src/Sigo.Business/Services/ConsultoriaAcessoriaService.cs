using Sigo.Business.Intefaces;
using Sigo.Business.Models;
using System.Threading.Tasks;

namespace Sigo.Business.Services
{
    public class ConsultoriaAcessoriaService : IConsultoriaAcessoriaService
    {
        private readonly IConsultoriaAcessoriaRepository _consultoriaAcessoriaRepository;

        public ConsultoriaAcessoriaService(IConsultoriaAcessoriaRepository consultoriaAcessoriaRepository)
        {
            _consultoriaAcessoriaRepository = consultoriaAcessoriaRepository;
        }

        public async Task Adicionar(ConsultoriaAcessoria consultoriaAcessoria)
        {
            await _consultoriaAcessoriaRepository.Adicionar(consultoriaAcessoria);
        }

        public async Task Atualizar(ConsultoriaAcessoria consultoriaAcessoria)
        {
            await _consultoriaAcessoriaRepository.Atualizar(consultoriaAcessoria);
        }

        public async Task Remover(ConsultoriaAcessoria consultoriaAcessoria)
        {
            await _consultoriaAcessoriaRepository.Remover(consultoriaAcessoria);
        }

        public void Dispose()
        {
            _consultoriaAcessoriaRepository?.Dispose();
        }
    }
}
