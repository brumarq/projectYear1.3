using SomerenModel;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SomerenDAL
{
    public class DrinkDao : BaseDao
    {
        public List<Drink> GetAllDrinks()
        {
            string query = "SELECT drinkID, stock, name, salesPrice, drinkType FROM [dbo].[Drinks] WHERE stock > 0 AND salesPrice > 1;";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        public void Update(Drink drink)
        {
            string query = "UPDATE Drinks SET name = @name, stock = @stock, salesPrice = @salesPrice WHERE drinkID=@drinkID";
            SqlParameter[] sqlParameters = {
                new SqlParameter("@name", drink.Name),
                new SqlParameter("@stock", drink.Stock),
                new SqlParameter("@salesPrice", drink.SalesPrice),
                new SqlParameter("@drinkID", drink.DrinkID)
            };

            ExecuteEditQuery(query, sqlParameters);
        }

        private List<Drink> ReadTables(DataTable dataTable)
        {
            List<Drink> drinks = new List<Drink>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Drink drink = new Drink()
                {
                    DrinkID = (int)dr["drinkID"],
                    Stock = (int)(dr["stock"]),
                    Name = dr["name"].ToString(),
                    SalesPrice = (double)(dr["salesPrice"]),
                    DrinkType = dr["drinkType"].ToString(),
                };
                drinks.Add(drink);
            }
            return drinks;
        }
    }
}
