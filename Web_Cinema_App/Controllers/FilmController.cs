﻿using Microsoft.AspNetCore.Mvc;
using Web_Cinema_App.Models;

namespace Web_Cinema_App.Controllers
{
    public class FilmController : Controller
    {
        public List<FilmModel> Film { get; set; } = new List<FilmModel>
            {
                new FilmModel() { Id = 1, Name = "Бетмен", Description = "skd;fjbnskdjfbnsdfklbnsdf", Genre = "Боевик" },
                new FilmModel() { Id = 2, Name = "Бетмен", Description = "skd;fjbnskdjfbnsdfklbnsdf", Genre = "Боевик" },
                new FilmModel() { Id = 1, Name = "Бетмен", Description = "skd;fjbnskdjfbnsdfklbnsdf", Genre = "Боевик" },
            };

        [HttpGet]
        public IActionResult FilmView()
        {
            return View(Film);
        }
    }
}
