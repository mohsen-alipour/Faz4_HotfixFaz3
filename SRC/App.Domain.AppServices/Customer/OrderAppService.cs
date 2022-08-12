using App.Domain.Core.Customer.Contacts.AppService;
using App.Domain.Core.Customer.Contacts.Service;
using App.Domain.Core.Customer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Customer
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IOrderService _orderService;

        public OrderAppService(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task<int> Add(OrderDto OrderDto)
        {
          return  await _orderService.Add(OrderDto);
        }

        public async Task Delete(int Id)
        {
            await _orderService.Delete(Id);
        }

        public async Task<bool> EsureExitOreder(int id)
        {
            return await _orderService.EsureExitOreder(id);
        }

        public async Task<bool> EsureExitUser(int id)
        {
            return await _orderService.EsureExitUser(id);
        }

        public async Task<OrderDto> Get(int id)
        {
            return await _orderService.Get(id);
        }

        public async Task<List<OrderDto>> GetAll(string UserId, CancellationToken cancellationToken)
        {
            return await _orderService.GetAll(UserId, cancellationToken);
        }

        public async Task Update(OrderDto OrderDto)
        {
            await _orderService.Update(OrderDto);
        }
    }
}
