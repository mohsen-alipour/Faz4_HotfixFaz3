using App.Domain.Core.BaseData.Contacts.AppService;
using App.Domain.Core.BaseData.Entity;
using App.Domain.Core.Expert.Contacts.AppService;
using App.Domain.Core.Expert.Dtos;
using App.EndPoint.UI.Models.Expert;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.EndPoint.UI.Controllers
{
    public class ExpertController : Controller
    {
        private readonly ICateguryAppService _categuryAppService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IExpertFavoriteCategoryAppService _expertFavoriteCategoryAppService;
        private readonly IBidAppService _bidAppService;

        public ExpertController(ICateguryAppService categuryAppService,
            UserManager<AppUser> userManager,
            IExpertFavoriteCategoryAppService expertFavoriteCategoryAppService,
            IBidAppService bidAppService)
        {
            _categuryAppService = categuryAppService;
            _userManager = userManager;
            _expertFavoriteCategoryAppService = expertFavoriteCategoryAppService;
            _bidAppService = bidAppService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ExpertIndex()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SetExpertSpeciallyFavorite()
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
        public async Task<IActionResult> SetExpertSpeciallyFavorite(ExpertSpecialyViewModel expertSpecialyViewModel)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(ModelServive);
            //}
            var dto = new ExpertFavoriteCategoryDto
            {

              Categoryid=expertSpecialyViewModel.categuryid,
              ExpertUserId= Convert.ToInt32(_userManager.GetUserId(HttpContext.User)),
            };
            await _expertFavoriteCategoryAppService.Add(dto);
            return RedirectToAction("ListExpertSpecialy");
        }

        public async Task<IActionResult> ListExpertSpecialy()
        {
            var record = await _expertFavoriteCategoryAppService.GetAll();
            var RC = record.Select(x => new ExpertSpecialyViewModel
            {
               ExpertFavoriteCategoryid=x.ExpertCategorySpecialyId,
               CategoryTitle=x.CategoryTitle,
               RegisterDate=x.CreatedAt,           

        }).ToList();

            return View(RC);
        }

        public async Task<IActionResult> RequestList()
        {
            var record = await _bidAppService.GetAll();
            var RC = record.Select(x => new RequestListViewModel
            {
               

            }).ToList();

            return View(RC);
        }








    }
}

