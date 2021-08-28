using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mail;
using WebApp.Data;
using WebApp.Dtos;
using WebApp.Models;
using WebApp.Services;
using WebApp.Utils;

namespace WebApp.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IUserRepository _repository;
        private readonly IVerificationRepository _verificationRepository;
        private readonly JwtService _jwtService;
        private readonly IEmailHandler _emailHandler;

        public AuthController(
            IUserRepository repository,
            IVerificationRepository verificactionRepository,
            JwtService jwtService,
            IEmailHandler emailHandler)
        {
            _repository = repository;
            _jwtService = jwtService;
            _verificationRepository = verificactionRepository;
            _emailHandler = emailHandler;
        }

        //TODO: implement IDisposable in EmailHandler
        /*
        protected override void Dispose(bool disposing)
        {
            _emailHandler.Dispose();
            base.Dispose(disposing);
        }*/

        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            User user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };

            User responseUser = null;

            try
            {
                responseUser = _repository.Create(user);
            }
            catch (DuplicatedUserException)
            {
                return BadRequest(new { message = "User already exists" });
            }

            Verification verification = _verificationRepository.CreateVerification(user);

            MailMessage mail = new MailMessage();
            mail.Body = "We are happy you signed up for VisualDIjkstra. To start using VisualDijkstra please verify your email";
            mail.Subject = "Confirmation";
            mail.To.Add(new MailAddress("samuele.girgenti458@gmail.com"));
            _emailHandler.SendEmail(mail);

            return Created("success", responseUser);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            User user = _repository.GetByEmail(dto.Email);

            if (user == null)
            {
                return NotFound(new { message = "Invalid credentials" });
            }

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
            {
                return NotFound(new { message = "Invalid credentials" });
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
                    Graphs = user.Graphs.Select(g => new { name = g.Name, id = g.Id, updatedOn = g.UpdatedOn })
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
