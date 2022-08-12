using App.Domain.Core.Customer.Contacts.AppService;
using App.Domain.Core.Customer.Dtos;
using App.EndPoint.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.UI.Controllers
{
    public class CommentController : Controller
    {
        private readonly IOrderAppService _orderAppService;
        private readonly IServiceCommentAppService _serviceCommentAppService;

        public CommentController(IOrderAppService orderAppService,
            IServiceCommentAppService serviceCommentAppService)
        {
            _orderAppService = orderAppService;
            _serviceCommentAppService = serviceCommentAppService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> commentService(int Id)
        {
            var Record = await _orderAppService.Get(Id);
            CommentViewModel V = new CommentViewModel();
            V.OrderId = Record.OrderId;
            V.ServiceTitle = Record.Servicetitle;
            V.CustomerUserId = Record.CustomerUserId;
            V.ServiceId = Record.ServiceId;
            return View(V);
        }
        [HttpPost]
        public async Task<IActionResult> commentService(CommentViewModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(model);
            //}
            var dto = new ServiceCommentDto
            {
                CommentText = model.CommentTitle,
                CreatedUserId = model.CustomerUserId,
                ServiceId = model.ServiceId,
            };
            await _serviceCommentAppService.Add(dto);
            return RedirectToAction("HistoryOrder","Customer");

        }
    }
}
