using DevsonMotors.Models;
using DevsonMotors.ViewModels;
using Microsoft.Identity.Client;

namespace DevsonMotors.Domains
{
    public class CustomerService
    {
        public class CustomersService : ICustomersService
        {
            private InventoryContext _context;
            public CustomersService(InventoryContext context)
            {
                _context = context;
            }

            public Customer GetCustomerById(int CustomerId)
            {
                Customer customer;
                try
                {
                    customer = _context.Find<Customer>(CustomerId);
                }
                catch (Exception)
                {
                    throw;
                }
                return customer;
            }

            List<Customer> GetCustomerList()
            {
                List<Customer> customerList;
                try
                {
                    customerList = _context.Set<Customer>().ToList();
                }
                catch (Exception)
                {
                    throw;
                }
                return customerList;
            }

            List<Customer> ICustomersService.GetCustomerList()
            {
                List<Customer> customerList;
                try
                {
                    customerList = _context.Set<Customer>().ToList();
                }
                catch (Exception)
                {
                    throw;
                }
                return customerList;
            }

            ResponseModel ICustomersService.SaveCustomer(Customer customer)
            {

                ResponseModel responseModel = new ResponseModel();
                try
                {
                    int CustomerId = 0;
                    List<Customer> _tempList = GetCustomerList();
                    Customer matchingCustomer = null;
                    foreach (Customer customer1 in _tempList)
                    {
                        if (customer1.CustomerName == customer.CustomerName)
                        {
                            matchingCustomer = customer1;
                            CustomerId = (int)customer1.CustomerId;
                            break;
                        }
                    }

                    if (matchingCustomer == null)
                    {
                        /* _tempAdd.ProductName = product.ProductName;
                         _tempAdd.Description = product.Description;
                         _tempAdd.Price = product.Price;
                         _tempAdd.QuintityInStock = product.QuintityInStock;*/
                        _context.Add<Customer>(customer);
                        responseModel.Message = "Customer Inserted Successfully";
                    }
                    else
                    {
                        Customer _tempUpdate = GetCustomerById(CustomerId);
                       /* _tempUpdate.QuintityInStock = _tempUpdate.QuintityInStock + product.QuintityInStock;*/
                        _context.Update<Customer>(_tempUpdate);
                        responseModel.Message = "Customer Update Successfully";
                    }
                    _context.SaveChanges();
                    responseModel.IsSuccess = true;
                }
                catch (Exception ex)
                {
                    responseModel.IsSuccess = false;
                    responseModel.Message = "Error : " + ex.Message;
                }
                return responseModel;
            }
        }
    }
}
