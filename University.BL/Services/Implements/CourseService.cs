using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.BL.Data;
using University.BL.Models;
using University.BL.Repositories;

namespace University.BL.Services.Implements
{
    public class CourseService: GenericService<Course>, ICourseService
    {
        public CourseService(ICourseRepository repository): base(repository)
        {

        }
       
    }
}
