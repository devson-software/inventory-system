using DevsonMotors.Models;
using DevsonMotors.ViewModels;

namespace DevsonMotors.Domains
{
    public interface ICustomersService
    {
        List<Customer> GetCustomerList();
        Customer GetCustomerById(int CustomerId);
        ResponseModel SaveCustomer(Customer customer);

    }
}
