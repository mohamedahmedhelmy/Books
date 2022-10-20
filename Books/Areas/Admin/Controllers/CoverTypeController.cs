using DataAccess.Repository.IRepository;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utility;

namespace Books.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var CoverTypeList = _unitOfWork.CoverType.GetAll();
            return View(CoverTypeList);
        }
       
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoverType CoverType)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Add(CoverType);
                _unitOfWork.Save();
                TempData["success"] = "CoverType Created successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(CoverType);
        }
        public IActionResult Edit(int? Id)
        {
            if (Id ==null ||Id==0)
            {
                return NotFound();
            }
            var obj=_unitOfWork.CoverType.GetFirstOrDefault(x => x.Id == Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverType CoverType)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Update(CoverType);
                _unitOfWork.Save();
                TempData["success"] = "CoverType updated successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(CoverType);
        }
       public IActionResult Delete(int? Id)
        {
            if (Id==null || Id==0)
            {
                return NotFound();
            }
            var obj=_unitOfWork.CoverType.GetFirstOrDefault(c=>c.Id == Id);
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
            var obj =_unitOfWork.CoverType.GetFirstOrDefault(c=>c.Id==Id);
            if (obj==null)
            {
                return NotFound();
            }
            _unitOfWork.CoverType.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "CoverType Deleted successfully";
           return RedirectToAction(nameof(Index));
        }
    }
}
