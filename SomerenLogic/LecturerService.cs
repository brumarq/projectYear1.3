using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
