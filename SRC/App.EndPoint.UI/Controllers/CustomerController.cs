using App.Domain.Core.BaseData.Contacts.AppService;
using App.Domain.Core.BaseData.Entity;
using App.Domain.Core.Customer.Contacts.AppService;
using App.EndPoint.UI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.UI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IOrderAppService _orderAppService;
        private readonly IServiceAppService _serviceAppService;

        public CustomerController(UserManager<AppUser> userManager,
            IOrderAppService orderAppService,
            IServiceAppService serviceAppService)
        {
            _userManager = userManager;
            _orderAppService = orderAppService;
            _serviceAppService = serviceAppService;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult CustomerIndex()
        {
            return View();
        }


        public async Task<IActionResult> HistoryOrder(CancellationToken cancellationToken)
        {
            var CurrentUserId = _userManager.GetUserId(HttpContext.User);
            var record = await _orderAppService.GetAll(CurrentUserId, cancellationToken);

            var RC = record.Select(x => new ListOrderViewModel
            {
                OrderId = x.OrderId,
                ServiceId = x.ServiceId,
                ServiceTitle = x.Servicetitle,
                CreatedAt = x.CreatedAt,
                FainalExpert = x.FainalExpertUserid,
                Price = x.ServiceBasePrice,
                statustitle = x.Statustitle,
            }).ToList();

            return View(RC);
        }

        public async Task<IActionResult> ListService(CancellationToken cancellationToken)
        {
            var record = await _serviceAppService.GetAll(cancellationToken);
            var RC = record.Select(x => new ListServiceViewModel
            {
                Id = x.ServiceId,
                CategoryTitle = x.CategoryTitle,
                Title = x.Title,
                Price = x.Price,
                ShortDescription = x.ShortDescription,
            }).ToList();

            return View(RC);
        }
    }
}
