using System;
using System.ComponentModel.DataAnnotations;

namespace PhoneService_API.Dtos
{
    public class RepairReadDto
    {
        public int Id { get; set; }

        public int Warranty { get; set; }

        public bool WarrantyIsActive => WarrantyDate > DateTime.Now;

        public string Description { get; set; }

        public bool DoneAttr { get; set; }

        public DateTime CompletionDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime WarrantyDate { get; set; }

        public ClientReadWithoutRepairsDto Client { get; set; }

        public ProductReadDto Product { get; set; }

        public int Price { get; set; }
    }
}