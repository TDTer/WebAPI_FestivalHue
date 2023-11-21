using FestivalHue2020WebAPI.Models;

namespace FestivalHue2020WebAPI.Interfaces
{
    public interface IChuongTrinhRepository
    {
        Task<List<ChuongTrinh>> GetAllChuongTrinhsAsync();
        Task<ChuongTrinh> GetChuongTrinhByIdAsync(int id);
        Task AddChuongTrinhAsync(ChuongTrinh chuongTrinh);
        Task UpdateChuongTrinhAsync(ChuongTrinh chuongTrinh);
        Task DeleteChuongTrinhAsync(int id);
    }
}
