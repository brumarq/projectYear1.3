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
    public class ActivityDao : BaseDao
    {
        public List<Activity> GetActivities()
        {
            string query = "SELECT activityID, name, date FROM [dbo].[Activities];";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        public void Update(Activity activity)
        {
            string query = "UPDATE Activities SET name = @name, date = @date WHERE drinkID=@drinkID";
            SqlParameter[] sqlParameters = {
                new SqlParameter("@name", activity.Name),
                new SqlParameter("@stock", activity.Date),
            };

            ExecuteEditQuery(query, sqlParameters);
        }

        public void Delete(int activityId)
        {
            string query = "DELETE FROM Activities WHERE activityID=@activityID";
            SqlParameter[] sqlParameters = {
                new SqlParameter("@activityID", activityId),
            };

            ExecuteEditQuery(query, sqlParameters);
        }

        public void Add(Activity activity)
        {
            string query = "INSERT INTO Activities (name, date) VALUES (@name, @date) SELECT SCOPE_IDENTITY();";
            SqlParameter[] sqlParameters = {
                new SqlParameter("@name", activity.Name),
                new SqlParameter("@date", activity.Date),
            };

            ExecuteEditQuery(query, sqlParameters);
        }

        private List<Activity> ReadTables(DataTable dataTable)
        {
            List<Activity> activities = new List<Activity>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Activity activity = new Activity()
                {
                    ActivityID = (int)dr["activityID"],
                    Name = dr["name"].ToString(),
                    Date = (DateTime)dr["date"],
                };
                activities.Add(activity);
            }
            return activities;
        }
    }
}
