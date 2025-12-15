using MagicVilla_Web.Models.DTO;

namespace MagicVilla_Web.Services.IServices
{
    public interface IVillaService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(VillaDtoCreate dto);
        Task<T> UpdateAsync<T>(VillaDtoUpdate dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
