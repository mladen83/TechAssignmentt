using DataAccessLibrary.DataAccess;
using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DataAccessLibrary.Providers
{
    public class SaleProvider : ISalesProvider
    {
        public List<Sale> GetAllSalesForCustomer(Guid customerId)
        {
            using (PeopleContext context = new())
            {
                List<Sale> customerSales = context
                    .Sales.Where(x => x.CustomerId == customerId)
                    .Include(p => p.SaleProduct)
                    .ToList();
                return customerSales;
            }
        }

        public DateTime? GetEarliestSaleDate()
        {
            using (PeopleContext context = new())
            {
                List<DateTime> saleDates = (from d in context.Sales select d.DateOfSale).ToList();
                if (saleDates.Count > 0)
                {
                    return saleDates.Min();
                }
                return null;
            }
        }

        public int GetSumOfYearlySales(int year)
        {
            using (PeopleContext context = new())
            {
                return context.Sales.Count(x => x.DateOfSale.Year == year);
            }
        }
    }
}
