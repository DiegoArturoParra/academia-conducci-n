using DrivingAcademy.DTO_s;
using DrivingAcademy.Entities;
using DrivingAcademy.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace DrivingAcademy.repositories
{
    public class DrivingAcademyRepository : IDrivingAcademyRepository
    {
        private readonly DrivingAcademyContext _context;
        public DrivingAcademyRepository(DrivingAcademyContext context)
        {
            _context = context;
        }
        public async Task<Response> CreateDetail(InfoDrivingAcademy info)
        {
            Response response = new();
            try
            {
                var validation = await ValidateDataDetail(info);
                if (validation.validate)
                {
                    foreach (var item in info.lessonIds)
                    {
                        InfoDrivingAcademy detail = new()
                        {
                            StudentId = info.StudentId,
                            LessonId = item
                        };
                        _context.Add(detail);
                    }
                    await _context.SaveChangesAsync();
                    response.StatusCode = HttpStatusCode.OK;
                    response.Message = "Creado con exito.";
                }
                else
                {
                    response = validation.response;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.StatusCode = HttpStatusCode.InternalServerError;
            }
            return response;
        }



        public async Task<Response> CreateStudent(Student student)
        {
            Response response = new();
            try
            {
                var validation = await ValidateDataStudent(student);
                if (validation.validate)
                {
                    _context.Add(student);
                    await _context.SaveChangesAsync();
                    response.StatusCode = HttpStatusCode.OK;
                    response.Message = "Creado con exito.";
                    response.Data = student;
                }
                else
                {
                    response = validation.response;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.StatusCode = HttpStatusCode.InternalServerError;
            }
            return response;
        }


        public async Task<IEnumerable<Lesson>> GetLessonsByModuleId(int moduleId)
        {
            return await _context.TableLessons.Where(x => x.ModuleId == moduleId).ToListAsync();
        }

        public async Task<IEnumerable<Licence>> GetLicences()
        {
            return await _context.TableLicences.ToListAsync();
        }

        public async Task<IEnumerable<Module>> GetModules()
        {
            return await _context.TableModules.ToListAsync();
        }

        public async Task<DetailStudentDTO> GetStudent(int studentId)
        {
            try
            {
                var query = (await (from student in _context.TableStudents.Include(x => x.TypeLicence)
                                    join detalles in _context.TableDetails on student.Id equals detalles.StudentId into detail
                                    from detalle in detail.DefaultIfEmpty()
                                    join lessons in _context.TableLessons.Include(x => x.Module) on detalle.LessonId equals lessons.Id
                                    into lesson
                                    from detailLesson in lesson.DefaultIfEmpty()
                                    where student.Id == studentId
                                    select new
                                    {
                                        student,
                                        detalle,
                                        detailLesson,
                                    }).ToListAsync());

                return query.Select(x => new DetailStudentDTO
                {
                    Age = x.student.Age,
                    Identification = x.student.Identification,
                    Name = x.student.Name,
                    TypeLicence = x.student.TypeLicence.TypeName,
                    StudentId = x.student.Id,

                    Lessons = x.detailLesson != null ? query.Select(x => new LessonDTO
                    {
                        Id = x.detailLesson.Id,
                        Module = x.detailLesson.Module.NameModule,
                        Name = x.detailLesson.NameLesson
                    }).ToList() : new List<LessonDTO>()
                }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _context.TableStudents.ToListAsync();
        }

        private async Task<(Response response, bool validate)> ValidateDataStudent(Student student)
        {
            bool validate = false;
            Response response = new();

            validate = !await _context.TableStudents.AnyAsync(x => x.Identification == student.Identification);
            response.Message = validate == false ? "Ya se encuentra un estudiante registrado por la identificación digitada" : string.Empty;
            response.StatusCode = validate == false ? HttpStatusCode.Conflict : HttpStatusCode.OK;

            if (validate)
            {
                validate = await _context.TableLicences.AnyAsync(x => x.Id == student.TypeLicenceId);
                response.Message = validate == false ? "No existe esa clase de licencia" : string.Empty;
                response.StatusCode = validate == false ? HttpStatusCode.NotFound : HttpStatusCode.OK;
            }
            return (response, validate);
        }
        private async Task<(Response response, bool validate)> ValidateDataDetail(InfoDrivingAcademy info)
        {
            bool validate = false;
            Response response = new();

            validate = await _context.TableStudents.AnyAsync(x => x.Id == info.StudentId);
            response.Message = validate == false ? "No se encuentra el estudiante." : string.Empty;
            response.StatusCode = validate == false ? HttpStatusCode.NotFound : HttpStatusCode.OK;

            if (validate)
            {
                foreach (var item in info.lessonIds)
                {
                    var exist = await _context.TableLessons.FirstOrDefaultAsync(x => x.Id == item);
                    if (exist == null)
                    {
                        validate = false;
                        response.StatusCode = HttpStatusCode.NotFound;
                        response.Message = "No se encuentra la clase seleccionada.";
                        continue;
                    }
                    else
                    {


                        var oneActive = await _context.TableDetails.Include(x => x.Lesson).
                            Where(x => x.StudentId == info.StudentId &&
                            x.Lesson.ModuleId == exist.ModuleId)
                            .CountAsync();
                        if (oneActive >= 1)
                        {
                            response.Message = "No puede tener mas de una clase del mismo modulo";
                            response.StatusCode = HttpStatusCode.Conflict;
                            validate = false;
                            continue;
                        }
                        validate = true;
                    }
                }
            }
            if (validate)
            {
                var repetido = await _context.TableLessons.Where(x => info.lessonIds.Contains(x.Id)).GroupBy(x => new { x.ModuleId })
                    .Select(x => new
                    {
                        count = x.Count(),
                    }).ToListAsync();

                if (repetido.Any(x => x.count > 1))
                {
                    response.Message = "No puede tener mas de una clase del mismo modulo";
                    response.StatusCode = HttpStatusCode.Conflict;
                    validate = false;
                }
                else
                {
                    validate = true;
                    response.StatusCode = HttpStatusCode.OK;
                }
            }
            return (response, validate);
        }
    }
}
