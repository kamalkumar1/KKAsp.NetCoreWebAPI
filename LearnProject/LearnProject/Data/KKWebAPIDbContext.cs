using LearnProject.Model.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace LearnProject.Data
{
    public class KKWebAPIDbContext : DbContext
    {
        public KKWebAPIDbContext(DbContextOptions<KKWebAPIDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Diffculty> Diffculties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var diffculties = new List<Diffculty>
            {
                new Diffculty { Id = new Guid("a1b2c3d4-e5f6-4789-9012-3456789abcde"), Name = "Easy" },
                new Diffculty { Id = new Guid("b2c3d4e5-f6a1-4890-0123-456789abcdef"), Name = "Medium" },
                new Diffculty { Id = new Guid("c3d4e5f6-a1b2-4901-1234-56789abcdef0"), Name = "Hard" }
            };

            modelBuilder.Entity<Diffculty>().HasData(diffculties);

            var regions = new List<Region>
            {
                new Region
                {
                    Id = new Guid("d1e2f3a4-b5c6-4718-9012-111111111111"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "https://example.com/images/auckland.jpg"
                },
                new Region
                {
                    Id = new Guid("e2f3a4b5-c6d7-4829-9012-222222222222"),
                    Name = "Wellington",
                    Code = "WLG",
                    RegionImageUrl = "https://example.com/images/wellington.jpg"
                },
                new Region
                {
                    Id = new Guid("f3a4b5c6-d7e8-4930-9012-333333333333"),
                    Name = "Canterbury",
                    Code = "CAN",
                    RegionImageUrl = "https://example.com/images/canterbury.jpg"
                },
                new Region
                {
                    Id = new Guid("a4b5c6d7-e8f9-5041-9012-444444444444"),
                    Name = "Otago",
                    Code = "OTA",
                    RegionImageUrl = "https://example.com/images/otago.jpg"
                },
                new Region
                {
                    Id = new Guid("b5c6d7e8-f9a1-5152-9012-555555555555"),
                    Name = "Bay of Plenty",
                    Code = "BOP",
                    RegionImageUrl = "https://example.com/images/bay-of-plenty.jpg"
                }
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
