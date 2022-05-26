using System;
using System.Threading.Tasks;
using Norma.Business.Intefaces;
using Norma.Business.Models;

namespace Norma.Business.Services
{
    public class NormaInternaService : INormaInternaService
    {
        private readonly INormaInternaRepository _normaInternaRepository;

        public NormaInternaService(INormaInternaRepository normaInternaRepository)
        {
            _normaInternaRepository = normaInternaRepository;
        }

        public async Task Adicionar(NormaInterna normaExterna)
        {
            await _normaInternaRepository.Adicionar(normaExterna);
        }

        public async Task Atualizar(NormaInterna normaExterna)
        {
            await _normaInternaRepository.Atualizar(normaExterna);
        }

        public async Task Remover(NormaInterna NormaExterna)
        {
            await _normaInternaRepository.Remover(NormaExterna);
        }

        public void Dispose()
        {
            _normaInternaRepository?.Dispose();
        }
    }
}