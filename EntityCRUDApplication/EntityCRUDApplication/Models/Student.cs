using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCRUDApplication.Models
{
    public class Student
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string StudentGender { get; set; }
        public int StudentAge { get; set; }

        public int CourseID { get; set; }
        public Course StudentCourse { get; set; }
    }
}
