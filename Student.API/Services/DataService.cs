using Microsoft.Data.SqlClient;
using Student.API.Interfaces;
using Student.API.Model;
using System.Data;

namespace Student.API.Services
{
    public class DataService : IDataService
    {
        private readonly IConfiguration Configuration;

        public DataService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //To View all employees details
        public IEnumerable<StudentDetails> GetAllStudents()
        {
            try
            {
                List<StudentDetails> lstStudent = new List<StudentDetails>();

                using (SqlConnection con = new SqlConnection(Configuration.GetConnectionString("DefaultConnection")))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllStudents", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        StudentDetails student = new StudentDetails();

                        student.Id = Convert.ToInt32(rdr["Id"]);
                        student.Name = rdr["Name"].ToString();
                        student.Age = Convert.ToInt32(rdr["Age"]);
                        student.Gender = rdr["Gender"].ToString();

                        lstStudent.Add(student);
                    }
                    con.Close();
                }
                return lstStudent;
            }
            catch
            {
                throw;
            }
        }

        //To Add new employee record 
        public StudentDetails AddStudent(StudentDetails student)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Configuration.GetConnectionString("DefaultConnection")))
                {
                    SqlCommand cmd = new SqlCommand("spAddStudent", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", student.Name);
                    cmd.Parameters.AddWithValue("@Age", student.Age);
                    cmd.Parameters.AddWithValue("@Gender", student.Gender);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return student;
            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particluar employee
        public StudentDetails UpdateStudent(StudentDetails student)
        {
            try
            {
               // StudentDetails student = new StudentDetails();
                using (SqlConnection con = new SqlConnection(Configuration.GetConnectionString("DefaultConnection")))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateStudent", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", student.Id);
                    cmd.Parameters.AddWithValue("@Name", student.Name);
                    cmd.Parameters.AddWithValue("@Age", student.Age);
                    cmd.Parameters.AddWithValue("@Gender", student.Gender);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return student;
            }
            catch
            {
                throw;
            }
        }

        //Get the details of a particular employee
        public StudentDetails GetStudentById(int id)
        {
            try
            {
                StudentDetails student = new StudentDetails();

                using (SqlConnection con = new SqlConnection(Configuration.GetConnectionString("DefaultConnection")))
                {
                    SqlCommand cmd = new SqlCommand("spGetStudentById", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("Id", id);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        student.Id = Convert.ToInt32(rdr["Id"]);
                        student.Name = rdr["Name"].ToString();
                        student.Age = Convert.ToInt32(rdr["Age"]);
                        student.Gender = rdr["Gender"].ToString();

                    }
                }
                return student;
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record on a particular employee
        public StudentDetails DeleteStudent(int id)
        {
            try
            {
                StudentDetails student = new StudentDetails();
                using (SqlConnection con = new SqlConnection(Configuration.GetConnectionString("DefaultConnection")))
                {
                    SqlCommand cmd = new SqlCommand("spDeleteStudent", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return student;
            }
            catch
            {
                throw;
            }
        }
    }

}

