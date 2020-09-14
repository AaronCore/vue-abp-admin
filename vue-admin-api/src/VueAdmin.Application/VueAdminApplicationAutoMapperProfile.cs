using AutoMapper;
using VueAdmin.Application.Contracts.System.Logging;
using VueAdmin.Application.Contracts.System.Menu;
using VueAdmin.Domain.System;

namespace VueAdmin.Application
{
    public class VueAdminApplicationAutoMapperProfile : Profile
    {
        public VueAdminApplicationAutoMapperProfile()
        {
            // Log
            CreateMap<LogInput, LogEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.CreateTime, opt => opt.Ignore());
            CreateMap<LogEntity, LogOut>()
                .ForMember(x => x.Id, opt => opt.MapFrom(o => o.Id.ToString()))
                .ForMember(x => x.CreateTime, opt => opt.MapFrom(o => o.CreateTime.ToString("yyyy-MM-dd HH:mm:ss")));

            // Menu
            CreateMap<MenuInput, MenuEntity>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.Creater, opt => opt.Ignore())
                .ForMember(x => x.CreateTime, opt => opt.Ignore())
                .ForMember(x => x.Editor, opt => opt.Ignore())
                .ForMember(x => x.EditTime, opt => opt.Ignore());
            CreateMap<MenuEntity, MenuOut>()
                .ForMember(x => x.Id, opt => opt.MapFrom(o => o.Id.ToString()))
                .ForMember(x => x.Creater, opt => opt.Ignore())
                .ForMember(x => x.CreateTime, opt => opt.MapFrom(o => o.CreateTime.ToString("yyyy-MM-dd HH:mm:ss")))
                .ForMember(x => x.Editor, opt => opt.Ignore())
                .ForMember(x => x.EditTime, opt => opt.Ignore());
        }
    }
}
