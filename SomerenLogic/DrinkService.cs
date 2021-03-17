using SomerenDAL;
using SomerenModel;
using System.Collections.Generic;

namespace SomerenLogic
{
    public class DrinkService
    {
        DrinkDao drinkdb;

        public DrinkService()
        {
            drinkdb = new DrinkDao();
        }

        public List<Drink> GetDrinks()
        {
            List<Drink> drinks = drinkdb.GetAllDrinks();
            return drinks;
        }
    }
}
