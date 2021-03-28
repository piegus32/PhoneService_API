using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhoneService_API.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        [Required]
        [Phone]
        public int Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public List<Repair> Repairs { get; set; }
    }
}
