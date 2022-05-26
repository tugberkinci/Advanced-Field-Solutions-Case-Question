using System;
using System.Collections.Generic;

namespace TestProject.Entities
{
    public partial class Transaction
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Input { get; set; } = null!;
        public string Output { get; set; } = null!;
    }
}
