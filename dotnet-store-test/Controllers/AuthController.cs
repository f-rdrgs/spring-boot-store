using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using dotnet_store_test.Database.Models;
using dotnet_store_test.Models.Auth_DTO;
using dotnet_store_test.Tools;

namespace dotnet_store_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(SpringStoreContext context, JWTHandler jwtHandler) : ControllerBase
    {
        private readonly SpringStoreContext _context = context;
        private readonly JWTHandler _jwtHandler = jwtHandler;

        [HttpPost("register")]
        public async Task<ActionResult<LoginData>> Register(LoginData data)
        {
            if (new List<string?> { data.Username, data.Email, data.Password }.Select(String.IsNullOrEmpty).ToList().All(value => value == true)) {
                return BadRequest();
            }

            var newUser = new User(data.Username, data.Email, data.Password);
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
    }
}
