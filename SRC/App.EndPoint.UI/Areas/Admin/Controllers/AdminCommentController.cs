using App.Domain.Core.Customer.Contacts.AppService;
using App.EndPoint.UI.Areas.Admin.Models.ViewModels.BaseData;
using Microsoft.AspNetCore.Mvc;


namespace App.EndPoint.UI.Areas.Admin.Controllers
{
    public class AdminCommentController : Controller
    {
        private readonly IServiceCommentAppService _serviceCommentAppService;

        public AdminCommentController(IServiceCommentAppService serviceCommentAppService)
        {
            _serviceCommentAppService = serviceCommentAppService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetAllComment()
        {
            var record = await _serviceCommentAppService.GetAll();
            var RC = record.Select(x => new AdminCommentViewModel
            {
                Id = x.Id,
                ServiceTitle = x.ServiceTitle,
                CommentText = x.CommentText,
                UserName = x.UserName,
                CreateAt = x.CreatedAt,
            }).ToList();

            return View(RC);
        }
    }
}
