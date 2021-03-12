using SomerenModel;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SomerenDAL
{
    public class StudentDao : BaseDao
    {
        public List<Student> GetAllStudents()
        {
            string query = "SELECT studentNumber, name, firstName, telephone, email FROM [dbo].[Students]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Student> ReadTables(DataTable dataTable)
        {
            List<Student> students = new List<Student>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Student student = new Student()
                {
                    StudentNumber = (int)dr["studentNumber"],
                    Name = dr["name"].ToString(),
                    Firstname = dr["firstName"].ToString(),
                    Telephone = dr["telephone"].ToString(),
                    Email = dr["email"].ToString(),
                };
                students.Add(student);
            }
            return students;
        }
    }
}
