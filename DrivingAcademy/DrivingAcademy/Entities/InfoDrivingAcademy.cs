using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrivingAcademy.Entities
{
    public partial class InfoDrivingAcademy
    {
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int LessonId { get; set; }
        public bool Active { get; set; } = true;
        public Lesson Lesson { get; set; } = null!;
        public Student Student { get; set; } = null!;
    }
}
