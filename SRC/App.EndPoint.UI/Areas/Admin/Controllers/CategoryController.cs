using App.Domain.Core.BaseData.Contacts.AppService;
using App.Domain.Core.BaseData.Dtos;
using App.EndPoint.UI.Areas.Admin.Models.ViewModels.BaseData;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.UI.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICateguryAppService _categuryAppService;
        private readonly IServiceAppService _serviceAppService;

        public CategoryController(ICateguryAppService categuryAppService,
             IServiceAppService serviceAppService)
        {
            _categuryAppService = categuryAppService;
            _serviceAppService = serviceAppService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetAllCategory()
        {
            var record = await _categuryAppService.GetAll();
            var RC = record.Select(x => new OutputCategoryViewModel
            {
                Id = x.Id,
                Title = x.Title,
            }).ToList();

            return View(RC);
        }


        [HttpGet]
        public async Task<IActionResult> SetCategory()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SetCategory(OutputCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var dto = new CategoryDto
            {
                Title = model.Title,
            };
            await _categuryAppService.Add(dto);
            return RedirectToAction("GetAllCategory");
        }


        public async Task<IActionResult> DeleteCategory(int id)
        {
            var record = await _serviceAppService.EsureExitCategory(id);
            if (record)
            {
                return RedirectToAction("Error");
            }
           
            await _categuryAppService.Delete(id);
            return RedirectToAction("GetAllCategory");

        }
        [HttpGet]
        public async Task<IActionResult> EditCategory(int id)
        {

            var X = await _categuryAppService.Get(id);
            OutputCategoryViewModel C = new OutputCategoryViewModel();

            C.Id = X.Id;
            C.Title = X.Title;
            return View(C);

        }

        [HttpPost]
        public async Task<IActionResult> EditCategory(OutputCategoryViewModel model)
        {
            try
            {
                var dto = new CategoryDto
                {
                    Id = model.Id,
                    Title = model.Title,
                };
                await _categuryAppService.Update(dto);
                return RedirectToAction("GetAllCategory");
            }
            catch(Exception ex)
            {
                throw new Exception($"Error on Edit Category, Error Message : {ex.Message}", ex);
            }
        

        }
        public async Task<IActionResult> Error()
        {

            return View();
        }

    }
}
