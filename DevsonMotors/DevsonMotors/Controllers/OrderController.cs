using Microsoft.AspNetCore.Mvc;

namespace DevsonMotors.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
