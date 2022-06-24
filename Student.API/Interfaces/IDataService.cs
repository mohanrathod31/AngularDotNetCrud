using Student.API.Model;

namespace Student.API.Interfaces
{
    public interface IDataService
    {
        IEnumerable<StudentDetails> GetAllStudents();

        StudentDetails AddStudent(StudentDetails student);

        StudentDetails UpdateStudent(StudentDetails student);

        StudentDetails GetStudentById(int id);

        StudentDetails DeleteStudent(int id);
    }
}
