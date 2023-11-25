using FestivalHue2020WebAPI.Data;
using FestivalHue2020WebAPI.Interfaces;
using FestivalHue2020WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FestivalHue2020WebAPI.Repositories
{
    public class TinTucRepository : ITinTucRepository
    {
        private readonly DataContext _dbContext;

        public TinTucRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TinTuc>> GetAllTinTucAsync()
        {
            return await _dbContext.TinTuc.ToListAsync();
        }

        public async Task<TinTuc> GetTinTucByIdAsync(int id)
        {
            return await _dbContext.TinTuc.FindAsync(id);
        }

        public async Task AddTinTucAsync(TinTuc tinTuc)
        {
            _dbContext.TinTuc.Add(tinTuc);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateTinTucAsync(TinTuc tinTuc)
        {
            _dbContext.Entry(tinTuc).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteTinTucAsync(int id)
        {
            var tinTuc = await _dbContext.TinTuc.FindAsync(id);
            if (tinTuc != null)
            {
                _dbContext.TinTuc.Remove(tinTuc);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
