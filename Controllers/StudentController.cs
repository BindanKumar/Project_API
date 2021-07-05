using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_API.Models;

namespace Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        public StudentController(IStudentRepository students)
        {
            Students = students;
        }
        public IStudentRepository Students { get; set; }

        public IEnumerable<Student> GetAll()
        {
            return Students.GetAll();
        }

        [HttpGet("{id}", Name = "GetStudent")]
        public IActionResult GetById(string id)
        {
            var item = Students.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
        [HttpPost]
        public IActionResult Create([FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest();
            }
            Students.Add(student);
            return CreatedAtRoute("GetStudent", new { id = student.ID }, student);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Student student)
        {
            if (student == null || student.ID != id)
            {
                return BadRequest();
            }

            var found = Students.Find(id);
            if (found == null)
            {
                return NotFound();
            }

            Students.Update(student);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            Students.Remove(id);
        }
    }
}
