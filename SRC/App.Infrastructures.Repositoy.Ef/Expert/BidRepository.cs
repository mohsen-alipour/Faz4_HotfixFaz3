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
    public class BidRepository : IBidRepository
    {
        private readonly AppDbContext _dbContext;

        public BidRepository(AppDbContext DbContext)
        {
            _dbContext = DbContext;
        }
        public Task Add(BidDto BidDto)
        {
            throw new NotImplementedException();
        }

        public async Task Add(int OrderId)
        {
            Bid NewBid = new Bid
            {
             OrderId = OrderId,
             CreatedAt=DateTime.Now,
            };
            _dbContext.Bids.Add(NewBid);
            await _dbContext.SaveChangesAsync();
        }

        public Task Delete(int Id)
        {
            throw new NotImplementedException();
        }

        //public async Task<BidDto> Get(int Id)
        //{
        //    return await _dbContext.Bids.Select(x => new BidDto
        //    {
        //        CreatedAt = x.CreatedAt,
        //        OrderId = x.OrderId,
               
        //    }).ToListAsync();
        //}

        public Task<List<BidDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(BidDto BidDto)
        {
            throw new NotImplementedException();
        }
    }
}
