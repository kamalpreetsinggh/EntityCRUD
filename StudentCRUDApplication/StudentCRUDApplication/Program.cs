using System;
using System.Collections.Generic;
using System.Linq;
using StudentCRUDApplication.Models;

namespace StudentCRUDApplication
{
    internal class Program
    {
        private static void Main(string[] args)
        { 
            do
            {
                Console.WriteLine("1: Insert Student\n2: View Student Details\n3: Update Student\n4: Delete Student\n5: Add Course\n6: Exit");
                var option = Console.ReadLine();

                if (option == "1")
                {
                    Console.WriteLine("Enter Student Name");
                    var name = Console.ReadLine();

                    Console.WriteLine("Enter Student Age");
                    var age = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter Student Gender");
                    var gender = Console.ReadLine();

                    var studentCourse = new StudentCourse();

                    foreach (var course in studentCourse.Courses)
                    {
                        Console.WriteLine(course.CourseID + ":" + "\t" + course.CoursedName);
                    }

                    Console.WriteLine("Enter Course ID");
                    var courseID = Convert.ToInt32(Console.ReadLine());

                    Insert(name, age, gender, courseID);

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

                        var studentCourse = new StudentCourse();

                        foreach (var course in studentCourse.Courses)
                        {
                            Console.WriteLine(course.CourseID + ":" + "\t" + course.CoursedName);
                        }

                        Console.WriteLine("Enter Course ID");
                        var courseID = Convert.ToInt32(Console.ReadLine());

                        Update(name, age, gender, courseID, student.StudentID);

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
                else if (option=="5")
                {
                    Console.WriteLine("Enter Course Name");
                    var courseName = Console.ReadLine();

                    AddCourse(courseName);

                    Console.WriteLine("Course Added Successfully");
                    Console.ReadLine();
                }
                else if (option == "6")
                {
                    break;
                }

            } while (true);
        }

        private static void Insert(string studentName, int studentAge, string studentGender, int studentCourseID)
        {
            using (var context = new StudentCourse())
            {
                var student = new Student()
                {
                    StudentName = studentName,
                    StudentAge = studentAge,
                    StudentGender = studentGender,
                    CourseID = studentCourseID
                };

                context.Students.Add(student);
                context.SaveChanges();
            }
        }

        private static void Update(string studentName, int studentAge, string studentGender, int studentCourseID, int studentID)
        {
            using (var context = new StudentCourse())
            {
                var student = context.Students.FirstOrDefault(x => x.StudentID == studentID);

                if (student != null)
                {
                    student.StudentName = studentName;
                    student.StudentAge = studentAge;
                    student.StudentGender = studentGender;
                    student.CourseID = studentCourseID;
                }

                context.SaveChanges();
            }
        }

        private static bool Delete(int studentID)
        {
            using (var context = new StudentCourse())
            {
                var student = context.Students.FirstOrDefault(x => x.StudentID == studentID);

                if (student == null) return false;
                context.Students.Remove(student);
                context.SaveChanges();
                return true;

            }
        }

        private static Student GetStudentByID(int studentID)
        {
            using (var context = new StudentCourse())
            {
                var student = context.Students.FirstOrDefault(x => x.StudentID == studentID);
                return student;
            }
        }

        private static void AddCourse(string courseName)
        {
            using (var context = new StudentCourse())
            {
                var course = new Course() 
                {
                    CoursedName = courseName
                };

                context.Courses.Add(course);
                context.SaveChanges();
            }
        }
    }
}
