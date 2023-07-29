using Microsoft.AspNetCore.Mvc;

namespace Thakshilawa.Api.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
      

    }
}
