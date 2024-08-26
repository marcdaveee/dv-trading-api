using System.ComponentModel.DataAnnotations;

namespace dv_trading_api.Dtos.Customer
{
    public class CreateCustomerDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [MinLength(11)]
        public string? ContactNo { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
    }
}
