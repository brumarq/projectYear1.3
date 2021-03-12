using SomerenModel;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SomerenDAL
{
    public class LecturerDao : BaseDao
    {
        public List<Teacher> GetAllLecturers()
        {
            string query = "SELECT teacherID, name, firstName, telephone, email FROM [dbo].[Teachers]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Teacher> ReadTables(DataTable dataTable)
        {
            List<Teacher> lecturers = new List<Teacher>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Teacher lecturer = new Teacher()
                {
                    TeacherNumber = (int)dr["teacherID"],
                    Name = dr["name"].ToString(),
                    FirstName = dr["firstName"].ToString(),
                    Telephone = dr["telephone"].ToString(),
                    Email = dr["email"].ToString(),
                };
                lecturers.Add(lecturer);
            }
            return lecturers;
        }
    }
}
