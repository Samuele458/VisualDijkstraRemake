using Microsoft.AspNetCore.Mvc;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    /// <summary>
    ///  Email verification controller
    /// </summary>
    [Route("api/verification")]
    [ApiController]
    public class VerificationController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IVerificationRepository _verificationRepository;

        /// <summary>
        ///  Controller contrustor, used in dependency injection
        /// </summary>
        /// <param name="userRepository">IUserRepository object</param>
        /// <param name="verificactionRepository">IVerificationRepository object</param>
        public VerificationController(
            IUserRepository userRepository,
            IVerificationRepository verificactionRepository)
        {
            _userRepository = userRepository;
            _verificationRepository = verificactionRepository;
        }

        /// <summary>
        ///  GET endpoint for verifying tokens
        /// </summary>
        /// <param name="token">Verification token string</param>
        /// <returns>Response to client</returns>
        [HttpGet]
        public IActionResult Verify(string token)
        {
            Verification verification = null;

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

                verification = _verificationRepository.ReadVerification(token);
                _userRepository.DeleteUser(verification.UserId.Value);

                return BadRequest("Token expired");
            }

            return Ok();
        }
    }
}
