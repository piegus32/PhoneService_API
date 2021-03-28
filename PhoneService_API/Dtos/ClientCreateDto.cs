using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PhoneService_API.Models;

namespace PhoneService_API.Dtos
{
    public class ClientCreateDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        [Required]
        [Phone]
        public int Phone { get; set; }

        public string Email { get; set; }
    }
}
