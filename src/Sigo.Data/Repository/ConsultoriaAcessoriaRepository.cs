using Norma.Data.Context;
using Norma.Data.Repository;
using Sigo.Business.Intefaces;
using Sigo.Business.Models;

namespace Sigo.Data.Repository
{
    public class ConsultoriaAcessoriaRepository : Repository<ConsultoriaAcessoria>, IConsultoriaAcessoriaRepository
    {
        public ConsultoriaAcessoriaRepository(DataDbContext context) : base(context) { }
    }
}
