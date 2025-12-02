using System.ComponentModel.DataAnnotations;

namespace LearnProject.Model.DTO
{
    public class AddRegisterRequestDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string[] Roles { get; set; }

    }
}
