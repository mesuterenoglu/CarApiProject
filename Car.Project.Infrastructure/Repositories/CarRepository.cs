using CarProject.Domain.Entities;
using CarProject.Domain.Interfaces;
using CarProject.Infrastructure.Context;
using System.Threading.Tasks;

namespace CarProject.Infrastructure.Repositories
{
    public class CarRepository : BaseRepository<Car>, ICarRepository
    {
        public CarRepository(AppDbContext context):base(context)
        {

        }

        public async Task TurnOffHeadlights(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            car.Headlights = false;
            _context.Cars.Update(car);
            await _context.SaveChangesAsync();
        }

        public async Task TurnOnHeadlights(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            car.Headlights = true;
            _context.Cars.Update(car);
            await _context.SaveChangesAsync();
        }
    }
}
