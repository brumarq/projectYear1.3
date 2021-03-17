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

        public void UpdateDrinks(Drink drink)
        {
            drinkdb.Update(drink);
        }

        public void DeleteDrink(int drinkID)
        {
            drinkdb.Delete(drinkID);
        }

        public void AddDrink(Drink drink)
        {
            drinkdb.Add(drink);
        }
    }
}
