using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenLogic
{
    public class UserService
    {
        UserDao userdb;


        public UserService()
        {
            userdb = new UserDao();

        }

        public List<User> GetLoginInfo(string username)
        {
            List<User> users = userdb.GetLoginInfo(username);
            return users;
        }
    }
}
