using App.Domain.Core.BaseData.Contacts.Repositories;
using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.BaseData.Entity;
using App.Domain.Core.Customer.Dtos;
using App.Infrastructures.Database.SqlServer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Repositoy.Ef.BaseData
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly AppDbContext _dbContext;

        public ServiceRepository(AppDbContext DbContext)
        {
            _dbContext = DbContext;
        }
        //<summary>
        //اضافه کردن یک سرویس جدید
        public async Task Add(ServiceDto ServiceDto)
        {
            Service services = new Service
            {
               Categoryid=ServiceDto.CategoryId,
               Title = ServiceDto.Title,
               ShortDescription = ServiceDto.ShortDescription,
               Price = ServiceDto.Price,           
            };
            _dbContext.Services.Add(services);
            await _dbContext.SaveChangesAsync();

        }
        /// <summary>
        /// حذف یک سرویس بر اساس ID
        /// </summary>
        /// <param name="Id"></param>
        public async Task Delete(int Id)
        {
            var record = await _dbContext.Services.Where(p => p.Id == Id).SingleOrDefaultAsync();
            _dbContext.Services.Remove(record);
            _dbContext.SaveChangesAsync();
        }

        public async Task<bool> EsureExitCategory(int id)
        {
           
            return _dbContext.Services.Any(p => p.Categoryid == id);
        }

        //<summary>
        //جستجوی یک نوع سرویس جدید
        public async Task<ServiceDto> Get(int id)
        {
            return await _dbContext.Services.Where(p => p.Id == id).Select(p => new ServiceDto()
            {
             ServiceId = p.Id,
             CategoryTitle = p.Category.Title,
             CategoryId = p.Categoryid,
             ShortDescription=p.ShortDescription,
             Price=p.Price,
             Title=p.Title,             
            }).SingleOrDefaultAsync();
        }
        //<summary>
        //مشاهده لیست کلیه سرویس ها
        public async Task<List<ServiceDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _dbContext.Services.Select(p => new ServiceDto()
            {
               ServiceId = p.Id,
               CategoryTitle =p.Category.Title,         
               Price=p.Price,
               ShortDescription=p.ShortDescription,
               Title=p.Title,
            }).ToListAsync();
        }

        public async Task Update(ServiceDto ServiceDto)
        {
           
            var record = await _dbContext.Services.Where(p => p.Id == ServiceDto.ServiceId).SingleOrDefaultAsync();
            record.Title = ServiceDto.Title;
            record.Price = ServiceDto.Price;
            record.ShortDescription = ServiceDto.ShortDescription;
            record.Categoryid=ServiceDto.CategoryId;
           _dbContext.SaveChangesAsync();
        }
    }
    
}
