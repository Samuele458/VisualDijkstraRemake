using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using WebApp.Data;
using WebApp.Dtos;
using WebApp.Models;
using WebApp.Utils;

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
                    Graphs = user.Graphs.Select(g => g.Name)
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

        [HttpPost("graph")]
        public IActionResult CreateGraph(CreateGraphDto dto)
        {
            User user;
            try
            {
                string jwt = Request.Cookies["jwt"];

                JwtSecurityToken token = _jwtService.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                user = _repository.GetById(userId);
            }
            catch (Exception)
            {
                return Unauthorized();
            }

            GraphModel graph = new GraphModel
            {
                Name = dto.Name,
                Data = dto.Data,
            };

            try
            {
                _repository.CreateGraph(user, graph);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Created("success", graph);
        }

        [HttpGet("graph")]
        public IActionResult ReadGraph(string name)
        {
            User user;

            try
            {
                string jwt = Request.Cookies["jwt"];

                JwtSecurityToken token = _jwtService.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                user = _repository.GetById(userId);

            }
            catch (Exception)
            {
                return Unauthorized();
            }

            GraphModel graph = _repository.ReadGraph(name, user);

            if (graph == default(GraphModel))
            {
                return NotFound();
            }
            else
            {
                return Ok(graph);
            }
        }


        [HttpPut("graph")]
        public IActionResult UpdateGraph(CreateGraphDto dto)
        {
            User user;

            try
            {
                string jwt = Request.Cookies["jwt"];
                JwtSecurityToken token = _jwtService.Verify(jwt);
                int userId = int.Parse(token.Issuer);
                user = _repository.GetById(userId);
            }
            catch (Exception)
            {
                return Unauthorized();
            }

            GraphModel graph = _repository.UpdateGraph(user, dto.Name, dto.Data);

            if (graph == default(GraphModel))
            {
                return NotFound();
            }
            else
            {
                return Ok(graph);
            }
        }
    }
}
