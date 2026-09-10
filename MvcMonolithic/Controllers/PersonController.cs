using Microsoft.AspNetCore.Mvc;
using MvcMonolithic.ApplicationServices.Contracts;

namespace MvcMonolithic.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonApplicationService _personApplicationService;

        #region [- Ctor -]
        public PersonController(IPersonApplicationService personApplicationService)
        {
            _personApplicationService = personApplicationService;
        }
        #endregion

        #region [- Index() -]
        public async Task<IActionResult> Index()
        {
            var result = await _personApplicationService.GetAllPerson();
            return View(result);
        }
        #endregion

        #region [- Create() -]
        public IActionResult Create() 
        {
            return View(); 
        }
        #endregion
    }
}
