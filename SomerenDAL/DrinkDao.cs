using SomerenModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenDAL
{
    public class DrinkDao : BaseDao
    {
        public List<Drink> GetAllDrinks()
        {
            string query = "SELECT drinkID, stock, name, salesPrice, drinkType FROM [dbo].[Drinks] WHERE stock > 1 AND salesPrice > 1;";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
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
