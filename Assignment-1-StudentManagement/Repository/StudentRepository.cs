using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Assignment_1_StudentManagement.Repository
{
    public class StudentRepository
    {
        
        public List<Student> GetStudents()
        {
            List<Student> studentList;
            using (StudentDBEntities studentDBEntities = new StudentDBEntities())
            {
                studentList = new List<Student>();
                studentList = studentDBEntities.Students.ToList();
            }
            return studentList;
        }
        
        public List<Student> GetStudentWhoseMarksGreaterThanSixty()
        {
            List<Student> studentList;
            using (StudentDBEntities studentDBEntities = new StudentDBEntities())
            {
                
                studentList = studentDBEntities.Students.Where(p => p.Marks>60).ToList();
            }
            return studentList;
        }
        public Student AddStudent(Student student)
        {
            using (StudentDBEntities studentDBEntities = new StudentDBEntities())
            {
                studentDBEntities.Students.Add(student);
                studentDBEntities.SaveChanges();
                return student;
            }
        }
        public void DeleteStudent()
        {

            using (StudentDBEntities studentDBEntities = new StudentDBEntities())
            {
                var allStudents = from m in studentDBEntities.Students
                                  select m;
                foreach (var allstudent in allStudents)
                {
                    studentDBEntities.Students.Remove(allstudent);
                }
                studentDBEntities.SaveChanges();
               
            }
        }
    }
}