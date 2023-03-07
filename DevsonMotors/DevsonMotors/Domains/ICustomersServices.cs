using DevsonMotors.Models;
using DevsonMotors.ViewModels;

namespace DevsonMotors.Domains
{
    public interface ICustomersServices
    {
        ResponseModel SaveCustomer(Customer customer);
    }
}