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
        private void checkIfActivityExists(Activity activity)
        {
            string query = "SELECT activityID, name, date FROM [dbo].[Activities] WHERE name=@name;";
            SqlParameter sqlParameters = new SqlParameter("@name", activity.Name);

            DataTable dataTable = ExecuteSelectQuery(query, sqlParameters);
            if (dataTable.Rows.Count >= 1)
            {
                throw new Exception("That Activity already exists. Choose another name.");
            }
        }
        public List<Activity> GetActivities()
        {
            string query = "SELECT activityID, name, date FROM [dbo].[Activities];";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        public void Update(Activity activity)
        {
            checkIfActivityExists(activity);

            string query = "UPDATE Activities SET name = @name, date = @date WHERE activityID=@activityID";
            SqlParameter[] sqlParameters = {
                new SqlParameter("@activityID", activity.ActivityID),
                new SqlParameter("@name", activity.Name),
                new SqlParameter("@date", activity.Date),
            };

            ExecuteEditQuery(query, sqlParameters);
        }

        public void Delete(Activity activity)
        {
            string query = "DELETE FROM Activities WHERE activityID=@activityID";
            SqlParameter[] sqlParameters = {
                new SqlParameter("@activityID", activity.ActivityID),
            };

            ExecuteEditQuery(query, sqlParameters);
        }

        public void Add(Activity activity)
        {
            checkIfActivityExists(activity);

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
