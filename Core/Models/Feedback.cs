using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Feedback:Basemodel
    {
        public string? UserId { get; set; }  // Reference to the user providing feedback
        public string? Subject { get; set; }
        public string? Message { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation property for the user
        public ApplicationUser? User { get; set; }
    }
}
