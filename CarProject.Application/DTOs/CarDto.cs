

namespace CarProject.Application.DTOs
{
    public class CarDto : BaseDto
    {
        public short Wheels { get; set; } = 4;
        public bool Headlights { get; set; } = false;
    }
}
