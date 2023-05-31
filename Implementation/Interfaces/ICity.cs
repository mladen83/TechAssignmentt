using ModelsDto;

namespace Implementation.Interfaces
{
    public interface ICity
    {
        List<CityDto> GetAllCities();

        int GetSumOfYearsSalesPerCity(int year, Guid cityId);
    }
}
