using FestivalHue2020WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FestivalHue2020WebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<ChuongTrinh> ChuongTrinh { get; set; }
        public DbSet<ChuongTrinhDetail> chuongTrinhDetail { get; set; }
        public DbSet<DiaDiem> DiaDiem { get; set;}      
        public DbSet<LichDien> LichDien { get; set; }
        public DbSet<TinTuc> TinTuc { get; set; }

    }
}
