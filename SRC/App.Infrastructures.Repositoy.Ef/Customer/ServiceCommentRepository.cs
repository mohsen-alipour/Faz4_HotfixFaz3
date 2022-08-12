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

    public class ServiceCommentRepository : IServiceCommentRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<AppUser> _userManager;

        public ServiceCommentRepository(AppDbContext DbContext,
               UserManager<AppUser> userManager)
        {
            _dbContext = DbContext;
            _userManager = userManager;
        }
        public async Task Add(ServiceCommentDto ServiceCommentDto)
        {

            ServiceComment ServiceComment = new ServiceComment
            {
                ServiceId = ServiceCommentDto.ServiceId,
                CommentText=ServiceCommentDto.CommentText,
                CreatedUserId=ServiceCommentDto.CreatedUserId,
                CreatedAt=DateTime.Now,       
            };
            _dbContext.ServiceComments.Add(ServiceComment);
            await _dbContext.SaveChangesAsync();
        }

        public Task Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceCommentDto> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ServiceCommentDto>> GetAll()
        {
            var ww = await _userManager.FindByIdAsync("2002");
            return await _dbContext.ServiceComments.Select(p => new ServiceCommentDto()
            {
                Id = p.Id,
                ServiceTitle = p.Service.Title,
                CommentText = p.CommentText,
                UserName = _userManager.Users.Where(x=>x.Id==p.CreatedUserId).Select(c=>c.UserName).SingleOrDefault(),
                CreatedAt = p.CreatedAt,
            }).ToListAsync();
        }

        public Task Update(ServiceCommentDto ServiceCommentDto)
        {
            throw new NotImplementedException();
        }
    }
}
