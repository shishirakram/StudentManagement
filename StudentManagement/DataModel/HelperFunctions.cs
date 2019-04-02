using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.DataModel
{
    public class HelperFunctions
    {
        public static List<Student> Students = new List<Student>();
        public static int count = 0;
        public static void createStudents()
        {
            if (count == 0)
            {
                //List<Student> Students = new List<Student>();
                Subject sub1 = new Subject()
                {
                    Maths = 100,
                    Science = 99,
                    SocialScience = 90,
                    Kannada = 98,
                    English = 100,
                    Hindi = 100
                };
                Standard std7 = new Standard()
                {
                    StandardId = 1,
                    StandardName = "7th"
                };
                Standard std8 = new Standard()
                {
                    StandardId = 2,
                    StandardName = "8th"
                };
                Student First = new Student()
                {
                    Name = "Shishira",
                    Id = 1,
                    Address = "Bangalore",
                    subject = sub1,
                    standard = std7

                };
                Subject sub2 = new Subject()
                {
                    Maths = 35,
                    Science = 35,
                    SocialScience = 40,
                    Kannada = 98,
                    English = 100,
                    Hindi = 100
                };
                Student Second = new Student()
                {
                    Name = "Shashwathi",
                    Id = 2,
                    Address = "Bangalore",
                    subject = sub2,
                    standard = std8

                };

                Subject sub3 = new Subject()
                {
                    Maths = 35,
                    Science = 35,
                    SocialScience = 40,
                    Kannada = 98,
                    English = 100,
                    Hindi = 100
                };
                Students.Add(First);
                Students.Add(Second);
            }
            count++;
            return ;

        }
        public static List<Student> AddStudent(List<Student> StudentList, Student std)
        {
            StudentList.Add(std);
            return StudentList;
        }
    }
}
