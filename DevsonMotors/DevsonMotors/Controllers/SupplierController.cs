using Microsoft.AspNetCore.Mvc;

namespace DevsonMotors.Controllers
{
    public class SupplierController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
