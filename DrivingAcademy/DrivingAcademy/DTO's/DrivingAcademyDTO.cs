using System.ComponentModel.DataAnnotations;

namespace DrivingAcademy.DTO_s
{
    public record CreateStudentDTO([Required] string Name,
        [Range(18, 70, ErrorMessage = "La edad debe ser entre 18 y 70 años")] short Age, [Required]
        string Identification, [Required] int typeLicenceId);
    public record CreateDetailDTO([Required] int StudentId, [Required] List<int> lessonIds);
    public record struct StudentDTO(int StudentId, string Name);

    public record struct LessonDTO(int Id, string Name, string Module);
    public record struct DetailStudentDTO(int StudentId, string Name, string TypeLicence, string Identification, short Age, List<LessonDTO> Lessons);
}
