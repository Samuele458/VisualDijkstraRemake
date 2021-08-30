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
    /// <summary>
    ///  Authentication controller
    /// </summary>
    [Route("api")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IUserRepository _repository;
        private readonly IVerificationRepository _verificationRepository;
        private readonly JwtService _jwtService;
        private readonly IEmailHandler _emailHandler;

        /// <summary>
        ///  Controller constructor used in dependency injection
        /// </summary>
        /// <param name="repository">IUserRepository for handling users</param>
        /// <param name="verificactionRepository">IVerification repository for handling issuing verification</param>
        /// <param name="jwtService">JwtService for handling JWT</param>
        /// <param name="emailHandler">EmailHandler, for sending emails</param>
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

        /// <summary>
        ///  POST endpoint for registering new users
        /// </summary>
        /// <param name="dto">DTO for registration</param>
        /// <returns>Response to client</returns>
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
            mail.Body = String.Format("We are happy you signed up for VisualDijkstra.\nTo start using VisualDijkstra please verify your email:\n{0}",
                                      "https://visualdijkstra.com/api/verification?token=" + verification.Token);


            mail.Subject = "Confirmation";
            mail.To.Add(new MailAddress(user.Email));
            mail.IsBodyHtml = true;
            _emailHandler.SendEmail(mail);

            return Created("success", responseUser);
        }

        /// <summary>
        ///  POST endpoint for handling user login
        /// </summary>
        /// <param name="dto">DTO for login</param>
        /// <returns>Response to client</returns>
        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            User user = _repository.GetByEmail(dto.Email);

            System.Diagnostics.Debug.WriteLine("Ver: " + (user.Verification == null));

            if (user == null || user.Verification != null)
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


        /// <summary>
        ///  Returns details of authenticated user
        /// </summary>
        /// <returns>Response with user details</returns>
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

        /// <summary>
        ///  User logout
        /// </summary>
        /// <returns>Response to client</returns>
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
