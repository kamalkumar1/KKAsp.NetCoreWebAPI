using Microsoft.AspNetCore.Identity;

namespace LearnProject.Repository.Tokens
{
    public interface ITokenRepositiory
    {
        string CreateToken(IdentityUser identityUser, List<string>roles);
    }
}
