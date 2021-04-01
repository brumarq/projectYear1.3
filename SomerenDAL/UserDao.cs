using SomerenModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenDAL
{
    public class UserDao : BaseDao
    {
        public List<User> GetLoginInfo(string username)
        {
            string query = "SELECT userId, username, passwordHashed, adminStatus FROM users WHERE username = @username";
            SqlParameter[] sqlParameters = {
                new SqlParameter("@username", username),
            };
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<User> ReadTables(DataTable dataTable)
        {
            List<User> users = new List<User>();

            foreach (DataRow dr in dataTable.Rows)
            {
                User user = new User()
                {
                    UserId = (int)dr["userId"],
                    Username = dr["username"].ToString(),
                    PasswordHashed = dr["passwordHashed"].ToString(),
                    AdminStatus = dr["adminStatus"].ToString(),
                };
                users.Add(user);
            }
            return users;
        }
    }
}
