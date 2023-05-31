using DataAccessLibrary.Models;

namespace DataAccessLibrary.Interfaces
{
    public interface ICustomerProvider
    {
        List<Customer> GetAllCustomers();
    }
}
