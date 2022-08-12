using App.Domain.Core.BaseData.Contacts.AppService;
using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.Customer.Contacts.AppService;
using App.EndPoint.UI.Areas.Admin.Models.ViewModels.BaseData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.EndPoint.UI.Areas.Admin.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceAppService _serviceAppService;
        private readonly ICateguryAppService _categuryAppService;
        private readonly IOrderAppService _orderAppService;

        public ServiceController(IServiceAppService serviceAppService,
            ICateguryAppService categuryAppService,
            IOrderAppService orderAppService)
        {
            _serviceAppService = serviceAppService;
            _categuryAppService = categuryAppService;
            _orderAppService = orderAppService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetAllService(CancellationToken cancellationToken)
        {
            var record = await _serviceAppService.GetAll(cancellationToken);
            var RC = record.Select(x => new ServiceViewModel
            {
                ServiceId = x.ServiceId,
                CategoryTitle = x.CategoryTitle,
                Title = x.Title,
                Price = x.Price,
                ShortDescription = x.ShortDescription,
            }).ToList();

            return View(RC);
        }

        [HttpGet]
        public async Task<IActionResult> setservice()
        {

            var category = await _categuryAppService.GetAll();
            ViewBag.category = category.Select
            (s => new SelectListItem
            {
                Text = s.Title,
                Value = s.Id.ToString()
            });

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> setservice(ServiceViewModel ModelServive)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(ModelServive);
            //}
            var dto = new ServiceDto
            {

                CategoryId = ModelServive.categuryid,
                Title = ModelServive.Title,
                Price = ModelServive.Price,
                ShortDescription = ModelServive.ShortDescription,
            };
            await _serviceAppService.Add(dto);
            return RedirectToAction("GetAllService");
        }
        public async Task<IActionResult> DeleteService(int id)
        {
            if (await _orderAppService.EsureExitOreder(id))
            {
                return RedirectToAction("Error");
            }

            await _serviceAppService.Delete(id);
            return RedirectToAction("GetAllService");

        }
        [HttpGet]
        public async Task<IActionResult> EditService(int id)
        {
            var category = await _categuryAppService.GetAll();
            ViewBag.category = category.Select
            (s => new SelectListItem
            {
                Text = s.Title,
                Value = s.Id.ToString()
            });

            var X = await _serviceAppService.Get(id);

            ServiceViewModel C = new ServiceViewModel();

            C.ServiceId = X.ServiceId;
            C.Title = X.Title;
            C.Price=X.Price;
            C.ShortDescription=X.ShortDescription;
            C.CategoryTitle = C.CategoryTitle;
         
            return View(C);


        }


        [HttpPost]
        public async Task<IActionResult> EditService(ServiceViewModel model)
        {
            var dto = new ServiceDto
            {
                ServiceId = model.ServiceId,
                CategoryId=model.categuryid,              
                Title = model.Title,
                ShortDescription=model.ShortDescription,
                Price=model.Price,
           
            };
            await _serviceAppService.Update(dto);
            return RedirectToAction("GetAllService");

        }



        public async Task<IActionResult> Error()
        {

            return View();
        }


    }
}
