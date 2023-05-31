using ModelsDto;

namespace Implementation.Interfaces
{
    public interface ICustomer
    {
        List<CustomerDto> GetAllCustomers();
    }
}
