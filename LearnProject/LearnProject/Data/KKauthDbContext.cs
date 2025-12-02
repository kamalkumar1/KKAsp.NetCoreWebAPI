using LearnProject.Model.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LearnProject.Data
{
    public class KKauthDbContext: IdentityDbContext
    {
        public KKauthDbContext(DbContextOptions<KKauthDbContext> dbContextOptions) : base(dbContextOptions)
        {
            

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var readerID = "3f2504e0-4f89-11d3-9a0c-0305e82c3301";
            var writerID = "3f2504e0-4f89-11d3-9a0c-0305e82c3305";

            var roles = new List<Microsoft.AspNetCore.Identity.IdentityRole>
            {
                new Microsoft.AspNetCore.Identity.IdentityRole
                {
                    Id = readerID,
                    ConcurrencyStamp = readerID,
                    Name = "Reader",
                    NormalizedName = "READER"
                },
                new Microsoft.AspNetCore.Identity.IdentityRole
                {
                    Id = writerID,
                    ConcurrencyStamp = writerID,
                    Name = "Writer",
                    NormalizedName = "WRITER"
                }
            };
            modelBuilder.Entity<Microsoft.AspNetCore.Identity.IdentityRole>().HasData(roles);

        }
    }
}
