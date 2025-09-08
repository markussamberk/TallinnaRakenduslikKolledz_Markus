using Microsoft.AspNetCore.Mvc;

namespace TallinnaRakenduslikKolledz.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
