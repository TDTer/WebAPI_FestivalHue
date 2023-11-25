using FestivalHue2020WebAPI.Data;
using FestivalHue2020WebAPI.Interfaces;
using FestivalHue2020WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FestivalHue2020WebAPI.Repositories
{
    public class LichDienRepository : ILichDienRepository
    {
        private readonly DataContext _dbContext;

        public LichDienRepository(DataContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<List<LichDien>> GetAllLichDienAsync()
        {
            return await _dbContext.LichDien
            .Include(ld => ld.DetailList)
            .ToListAsync();
        }

        public async Task<LichDien> GetLichDienByDateAsync(DateTime day)
        {
            return await _dbContext.LichDien
            .Include(ct => ct.DetailList)
            .FirstOrDefaultAsync(ct => ct.fdate == day);
        }
        public async Task<LichDien> GetLichDienByIdAsync(int id)
        {
            return await _dbContext.LichDien
            .Include(ct => ct.DetailList)
            .FirstOrDefaultAsync(ct => ct.Id == id);
        }
        public async Task AddLichDienhAsync(LichDien LichDien)
        {
            _dbContext.LichDien.Add(LichDien);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateLichDienAsync(LichDien LichDien)
        {
            _dbContext.Entry(LichDien).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteLichDienAsync(int id)
        {
            var LichDien = await _dbContext.LichDien.FindAsync(id);
            _dbContext.LichDien.Remove(LichDien);
            await _dbContext.SaveChangesAsync();
        }
    }
}
