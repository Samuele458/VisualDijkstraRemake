using Microsoft.AspNetCore.Mvc;
using WebApp.Data;
using WebApp.Services;

namespace WebApp.Controllers
{
    [Route("api/verification")]
    [ApiController]
    public class VerificationController : Controller
    {
        private readonly IUserRepository _repository;
        private readonly IVerificationRepository _verificationRepository;
        private readonly JwtService _jwtService;

        public VerificationController(
            IUserRepository repository,
            IVerificationRepository verificactionRepository,
            JwtService jwtService)
        {
            _repository = repository;
            _jwtService = jwtService;
            _verificationRepository = verificactionRepository;
        }


    }
}
