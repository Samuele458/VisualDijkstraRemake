using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using VisualDijkstraRemake.Models;
using VisualDijkstraRemake.Utils;
using WebApp.Data;
using WebApp.Dtos;
using WebApp.Models;
using WebApp.Utils;

namespace WebApp.Controllers
{
    [Route("api")]
    [ApiController]
    public class GraphController : Controller
    {
        private readonly IGraphRepository _graphRepository;
        private readonly IUserRepository _userRepository;
        private readonly JwtService _jwtService;

        public GraphController(IGraphRepository graphRepository, IUserRepository userRepository, JwtService jwtService)
        {
            _graphRepository = graphRepository;
            _userRepository = userRepository;
            _jwtService = jwtService;
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

        [HttpGet("graph")]
        public IActionResult ReadGraph(string name)
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

            GraphModel graph = _graphRepository.ReadGraph(name, user);

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
                user = _userRepository.GetById(userId);
            }
            catch (Exception)
            {
                return Unauthorized();
            }

            GraphModel graph = _graphRepository.UpdateGraph(user, dto.Name, dto.Data);

            if (graph == default(GraphModel))
            {
                return NotFound();
            }
            else
            {
                return Ok(graph);
            }
        }

        [HttpGet("graph/solve")]
        public IActionResult Solve(string name, string source, string dest)
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

            Debug.WriteLine(name + " " + source + " " + dest);

            GraphModel graphModel = _graphRepository.ReadGraph(name, user);
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
