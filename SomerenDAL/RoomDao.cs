using SomerenModel;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace SomerenDAL
{
    public class RoomDao : BaseDao
    {
        public List<Room> GetAllRooms()
        {
            string query = "SELECT roomNumber, roomCapacity, roomType FROM [dbo].[Rooms]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Room> ReadTables(DataTable dataTable)
        {
            List<Room> room = new List<Room>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Room Room = new Room()
                {
                    Number = (int)dr["roomNumber"],
                    Capacity = (int)(dr["roomCapacity"]),
                    Type = (dr["roomType"].ToString()),
                };
                room.Add(Room);
            }
            return room;
        }
    }
}