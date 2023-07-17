using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Entities.Concert;
using NLayer.Core.Utilities.Results.ComplexTypes;
using NLayer.Repository.EntityFramework.Contexts;
using NLayer.Web.Helpers;
using NLayer.Web.Models.Cart;

namespace NLayer.Web.Controllers
{
    public class CartController : Controller
    {
        private ElectroDbContext _db;
        private UserManager<User> _userManager;
        public CartController(ElectroDbContext db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var user = _userManager.GetUserAsync(HttpContext.User).Result;
            Cart cart = HttpContext.Session.GetAsObject<Cart>("cart");
            if (user == null)
            {
                ViewData["user"] = null;
                return View(cart);
            }
            else
            {
                ViewData["user"] = user;
                return View(cart);
            }        
        }
        [HttpPost]
        public IActionResult AddToCart(int Id)
        {
            
            Cart cart = HttpContext.Session.GetAsObject<Cart>("cart");          
            if (cart == null)
            {
                cart = new Cart();
            }

            var product = _db.Products.FirstOrDefault(x => x.Id == Id);
            if (product != null)
            {
                cart.AddProduct(product, 1);
            }

            HttpContext.Session.SetToJson<Cart>("cart", cart);
            return RedirectToAction("Index", "cart");
        }
        public IActionResult RemoveFromCart(int Id)
        {
            Cart cart = HttpContext.Session.GetAsObject<Cart>("cart");
            if (cart == null)
            {
                cart = new Cart();
            }

            var product = _db.Products.FirstOrDefault(x => x.Id == Id);
            if (product != null)
            {
                cart.DeleteProduct(product);
            }

            HttpContext.Session.SetToJson<Cart>("cart", cart);
            return RedirectToAction("Index", "cart");
        }
        // Checkout kullanıcı Login olduktan sonrada gösterilebilir. [Authorize]
        [HttpGet]
        public IActionResult Checkout()
        {
            var user = _userManager.GetUserAsync(HttpContext.User).Result;
            if (user == null)
            {               
                return RedirectToAction("Index");                
            }
            return View(new ShippingDetails());
        }
        [HttpPost]
        public IActionResult Checkout(ShippingDetails entity)
        {         
            Cart cart = HttpContext.Session.GetAsObject<Cart>("cart");
            
            if (cart.CartLines.Count == 0)
            {
                ViewData["Message"] = "Sepetinizde ürün bulunmamaktadır!";                
            }
            else
            {
                if (ModelState.IsValid)
                {
                    // Siparişi veritabnına kaydet.
                    // Sepeti temizle.
                    SaveOrder(cart, entity);
                    cart.Clear();
                    HttpContext.Session.SetToJson<Cart>("cart", cart);
                    return View("Completed");
                }
                else
                {
                    return View(entity);
                }
            }   
            return NotFound();
        }
        public void SaveOrder(Cart cart, ShippingDetails entity)
        {
            var user = _userManager.GetUserAsync(HttpContext.User);
           // var user2 = _db.Orders.Where(i => i.UserName == User.Identity.Name);
            var order = new Order
            {
                UserId = user.Result.Id,
                UserName = user.Result.UserName,
                OrderNumber = "SN" + (new Random().Next(1111, 9999).ToString()),
                Status= OrderStatus.ReceivedOrder,
                Description = entity.Description,
                Total = cart.Total(),
                AddressTitle = entity.AddressTitle,
                Address = entity.Address,
                Country = entity.Country,
                City = entity.City,
                District = entity.District,
                PostalCode = entity.PostalCode,
                IsActive = false,                
                OrderDetails = new List<OrderDetail>(),                   
            };         
            
            foreach (var item in cart.CartLines)
            {
                var orderDetail = new OrderDetail
                {
                     Quantity= item.Quantity,
                     SubTotal=Convert.ToDouble(item.SubTotal),
                     Price=item.Product.Price,
                     ProductId=item.Product.Id,                               
                };
                order.OrderDetails.Add(orderDetail);
            }
            
            _db.Orders.Add(order);
            _db.SaveChanges();
        }
        public PartialViewResult CartSummary()
        {
            Cart cart = HttpContext.Session.GetAsObject<Cart>("cart");
            if (cart == null)
            {
                cart = new Cart();
            }
            HttpContext.Session.SetToJson<Cart>("cart", cart);
            return PartialView("_CartSummaryPartial", cart);
        }
    }
}
