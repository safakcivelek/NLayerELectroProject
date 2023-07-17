using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs.Concert;
using NLayer.Core.Services;
using NLayer.Core.Utilities.Results.ComplexTypes;
using NLayer.Service.OtherServices.Abstract;
using NLayer.Web.Models;

namespace NLayer.Web.Controllers
{
    /* 
     * Not: Route Attribute'sini pasife aldım çünkü Home/Products sayfasında azalan artan veya 6'şarlı, 12şerli gibi sıralamalarda sayfa hata alıyor.
     * Bu hatanın Nedeni : Product view sayfasına yazdığım JQuery kodlarının içerisindeki şu yönlendirmeden kaynaklı =>
     * => window.location.href = "/Home/Products"
    */
    // Eğer Controller üzerinde bir Route eklenirse, tüm actioanlara Route bilgisi geçilmesi gerekir.
    //[Route("/")]
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IMailService _mailService;

        public HomeController(ICategoryService categoryService, IProductService productService, IMailService mailService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _mailService = mailService;
        }

        //[Route("index")]
        //[Route("anasayfa")]
        //[Route("")]
        [HttpGet]       
        public async Task<IActionResult> Index() // Burası Anasayfa
        {
            var productsWithCategory = await _productService.GetLastProductsAsync(3);
            var newProducts = await _productService.GetLastProductsAsync(5);
            var categories = await _categoryService.GetAllByNonDeletedAndActiveAsync();
            var bestSellersProducts = _productService.GetBestSellers(5);
            var trendProducts = await _productService.GetTrendProductsAsync(24);
            

            if (productsWithCategory.ResultStatus == ResultStatus.Success &&
                newProducts.ResultStatus == ResultStatus.Success &&
                categories.ResultStatus == ResultStatus.Success &&
                bestSellersProducts.ResultStatus == ResultStatus.Success &&
                trendProducts.ResultStatus == ResultStatus.Success)
            {
                return View(new HomeIndexViewModel
                {
                    ProductsWithCategory = productsWithCategory.Data,
                    NewProducts = newProducts.Data,
                    Categories = categories.Data,
                    BestSellersProducts = bestSellersProducts.Data,
                    TrendProducts = trendProducts.Data,

                });
            }
            return NotFound();            
        }
      
        [Route("Home/Products")]
        [Route("Home/Products/{categoryId}")]
        [HttpGet]        
        public async Task<ActionResult> Products(int? categoryId, int currentPage = 1, int pageSize = 6, bool isAscending = true)
        {
            var productsResult = await (categoryId == null
                ? _productService.GetAllByPagingAsync(null, currentPage, pageSize,isAscending)
                : _productService.GetAllByPagingAsync(categoryId.Value, currentPage, pageSize, isAscending));

            if (productsResult.ResultStatus == ResultStatus.Success)
            {
                // Burada ViewModel değilde Dto dönsem sorun çıkarmı?
                    
                return View(new HomeProductsViewModel
                {
                    Products = productsResult.Data
                });
            }
            return NotFound();
        }

        //[Route("hakkimizda")]
        //[Route("hakkinda")]
        [HttpGet]
        public IActionResult About()
        {
            //throw new Exception("Hata!");
            return View();
        }

        //[Route("iletisim")]
        [HttpGet]
        public IActionResult Contact()
        {
            //throw new NullReferenceException();
            return View();
        }

        //[Route("iletisim")]
        [HttpPost]
        public IActionResult Contact(EmailSendDto emailSendDto)
        {
            if (ModelState.IsValid)
            {
                var result = _mailService.SendContactEmail(emailSendDto);
                ViewData["Message"] = $"{result.Message}";
                return View();
            }
            return View(emailSendDto);
        }        
    }
}