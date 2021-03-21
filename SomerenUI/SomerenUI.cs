using SomerenLogic;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace SomerenUI
{
    public partial class SomerenUI : Form
    {
        private EventLog appLog = new EventLog("Application"); // Initiate EventLog

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
            EventLog appLog = new EventLog("Application"); // Initiate EventLog

            if (panelName == "Dashboard")
            {
                // hide all other panels
                pnlStudents.Hide();
                pnlLecturers.Hide();
                pnlRooms.Hide();

                // show dashboard
                pnlDashboard.Show();
                imgDashboard.Show();
            }
            else if (panelName == "Students")
            {
                // hide all other panels
                pnlDashboard.Hide();
                imgDashboard.Hide();
                pnlLecturers.Hide();
                pnlRooms.Hide();
                pnlDrinks.Hide();
                pnlCashRegister.Hide();

                // show students
                pnlStudents.Show();

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
                        ListViewItem li = new ListViewItem(new string[] {
                            s.StudentNumber.ToString(),
                            s.Firstname,
                            s.Name
                        });
                        listViewStudents.Items.Add(li); // Add all the values to the listview
                    }
                }
                catch (Exception e)
                {
                    appLog.Source = "Loading Panel Students";
                    appLog.WriteEntry(e.Message);
                    MessageBox.Show("Something went wrong while loading the students: " + e.Message);
                }
            }
            else if (panelName == "Lecturers")
            {
                // hide all other panels
                pnlDashboard.Hide();
                imgDashboard.Hide();
                pnlStudents.Hide();
                pnlRooms.Hide();
                pnlDrinks.Hide();
                pnlCashRegister.Hide();

                // show lecturers
                pnlLecturers.Show();

                try
                {
                    // fill the lecturers listview within the lecturers panel with a list of lecturers
                    LecturerService lecturerService = new LecturerService();
                    List<Teacher> lecturersList = lecturerService.GetTeachers();

                    // clear the listview before filling it again
                    listViewLecturers.Clear();

                    // Add columsn since .Clear() also deletes the columns
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
                        listViewLecturers.Items.Add(li); // Add all the values to the listview
                    }
                }
                catch (Exception e)
                {
                    appLog.Source = "Loading Panel Teachers";
                    appLog.WriteEntry(e.Message);
                    MessageBox.Show("Something went wrong while loading the teachers: " + e.Message);
                }
            }
            else if (panelName == "Rooms")
            {
                // hide all other panels
                pnlDashboard.Hide();
                imgDashboard.Hide();
                pnlLecturers.Hide();
                pnlStudents.Hide();
                pnlDrinks.Hide();
                pnlCashRegister.Hide();

                // show Rooms
                pnlRooms.Show();

                try
                {
                    // fill the Rooms listview within the Rooms panel with a list of Rooms
                    RoomService roomService = new RoomService();
                    List<Room> roomsList = roomService.GetRooms();

                    // clear the listview before filling it again
                    listViewRooms.Clear();

                    // Add columsn since .Clear() also deletes the columns
                    listViewRooms.Columns.Add("Number", 100);
                    listViewRooms.Columns.Add("Type", 100);
                    listViewRooms.Columns.Add("Capacity", 100);

                    listViewRooms.View = View.Details;

                    foreach (SomerenModel.Room s in roomsList)
                    {
                        ListViewItem li = new ListViewItem(new string[] {
                        s.Number.ToString(),
                        s.Type,
                        s.Capacity.ToString(),

                    });
                        listViewRooms.Items.Add(li); // Add all the values to the listview
                    }
                }
                catch (Exception e)
                {
                    appLog.Source = "Loading Panel Rooms";
                    appLog.WriteEntry(e.Message);
                    MessageBox.Show("Something went wrong while loading the rooms: " + e.Message);
                }
            }
            else if (panelName == "Drinks")
            {
                // hide all other panels
                pnlDashboard.Hide();
                imgDashboard.Hide();
                pnlLecturers.Hide();
                pnlStudents.Hide();
                pnlRooms.Hide();
                pnlCashRegister.Hide();

                // show Rooms
                pnlDrinks.Show();

                try
                {
                    // fill the Rooms listview within the Rooms panel with a list of Rooms
                    DrinkService drinkService = new DrinkService();
                    List<Drink> drinksList = drinkService.GetDrinks();

                    // clear the listview before filling it again
                    listViewDrinks.Clear();

                    listViewDrinks.FullRowSelect = true;

                    // Add columsn since .Clear() also deletes the columns
                    listViewDrinks.Columns.Add("Name", 100);
                    listViewDrinks.Columns.Add("Stock", 100);
                    listViewDrinks.Columns.Add("Price", 100);
                    listViewDrinks.Columns.Add("Status", 100);


                    listViewDrinks.View = View.Details;

                    foreach (SomerenModel.Drink s in drinksList)
                    {
                        string status;

                        if (s.Stock < 10)
                        {
                            status = "Stock nearly depleted";
                        }
                        else
                        {
                            status = "Stock sufficient";
                        }
                        ListViewItem li = new ListViewItem(new string[] {
                        s.Name.ToString(),
                        s.Stock.ToString(),
                        s.SalesPrice.ToString(),
                        status.ToString(),
                        s.DrinkID.ToString(),
                    });
                        listViewDrinks.Items.Add(li); // Add all the values to the listview
                    }
                }
                catch (Exception e)
                {
                    appLog.Source = "Application";
                    appLog.WriteEntry(e.Message);
                    MessageBox.Show("Something went wrong while loading the drinks: " + e.Message);
                }
            }
            else if (panelName == "CashRegister")
            {
                // hide all other panels
                pnlDashboard.Hide();
                imgDashboard.Hide();
                pnlLecturers.Hide();
                pnlStudents.Hide();
                pnlRooms.Hide();
                pnlDrinks.Hide();
                // show Rooms
                pnlCashRegister.Show();

                try
                {
                    // fill the students listview within the students panel with a list of students
                    StudentService studService = new StudentService(); ;
                    List<Student> studentList = studService.GetStudents(); ;

                    // clear the listview before filling it again
                    listViewCashierStudents.Clear();

                    listViewCashierStudents.Columns.Add("Student Number", 100);
                    listViewCashierStudents.Columns.Add("First Name", 100);
                    listViewCashierStudents.Columns.Add("Name", 100);
                    listViewCashierStudents.View = View.Details;

                    foreach (SomerenModel.Student s in studentList)
                    {
                        ListViewItem li = new ListViewItem(new string[] {
                            s.StudentNumber.ToString(),
                            s.Firstname,
                            s.Name
                        });
                        listViewCashierStudents.Items.Add(li); // Add all the values to the listview
                    }
                }
                catch (Exception e)
                {
                    appLog.Source = "Loading Panel Students";
                    appLog.WriteEntry(e.Message);
                    MessageBox.Show("Something went wrong while loading the students: " + e.Message);
                }

                // show Rooms
                pnlDrinks.Show();

                try
                {
                    // fill the Rooms listview within the Rooms panel with a list of Rooms
                    DrinkService drinkService = new DrinkService();
                    List<Drink> drinksList = drinkService.GetDrinks();

                    // clear the listview before filling it again
                    listViewCashierDrinks.Clear();

                    listViewCashierDrinks.FullRowSelect = true;

                    // Add columsn since .Clear() also deletes the columns
                    listViewCashierDrinks.Columns.Add("Name", 100);
                    listViewCashierDrinks.Columns.Add("Stock", 100);
                    listViewCashierDrinks.Columns.Add("Price", 100);
                    listViewCashierDrinks.Columns.Add("Status", 100);


                    listViewCashierDrinks.View = View.Details;

                    foreach (SomerenModel.Drink s in drinksList)
                    {
                        string status;

                        if (s.Stock < 10)
                        {
                            status = "Stock nearly depleted";
                        }
                        else
                        {
                            status = "Stock sufficient";
                        }
                        ListViewItem li = new ListViewItem(new string[] {
                        s.Name.ToString(),
                        s.Stock.ToString(),
                        s.SalesPrice.ToString(),
                        status.ToString(),
                        s.DrinkID.ToString(),
                    });
                        listViewCashierDrinks.Items.Add(li); // Add all the values to the listview
                    }
                }
                catch (Exception e)
                {
                    appLog.Source = "Application";
                    appLog.WriteEntry(e.Message);
                    MessageBox.Show("Something went wrong while loading the drinks: " + e.Message);
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

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Rooms");
        }

        private void drinksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Reset the text boxes
            txtName.Text = "";
            txtStock.Text = "";
            txtPrice.Text = "";

            showPanel("Drinks");
        }

        private void listViewDrinks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewDrinks.SelectedItems.Count != 1)
                return;

            try
            {
                txtName.Text = listViewDrinks.SelectedItems[0].SubItems[0].Text;
                txtStock.Text = listViewDrinks.SelectedItems[0].SubItems[1].Text;
                txtPrice.Text = listViewDrinks.SelectedItems[0].SubItems[2].Text;
            }
            catch (Exception err)
            {
                appLog.Source = "Application";
                appLog.WriteEntry(err.Message);
                throw;
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (listViewDrinks.SelectedItems.Count != 1)
                return;

            try
            {
                string drinkID = listViewDrinks.SelectedItems[0].SubItems[4].Text;

                // Set up Drink object
                Drink drink = new Drink();

                drink.DrinkID = int.Parse(drinkID);
                drink.Name = txtName.Text;
                drink.Stock = int.Parse(txtStock.Text);
                drink.SalesPrice = double.Parse(txtPrice.Text);

                //Update
                DrinkService drinkService = new DrinkService();
                drinkService.UpdateDrinks(drink);

                //Reset everything after updating
                showPanel("Drinks");
                txtName.Text = "";
                txtStock.Text = "";
                txtPrice.Text = "";
            }
            catch (Exception err)
            {
                appLog.Source = "Application";
                appLog.WriteEntry(err.Message);
                throw;
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewDrinks.SelectedItems.Count != 1)
                return;

            try
            {
                string drinkID = listViewDrinks.SelectedItems[0].SubItems[4].Text;

                // Set up Drink object
                Drink drink = new Drink();

                //Delete
                DrinkService drinkService = new DrinkService();
                drinkService.DeleteDrink(int.Parse(drinkID));

                //Reset everything after deleting
                showPanel("Drinks");
                txtName.Text = "";
                txtStock.Text = "";
                txtPrice.Text = "";
            }
            catch (Exception err)
            {
                appLog.Source = "Application";
                appLog.WriteEntry(err.Message);
                throw;
            }

        }

        private void btnShowAddDrink_Click(object sender, EventArgs e)
        {

            try
            {
                btnUpdateDrink.Hide();
                btnShowAddDrink.Hide();
                btnDeleteDrink.Hide();
                lblDrinkType.Show();
                txtDrinkType.Show();

                btnAddDrink.Show();
                btnBackDrink.Show();
            }
            catch (Exception err)
            {
                appLog.Source = "Application";
                appLog.WriteEntry(err.Message);
                throw;
            }
        }

        private void btnAddDrink_Click(object sender, EventArgs e)
        {
            try
            {
                // Set up Drink object
                Drink drink = new Drink();

                drink.Name = txtName.Text;
                drink.Stock = int.Parse(txtStock.Text);
                drink.SalesPrice = double.Parse(txtPrice.Text);

                //Add
                DrinkService drinkService = new DrinkService();

                drink.Name = txtName.Text;
                drink.Stock = int.Parse(txtStock.Text);
                drink.SalesPrice = double.Parse(txtPrice.Text);
                drink.DrinkType = txtDrinkType.Text;

                drinkService.AddDrink(drink);

                //Reset everything after updating
                showPanel("Drinks");
                txtName.Text = "";
                txtStock.Text = "";
                txtPrice.Text = "";
                txtDrinkType.Text = "";
            }
            catch (Exception err)
            {
                appLog.Source = "Application";
                appLog.WriteEntry(err.Message);
                throw;
            }
        }

        private void btnBackDrink_Click(object sender, EventArgs e)
        {
            btnUpdateDrink.Show();
            btnShowAddDrink.Show();
            btnDeleteDrink.Show();
            lblDrinkType.Hide();
            txtDrinkType.Hide();

            btnAddDrink.Hide();
            btnBackDrink.Hide();
        }

        private void cashRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("CashRegister");
        }

        private void btnBuyDrink_Click(object sender, EventArgs e)
        {

        }
    }
}
