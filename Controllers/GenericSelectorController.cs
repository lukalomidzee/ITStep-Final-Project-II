using CarRentalApplication.Interfaces;
using CarRentalApplication.Models.VMs.Selectors;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApplication.Controllers
{
    public abstract class GenericSelectorController<T, TValue> : Controller
    where T : class, ISelector<TValue>, new()
    {
        protected readonly IGenericSelectorService<T, TValue> _service;
        protected abstract string ControllerName { get; }
        protected abstract string DisplayName { get; }

        public GenericSelectorController(IGenericSelectorService<T, TValue> service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _service.GetAllAsync();

            if (response?.Data == null)
            {
                return View(new List<dynamic>());
            }

            var dynamicList = response.Data.Select(x => (dynamic)x).ToList();
            return View(dynamicList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TValue value)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.CreateAsync(value);
                if (result.Success == false)
                {
                    TempData["Error"] = result.Message;
                }
                else
                {
                    TempData["Success"] = "Created successfully";
                }
                return RedirectToAction(nameof(Index));
            }

            if (typeof(TValue) == typeof(int) || typeof(TValue) == typeof(float))
            {
                TempData["Error"] = "Couldn't create value. Value must be numeric";
            }
            else
            {
                TempData["Error"] = "Couldn't create value";
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _service.GetByIdAsync(id);
            if (!response.Success)
            {
                return NotFound();
            }

            var model = new SelectorViewModel
            {
                Id = response.Data.Id,
                Value = response.Data.Value,
                DisplayName = DisplayName,
                ValueType = typeof(TValue).Name
            };

            return View(model);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, SelectorViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var response = await _service.UpdateAsync(id, model.Value);
        //        if (!response.Success)
        //        {
        //            return NotFound();
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(model);
        //}

        //[HttpPost("EditConfirmed/{id}")/*, ActionName("Edit")*/]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> EditConfirmed(int id, TValue model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var response = await _service.UpdateAsync(id, model);
        //        if (!response.Success)
        //        {
        //            return NotFound();
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    //if (string.IsNullOrWhiteSpace(model))
        //    //    TempData["Error"] = "Value couldn't be empty";

        //    return RedirectToAction(nameof(Index));
        //}

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _service.GetByIdAsync(id);
            if (!response.Success)
            {
                return NotFound();
            }
            return View(response.Data);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        public override ViewResult View(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
            {
                viewName = ControllerContext.ActionDescriptor.ActionName;
            }

            // Use shared views for CRUD operations
            if (new[] { "Index", "Create", "Edit", "Delete" }.Contains(viewName))
            {
                viewName = $"~/Views/Shared/GenericSelector/{viewName}.cshtml";
            }

            ViewData["Title"] = DisplayName + (viewName switch
            {
                "Index" => " List",
                "Create" => " - Create",
                "Edit" => " - Edit",
                "Delete" => " - Delete",
                _ => ""
            });

            return base.View(viewName, model);
        }

    }

}
