using System.Text.Json.Serialization;

namespace WebApp.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }



        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public string Password { get; set; }
    }
}
