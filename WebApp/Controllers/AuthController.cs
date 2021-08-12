using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using WebApp.Data;
using WebApp.Dtos;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IUserRepository _repository;
        private readonly JwtService _jwtService;

        public AuthController(IUserRepository repository, JwtService jwtService)
        {
            _repository = repository;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            User user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };

            return Created("success", _repository.Create(user));
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            User user = _repository.GetByEmail(dto.Email);

            if (user == null)
            {
                return BadRequest(new { message = "Invalid credentials" });
            }

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
            {
                return BadRequest(new { message = "Invalid credentials" });
            }

            string jwt = _jwtService.Generate(user.Id);

            Response.Cookies.Append("jwt", jwt, new Microsoft.AspNetCore.Http.CookieOptions
            {
                HttpOnly = true
            });

            return Ok(new
            {
                message = "success"
            });
        }


        [HttpGet("user")]
        public IActionResult User()
        {
            try
            {
                string jwt = Request.Cookies["jwt"];

                JwtSecurityToken token = _jwtService.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                var user = _repository.GetById(userId);



                return Ok(new
                {
                    Name = user.Name,
                    Email = user.Email,
                    Graphs = user.Graphs.Select(g => new { name = g.Name, id = g.Id })
                });
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }


        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");

            return Ok(new
            {
                message = "success"
            });
        }


    }
}
