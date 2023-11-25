using FestivalHue2020WebAPI.Data;
using FestivalHue2020WebAPI.DTO;
using FestivalHue2020WebAPI.Interfaces;
using FestivalHue2020WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FestivalHue2020WebAPI.Repositories
{
    public class DiaDiemRepository : IDiaDiemRepository
    {
        private readonly DataContext _dbContext;

        public DiaDiemRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<DiaDiem>> GetAllDiaDiemAsync()
        {
            return await _dbContext.DiaDiem.ToListAsync();
        }
        public async Task<DiaDiem> GetDiaDiemByIdAsync(int id)
        {
            return await _dbContext.DiaDiem.FindAsync(id);
        }
        public async Task AddDiaDiemAsync(DiaDiem DiaDiem)
        {
            _dbContext.DiaDiem.Add(DiaDiem);
            await _dbContext.SaveChangesAsync();
        }
       
        public async Task UpdateDiaDiemAsync(DiaDiem DiaDiem)
        {
            _dbContext.Entry(DiaDiem).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteDiaDiemAsync(int id)
        {
            var diaDiem = await _dbContext.DiaDiem.FindAsync(id);
            if (diaDiem != null)
            {
                _dbContext.DiaDiem.Remove(diaDiem);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
