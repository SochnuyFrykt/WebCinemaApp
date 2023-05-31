using Microsoft.AspNetCore.Mvc;

namespace Web_Cinema_App.Controllers
{
    public class AdminPanelController : Controller
    {
        public IActionResult AdminPanelView() => View();
    }
}
