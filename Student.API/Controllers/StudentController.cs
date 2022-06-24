using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student.API.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Student.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentBDContext _myWorldDbContext;
        public StudentController(StudentBDContext myWorldDbContext)
        {
            _myWorldDbContext = myWorldDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var students = await _myWorldDbContext.Student.ToListAsync();
            return Ok(students);
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        // POST api/<StudentController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Student.API.Data.Model.Student payload)
        {
            _myWorldDbContext.Student.Add(payload);
            await _myWorldDbContext.SaveChangesAsync();
            return Ok(payload);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Student.API.Data.Model.Student payload)
        {
            _myWorldDbContext.Student.Update(payload);
            await _myWorldDbContext.SaveChangesAsync();
            return Ok(payload);
        }

        // DELETE api/<StudentController>/5
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var studentToDelete = await _myWorldDbContext.Student.FindAsync(id);
            if (studentToDelete == null)
            {
                return NotFound();
            }
            _myWorldDbContext.Student.Remove(studentToDelete);
            await _myWorldDbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
