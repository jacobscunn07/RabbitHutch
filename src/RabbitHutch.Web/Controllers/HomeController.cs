using Microsoft.AspNetCore.Mvc;

namespace RabbitHutch.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}