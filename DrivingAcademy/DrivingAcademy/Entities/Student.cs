using System.ComponentModel.DataAnnotations;

namespace DrivingAcademy.Entities
{
    public partial class Student
    {
        public int Id { get; set; }
        [Required]
        [Range(18, 70, ErrorMessage = "La edad debe ser entre 18 y 70 años")]
        public short Age { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Identification { get; set; } = null!;
        public int TypeLicenceId { get; set; }
        public Licence TypeLicence { get; set; } = null!;
    }
}
