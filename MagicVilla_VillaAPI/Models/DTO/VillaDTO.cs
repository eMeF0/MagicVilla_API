using System.ComponentModel.DataAnnotations;

namespace MagicVilla_VillaAPI.Models.DTO
{
    public class VillaDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(40, ErrorMessage = "The name has a maximum length of 40 characters.")]
        [MinLength(3, ErrorMessage = "The name has a minimum length of 3 characters.")]
        public string Name { get; set; }
        public int Occupancy { get; set; }

        public int Sqft { get; set; }
    }
}
