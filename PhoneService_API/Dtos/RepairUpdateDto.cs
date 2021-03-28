using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using PhoneService_API.Models;

namespace PhoneService_API.Dtos
{
    public class RepairUpdateDto
    {
        public int Warranty { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime WarrantyDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime CompletionDate { get; set; }

        public bool DoneAttr { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

    }
}
