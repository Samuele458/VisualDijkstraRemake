using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using VisualDijkstraLib.Models;
using VisualDijkstraLib.Utils;
using WebApp.Data;
using WebApp.Dtos;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    /// <summary>
    ///  Graph controller
    /// </summary>
    [Route("api")]
    [ApiController]
    public class GraphController : Controller
    {
        private readonly IGraphRepository _graphRepository;
        private readonly IUserRepository _userRepository;
        private readonly JwtService _jwtService;

        /// <summary>
        ///  Controller constructor used in dependency injection
        /// </summary>
        /// <param name="userRepository">IUserRepository for handling users</param>
        /// <param name="graphRepository">IGraphRepository for handling graphs</param>
        /// <param name="jwtService">JwtService for handling JWT</param>
        public GraphController(IGraphRepository graphRepository, IUserRepository userRepository, JwtService jwtService)
        {
            _graphRepository = graphRepository;
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        /// <summary>
        ///  POST endpoint for creating graphs
        /// </summary>
        /// <param name="dto">DTO for graph creation</param>
        /// <returns>Created graph in response</returns>
        [HttpPost("graph")]
        public IActionResult CreateGraph(CreateGraphDto dto)
        {
            User user;
            try
            {
                string jwt = Request.Cookies["jwt"];
                JwtSecurityToken token = _jwtService.Verify(jwt);
                int userId = int.Parse(token.Issuer);
                user = _userRepository.GetById(userId);
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
                _graphRepository.CreateGraph(user, graph);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Created("success", graph);
        }


        /// <summary>
        ///  GET endpoint for reading an existing graph
        /// </summary>
        /// <param name="id">Graph id</param>
        /// <returns>Graph data in response</returns>
        [HttpGet("graph")]
        public IActionResult ReadGraph(int id)
        {
            User user;

            try
            {
                string jwt = Request.Cookies["jwt"];

                JwtSecurityToken token = _jwtService.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                user = _userRepository.GetById(userId);

            }
            catch (Exception)
            {
                return Unauthorized();
            }

            GraphModel graph = _graphRepository.ReadGraph(id, user);

            if (graph == default(GraphModel))
            {
                return NotFound();
            }
            else
            {
                return Ok(graph);
            }
        }

        /// <summary>
        ///  PUT request for updating graph data
        /// </summary>
        /// <param name="dto">DTO for updating graph</param>
        /// <returns>Data of updated graph in response</returns>
        [HttpPut("graph")]
        public IActionResult UpdateGraph(CreateGraphDto dto)
        {
            User user;

            try
            {
                string jwt = Request.Cookies["jwt"];
                JwtSecurityToken token = _jwtService.Verify(jwt);
                int userId = int.Parse(token.Issuer);
                user = _userRepository.GetById(userId);
            }
            catch (Exception)
            {
                return Unauthorized();
            }

            GraphModel graph = null;

            if (!string.IsNullOrEmpty(dto.Data))
            {
                try
                {
                    graph = _graphRepository.UpdateGraphData(user, dto.Id, dto.Data);
                }
                catch (InvalidSaveFileFormat e)
                {
                    return BadRequest();
                }
            }

            else if (!string.IsNullOrEmpty(dto.Name))
            {
                graph = _graphRepository.UpdateGraphName(user, dto.Id, dto.Name);
            }

            System.Threading.Thread.Sleep(500);

            if (graph != null && graph == default(GraphModel))
            {
                return NotFound();
            }
            else
            {
                return Ok(graph);
            }
        }


        /// <summary>
        ///  DELETE endpoint for deleting graph
        /// </summary>
        /// <param name="id">Graph id</param>
        /// <returns>Deleted graph data in response</returns>
        [HttpDelete("graph")]
        public IActionResult DeleteGraph(int id)
        {
            User user;

            try
            {
                string jwt = Request.Cookies["jwt"];
                JwtSecurityToken token = _jwtService.Verify(jwt);
                int userId = int.Parse(token.Issuer);
                user = _userRepository.GetById(userId);
            }
            catch (Exception)
            {
                return Unauthorized();
            }

            GraphModel graph = _graphRepository.DeleteGraph(id, user);
            if (graph == default(GraphModel))
            {
                return NotFound();
            }
            else
            {
                return Ok(graph);
            }
        }

        /// <summary>
        ///  GET request for solving graph
        /// </summary>
        /// <param name="id">Graph id</param>
        /// <param name="source">Source node name</param>
        /// <param name="dest">Destination node name</param>
        /// <returns>Dijkstra solution step-by-step in response</returns>
        [HttpGet("graph/solve")]
        public IActionResult Solve(int id, string source, string dest)
        {
            User user;

            try
            {
                string jwt = Request.Cookies["jwt"];
                JwtSecurityToken token = _jwtService.Verify(jwt);
                int userId = int.Parse(token.Issuer);
                user = _userRepository.GetById(userId);
            }
            catch (Exception)
            {
                return Unauthorized();
            }

            GraphModel graphModel = _graphRepository.ReadGraph(id, user);
            if (graphModel == default(GraphModel))
            {
                return NotFound();
            }

            Graph graph = GraphUtils.decodeGraphFromJSONString(graphModel.Data);

            Dijkstra solver = new Dijkstra(graph);
            List<GraphState> states = solver.Solve(source, dest);

            return Ok(states);
        }
    }
}
