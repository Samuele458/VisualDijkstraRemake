using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebApp.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        public virtual IList<GraphModel> Graphs { get; set; }

        public User()
        {
            Graphs = new List<GraphModel>();

        }
    }
}
