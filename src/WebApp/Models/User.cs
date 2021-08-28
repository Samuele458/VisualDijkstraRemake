using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebApp.Models
{
    /// <summary>
    ///  Users handling model
    /// </summary>
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        /// <summary>
        ///  Graphs owned by user
        /// </summary>
        public virtual IList<GraphModel> Graphs { get; set; }

        public virtual Verification Verification { get; set; }

        public User()
        {
            Graphs = new List<GraphModel>();

        }
    }
}
