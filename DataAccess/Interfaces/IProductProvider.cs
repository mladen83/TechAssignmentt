using DataAccessLibrary.Models;

namespace DataAccessLibrary.Interfaces
{
    public interface IProductProvider
    {
        List<Product> GetAllProducts();
    }
}
