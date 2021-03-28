﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using PhoneService_API.Models;

namespace PhoneService_API.Dtos
{
    public class RepairCreateDto
    {
        [Required]
        public int Warranty { get; set; }

        [Required]
        public string Description { get; set; }

        public int Price { get; set; }

        [ForeignKey(nameof(Client))]
        public int ClientId { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

    }
}
