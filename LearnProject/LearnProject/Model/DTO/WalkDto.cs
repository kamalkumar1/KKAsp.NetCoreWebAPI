using LearnProject.Model.Domain;

namespace LearnProject.Model.DTO
{
    public class WalkDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
       

        //Navigation Properties 
        public RegionDto Region { get; set; }
        public DiffcultyDto Diffculty { get; set; }

    }
}
