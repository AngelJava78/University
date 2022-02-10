using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BL.Models;

namespace University.BL.Dtos
{
    public class MapperConfig
    {
        public static MapperConfiguration MapperConfiguration()
        {
            return new MapperConfiguration(config =>
            {
                config.CreateMap<Course, CourseDTO>(); //GET
                config.CreateMap<CourseDTO, Course>(); //POST, PUT
                config.CreateMap<Student, StudentDTO>();
                config.CreateMap<StudentDTO, Student>();
                config.CreateMap<Enrollment, EnrollmentDTO>();
                config.CreateMap<EnrollmentDTO, Enrollment>();
            });
        }
    }
}
