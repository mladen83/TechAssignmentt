using DataAccessLibrary.Models;

namespace DataAccessLibrary.Interfaces
{
    public interface ISalesProvider
    {
        List<Sale> GetAllSalesForCustomer(Guid customerId);
        DateTime? GetEarliestSaleDate();
        int GetSumOfYearlySales(int year);
    }
}
