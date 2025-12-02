using LearnProject.Model.DTO;
using LearnProject.Repository.Tokens;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using LearnProject.Model;

namespace LearnProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenRepositiory _tokenRepositiory;
        public AuthController(UserManager<IdentityUser> userManager, ITokenRepositiory tokenRepositiory)
        {
            _userManager = userManager;
            _tokenRepositiory = tokenRepositiory;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody]LoginRequestDto loginRequestDto)
        {
            var user = await _userManager.FindByEmailAsync(loginRequestDto.Email);
            if (user == null)
            {
                return BadRequest("Invalid email or password.");
            }
            var checkPassword = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);
            if (!checkPassword)
            {
                return BadRequest("Invalid email or password.");
            }
            var roles = await _userManager.GetRolesAsync(user);
            if (roles == null) {    
                return BadRequest("User has no roles assigned.");
            }
            var token = _tokenRepositiory.CreateToken(user, roles.ToList());

            var response = new ResultBaseModel<LoginResponseDTO>
            {
                Statuscode = 200,
                Message = "Login Successful",
                BaseResult = new BaseResult<LoginResponseDTO>
                {
                    Data = new LoginResponseDTO { Token = token , IdentityUser = user }
                }
            };

            return Ok(response);
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] Model.DTO.AddRegisterRequestDto addRegisterRequestDto)
        {
            var existingUser = await _userManager.FindByEmailAsync(addRegisterRequestDto.Email);
            if (existingUser != null)
            {
                return BadRequest("User with this email already exists.");
            }
            var newUser = new IdentityUser
            {
                UserName = addRegisterRequestDto.Email,
                Email = addRegisterRequestDto.Email
            };
            var createUserResult = await _userManager.CreateAsync(newUser, addRegisterRequestDto.Password);
            if (!createUserResult.Succeeded)
            {
                return BadRequest(createUserResult.Errors);
            }
            else
            {
                if (addRegisterRequestDto.Roles != null && addRegisterRequestDto.Roles.Length > 0)
                {
                    var addToRolesResult = await _userManager.AddToRolesAsync(newUser, addRegisterRequestDto.Roles);
                    if (!addToRolesResult.Succeeded)
                    {
                        return BadRequest(addToRolesResult.Errors);
                    }
                    else
                    {
                        var response = new ResultBaseModel<LoginResponseDTO>
                        {
                            Statuscode = 200,
                            Message = "register Successful"
                        };
                        return Ok(response);
                    }
                }
                else
                {
                     return Ok("Roles Not defined.");
                }
            }
        }
    }
}
