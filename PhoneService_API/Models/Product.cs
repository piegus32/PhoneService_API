using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhoneService_API.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string Color { get; set; }

        public Repair Repair { get; set; }
    }
}