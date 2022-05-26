using Newtonsoft.Json;

namespace TestProject.Models
{
    public class UserModel
    {
        public string? UserMail { get; set; } 

        [JsonIgnore]
        public DateTime? CreatedAt { get; set; }
    }
}
