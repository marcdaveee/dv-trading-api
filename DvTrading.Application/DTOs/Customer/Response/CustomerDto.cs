namespace DvTrading.Application.DTOs.Customer.Response
{
    public class CustomerDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string? ContactNo { get; set; }

        public string? Email { get; set; }
    }
}
