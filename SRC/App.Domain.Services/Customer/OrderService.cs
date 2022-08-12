using App.Domain.Core.Customer.Contacts.Repositories;
using App.Domain.Core.Customer.Contacts.Service;
using App.Domain.Core.Customer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Customer
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<int> Add(OrderDto OrderDto)
        {
            return await _orderRepository.Add(OrderDto);
        }

        public async Task Delete(int Id)
        {
            await  _orderRepository.Delete(Id);
        }

        public async Task<bool> EsureExitOreder(int id)
        {
            return await _orderRepository.EsureExitOreder(id);
        }

        public async Task<bool> EsureExitUser(int id)
        {
            return await _orderRepository.EsureExitUser(id);
        }

        public async Task<OrderDto> Get(int id)
        {
           return await _orderRepository.Get(id);
        }

        public async Task<List<OrderDto>> GetAll(string UserId, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetAll(UserId, cancellationToken);
        }

        public async Task Update(OrderDto OrderDto)
        {
            await _orderRepository.Update(OrderDto);
        }
    }
}
