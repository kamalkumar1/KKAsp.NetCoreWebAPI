using System.ComponentModel.DataAnnotations;

namespace LearnProject.Model.DTO
{
    public class AddRegionRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Minumum 3 required")]
        [MaxLength(5, ErrorMessage = "Max lenght 5 required")]
        public string? Code { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Minumum 3 required")]
        [MaxLength(10, ErrorMessage = "Max lenght 5 required")]
        public string? Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
