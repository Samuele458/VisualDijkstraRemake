using Newtonsoft.Json;
using System;

namespace WebApp.Models
{
    /// <summary>
    ///  Graph model used in Entity Framework, in order to handle graphs
    /// </summary>
    public class GraphModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        ///  Graph data, encoded in json format
        /// </summary>
        public string Data { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }


        /// <summary>
        ///  Owner user id
        /// </summary>
        public int UserId { get; set; }


        /// <summary>
        ///  Reference to owner user
        /// </summary>
        [JsonIgnore]
        public User User { get; set; }
    }
}
