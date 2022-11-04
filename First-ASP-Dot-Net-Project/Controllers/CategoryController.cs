using Microsoft.AspNetCore.Mvc;

namespace First_ASP_Dot_Net_Project.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
