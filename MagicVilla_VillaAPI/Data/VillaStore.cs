using MagicVilla_VillaAPI.Models.DTO;

namespace MagicVilla_VillaAPI.Data
{
    public class VillaStore
    {
        public static List<VillaDto> villaList = new List<VillaDto>
            {
                new VillaDto { Id = 1, Name = "Ocean View Villa", Sqft = 100, Occupancy = 4},
                new VillaDto { Id = 2, Name = "Mountain Retreat Villa", Sqft = 300, Occupancy = 6}
            };
    }
}
