using FestivalHue2020WebAPI.Models;

namespace FestivalHue2020WebAPI.Interfaces
{
    public interface ITinTucRepository
    {
        Task<List<TinTuc>> GetAllTinTucAsync();
        Task<TinTuc> GetTinTucByIdAsync(int id);
        Task AddTinTucAsync(TinTuc TinTuc);
        Task UpdateTinTucAsync(TinTuc TinTuc);
        Task DeleteTinTucAsync(int id);
    }
}
