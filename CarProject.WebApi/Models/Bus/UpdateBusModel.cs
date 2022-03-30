

using System.ComponentModel.DataAnnotations;

namespace CarProject.WebApi.Models.Bus
{
    public class UpdateBusModel
    {
        [MaxLength(100)]
        public string Brand { get; set; }
        [MaxLength(100)]
        public string Color { get; set; }
        public short Capacity { get; set; }
    }
}
