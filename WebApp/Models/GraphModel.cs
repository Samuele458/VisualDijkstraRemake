

using Newtonsoft.Json;

namespace WebApp.Models
{
    public class GraphModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Data { get; set; }


        public int UserId { get; set; }

        [JsonIgnore]
        public User User { get; set; }
    }
}
