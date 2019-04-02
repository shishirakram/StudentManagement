using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.DataModel;

namespace UI.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<Student> students = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44388/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Students");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Student>>();
                    readTask.Wait();

                    students = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    students = Enumerable.Empty<Student>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(students);

        }
        public ActionResult create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> create(Student student)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:44388/api/");

                //HTTP POST
                var postTask = await client.PostAsJsonAsync<Student>("Students", student);
               // postTask.Wait();

                //var result = postTask.Result;
                //if (result.IsSuccessStatusCode)
                //{
                    return RedirectToAction("Index");
                //}
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(student);
        }
    
    }
}