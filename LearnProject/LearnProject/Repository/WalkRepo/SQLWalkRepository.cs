using AutoMapper;
using LearnProject.Data;
using LearnProject.Model.Domain;
using LearnProject.Model.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearnProject.Repository.WalkRepo
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly KKWebAPIDbContext kKWebAPIDbContext;
        public readonly  IWalkRepository WalkRepository;
        public readonly IMapper _mapper;

        public SQLWalkRepository(KKWebAPIDbContext kKWebAPIDbContext, IMapper mapper)
        {
            this.kKWebAPIDbContext = kKWebAPIDbContext;
            this._mapper = mapper;
        }

        public async Task<Walk> AddWalkAsync(Walk addWalkRequest)
        {
            await kKWebAPIDbContext.Walks.AddAsync(addWalkRequest);
            await kKWebAPIDbContext.SaveChangesAsync();
            return addWalkRequest;
        }

        public async Task<List<Walk>> GetAllWalksAsync()
        {
            var list = await kKWebAPIDbContext.Walks.Include("Diffculty").Include("Region").ToListAsync();
            await kKWebAPIDbContext.SaveChangesAsync();
            return list;

        }

        public async Task<Walk> GetWalkAsync(Guid id)
        {
            var list = await kKWebAPIDbContext.Walks.Include("Diffculty").Include("Region").FirstOrDefaultAsync(x=>x.Id == id);

            await kKWebAPIDbContext.SaveChangesAsync();
            return list;

        }

        public async Task<List<Walk>> AllWalksWithFilterAsync(string? filteron = null, string? filterquery = null)
        {
            var list = kKWebAPIDbContext.Walks.Include("Diffculty").Include("Region").AsQueryable();
            if (string.IsNullOrWhiteSpace(filteron) == false && string.IsNullOrWhiteSpace(filterquery) == false)
            {
                if (filteron.Equals("name", StringComparison.OrdinalIgnoreCase))
                {
                    list = list.Where(x => x.Name.Contains(filterquery));
                }
            }

            return await list.ToListAsync();
        }
    }
}
