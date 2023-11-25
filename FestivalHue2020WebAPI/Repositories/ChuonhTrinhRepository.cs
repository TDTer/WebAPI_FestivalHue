using FestivalHue2020WebAPI.Data;
using FestivalHue2020WebAPI.Interfaces;
using FestivalHue2020WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FestivalHue2020WebAPI.Repositories
{
    public class ChuongTrinhRepository : IChuongTrinhRepository
    {
        private readonly DataContext _dbContext;

        public ChuongTrinhRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ChuongTrinh>> GetAllChuongTrinhsAsync()
        {
            return await _dbContext.ChuongTrinh.Include(ct => ct.DetailList).ToListAsync();
        }

        public async Task<ChuongTrinh> GetChuongTrinhByIdAsync(int id)
        {
            return await _dbContext.ChuongTrinh
            .Include(ct => ct.DetailList)
            .FirstOrDefaultAsync(ct => ct.Id == id);
        }

        public async Task AddChuongTrinhAsync(ChuongTrinh chuongTrinh)
        {
            _dbContext.ChuongTrinh.Add(chuongTrinh);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateChuongTrinhAsync(ChuongTrinh chuongTrinh)
        {
            _dbContext.Entry(chuongTrinh).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteChuongTrinhAsync(int id)
        {
            var chuongTrinh = await _dbContext.ChuongTrinh.FindAsync(id);
            _dbContext.ChuongTrinh.Remove(chuongTrinh);
            await _dbContext.SaveChangesAsync();
        }
    }
}
