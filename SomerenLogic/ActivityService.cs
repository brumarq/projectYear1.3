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
            List<Activity> drinks = activitydb.GetActivities();
            return drinks;
        }

        public void UpdateActivities(Activity drink)
        {
            activitydb.Update(drink);
        }

        public void DeleteActivity(int drinkID)
        {
            activitydb.Delete(drinkID);
        }

        public void AddActivity(Activity drink)
        {
            activitydb.Add(drink);
        }
    }
}
