using App.Domain.Core.Expert.Contacts.Repositories;
using App.Domain.Core.Expert.Dtos;
using App.Domain.Core.Expert.Entity;
using App.Infrastructures.Database.SqlServer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.Repositoy.Ef.Expert
{
    public class ExpertFavoriteCategoryRepository : IExpertFavoriteCategoryRepository
    {
        private readonly AppDbContext _dbContext;

        public ExpertFavoriteCategoryRepository(AppDbContext DbContext)
        {
            _dbContext = DbContext;
        }
        public async Task Add(ExpertFavoriteCategoryDto ExpertFavoriteCategoryDto)
        {
            ExpertFavoriteCategory ExpertSpecialy = new ExpertFavoriteCategory
            {
            Categoryid= ExpertFavoriteCategoryDto.Categoryid,
            CreatedAt=DateTime.Now,
            ExpertUserId=ExpertFavoriteCategoryDto.ExpertUserId,
            };
            _dbContext.ExpertFavoriteCategories.Add(ExpertSpecialy);
            await _dbContext.SaveChangesAsync();
        }

        public Task Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ExpertFavoriteCategoryDto> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ExpertFavoriteCategoryDto>> GetAll()
        {
            return await _dbContext.ExpertFavoriteCategories.Select(p=> new ExpertFavoriteCategoryDto()
            {
               ExpertCategorySpecialyId=p.Id,
               Categoryid=p.Id,
               CategoryTitle=p.Category.Title,
               CreatedAt=p.CreatedAt,
               ExpertUserId=p.ExpertUserId,

            }).ToListAsync();

        }

        public Task Update(ExpertFavoriteCategoryDto ExpertFavoriteCategoryDto)
        {
            throw new NotImplementedException();
        }

    }
}
