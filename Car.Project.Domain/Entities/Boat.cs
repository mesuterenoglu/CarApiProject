

using CarProject.Domain.Entities.Abstract;

namespace CarProject.Domain.Entities
{
    public class Boat : Vehicle
    {
        public short Length { get; set; }
        public short Width { get; set; }
        public short Depth { get; set; }

    }
}
