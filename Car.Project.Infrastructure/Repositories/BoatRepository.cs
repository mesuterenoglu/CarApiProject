using CarProject.Domain.Entities;
using CarProject.Domain.Interfaces;
using CarProject.Infrastructure.Context;

namespace CarProject.Infrastructure.Repositories
{
    public class BoatRepository : BaseRepository<Boat>,IBoatRepository
    {
        public BoatRepository(AppDbContext context):base(context)
        {

        }
    }
}
