using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PhoneService_API.Models;

namespace PhoneService_API.Dtos
{
    public class ClientReadDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int Phone { get; set; }

        public string Email { get; set; }

        public ICollection<RepairReadWithoutClient> Repairs { get; set; } = new List<RepairReadWithoutClient>();
    }
}
