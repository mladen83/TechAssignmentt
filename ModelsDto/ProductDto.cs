namespace ModelsDto
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public List<SalesDto> ProductSales { get; set; } = new List<SalesDto>();
    }
}
