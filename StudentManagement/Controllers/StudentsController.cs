using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.DataModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentManagement.Controllers
{
    // List<Student> Students = new List<Student>();
   
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {


         // GET: api/<controller>
         [HttpGet]
        public IEnumerable<Student> GetAllStudents()
        {
             HelperFunctions.createStudents();
            List<Student> Student = null;

            Student = HelperFunctions.Students.Select(s => new Student()
                        {
                            Id = s.Id,
                            Name = s.Name,
                            Address = s.Address,
                            standard = s.standard,
                            subject = s.subject
                        }).ToList<Student>();
            return Student;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Student GetStudentsById(int id)
        {
            Student std = null;
            std = HelperFunctions.Students.Where(s => s.Id == id)
                    .Select(s => new Student()
            {
                        Id = s.Id,
                        Name = s.Name,
                        Address = s.Address,
                        standard = s.standard,
                        subject = s.subject
                    }).SingleOrDefault<Student>();
            return std;
        }

        // POST api/<controller>
        [HttpPost]
        public void CreateStudent([FromBody]Student student)
        {
            if (!ModelState.IsValid)
                return;
            HelperFunctions.Students = HelperFunctions.AddStudent(HelperFunctions.Students, student);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
