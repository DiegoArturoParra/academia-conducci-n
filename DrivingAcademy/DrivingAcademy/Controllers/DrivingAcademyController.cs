using AutoMapper;
using DrivingAcademy.DTO_s;
using DrivingAcademy.Entities;
using DrivingAcademy.repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrivingAcademy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrivingAcademyController : ControllerBase
    {
        private readonly IDrivingAcademyRepository _drivingAcademyRepository;
        private readonly IMapper _mapper;

        public DrivingAcademyController(IDrivingAcademyRepository drivingAcademyRepository, IMapper mapper)
        {
            _drivingAcademyRepository = drivingAcademyRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("list-students")]
        public async Task<IActionResult> ListStudents()
        {
            var listado = await _drivingAcademyRepository.GetStudents();
            var students = _mapper.Map<IEnumerable<Student>, IEnumerable<StudentDTO>>(listado);
            return Ok(students);
        }

        [HttpGet]
        [Route("list-modules")]
        public async Task<IActionResult> GetModules()
        {
            return Ok(await _drivingAcademyRepository.GetModules());
        }


        [HttpGet]
        [Route("list-lessons-by-module/{id}")]
        public async Task<IActionResult> GetLessonsByModuleId(int id)
        {
            return Ok(await _drivingAcademyRepository.GetLessonsByModuleId(id));
        }

        [HttpGet]
        [Route("list-licences")]
        public async Task<IActionResult> GetLicences()
        {
            return Ok(await _drivingAcademyRepository.GetLicences());
        }



        [HttpGet]
        [Route("student/{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _drivingAcademyRepository.GetStudent(id);
            return Ok(student);
        }

        [HttpPost]
        [Route("create-student")]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentDTO createStudent)
        {
            var student = _mapper.Map<Student>(createStudent);
            var response = await _drivingAcademyRepository.CreateStudent(student);
            return StatusCode((int)response.StatusCode, response.Message);
        }

        [HttpPost]
        [Route("create-detail")]
        public async Task<IActionResult> CreateDetail([FromBody] CreateDetailDTO createDetail)
        {
            var detail = _mapper.Map<InfoDrivingAcademy>(createDetail);
            var response = await _drivingAcademyRepository.CreateDetail(detail);
            return StatusCode((int)response.StatusCode, response.Message);
        }
    }
}
