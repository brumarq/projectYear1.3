using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenLogic
{
    public class ActivityService
    {
        ActivityDao activitydb;

        public ActivityService()
        {
            activitydb = new ActivityDao();
        }
        public List<Activity> GetActivities()
        {
            List<Activity> activities = activitydb.GetActivities();
            return activities;
        }

        public void UpdateActivities(Activity activity)
        {
            activitydb.Update(activity);
        }

        public void DeleteActivity(Activity activity)
        {
            activitydb.Delete(activity);
        }

        public void AddActivity(Activity activity)
        {
            activitydb.Add(activity);
        }
    }
}
