using SomerenLogic;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SomerenUI
{
    public partial class SomerenUI : Form
    {
        public SomerenUI()
        {
            InitializeComponent();
        }

        private void SomerenUI_Load(object sender, EventArgs e)
        {
            showPanel("Dashboard");
        }

        private void showPanel(string panelName)
        {

            if (panelName == "Dashboard")
            {
                // hide all other panels
                pnlStudents.Hide();
                pnlLecturers.Hide();

                // show dashboard
                pnlDashboard.Show();
                imgDashboard.Show();
            }
            else if (panelName == "Students")
            {
                // hide all other panels
                pnlDashboard.Hide();
                imgDashboard.Hide();

                // show students
                pnlStudents.Show();
                pnlLecturers.Hide();

                try
                {
                    // fill the students listview within the students panel with a list of students
                    StudentService studService = new StudentService(); ;
                    List<Student> studentList = studService.GetStudents(); ;

                    // clear the listview before filling it again
                    listViewStudents.Clear();

                    listViewStudents.Columns.Add("Student Number", 100);
                    listViewStudents.Columns.Add("First Name", 100);
                    listViewStudents.Columns.Add("Name", 100);
                    listViewStudents.View = View.Details;

                    foreach (SomerenModel.Student s in studentList)
                    {
                        ListViewItem li2 = new ListViewItem(new string[] {
                            s.StudentNumber.ToString(),
                            s.Firstname,
                            s.Name
                        });
                        listViewStudents.Items.Add(li2);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong while loading the students: " + e.Message);
                }
            }
            else if (panelName == "Lecturers")
            {
                // hide all other panels
                pnlDashboard.Hide();
                imgDashboard.Hide();
                

                // show students
                pnlLecturers.Show();
                pnlStudents.Hide();

                try
                {
                    // fill the students listview within the students panel with a list of students
                    LecturerService lecturerService = new LecturerService();
                    List<Teacher> lecturersList = lecturerService.GetTeachers();

                    // clear the listview before filling it again
                    listViewLecturers.Clear();

                    listViewLecturers.Columns.Add("Lecturer ID", 100);
                    listViewLecturers.Columns.Add("First Name", 100);
                    listViewLecturers.Columns.Add("Name", 100);
                    listViewLecturers.View = View.Details;

                    foreach (SomerenModel.Teacher s in lecturersList)
                    {
                        ListViewItem li = new ListViewItem(new string[] {
                        s.TeacherNumber.ToString(),
                        s.FirstName,
                        s.Name
                    });
                        listViewLecturers.Items.Add(li);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong while loading the teachers: " + e.Message);
                }
            }
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dashboardToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showPanel("Dashboard");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void imgDashboard_Click(object sender, EventArgs e)
        {
            MessageBox.Show("What happens in Someren, stays in Someren!");
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Students");
        }
        private void lecturersToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            showPanel("Lecturers");
        }
    }
}
