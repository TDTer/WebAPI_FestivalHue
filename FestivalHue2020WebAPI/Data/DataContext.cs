using FestivalHue2020WebAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FestivalHue2020WebAPI.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<ChuongTrinh> ChuongTrinh { get; set; }
        public DbSet<ChuongTrinhDetail> chuongTrinhDetail { get; set; }
        public DbSet<DiaDiem> DiaDiem { get; set; }
        public DbSet<LichDien> LichDien { get; set; }
        public DbSet<TinTuc> TinTuc { get; set; }
        public DbSet<Ve> Ve { get; set; }
    }
}
