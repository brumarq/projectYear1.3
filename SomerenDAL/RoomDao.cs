﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using SomerenModel;


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