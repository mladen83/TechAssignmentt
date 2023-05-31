using Implementation.Interfaces;
using ModelsDto;

namespace Api
{
    public class MyMethod : BackgroundService
    {
        private readonly ICustomer _customerClient;
        private readonly ISales _salesClient;
        private readonly IProduct _productClient;
        private readonly ICity _cityClient;
        private readonly ILogger<MyMethod> _logger;

        public MyMethod(
            ICustomer customerClient,
            ISales saleClient,
            IProduct productClient,
            ICity cityClient,
            ILogger<MyMethod> logger
            )
        {
            _customerClient = customerClient;
            _salesClient = saleClient;
            _productClient = productClient;
            _cityClient = cityClient;
            _logger = logger;
        }

        protected override Task ExecuteAsync(CancellationToken cancellationToken)
        {
            try
            {
                List<CustomerDto> customerDtos = _customerClient.GetAllCustomers();

                foreach (CustomerDto customerDto in customerDtos)
                {
                    List<SalesDto> customerSales = _salesClient.GetAllSalesForCustomer(customerDto.Id);

                    List<ProductDto> products = customerSales.Select(x => x.SaleProductDto).ToList(); // Implement logic for geting products
                    foreach (ProductDto product in products)
                    {
                        int clientSalesQuantity = customerSales.Count(x => x.ProductId == product.Id); // Implement logic for getting total quanity per client/per product
                        decimal clientSalesTotalAmount = customerSales.Where(x => x.ProductId == product.Id).Sum(s => s.PricePerPiece); // Implement logic for getting total sales amount per client/per product

                        var resultStr = $"For the client {customerDto.Name} stats are: {product.Name} - sold pieces: {clientSalesQuantity},  for the Total amount: {clientSalesTotalAmount}.";

                        _logger.LogInformation(resultStr);
                    }
                }

                List<ProductDto> allProducts = _productClient.GetAllProducts();

                foreach (ProductDto product in allProducts)
                {
                    decimal avgSalePrice = product.ProductSales.Average(x => x.PricePerPiece);
                    string avgSalePriceLogStr = $"For product {product.Name} average sale price is {avgSalePrice}.";

                    _logger.LogInformation(avgSalePriceLogStr);
                }

                DateTime? earliestSaleDate = _salesClient.GetEarliestSaleDate();

                if (!earliestSaleDate.HasValue)
                {
                    string logStr = $"There are no sales saved!";
                    _logger.LogInformation(logStr);
                }
                else
                {
                    List<CityDto> cities = _cityClient.GetAllCities();

                    int salesYearStart = earliestSaleDate.Value.Year; //get first year when sales started

                    for (int year = salesYearStart; year <= DateTime.Now.Year; year++)
                    {
                        int sumOfYearsSales = _salesClient.GetSumOfYearlySales(year); // sumOfYearSales

                        string logStr = $"In year {salesYearStart} we had total amount of {sumOfYearsSales} sales.";
                        _logger.LogInformation(logStr);

                        // No need to fetch data per city if there are no sales at all for current year.
                        if (sumOfYearsSales > 0)
                        {
                            foreach (var city in cities)
                            {
                                int sumOfYearsSalesPerCity = _cityClient.GetSumOfYearsSalesPerCity(year, city.Id);
                                string resultPerCity = $"In year {year} in city {city.Name} we had total amount of {sumOfYearsSalesPerCity} sales.";
                                _logger.LogInformation(resultPerCity);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return Task.CompletedTask;
        }
    }
}
