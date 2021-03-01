using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using SomerenModel;

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
                    studentNumber = (int)dr["studentNumber"],
                    name = (String)(dr["name"].ToString()),
                    firstName = (String)(dr["firstName"].ToString()),
                    telephone = (String)(dr["telephone"].ToString()),
                    email = (String)(dr["email"].ToString()),
                };
                students.Add(student);
            }
            return students;
        }
    }
}
