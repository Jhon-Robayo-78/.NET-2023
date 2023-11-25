using api_university.DataAccess;
using api_university.Helpers;
using api_university.Models.DataModels;
using Azure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_university.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UniversityDBContext _context;
        private readonly JwtSettings _jwtSettings;
        public AccountController(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }
        //example user
        private IEnumerable<User> Logins = new List<User>()
        {
            new User()
            {
                Id = 1,
                Email = "bobafeetrobayo@gmail.com",
                Name = "Admin",
                Password = "123456"
            },
            new User()
            {
                Id = 2,
                Email = "bobafeetrobayo2@gmail.com",
                Name = "User1",
                Password = "654321"
            }
        };

        [HttpPost]
        public IActionResult GetToken(UserLogins userLogin)
        {
            try
            {
                var Token = new UserTokens();

                //TODO:
                //Search a user in context with LINQ
                var searchUser = (from user in _context.Users
                                  where user.Name == userLogin.UserName && user.Password == userLogin.UserPassWord
                                  select user).FirstOrDefault();
                
                //al busca por usuario se cambia la forma de busqueda del mismo Console.WriteLine("User found", searchUser);


                //var Valid = Logins.Any(user => user.Name.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));
             

                if(searchUser != null)
                {
                    //var user = Logins.FirstOrDefault(user => user.Name.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));
                    
                    Token = JwtHelpers.GetTokenKey(new UserTokens()
                    {
                        UserName = searchUser.Name,
                        EmailId = searchUser.Email,
                        Id = searchUser.Id,
                        GuidId = Guid.NewGuid(),
                    }, _jwtSettings ); 
                }
                else
                {
                    return BadRequest("Wrong Password");
                }
                return Ok(Token);
            }catch (Exception ex)
            {
                throw new Exception("GetToken Error", ex);
            }
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles ="Administrator")]
        public IActionResult GetUserList()
        {
            return Ok(Logins);
        }
    }
}
