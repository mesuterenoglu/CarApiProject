

using System.ComponentModel.DataAnnotations;

namespace CarProject.WebApi.Models.Boat
{
    public class UpdateBoatModel
    {
        [MaxLength(100)]
        public string Brand { get; set; }
        [MaxLength(100)]
        public string Color { get; set; }
        public short Length { get; set; }
        public short Width { get; set; }
        public short Depth { get; set; }
    }
}
