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
    public class BuyDao : BaseDao
    {
        public void Buy(Drink drink, Student student)
        {
            string query = "INSERT INTO buy (studentID, drinkID) VALUES (@studentID, @drinkID)";
            SqlParameter[] sqlParameters = {
                new SqlParameter("@studentID", student.StudentID),
                new SqlParameter("@drinkID", drink.DrinkID),
            };

            ExecuteEditQuery(query, sqlParameters);
        }
    }
}
