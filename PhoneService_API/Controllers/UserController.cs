using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PhoneService_API.Data;
using PhoneService_API.Dtos;
using PhoneService_API.Helpers;
using PhoneService_API.Models;
using PhoneService_API.Services;

namespace PhoneService_API.Controllers
{
    [Route("auth")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IUserRepo _repository;
        private readonly UserService _userService;

        public UserController(IUserRepo userRepo, IOptions<AppSettings> appSettings, AppDbContext context)
        {
            _userService = new UserService(appSettings, userRepo, context);
            _repository = userRepo;
            _context = context;
        }

        [HttpPost]
        [Route("signin")]
        [AllowAnonymous]
        public ActionResult<dynamic> Authenticate([FromBody] UserReadDto model)
        {
            var response = _userService.Authenticate(model.Username, model.Password, IpAddress());

            if (response == null)
                return BadRequest(new {message = "Username or password is incorrect"});

            SetTokenCookie(response.RefreshToken);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("refresh-token")]
        public IActionResult RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var response = _userService.RefreshToken(refreshToken, IpAddress());

            if (response == null)
                return Unauthorized(new {message = "Invalid token"});

            SetTokenCookie(response.RefreshToken);

            return Ok(response);
        }

        [HttpPost("revoke-token")]
        public IActionResult RevokeToken([FromBody] RevokeTokenRequest model)
        {
            // accept token from request body or cookie
            var token = model.Token ?? Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(token))
                return BadRequest(new {message = "Token is required"});

            var response = _userService.RevokeToken(token, IpAddress());

            if (!response)
                return NotFound(new {message = "Token not found"});

            return Ok(new {message = "Token revoked"});
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);
            if (user == null) return NotFound();

            return Ok(user);
        }

        [HttpGet("isProtected")]
        public ActionResult IsProtected()
        {
            return Ok();
        }

        [HttpPost]
        [Route("register")]
        public ActionResult CreateUser([FromBody] UserReadDto model)
        {
            // validation
            if (string.IsNullOrWhiteSpace(model.Password))
                throw new Exception("Password is required");
            var user = new User();

            if (_context.User.Any(x => x.Username == user.Username))
                throw new Exception("Username \"" + user.Username + "\" is already taken");

            PasswordHashHandler.CreatePasswordHash(model.Password, out var passwordHash, out var passwordSalt);
            user.Username = model.Username;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _repository.Create(user);
            _repository.SaveChanges();
            return Ok();
        }

        private void SetTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(3),
                Path = "/auth/refresh-token"
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }

        private string IpAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            return HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString();
        }
    }
}