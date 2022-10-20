using DataAccess.Repository.IRepository;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utility;

namespace Books.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var categoryList = _unitOfWork.Category.GetAll();
            return View(categoryList);
        }
       
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(category);
                _unitOfWork.Save();
                TempData["success"] = "Category Created successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
        public IActionResult Edit(int? Id)
        {
            if (Id ==null ||Id==0)
            {
                return NotFound();
            }
            var obj=_unitOfWork.Category.GetFirstOrDefault(x => x.Id == Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(category);
                _unitOfWork.Save();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
       public IActionResult Delete(int? Id)
        {
            if (Id==null || Id==0)
            {
                return NotFound();
            }
            var obj=_unitOfWork.Category.GetFirstOrDefault(c=>c.Id == Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        } 
       [HttpPost,ActionName("Delete")]
       [ValidateAntiForgeryToken]
       public IActionResult DeletePOST(int? Id)
        {
            var obj =_unitOfWork.Category.GetFirstOrDefault(c=>c.Id==Id);
            if (obj==null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category Deleted successfully";
           return RedirectToAction(nameof(Index));
        }
    }
}
