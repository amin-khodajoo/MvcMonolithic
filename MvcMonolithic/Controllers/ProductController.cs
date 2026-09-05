using Microsoft.AspNetCore.Mvc;
using MvcMonolithic.ApplicationServices.Contracts;

namespace MvcMonolithic.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApplicationService _productApplicationService;

        public ProductController(IProductApplicationService productApplicationService)
        {
            _productApplicationService = productApplicationService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _productApplicationService.GetAllProduct();
            return View(result);
        }
    }
}
