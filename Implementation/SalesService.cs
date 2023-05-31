using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Models;
using Implementation.Interfaces;
using ModelsDto;

namespace Implementation
{
    public class SalesService : ISales
    {
        private readonly ISalesProvider _provider;

        public SalesService(ISalesProvider salesProvider)
        {
            _provider = salesProvider;
        }
        public List<SalesDto> GetAllSalesForCustomer(Guid customerId)
        {
            List<SalesDto> dtoResults = new();

            List<Sale> dbSales = _provider.GetAllSalesForCustomer(customerId);

            foreach (Sale sale in dbSales) 
            {
                SalesDto dto = new()
                {
                    CustomerId = customerId,
                    DateOfSale = sale.DateOfSale,
                    Id = sale.Id,
                    PricePerPiece = sale.PricePerPiece,
                    ProductId = sale.ProductId,
                    Quantity = sale.Quantity,
                    SaleProductDto = new ProductDto() 
                    { 
                        Id = sale.SaleProduct.Id,
                        Name = sale.SaleProduct.Name
                    }
                };
                
                dtoResults.Add(dto);
            }

            return dtoResults;
        }

        public DateTime? GetEarliestSaleDate()
        {
            return _provider.GetEarliestSaleDate();
        }

        public int GetSumOfYearlySales(int year)
        {
            return _provider.GetSumOfYearlySales(year);
        }
    }
}
