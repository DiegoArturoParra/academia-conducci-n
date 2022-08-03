using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrivingAcademy.Entities
{
    public partial class InfoDrivingAcademy
    {
        [NotMapped]
        [Required]
        public List<int> lessonIds { get; set; } = null!;
    }
}
