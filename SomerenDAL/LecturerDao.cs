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
                    teacherNumber = (int)dr["teacherID"],
                    name = (String)(dr["name"].ToString()),
                    firstName = (String)(dr["firstName"].ToString()),
                    telephone = (String)(dr["telephone"].ToString()),
                    email = (String)(dr["email"].ToString()),
                };
                lecturers.Add(lecturer);
            }
            return lecturers;
        }
    }
}
