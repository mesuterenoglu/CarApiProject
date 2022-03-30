

using CarProject.Domain.Entities;
using CarProject.Domain.Interfaces;
using CarProject.Infrastructure.Context;

namespace CarProject.Infrastructure.Repositories
{
    public class BusRepository : BaseRepository<Bus>, IBusRepository
    {
        public BusRepository(AppDbContext context):base(context)
        {

        }
    }
}
