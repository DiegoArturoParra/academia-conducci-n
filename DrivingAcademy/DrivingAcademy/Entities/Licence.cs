using System.ComponentModel.DataAnnotations;

namespace DrivingAcademy.Entities
{
    public partial class Licence
    {
        public int Id { get; set; }
        [Required]
        public string TypeName { get; set; } = null!;
    }
}
