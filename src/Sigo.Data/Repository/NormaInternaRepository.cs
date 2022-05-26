using Norma.Business.Intefaces;
using Norma.Business.Models;
using Norma.Data.Context;

namespace Norma.Data.Repository
{
    public class NormaInternaRepository : Repository<NormaInterna>, INormaInternaRepository
    {
        public NormaInternaRepository(DataDbContext context) : base(context) { }
    }
}