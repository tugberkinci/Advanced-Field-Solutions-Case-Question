

using Newtonsoft.Json;

namespace TestProject.Models
{
    public class UserTokenModel
    {
        public int UserId { get; set; }
        public string? Token { get; set; } 
        public string? Secret { get; set; } 

        [JsonIgnore]
        public DateTime? CreatedAt { get; set; }
    }
}
