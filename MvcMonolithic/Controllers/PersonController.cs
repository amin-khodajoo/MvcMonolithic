using Microsoft.AspNetCore.Mvc;
using MvcMonolithic.ApplicationServices.Contracts;

namespace MvcMonolithic.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonApplicationService _personApplicationService;

        public PersonController(IPersonApplicationService personApplicationService)
        {
            _personApplicationService = personApplicationService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _personApplicationService.GetAllPerson();
            return View(result);
        }
    }
}
