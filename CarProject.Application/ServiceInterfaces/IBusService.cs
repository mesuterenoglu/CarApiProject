

using CarProject.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarProject.Application.ServiceInterfaces
{
    public interface IBusService
    {
        Task AddAsync(BusDto entity);
        Task DeleteAsync(int id);
        Task RemoveFromDbAsync(int id);
        Task UpdateAsync(BusDto entity);
        Task<List<BusDto>> GetAllAsync();
        Task<List<BusDto>> GetAllInActiveAsync();
        Task<List<BusDto>> GetAllActiveAsync();
        Task<BusDto> GetbyIdAsync(int id);
        Task<List<BusDto>> GetbyColorAsync(string color);
        Task<bool> AnyAsync(int id);
    }
}
