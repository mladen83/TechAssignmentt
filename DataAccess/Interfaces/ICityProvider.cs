using DataAccessLibrary.Models;

namespace DataAccessLibrary.Interfaces
{
    public  interface ICityProvider
    {
        List<City> GetAllCities();
        int GetSumOfYearsSalesPerCity(int year, Guid cityId);
    }
}
