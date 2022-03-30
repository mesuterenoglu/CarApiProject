using CarProject.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarProject.Application.ServiceInterfaces
{
    public interface IBoatService
    {
        Task AddAsync(BoatDto entity);
        Task DeleteAsync(int id);
        Task RemoveFromDbAsync(int id);
        Task UpdateAsync(BoatDto entity);
        Task<List<BoatDto>> GetAllAsync();
        Task<List<BoatDto>> GetAllInActiveAsync();
        Task<List<BoatDto>> GetAllActiveAsync();
        Task<BoatDto> GetbyIdAsync(int id);
        Task<List<BoatDto>> GetbyColorAsync(string color);
        Task<bool> AnyAsync(int id);
    }
}
