using DevsonMotors.Domains;
using DevsonMotors.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using static DevsonMotors.Domains.CustomerService;
using static DevsonMotors.Domains.ProductService;

namespace DevsonMotors.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        ICustomersService _customerService;
        public CustomerController(ICustomersService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllCustomers()
        {
            try
            {
                var customer = _customerService.GetCustomerList();
                if (customer == null) return NotFound();
                return Ok(customer);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("[action]/id")]
        public IActionResult GetCustomertById(int CustomerId)
        {
            try
            {
                var customer = _customerService.GetCustomerById(CustomerId);
                if (customer == null) return NotFound();
                return Ok(customer);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult SaveCustomer(Customer customer)
        {
            try
            {
                var model = _customerService.SaveCustomer(customer);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
