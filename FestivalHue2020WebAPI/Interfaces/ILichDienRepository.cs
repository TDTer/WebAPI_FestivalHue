using FestivalHue2020WebAPI.Models;

namespace FestivalHue2020WebAPI.Interfaces
{
    public interface ILichDienRepository
    {
        Task<List<LichDien>> GetAllLichDienAsync();
        Task<LichDien> GetLichDienByDateAsync(DateTime day);
        Task<LichDien> GetLichDienByIdAsync(int id);
        Task AddLichDienhAsync(LichDien LichDien);
        Task UpdateLichDienAsync(LichDien LichDien);
        Task DeleteLichDienAsync(int id);
    }
}
