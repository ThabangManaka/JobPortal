using Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class JobPostController : Controller
    {

        private readonly IUnitOfWork uow;

        public IActionResult Index()
        {
            return View();
        }
    }
}
