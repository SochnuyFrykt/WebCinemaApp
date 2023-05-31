using Microsoft.AspNetCore.Mvc;

namespace Web_Cinema_App.Controllers
{
    public class GoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
