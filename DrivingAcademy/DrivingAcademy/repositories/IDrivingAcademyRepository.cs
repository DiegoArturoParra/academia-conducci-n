using DrivingAcademy.DTO_s;
using DrivingAcademy.Entities;
using DrivingAcademy.Helpers;

namespace DrivingAcademy.repositories
{
    public interface IDrivingAcademyRepository
    {
        public Task<IEnumerable<Student>> GetStudents();
        public Task<DetailStudentDTO> GetStudent(int studentId);
        public Task<IEnumerable<Licence>> GetLicences();
        public Task<Response> CreateStudent(Student student);
        public Task<IEnumerable<Module>> GetModules();
        public Task<IEnumerable<Lesson>> GetLessonsByModuleId(int moduleId);
        public Task<Response> CreateDetail(InfoDrivingAcademy info);
    }
}
