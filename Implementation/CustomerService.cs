using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Models;
using Implementation.Interfaces;
using ModelsDto;

namespace Implementation
{
    public class CustomerService : ICustomer
    {
        private readonly ICustomerProvider _provider;
        public CustomerService(ICustomerProvider provider)
        {
            _provider = provider;
        }
        
        public List<CustomerDto> GetAllCustomers()
        {
            List<Customer> dbCustomers = _provider.GetAllCustomers();

            List<CustomerDto> customerDtosResult = new();

            foreach (Customer dbCustomer in dbCustomers)
            {
                CustomerDto dto = new()
                {
                    Id = dbCustomer.Id,
                    Name = dbCustomer.Name,
                    CityId = dbCustomer.CityId
                };
                customerDtosResult.Add(dto);
            }

            return customerDtosResult;
        }
    }
}
