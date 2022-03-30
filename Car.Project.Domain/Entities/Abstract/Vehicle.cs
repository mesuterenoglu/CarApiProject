

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarProject.Domain.Entities.Abstract
{
    public abstract class Vehicle
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        [MaxLength(100)]
        public string Brand { get; set; }
        [MaxLength(100)]
        public string Color { get; set; }
    }
}
