

using CarProject.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarProject.Application.ServiceInterfaces
{
    public interface ICarService
    {
        Task AddAsync(CarDto entity);
        Task DeleteAsync(int id);
        Task RemoveFromDbAsync(int id);
        Task UpdateAsync(CarDto entity);
        Task<List<CarDto>> GetAllAsync();
        Task<List<CarDto>> GetAllInActiveAsync();
        Task<List<CarDto>> GetAllActiveAsync();
        Task<CarDto> GetbyIdAsync(int id);
        Task<List<CarDto>> GetbyColorAsync(string color);
        Task<bool> AnyAsync(int id);
        Task TurnOnHeadlights(int id);
        Task TurnOffHeadlights(int id);
    }
}
