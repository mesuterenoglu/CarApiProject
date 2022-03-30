

using CarProject.Domain.Entities;
using System.Threading.Tasks;

namespace CarProject.Domain.Interfaces
{
    public interface ICarRepository : IRepository<Car>
    {
        Task TurnOnHeadlights(int id);
        Task TurnOffHeadlights(int id);
    }
}
