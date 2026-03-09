using FirstProject.Data;
using FirstProject.DTOs;
using FirstProject.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _db;
        public AuthController(AppDbContext db)
        {
            _db = db;
        }
        [HttpPost("signUp")]
        public IActionResult Register(UserRegisterDto dto)
        {
            var data= new User(){
            Name=dto.Name,
            Email = dto.Email,
            UserName=dto.UserName,
            Password=dto.Password
            };
            _db.Users.Add(data);
            _db.SaveChanges();
            return Ok(new {message= "User registered successfully!" });
        }
        [HttpPost("login")]
        public IActionResult Login(UserLoginDto dto)
        {
            var data = _db.Users.FirstOrDefault(x=>x.UserName==dto.UserName);
           if(data==null||data.UserName!=dto.UserName)
            return Unauthorized(new { message = "Invalid Username or Password" });

            return Ok(new
            {
                message = "Welcome back bro",
                UserName = data.UserName,
                name = data.Name
            });
        }
        

    }
}
