using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PhoneService_API.Dtos;

namespace PhoneService_API.Models
{
    public class Repair
    {
        public ClientReadWithoutRepairsDto Client = new ClientReadWithoutRepairsDto();

        public ProductReadDto Product = new ProductReadDto();

        [Key] public int Id { get; set; }

        [Required] public int Warranty { get; set; }

        public bool WarrantyIsActive => WarrantyDate > DateTime.Now;

        [DataType(DataType.Date)]
        public DateTime? WarrantyDate { get; set; } = null;

        [Required] public string Description { get; set; }

        public bool DoneAttr { get; set; } = false;

        [DataType(DataType.Date)]
        public DateTime? CompletionDate { get; set; } = null;

        [ForeignKey(nameof(Client))] public int ClientId { get; set; }

        [ForeignKey(nameof(Product))] public int ProductId { get; set; }

        public int Price { get; set; }
    }
}