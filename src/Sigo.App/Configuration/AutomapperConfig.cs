using AutoMapper;
using Norma.Business.Models;
using Sigo.Business.Models;
using Sigo.Models;

namespace Sigo.App.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<NormaInternaViewModel, NormaInterna>();
            CreateMap<NormaInterna, NormaInternaViewModel>();

            CreateMap<ConsultoriaAcessoriaViewModel, ConsultoriaAcessoria>();
            CreateMap<ConsultoriaAcessoria, ConsultoriaAcessoriaViewModel>();
        }
    }
}
