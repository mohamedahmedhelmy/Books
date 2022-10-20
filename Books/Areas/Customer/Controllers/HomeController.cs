using DataAccess.Repository.IRepository;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Books.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var products = _unitOfWork.Product.GetAll(includeProperties: "Category,CoverType");
            return View(products);
        }
        public IActionResult Details(int productId)
        {
            var shoppingCart = new ShoppingCart
            {
                Product = _unitOfWork.Product.GetFirstOrDefault(p => p.Id == productId, includeProperties: "Category,CoverType"),
                ProductId = productId,
                Count = 1
            };
            return View(shoppingCart);
        }   
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Details(ShoppingCart shoppingCart)
        {
            var claimsIdntity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdntity.FindFirst(ClaimTypes.NameIdentifier);
            shoppingCart.ApplicationUserId = claim.Value;
            var cartFromDB = _unitOfWork.ShoppingCart
                 .GetFirstOrDefault(c=>c.ApplicationUserId==claim.Value && c.ProductId==shoppingCart.ProductId);
            if (cartFromDB != null)
            {
                _unitOfWork.ShoppingCart.InCrementCount(cartFromDB, shoppingCart.Count);
            }
            else
            {
                _unitOfWork.ShoppingCart.Add(shoppingCart);
            }
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
