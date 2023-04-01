using EstateWebManager.API.Dto;
using EstateWebManager.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EstateWebManager.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        
        private readonly UserManager<User> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersController(IConfiguration configuration, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _configuration = configuration;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim("userId", user.Id.ToString()),
                    new Claim("email", user.Email), //ClaimTypes.Email
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim("role", userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],//"https://localhost:7147",
                    audience: _configuration["JWT:ValidAudience"], //"http://localhost:4200",
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }

            return Unauthorized();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userRoleExist = await _roleManager.RoleExistsAsync("admin");
            if (!userRoleExist)
            {
                await _roleManager.CreateAsync(new IdentityRole("admin"));
            }

            userRoleExist = await _roleManager.RoleExistsAsync("user");
            if (!userRoleExist)
            {
                await _roleManager.CreateAsync(new IdentityRole("user"));
            }

            var userExists = await _userManager.FindByNameAsync(model.Email);
            if (userExists != null)
            {
                return BadRequest(new { message = "User already exists!" });
            }

            User user = new User()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return BadRequest(new { message = "User creation failed! Please check user details and try again." });
            }

            await _userManager.AddToRoleAsync(user, "user");

            if (model.Email == "bogdanvflorea@gmail.com")
            {
                await _userManager.AddToRoleAsync(user, "admin");
            }

            return CreatedAtAction(nameof(Register), user);
            //return Ok("User created successfully!");
        }

        [HttpGet]
        [Route("/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var user = await _userManager.FindByNameAsync(email);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        [Route("assign-role")]
        public async Task<IActionResult> AssignRole(string userName, string role)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return BadRequest(new { message = "User does not exist!" });
            }

            var roleExists = await _roleManager.RoleExistsAsync(role);
            if (!roleExists)
            {
                return BadRequest(new { message = "Role does not exist!" });
            }

            var result = await _userManager.AddToRoleAsync(user, role);
            if (!result.Succeeded)
            {
                return BadRequest(new { message = "Failed to assign role!" });
            }

            return Ok("Role assigned successfully!");
        }
    }
}
