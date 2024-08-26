namespace dv_trading_api.Dtos.Supplier
{
    public class SupplierDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string? ContactNo { get; set; } = string.Empty;

        public string? Email { get; set; } = string.Empty;
    }
}
