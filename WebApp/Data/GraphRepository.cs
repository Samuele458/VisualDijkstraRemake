﻿using System.Linq;
using WebApp.Models;

namespace WebApp.Data
{
    public class GraphRepository : IGraphRepository
    {

        private readonly UserContext _context;

        public GraphRepository(UserContext context)
        {
            _context = context;
        }

        public GraphModel CreateGraph(User user, GraphModel graph)
        {
            graph.User = user;
            user.Graphs.Add(graph);
            _context.Graphs.Add(graph);
            _context.SaveChanges();

            return graph;
        }

        public GraphModel ReadGraph(int graphId, User user)
        {
            return _context
                        .Graphs
                        .FirstOrDefault(g => g.UserId == user.Id && g.Id == graphId);
        }

        public GraphModel UpdateGraph(User user, int graphId, string newData)
        {
            GraphModel graph = _context
                .Graphs
                .FirstOrDefault(g => g.UserId == user.Id && g.Id == graphId);

            if (graph != default(GraphModel))
            {
                graph.Data = newData;
                _context.SaveChanges();
            }

            return graph;
        }
    }
}
