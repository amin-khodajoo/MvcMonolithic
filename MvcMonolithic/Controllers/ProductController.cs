using Microsoft.AspNetCore.Mvc;
using MvcMonolithic.ApplicationServices;
using MvcMonolithic.ApplicationServices.Contracts;
using MvcMonolithic.ApplicationServices.Dtos;

namespace MvcMonolithic.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApplicationService _productApplicationService;

        #region [- Ctor -]
        public ProductController(IProductApplicationService productApplicationService)
        {
            _productApplicationService = productApplicationService;
        }
        #endregion

        #region [- Index() -]
        public async Task<IActionResult> Index()
        {
            var result = await _productApplicationService.GetAllProduct();
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
        public async Task<IActionResult> Create(PostProductDto postProductDto)
        {
            if (ModelState.IsValid)
            {
                await _productApplicationService.Post(postProductDto);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(postProductDto);
            }
        }
        #endregion

        #region [- Edit() -]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productApplicationService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PutProductDto putProductDto)
        {
            if (ModelState.IsValid)
            {
                await _productApplicationService.Put(putProductDto);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(putProductDto);
            }
        }
        #endregion
    }
}
