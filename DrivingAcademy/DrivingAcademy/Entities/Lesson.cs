using System.ComponentModel.DataAnnotations;

namespace DrivingAcademy.Entities
{
    public partial class Lesson
    {
        public int Id { get; set; }
        [Required]
        public string NameLesson { get; set; } = null!;
        public int ModuleId { get; set; }
        public Module Module { get; set; } = null!;
    }
}
