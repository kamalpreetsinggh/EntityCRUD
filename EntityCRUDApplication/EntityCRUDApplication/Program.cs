using EntityCRUDApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCRUDApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("1: Insert Student\n2: View Student Details\n3: Update Student\n4: Delete Student\n5: Exit");
                var option = Console.ReadLine();
                
                if (option == "1")
                {
                    Console.WriteLine("Enter Student Name");
                    var name = Console.ReadLine();

                    Console.WriteLine("Enter Student Age");
                    var age = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter Student Gender");
                    var gender = Console.ReadLine();

                    Insert(name, age, gender);
                    
                    Console.WriteLine("Record Added Successfully");
                    Console.ReadLine();
                }
                else if (option == "2")
                {
                    Console.WriteLine("Enter Student ID");
                    var id = Convert.ToInt32(Console.ReadLine());
                    
                    var student = GetStudentByID((id));
                    if (student != null)
                    {
                        Console.WriteLine("Student Name: " + student.StudentName + "\t" + "Student Age: " + student.StudentAge + "\t" + "Student Gender: " + student.StudentGender);
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Student Not Found");
                        Console.ReadLine();
                    }
                }
                else if (option == "3")
                {
                    Console.WriteLine("Enter Student ID");
                    var id = Convert.ToInt32(Console.ReadLine());

                    var student = GetStudentByID((id));

                    if (student != null)
                    {
                        Console.WriteLine("Enter Student Name");
                        var name = Console.ReadLine();

                        Console.WriteLine("Enter Student Age");
                        var age = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Enter Student Gender");
                        var gender = Console.ReadLine();

                        Update(name, age, gender, student);
                        
                        Console.WriteLine("Record Updated Successfully");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Student Not Found");
                        Console.ReadLine();
                    }
                }
                else if (option == "4")
                {
                    Console.WriteLine("Enter Student ID");
                    var id = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine(Delete(id) ? "Record Deleted Successfully" : "Student Not Found");
                    Console.ReadLine();
                }
                else if (option == "5")
                {
                    break;
                }            
                
            } while (true);
        }

        private static void Insert(string studentName, int studentAge, string studentGender)
        {
            using (var context = new StudentCourses())
            {
                var student = new Student()
                {
                    StudentName = studentName,
                    StudentAge =  studentAge,
                    StudentGender = studentGender
                };

                context.Students.Add(student);
                context.SaveChanges();
            }
        }

        private static void Update(string studentName, int studentAge, string studentGender, Student student)
        {
            using (var context = new StudentCourses())
            {
                student.StudentName = studentName;
                student.StudentAge = studentAge;
                student.StudentGender = studentGender;
                context.SaveChanges();
            }
        }

        private static bool Delete(int studentID)
        {
            using (var context = new StudentCourses())
            {
                var student = GetStudentByID((studentID));
                
                if (student != null)
                {
                    context.Students.Remove(student);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private static Student GetStudentByID(int studentID)
        {
            using (var context = new StudentCourses())
            {
                var student = context.Students.FirstOrDefault(x => x.StudentID == studentID);
                return student;
            }
        }
    }
}
