
namespace CarProject.Application.DTOs
{
    public abstract class BaseDto
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
    }
}
