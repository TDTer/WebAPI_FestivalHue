using FestivalHue2020WebAPI.Data;
using FestivalHue2020WebAPI.Interfaces;
using FestivalHue2020WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FestivalHue2020WebAPI.Repositories
{
    public class VeRepository : IVeReponsitory
    {
        private readonly DataContext _dbContext;

        public VeRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Ve>> GetAllVeAsync()
        {
            return await _dbContext.Ve.Include(v => v.ChuongTrinh).ToListAsync();
        }

        public async Task<Ve> GetVeByIdAsync(int id)
        {
            return await _dbContext.Ve.Include(v => v.ChuongTrinh).FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task AddVeAsync(Ve ve)
        {
            _dbContext.Ve.Add(ve);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateVeAsync(Ve ve)
        {
            _dbContext.Entry(ve).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteVeAsync(int id)
        {
            var ve = await _dbContext.Ve.FindAsync(id);
            if (ve != null)
            {
                _dbContext.Ve.Remove(ve);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
