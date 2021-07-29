using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApp.Controllers
{
    [Route("api/graph")]
    [ApiController]
    public class GraphController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public GraphController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get(string name)
        {
            string query = @"SELECT GraphName, GraphData FROM graphs WHERE GraphName = '" + name + "'";
            DataTable table = new DataTable();

            string source = _configuration.GetConnectionString("VisualDijkstraConn");
            SqlDataReader reader;

            using (SqlConnection conn = new SqlConnection(source))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    reader = command.ExecuteReader();
                    table.Load(reader);

                    reader.Close();
                    conn.Close();
                }
            }

            return new JsonResult(table);
        }
    }
}
