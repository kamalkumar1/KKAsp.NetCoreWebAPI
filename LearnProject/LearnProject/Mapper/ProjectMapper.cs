using AutoMapper;
using LearnProject.Model.Domain;
using LearnProject.Model.DTO;

namespace LearnProject.Mapper
{
    public class ProjectMapperProfiles: Profile
    {

        public ProjectMapperProfiles()
        {
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<AddRegionRequestDto,Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDtos,Region>().ReverseMap();
           
            CreateMap<AddWalkRequestDto,Walk >().ReverseMap();
            CreateMap<Walk, WalkDto>().ReverseMap();

            CreateMap<Diffculty, DiffcultyDto>().ReverseMap();
        }
    }
}
