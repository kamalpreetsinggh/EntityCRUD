using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCRUDApplication.Models
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }
        public string CoursedName { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
