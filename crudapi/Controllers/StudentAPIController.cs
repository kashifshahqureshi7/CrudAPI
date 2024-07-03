using crudapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crudapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly StudentDBContext context;

        public StudentAPIController(StudentDBContext context)
        {
            this.context = context;
        }
        [HttpGet]
      public async Task<ActionResult <List<Student>>> GetStudents()
        {
          var data=await context.Students.ToListAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentbyid(int id)
        {
            var std=await context.Students.FindAsync(id);
            if (std == null) 
            {
                return NotFound();
            }
            return Ok(std);
        }
        [HttpPost]
        public async Task<ActionResult<List<Student>>> AddStudent(Student std)
        {
            await context.Students.AddAsync(std);
            await context.SaveChangesAsync();
            return Ok(std);
        }
        [HttpPut]
        public async Task<ActionResult<List<Student>>> UpdateStudent(int id,Student std)
        {
            

            var student = await context.Students.FindAsync(id);
            if (student == null) return BadRequest();

            if (!string.IsNullOrEmpty(std.Name))
            {
                student.Name = std.Name;
            }

            if (!string.IsNullOrEmpty(std.Gender))
            {
                student.Gender = std.Gender;
            }
            if (std.Age != null && std.Age > 0) student.Age = std.Age;
           

            context.Entry(student).State= EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(std);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Student>>> DeleteStundent(int id)
        {
            var std = await context.Students.FindAsync(id);
            if(std == null)
            {
                return NotFound();
            }
            context.Students.Remove(std);
            await context.SaveChangesAsync();
            return Ok();

        }
    }
}
