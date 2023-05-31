using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Models;
using Implementation.Interfaces;
using ModelsDto;

namespace Implementation
{
    public class CityService : ICity
    {
        private readonly ICityProvider _cityProvider;

        public CityService(ICityProvider cityProvider)
        {
            _cityProvider = cityProvider;
        }

        public List<CityDto> GetAllCities()
        {
            List<CityDto> results = new();

            List<City> cities = _cityProvider.GetAllCities();

            foreach (City c in cities) 
            {
                CityDto dto = new()
                {
                    Id = c.Id,
                    Name = c.Name
                };
                results.Add(dto);
            }
            return results;
        }

        public int GetSumOfYearsSalesPerCity(int year, Guid cityId)
        {
            return _cityProvider.GetSumOfYearsSalesPerCity(year, cityId);
        }
    }
}
