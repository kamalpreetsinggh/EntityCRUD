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
                Console.WriteLine("1: Insert\n2: Update\n3: Delete\n4: Exit");
                string option = Console.ReadLine();
                if (option == "1")
                {
                    Console.WriteLine("Enter student ID");
                    int id = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter student Name");
                    string name = Console.ReadLine();

                    Console.WriteLine("Enter student age");
                    int age = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter student gender");
                    string gender = Console.ReadLine();

                    //Console.WriteLine("Enter date of birth");
                    //DateTime dateOfBirth = Convert.ToDateTime(Console.ReadLine());

                    Insert(id, name, age, gender);
                }
                else if (option == "4")
                {
                    break;
                }
            } while (true);

        }

        static void Insert(int id, string name, int age, string gender)
        {
            using (var context = new StudentCourses())
            {
                var student = new Student()
                {
                    StudentID = id,
                    StudentName = name,
                    Age = age,
                    Gender = gender
                };

                context.Students.Add(student);
                context.SaveChanges();
            }
        }
    }
}
