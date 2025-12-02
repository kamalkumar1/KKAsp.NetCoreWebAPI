using Microsoft.AspNetCore.Identity;

namespace LearnProject.Model.DTO
{
    public class LoginResponseDTO
    {
        public string Token { get; set; }
        public IdentityUser  IdentityUser { get; set; }


    }
}
