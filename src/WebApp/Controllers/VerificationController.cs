using Microsoft.AspNetCore.Mvc;
using WebApp.Data;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    [Route("api/verification")]
    [ApiController]
    public class VerificationController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IVerificationRepository _verificationRepository;
        private readonly JwtService _jwtService;

        public VerificationController(
            IUserRepository userRepository,
            IVerificationRepository verificactionRepository,
            JwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
            _verificationRepository = verificactionRepository;
        }

        [HttpGet]
        public IActionResult Verify(string token)
        {
            Verification verification = null;

            System.Diagnostics.Debug.WriteLine("Token:" + token);

            try
            {
                verification = _verificationRepository.Verify(token);
            }
            catch (VerificationNotFoundException)
            {
                return NotFound("Invalid token");
            }
            catch (VerificationTokenExpiredException)
            {
                if (verification != null)
                {
                    _userRepository.DeleteUser(verification.UserId.Value);
                }

                return BadRequest("Token expired");
            }

            return Ok();
        }
    }
}
