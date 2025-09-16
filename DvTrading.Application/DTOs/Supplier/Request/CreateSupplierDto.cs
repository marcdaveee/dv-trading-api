using System.ComponentModel.DataAnnotations;

namespace DvTrading.Application.DTOs.Supplier.Request
{
    public class CreateSupplierDto
    {
        [Required]
        [MinLength(1)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MinLength(1)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MinLength(1)]
        public string Address { get; set; } = string.Empty;

        [MinLength(11)]
        public string? ContactNo { get; set; } = string.Empty;

        [EmailAddress]
        public string? Email { get; set; } = string.Empty;
    }
}
