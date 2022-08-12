using App.Domain.Core.BaseData.Entity;
using App.Domain.Core.Customer.Contacts.Repositories;
using App.Domain.Core.Customer.Dtos;
using App.Domain.Core.Customer.Entity;
using App.Infrastructures.Database.SqlServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Repositoy.Ef.Customer
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<AppUser> _userManager;

        public OrderRepository(AppDbContext DbContext, UserManager<AppUser> userManager)
        {
            _dbContext = DbContext;
            _userManager = userManager;
        }

        /// <summary>
        /// ثبت سفارشات توسط مشتریان
        /// </summary>
        /// <param name="OrderDto"></param>
        /// <returns></returns>
        public async Task<int> Add(OrderDto OrderDto)
        {
            Order order = new Order
            {
                StatusId=OrderDto.StatusId,
                ServiceBasePrice = OrderDto.ServiceBasePrice,
                Serviceid = OrderDto.Serviceid,
                CreatedAt=OrderDto.CreatedAt,
                CustomerUserId=OrderDto.CustomerUserId,
            };
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
            return order.Id;
        }

    /// <summary>
    /// حذف سفارش از سبد خرید
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
        public async Task Delete(int Id)
        {
            var record = await _dbContext.Orders.Where(p => p.Id == Id).SingleOrDefaultAsync();
            _dbContext.Orders.Remove(record);
            _dbContext.SaveChangesAsync();
        }

        public async Task<bool> EsureExitOreder(int id)
        {
            return _dbContext.Orders.Any(p => p.Serviceid == id);
        }
        /// <summary>
        /// چک کردن وجود userId 
        /// </summary>
    
        public async Task<bool> EsureExitUser(int id)
        {
            return  _dbContext.Orders.Any(p => p.CustomerUserId == id);
        }

        /// <summary>
        /// مشاهده لیست کلیه سفارشات مشتری
        /// </summary>
        public async Task<OrderDto> Get(int id)
        {
            return await _dbContext.Orders.Where(p => p.Id == id).Select(u => new OrderDto()
            {
                OrderId = u.Id,
                ServiceId=u.Serviceid,
                Servicetitle=u.Service.Title,
                CustomerUserId=u.CustomerUserId,
                Serviceid=u.Serviceid,
                
            }).SingleAsync();
        }
      
    
        public async Task<List<OrderDto>> GetAll(string UserId, CancellationToken cancellationToken)
        {
            return await _dbContext.Orders.Where(u=>u.CustomerUserId==Convert.ToInt32(UserId)).Select(p => new OrderDto()
            {
                OrderId = p.Id,
                Servicetitle = p.Service.Title,
                ServiceId = p.Serviceid,

                CustomerUserName = _userManager.Users.Where(u => u.Id == p.CustomerUserId)
           .Select(x => x.UserName).SingleOrDefault(),

                ServiceBasePrice = p.Service.Price,

                TotalPrice = _dbContext.Bids.Where(u => u.OrderId == p.Id && u.IsApproved == true)
           .Select(x => x.SuggestedPrice).SingleOrDefault(),

                CreatedAt = p.CreatedAt,
                Statustitle = p.Status.Title,

                FainalExpertUserName = _userManager.Users.Where(u => u.Id == p.FainalExpertUserid)
           .Select(p => p.UserName).SingleOrDefault(),
            }).ToListAsync();
        }

        public Task Update(OrderDto OrderDto)
        {
            throw new NotImplementedException();
        }
    }
}
