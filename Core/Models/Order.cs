using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Order : Basemodel
    {
        public DateTime OrderDate { get; set; }
        public string? Status { get; set; } 

        public string? ChemistId { get; set; }
        public ApplicationUser? Chemist { get; set; }

        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}
