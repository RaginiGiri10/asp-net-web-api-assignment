using Assignment_1_StudentManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Assignment_1_StudentManagement.Controllers
{
    public class StudentController: ApiController
    {
        [Route("api/student/allStudent")]
        public HttpResponseMessage Get()
        {
            var studentRepository = new StudentRepository();
            var students = studentRepository.GetStudents();
            if (students == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"No student found.");
            }
            return Request.CreateResponse(HttpStatusCode.OK, students);
        }
        [Route("api/student/allStudentbyMarksGreaterthanSixty")]
        public HttpResponseMessage GetMarks()
        {
            var studentRepository = new StudentRepository();
            var student = studentRepository.GetStudentWhoseMarksGreaterThanSixty();
            if (student == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Student with marks greater than sixty not found.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, student);

        }

        public HttpResponseMessage Post(Student student)
        {
            var studentRepository = new StudentRepository();
            var addedStudent = studentRepository.AddStudent(student);
            var responseMessage = Request.CreateResponse(HttpStatusCode.Created);
            responseMessage.Headers.Location = new Uri($"{Request.RequestUri}/{student.Id}");
            return responseMessage;
        }
        public HttpResponseMessage Delete()
        {
            var studentRepository = new StudentRepository();
            var students = studentRepository.GetStudents();
            if (students == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"No student found.");
            }
            else
            {
                studentRepository.DeleteStudent();
                return Request.CreateResponse(HttpStatusCode.OK, $"All student suceessfully removed");
            }
            
        }



    }
}