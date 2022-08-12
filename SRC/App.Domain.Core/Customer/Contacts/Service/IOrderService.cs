using App.Domain.Core.Customer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Customer.Contacts.Service
{
    public interface IOrderService
    {
        Task<int> Add(OrderDto OrderDto);
        Task<List<OrderDto>> GetAll(string UserId, CancellationToken cancellationToken);
        Task<OrderDto> Get(int id);
        Task<bool> EsureExitOreder(int id);
        Task<bool> EsureExitUser(int id);
        Task Update(OrderDto OrderDto);
        Task Delete(int Id);
    }
}
