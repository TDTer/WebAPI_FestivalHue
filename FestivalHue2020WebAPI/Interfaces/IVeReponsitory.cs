using FestivalHue2020WebAPI.Models;

namespace FestivalHue2020WebAPI.Interfaces
{
    public interface IVeReponsitory
    {
        Task<List<Ve>> GetAllVeAsync();
        Task<Ve> GetVeByIdAsync(int id);
        Task AddVeAsync(Ve Ve);
        Task UpdateVeAsync(Ve Ve);
        Task DeleteVeAsync(int id);
    }
}
