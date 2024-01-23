using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class OrderItem:Basemodel
    {
        public int Quantity { get; set; }

        // Foreign Key for Product
        public int ProductId { get; set; }

        [Display(Name = "Product")]
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        // Foreign Key for Order
        public int OrderId { get; set; }

        [Display(Name = "Order")]
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
    }
}
