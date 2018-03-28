using Microsoft.AspNetCore.Mvc;

namespace IdeaApi.Controllers
{
    public class IndexController : Controller
    {
        [Route("")]
        [Route("/index")]
        [Route("/idea")]
        [Route("/idea/{id}")]
        public IActionResult Index()
        {
            return View("React");
        }
    }
}