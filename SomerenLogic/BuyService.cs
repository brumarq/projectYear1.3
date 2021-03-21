using SomerenModel;
using SomerenDAL;
using System.Collections.Generic;

namespace SomerenLogic
{
    public class BuyService
    {
        BuyDao buydb;
        DrinkDao drinkdb;
        StudentDao studentdb;


        public BuyService()
        {
            buydb = new BuyDao();
            drinkdb = new DrinkDao();
            studentdb = new StudentDao();

        }

        public List<Drink> GetCashierDrinks()
        {
            List<Drink> drinks = drinkdb.GetAllDrinks();
            return drinks;
        }

        public List<Student> GetCashierStudents()
        {
            List<Student> students = studentdb.GetAllStudents();
            return students;
        }

        public void Buy(Drink drinkId, Student studentId)
        {
            buydb.Buy(drinkId, studentId);
        }
    }
}
