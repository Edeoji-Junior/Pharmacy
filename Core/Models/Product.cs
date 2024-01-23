using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Product : Basemodel
    {
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string? BatchNumber { get; set; }

        // Foreign Key for Chemist (ApplicationUser)
        public string? ChemistId { get; set; }
        public virtual ApplicationUser? Chemist { get; set; }
        public string? DosageInformation { get; set; }

        // Foreign Key for Category
        public int CategoryId { get; set; }

        [Display(Name = "Category")]
        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }

        // Foreign Key for Manufacturer
        public int ManufacturerId { get; set; }

        [Display(Name = "Manufacturer")]
        [ForeignKey("ManufacturerId")]
        public virtual Manufacturer? Manufacturer { get; set; }

        // Dosage information
        public string? Dosage { get; set; }
    }
}
