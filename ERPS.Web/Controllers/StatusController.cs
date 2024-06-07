using Microsoft.AspNetCore.Mvc;

namespace ERPS.Web.Controllers
{
    public class StatusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit(string id)
        {
            return new ContentResult { Content = id };
        }
    }
}
