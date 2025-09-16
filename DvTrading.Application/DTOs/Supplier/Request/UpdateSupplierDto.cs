using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace DvTrading.Application.DTOs.Supplier.Request
{
    public class UpdateSupplierDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MinLength(1)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MinLength(1)]
        public string Address { get; set; } = string.Empty;

        [MaxLength(11)]
        public string? ContactNo { get; set; } = string.Empty;

        [EmailAddress]
        public string? Email { get; set; } = string.Empty;
    }
}
