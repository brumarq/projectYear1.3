using SomerenDAL;
using SomerenModel;
using System.Collections.Generic;

namespace SomerenLogic
{
    public class LecturerService
    {
        LecturerDao teacherdb;

        public LecturerService()
        {
            teacherdb = new LecturerDao();
        }

        public List<Teacher> GetTeachers()
        {
            List<Teacher> lecturers = teacherdb.GetAllLecturers();
            return lecturers;
        }
    }
}
