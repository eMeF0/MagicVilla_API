using AutoMapper;

namespace MagicVilla_VillaAPI.Mapping
{
    public class MappingConfigure : Profile
    {
        public MappingConfigure()
        {
            CreateMap<Models.Villa, Models.DTO.VillaDto>().ReverseMap();
            CreateMap<Models.Villa, Models.DTO.VillaDtoCreate>().ReverseMap();
            CreateMap<Models.Villa, Models.DTO.VillaDtoUpdate>().ReverseMap();
            CreateMap<Models.DTO.VillaDtoUpdate, Models.DTO.VillaDtoCreate>().ReverseMap();
        }
    }
}
