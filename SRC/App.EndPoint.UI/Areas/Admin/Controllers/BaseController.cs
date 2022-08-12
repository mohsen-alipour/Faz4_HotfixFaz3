using App.Domain.Core.BaseData.Contacts.AppService;
using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.Customer.Contacts.AppService;
using App.EndPoint.UI.Areas.Admin.Models.ViewModels.BaseData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.EndPoint.UI.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {

        private readonly IServiceAppService _serviceAppService;
        private readonly IOrderAppService _orderAppService;
        private readonly IAppFileAppService _appFileAppService;
        private readonly ICateguryAppService _categuryAppService;

        public BaseController(
            IServiceAppService serviceAppService,
            IOrderAppService orderAppService,
            IAppFileAppService appFileAppService,
            ICateguryAppService categuryAppService
            )
        {
            
            _serviceAppService = serviceAppService;
            _orderAppService = orderAppService;
            _appFileAppService = appFileAppService;
            _categuryAppService = categuryAppService;
        }
 
      

        #region Service

      
        #endregion Service

        #region Order

        public async Task<IActionResult> GetAllOrder(string UserId ,CancellationToken cancellationToken)
        {
            var record = await _orderAppService.GetAll(UserId,cancellationToken);
            var RC = record.Select(x => new OrderViewModel
            {
            ServiceTitle=x.Servicetitle,
            CustomerUserName=x.CustomerUserName,
            BasePrice=x.ServiceBasePrice,
            TotalPrice=x.TotalPrice,
            OrderDate=x.CreatedAt,
            StatusTitle = x.Statustitle,
            FainalExpertUserName = x.FainalExpertUserName
                     
            }).ToList();

            return View(RC);
        }

        #endregion Order

        #region File
        public async Task<IActionResult> GetAllFile()
        {
            var record = await _appFileAppService.GetAll();
            var R = record.Select(x => new AdminFileViewModel
            {
             Id=x.Id,
             CreatedAt=x.CreatedAt,
             FileNme=x.FileNme,
            }).ToList();

            return View(R);
        }
        #endregion File
   

    }
}
