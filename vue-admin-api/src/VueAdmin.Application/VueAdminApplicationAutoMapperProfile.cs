using AutoMapper;
using VueAdmin.Application.Contracts.Logging;
using VueAdmin.Domain.Logging;

namespace VueAdmin.Application
{
    public class VueAdminApplicationAutoMapperProfile : Profile
    {
        public VueAdminApplicationAutoMapperProfile()
        {
            // Log
            CreateMap<LogEntity, LogInput>();
            CreateMap<LogOut, LogEntity>();

        }
    }
}
