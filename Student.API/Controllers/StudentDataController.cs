using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.API.Interfaces;
using Student.API.Model;

namespace Student.API.Controllers
{
    // [Route("api/[controller]")]
    [ApiController]
    public class StudentDataController : ControllerBase
    {
        private readonly IDataService _dataService;

        public StudentDataController(IDataService dataService)
        {
            _dataService = dataService;
        }
        // GET: StudentDataController
        [HttpGet]
        [Route("api/Student/GetAllStudents")]
        public IEnumerable<StudentDetails> GetAllStudentsList()
        {
            return _dataService.GetAllStudents();
        }

        [HttpPost]
        [Route("api/Student/CreateStudent")]
        public StudentDetails Create([FromBody] StudentDetails student)
        {
            return _dataService.AddStudent(student);
        }

        [HttpGet]
        [Route("api/Student/Details/{id}")]
        public StudentDetails Details(int id)
        {
            return _dataService.GetStudentById(id);
        }

        [HttpPut]
        [Route("api/Student/Edit")]
        public StudentDetails Edit([FromBody] StudentDetails student)
        {
            return _dataService.UpdateStudent(student);

        }

        [HttpDelete]
        [Route("api/Student/Delete/{id}")]
        public StudentDetails Delete(int id)
        {
            return _dataService.DeleteStudent(id);
        }
    }
}
