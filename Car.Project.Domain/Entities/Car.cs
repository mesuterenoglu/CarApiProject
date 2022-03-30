

using CarProject.Domain.Entities.Abstract;

namespace CarProject.Domain.Entities
{
    public class Car : Vehicle
    {
        public short Wheels { get; set; } = 4;
        public bool Headlights { get; set; } = false;
    }
}
