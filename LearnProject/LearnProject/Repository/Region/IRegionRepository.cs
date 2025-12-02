using LearnProject.Model.Domain;
using LearnProject.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearnProject.Repository.Region
{
    public interface IRegionRepository
    {
        Task<List<LearnProject.Model.Domain.Region>> GetAllRegions();
        Task<LearnProject.Model.Domain.Region> GetById(Guid guid);
        Task<LearnProject.Model.Domain.Region> AddRegion(AddRegionRequestDto addRegionRequestDto);
        Task<LearnProject.Model.Domain.Region> UpdateRegion(LearnProject.Model.Domain.Region region, UpdateRegionRequestDtos updateRegionRequestDto);
        Task<Model.Domain.Region> DeleteRegion(Model.Domain.Region existingRegion);
    }
}
