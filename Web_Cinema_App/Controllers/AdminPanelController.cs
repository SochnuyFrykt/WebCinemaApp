using Microsoft.AspNetCore.Mvc;
using Web_Cinema_App.Entities;

namespace Web_Cinema_App.Controllers
{
    public class AdminPanelController : Controller
    {
        public IActionResult AdminPanelView() => View();
    }
}
