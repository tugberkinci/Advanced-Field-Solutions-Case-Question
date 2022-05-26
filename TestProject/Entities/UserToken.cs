using System;
using System.Collections.Generic;

namespace TestProject.Entities
{
    public partial class UserToken
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Token { get; set; } = null!;
        public string Secret { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
    }
}
