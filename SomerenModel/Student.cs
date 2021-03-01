using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Student
    {
        public String name { get; set; }
        public String firstName { get; set; }
        public int studentNumber { get; set; } // StudentNumber, e.g. 474791
        public string telephone { get; set; }
        public string email { get; set; }
        public Room roomId { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
