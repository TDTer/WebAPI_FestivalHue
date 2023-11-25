using FestivalHue2020WebAPI.Models;

namespace FestivalHue2020WebAPI.Interfaces
{
    public interface IDiaDiemRepository
    {
        Task<List<DiaDiem>> GetAllDiaDiemAsync();
        Task<DiaDiem> GetDiaDiemByIdAsync(int id);
        Task AddDiaDiemAsync(DiaDiem DiaDiem);
        Task UpdateDiaDiemAsync(DiaDiem DiaDiem);
        Task DeleteDiaDiemAsync(int id);
    }
}
