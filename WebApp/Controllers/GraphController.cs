using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebApp.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class GraphController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public GraphController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


    }
}
