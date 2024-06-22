using Client.Persistence.Application.Auth.JwtHelper.Interface;
using Client.Persistence.Domain.UserAuth.Model;
using Microsoft.AspNetCore.Mvc;
using Client.Persistence.Domain.UserAuth.Repostory.Interface;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Client.Persistence.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IJwtAuth? _jwtAuth;
        private readonly IUserAuthRegister? _userAuthRegister;

        public AuthController(IJwtAuth? jwtAuth, IUserAuthRegister? userAuthRegister)
        {
            _jwtAuth = jwtAuth;
            _userAuthRegister = userAuthRegister;
        }

        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="user">Detalhes do usuário sendo registrado</param>
        /// <returns>Returns if an user was registered or not</returns>
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            var userRegistered = await _userAuthRegister?.GetAsync(user?.Email?.ToLower());

            if (userRegistered?.Name == user?.Name) {
                return BadRequest("This e-mail is already registered, try again with another one.");
            }

            if (user is User) {
                await _userAuthRegister.CreateAsync(user);
                return Created();
            }

            return BadRequest("Erro ao registrar usuário.");
        }

        /// <summary>
        /// Authenticates a user
        /// </summary>
        /// <param name="email">Email of the user.</param>
        /// <param name="password">Password of the user.</param>
        /// <returns>Token JWT if success</returns>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login(string email, string password)
        {
            var userExists = await _userAuthRegister.GetAsync(email.ToLower());

            if (userExists == null)
                return Unauthorized(new { Message = "Email e/ou senha inválido(s)." });


            if (userExists.Password != password)
                return Unauthorized(new { Message = "Email e/ou senha inválido(s)." });


            var token = _jwtAuth.GenerateToken(userExists);

            return Ok(new { token });
        }

        /// <summary>
        /// Verifies a user
        /// </summary>
        /// <returns>User Name and Role</returns>
        [HttpGet("user")]
        [Authorize(Roles = "Menager,Admin,Regular")]
        public IActionResult GetEmployeee()
        {
            var role = HttpContext.User.FindAll(ClaimTypes.Role).FirstOrDefault();

            return Ok($"User: {User?.Identity?.Name} | Access Type: {role?.Value}");
        }
    }
}
