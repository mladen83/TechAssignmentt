using DataAccessLibrary.DataAccess;
using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Models;

namespace DataAccessLibrary.Providers
{
    public class CityProvider : ICityProvider
    {
        public List<City> GetAllCities()
        {
            using (PeopleContext context = new())
            {
                return context.Cities.ToList();
            }
        }

        public int GetSumOfYearsSalesPerCity(int year, Guid cityId)
        {
            using (PeopleContext context = new())
            {
                var result = from city in context.Cities
                             join customer in context.Customers on city.Id equals customer.CityId
                             join sale in context.Sales on customer.Id equals sale.CustomerId
                             where sale.DateOfSale.Year == year && city.Id == cityId
                             select sale.Id;

                return result.Count();
            }
        }
    }
}
