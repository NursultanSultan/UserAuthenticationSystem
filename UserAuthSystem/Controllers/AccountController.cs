using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAuthSystem.DAL;
using UserAuthSystem.Entities;
using UserAuthSystem.Services;

namespace UserAuthSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly DataContext _context;

        public AccountController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Regiter(string username , string password)
        {
            var userExists = _context.Users.Any(u => u.Username == username);
            if (userExists)
            {
                return BadRequest("User Already Exist");
            }

            var salt = PasswordHasher.GenerateSalt();
            var passwordHash = PasswordHasher.HashPassword(password, salt);

            var user = new User
            {
                Username = username,
                Email = "nursultan@gmail.com",
                PasswordHash = passwordHash,
                PasswordSalt = salt
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok("User registered succesfully.");
        }

    }
}
