using System.ComponentModel.DataAnnotations;

namespace PhoneService_API.Dtos
{
    public class ProductUpdateDto
    {
        [Required] public string Brand { get; set; }

        [Required] public string Model { get; set; }

        [Required] public string Color { get; set; }
    }
}