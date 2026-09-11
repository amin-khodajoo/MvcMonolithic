using Microsoft.AspNetCore.Mvc;
using MvcMonolithic.ApplicationServices.Contracts;
using MvcMonolithic.ApplicationServices.Dtos;

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
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostPersonDto postPersonDto)
        {
            if (ModelState.IsValid)
            {
                await _personApplicationService.Post(postPersonDto);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(postPersonDto);
            }
        }
        #endregion

        #region [- Edit() -]
        [HttpGet]
        public async Task<IActionResult> Edit(int id) 
        { 
            var person = await _personApplicationService.GetById(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PutPersonDto putPersonDto)
        {
            if (ModelState.IsValid)
            {
                await _personApplicationService.Put(putPersonDto);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(putPersonDto);
            }
        }
        #endregion
    }
}
