using AutoMapper;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.DTO;

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
            CreateMap<VillaNumber, VillaNumberDTO>().ReverseMap();
            CreateMap<VillaNumber, VillaNumberDTOCreate>().ReverseMap();
            CreateMap<VillaNumber, VillaNumberDTOUpdate>().ReverseMap();
            CreateMap<VillaNumberDTOCreate, VillaNumberDTOUpdate>().ReverseMap();

        }
    }
}
