using DataAccessLibrary.DataAccess;
using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLibrary.Providers
{
    public class ProductProvider : IProductProvider
    {
        public List<Product> GetAllProducts()
        {
            using (PeopleContext context = new())
            {
                List<Product> dbProducts = context
                    .Products
                    .Include(p => p.ProductSales)
                    .ToList();

                return dbProducts;
            }
        }
    }
}
