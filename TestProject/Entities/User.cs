using System;
using System.Collections.Generic;

namespace TestProject.Entities
{
    public partial class User
    {
        public int Id { get; set; }
        public string UserMail { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
    }
}
