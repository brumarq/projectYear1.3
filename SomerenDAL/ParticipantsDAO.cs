using SomerenModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenDAL
{
    public class ParticipantsDAO: BaseDao
    {
            /*public List<Participants> GetAllParticipates()
            {
                List<Participants> participantsList = new List<Participants>();

            SqlCommand cmd = new SqlCommand(sth  sth sth sth);
                OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Participants participants1 = ReadParticipants(reader);
                    participantsList.Add(participants1);
                }
                reader.Close();

                return participantsList;

            }
            public List<Participants> GetallparticipatesByID(int id)
            {
                List<Participants> participantsList = new List<Participants>();
                SqlCommand cmd = new SqlCommand(sth  sth sth sth);
            OpenConnection();
                cmd.Parameters.AddWithValue("@aId", id);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                Participants participants1 = ReadParticipants(reader);
                    participantsList.Add(participants1);
                }
                reader.Close();
                return participantsList;
            }
            private Participants ReadParticipants(SqlDataReader reader)
            {
                Student student1 = new Student()
                {
                    StudentID = (int)reader["lecturerID"],
                    Firstname = (string)(reader["firstname"]),
                    Name = (string)(reader["lastname"]),
                };



            Participants paticipant = new Participants()
                {
                    student = student1,
                    activityID = (int)reader["activityID"],
                    DateActivity = (DateTime)reader["DateTime"],

                };
                return paticipant;
            }
            public void Addparticipants(int id, int sID)
            {

                SqlCommand cmd = new SqlCommand("insert into Participate (studentID,activityID) values(@lID, @aID); ");
                OpenConnection();
                cmd.Parameters.AddWithValue("@aID", id);
                cmd.Parameters.AddWithValue("@lID", sID);
                cmd.ExecuteNonQuery();

            }

            public void Deleteparticipants(int id, int sid)
            {
                SqlCommand cmd = new SqlCommand(" delete from Participate where studentID=@lID and activityID=@aID;");
                OpenConnection();
                cmd.Parameters.AddWithValue("@lID", sid);
                cmd.Parameters.AddWithValue("@aID", id);
                cmd.ExecuteNonQuery();
            }*/
    }
}
