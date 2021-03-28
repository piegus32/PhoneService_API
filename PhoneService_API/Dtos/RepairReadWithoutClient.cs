using System;
using System.ComponentModel.DataAnnotations;

namespace PhoneService_API.Dtos
{
    public class RepairReadWithoutClient
    {
        public int Id { get; set; }

        public bool WarrantyIsActive => WarrantyDate > DateTime.Now;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CompletionDate { get; set; }

        public DateTime WarrantyDate { get; set; }

        public string Description { get; set; }

        public ProductReadDto Product { get; set; }
    }
}