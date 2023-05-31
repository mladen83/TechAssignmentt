namespace ModelsDto
{
    public class SalesDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public decimal PricePerPiece { get; set; }
        public int Quantity { get; set; }
        public DateTime? DateOfSale { get; set; }
        public ProductDto SaleProductDto { get; set; } = new ProductDto();
    }
}
