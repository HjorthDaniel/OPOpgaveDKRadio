using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using OPOpgaveDKRadio.Model;
using OPOpgaveDKRadio.Repository;

namespace OPOpgaveDKRadio
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly UserRepository _userRepository = new UserRepository();
		private readonly IConfiguration _configuration;

		public AuthController(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		[HttpPost("login")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public IActionResult Login([FromBody] LoginRequest request)
		{
			User? user = _userRepository.Login(request.Username, request.Password);

			if (user == null)
			{
				return Unauthorized();
			}

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new[]
				{
					new Claim(ClaimTypes.Name, user.Username),
					new Claim(ClaimTypes.Role, user.Role)
				}),
				Expires = DateTime.UtcNow.AddHours(1),
				Issuer = _configuration["Jwt:Issuer"],
				Audience = _configuration["Jwt:Audience"],
				SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
			};

			string token = new JsonWebTokenHandler().CreateToken(tokenDescriptor);

			return Ok(new { token, username = user.Username, role = user.Role });
		}

		[HttpGet("me")]
		[Authorize]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public IActionResult Me()
		{
			return Ok(new { username = User.Identity!.Name, isAdmin = User.IsInRole("Admin") });
		}
	}
}