using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Manufacturer : Basemodel
    {
        // Navigation property for products
        public ICollection<Product>? Products { get; set; }
    }
}
