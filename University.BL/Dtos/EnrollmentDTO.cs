using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.BL.Dtos
{
    public class EnrollmentDTO
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public CourseDTO CourseDTO { get; set; }
        public StudentDTO StudentDTO { get; set; }
        public Grade Grade { get; set; }

    }
}
