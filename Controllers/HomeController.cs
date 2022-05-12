using MyCollection.Data;
using Microsoft.AspNetCore.Mvc;

namespace MyCollection.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
