using Microsoft.AspNetCore.Mvc;
using MVC_project.Models;

namespace MVC_project.Controllers
{
    public class ViewController : Controller
    {
        public IActionResult View()
        {
            var model = new Student { Id = 1, Name = "John", Surname = "Doe", Status = "отчислен" };
            return View(model);
        }
    }
}