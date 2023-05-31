using ModelsDto;

namespace Implementation.Interfaces
{
    public interface ISales
    {
        List<SalesDto> GetAllSalesForCustomer(Guid customerId);
        DateTime? GetEarliestSaleDate();
        int GetSumOfYearlySales(int year);
    }
}
