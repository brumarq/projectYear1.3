using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Participants
    {
        public Student student {get; set;}
        public int activityID {get; set;}
    public DateTime DateActivity {get; set;}
public string FullName { get { return student.Name + ", " + student.Firstname; } }
    }
}
