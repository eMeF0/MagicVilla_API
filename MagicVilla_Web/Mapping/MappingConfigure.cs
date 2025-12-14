using AutoMapper;
using MagicVilla_Web.Models.DTO;

namespace MagicVilla_Web.Mapping
{
    public class MappingConfigure : Profile
    {
        public MappingConfigure()
        {
            CreateMap<VillaDto, VillaDtoCreate>().ReverseMap();
            CreateMap<VillaDto, VillaDtoUpdate>().ReverseMap();
            CreateMap<VillaNumberDTO, VillaNumberDTOUpdate>().ReverseMap();
            CreateMap<VillaNumberDTO, VillaNumberDTOCreate>().ReverseMap();

        }
    }
}
