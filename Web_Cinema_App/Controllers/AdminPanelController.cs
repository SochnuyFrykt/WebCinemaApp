using Microsoft.AspNetCore.Mvc;
using Web_Cinema_App.Entities;

namespace Web_Cinema_App.Controllers
{
    public class AdminPanelController : Controller
    {
        public IActionResult AdminPanelView()
        {
            DataContext dataContext = new DataContext();

            var filmController = new FilmController();
            ViewData["Film"] = filmController.Film;

            var cinemaController = new CinemaModelsController(dataContext);
            ViewData["Cinema"] = cinemaController._context.Cinema.ToList();

            return View();
        }
    }
}
