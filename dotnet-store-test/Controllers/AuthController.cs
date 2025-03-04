using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using dotnet_store_test.Database.Models;
using dotnet_store_test.Models.Auth_DTO;
using dotnet_store_test.Tools;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.RateLimiting;

namespace dotnet_store_test.Controllers
{
    [Route("api/[controller]")]
    [EnableRateLimiting("fixed")]
    [ApiController]
    public class AuthController(SpringStoreContext context, JWTHandler jwtHandler, LoginTools loginTools) : ControllerBase
    {
        private readonly SpringStoreContext _context = context;
        private readonly JWTHandler _jwtHandler = jwtHandler;
        private readonly LoginTools _loginTools = loginTools;

        [HttpPost("register")]
        public async Task<ActionResult<LoginData>> Register(LoginData data)
        {
            if (new List<string?> { data.Username, data.Email, data.Password }.Select(String.IsNullOrEmpty).ToList().All(value => value == true))
            {
                return BadRequest();
            }

            var newUser = new User(data.Username, data.Email, _loginTools.HashPassword(data.Password));
            _context.Add<User>(newUser);

            int changes = await _context.SaveChangesAsync();


            if (changes > 0)
            {
                var dictClaims = new Dictionary<string, string>
                {
                    { "id", newUser.Id.ToString() }
                };

                var token = _jwtHandler.GenerateToken(dictClaims);

                var response = new { id = newUser.Id, token };
                return Ok(new JsonResult(response));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginData>> Login(LoginData data)
        {
            if (new List<string?> { data.Email, data.Password }.Select(String.IsNullOrEmpty).ToList().All(value => value == true))
            {
                return BadRequest();
            }

            User userDb;
            try
            {
                userDb = await _context.Users.Where(u => u.Email.Equals(data.Email)).SingleAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while getting user data: " + e);
                return BadRequest();
            }
            if (!_loginTools.VerifyPassword(data.Password, userDb.Password))
            {
                return Unauthorized();
            }

            
            var logDict = new Dictionary<string, string> { { "id", userDb.Id.ToString() } };
            var token = _jwtHandler.GenerateToken(logDict);

            return Ok(new JsonResult(new { id = userDb.Id.ToString(), token }));

            
        }
    }
}
