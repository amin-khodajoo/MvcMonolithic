using Microsoft.AspNetCore.Mvc;
using MvcMonolithic.ApplicationServices.Contracts;

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
        public IActionResult Create()
        {
            return View();
        }
        #endregion
    }
}
