

using System.ComponentModel.DataAnnotations;

namespace CarProject.WebApi.Models
{
    public class UpdateCarModel
    {
        [MaxLength(100)]
        public string Brand { get; set; }
        [MaxLength(100)]
        public string Color { get; set; }

        public bool Headlights { get; set; }
    }
}
