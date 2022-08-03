using AutoMapper;
using DrivingAcademy.DTO_s;
using DrivingAcademy.Entities;

namespace DrivingAcademy.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateStudentDTO, Student>();

            CreateMap<Student, StudentDTO>()
                    .ForMember(dest => dest.StudentId, otp => otp.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, otp => otp.MapFrom(src => src.Name));

            CreateMap<CreateDetailDTO, InfoDrivingAcademy>();
        }
    }
}
