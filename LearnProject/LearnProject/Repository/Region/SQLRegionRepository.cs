using LearnProject.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LearnProject.Model.Domain;
using LearnProject.Model.DTO;

namespace LearnProject.Repository.Region
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly KKWebAPIDbContext _kKWebAPIDbContext;
      
        public SQLRegionRepository(KKWebAPIDbContext kKWebAPIDbContext) 
        {
            this._kKWebAPIDbContext = kKWebAPIDbContext;
        }

        public Task<List<Model.Domain.Region>> GetAllRegions()
        {
            return _kKWebAPIDbContext.Regions.ToListAsync();
        }

        public Task<Model.Domain.Region> GetById(Guid guid)
        {
            return _kKWebAPIDbContext.Regions.FirstOrDefaultAsync(x => x.Id == guid);
        }

        public async Task<LearnProject.Model.Domain.Region> AddRegion(AddRegionRequestDto addRegionRequestDto)
        {
            var region = new LearnProject.Model.Domain.Region
            {
                Name = addRegionRequestDto.Name!,
                Code = addRegionRequestDto.Code!,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl
            };

            // Add region to database
            await _kKWebAPIDbContext.Regions.AddAsync(region);
            _kKWebAPIDbContext.SaveChanges();
            return region;

        }
        public async Task<Model.Domain.Region> UpdateRegion(LearnProject.Model.Domain.Region existingRegion, UpdateRegionRequestDtos updateRegionRequestDto)
        {
            existingRegion.Name = updateRegionRequestDto.Name ?? existingRegion.Name;
            existingRegion.Code = updateRegionRequestDto.Code ?? existingRegion.Code;
            existingRegion.RegionImageUrl = updateRegionRequestDto.RegionImageUrl ?? existingRegion.RegionImageUrl;

            _kKWebAPIDbContext.Regions.Update(existingRegion);
            await _kKWebAPIDbContext.SaveChangesAsync();
            return existingRegion;

        }

        public async Task<Model.Domain.Region> DeleteRegion(Model.Domain.Region existingRegion)
        {
             _kKWebAPIDbContext.Regions.Remove(existingRegion);
              await _kKWebAPIDbContext.SaveChangesAsync();
              return existingRegion;
        }

    }
}
