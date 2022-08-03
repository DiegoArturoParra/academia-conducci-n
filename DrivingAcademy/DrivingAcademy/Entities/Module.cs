using System.ComponentModel.DataAnnotations;

namespace DrivingAcademy.Entities
{
    public partial class Module
    {
        public int Id { get; set; }
        [Required]
        public string NameModule { get; set; } = null!;
    }
}
