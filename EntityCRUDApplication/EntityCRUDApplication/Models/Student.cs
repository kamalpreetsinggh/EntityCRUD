using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCRUDApplication.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public Course Course { get; set; }

    }
}
