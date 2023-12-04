using Dms.Core.Interfaces;
using Dms.Models.ReCall;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dms.Infrastructure.Repositories.ReCallRepository
{
    public class RecallRepository : IRecallRepository
    {
        private readonly DmsSqlDbContext _dbContext;
        public RecallRepository(DmsSqlDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Recall>> GetAllRecallsAsync()
        {
           return await _dbContext.Recalls.ToListAsync();
        }
        public async Task<Recall> GetRecallByIdAsync(Guid id)
        {
            return await _dbContext.Recalls.FindAsync(id);
        }
        public async Task AddRecallAsync(Recall recall)
        {
            _dbContext.Recalls.Add(recall);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateRecallAsync(Recall recall)
        {
            _dbContext.Recalls.Update(recall);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteRecallByIdAsync(Guid id)
        {
            var recall = await _dbContext.Recalls.FindAsync(id);
            if(recall != null)
            {
                _dbContext.Recalls.Remove(recall);
                await _dbContext.SaveChangesAsync();
            }
        }

    }
}
