using LearnProject.Model.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace LearnProject.Repository.WalkRepo
{
    public interface IWalkRepository
    {
       Task<Model.Domain.Walk> AddWalkAsync(Model.Domain.Walk addWalkRequestDto);
       Task<List<Model.Domain.Walk>> GetAllWalksAsync();

        Task<Model.Domain.Walk> GetWalkAsync(Guid id);
        Task<List<Walk>> AllWalksWithFilterAsync(string? filteron = null, string? filterquery = null);

    }
}
