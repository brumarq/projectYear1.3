using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Student
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Firstname { get; set; }
        public int StudentNumber { get; set; } // StudentNumber, e.g. 474791
        public string Telephone { get; set; }
        public string Email { get; set; }
        public int RoomId { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
