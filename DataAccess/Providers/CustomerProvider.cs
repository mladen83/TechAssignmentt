using DataAccessLibrary.DataAccess;
using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Models;

namespace DataAccessLibrary.Providers
{
    public class CustomerProvider : ICustomerProvider
    {
        public List<Customer> GetAllCustomers()
        {
            using (PeopleContext context = new())
            {
                return context.Customers.ToList();
            }
        }
    }
}
