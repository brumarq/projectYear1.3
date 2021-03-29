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

        private void activitySupervisorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("ActivitySupervisors");
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
                pnlLecturers.Hide();
                pnlDrinks.Hide();
                pnlCashRegister.Hide();
                pnlActivities.Hide();
                pnlActivitySupervisors.Hide();
                //pnlActivityParticipants.Hide();

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
                pnlActivities.Hide();
                pnlActivitySupervisors.Hide();
                //pnlActivityParticipants.Hide();

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
                pnlActivities.Hide();
                pnlActivitySupervisors.Hide();
                //pnlActivityParticipants.Hide();

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
                pnlActivities.Hide();
                pnlActivitySupervisors.Hide();
                //pnlActivityParticipants.Hide();

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
                pnlActivities.Hide();
                pnlActivitySupervisors.Hide();
                //pnlActivityParticipants.Hide();

                // show Drinks
                pnlDrinks.Show();

                try
                {
                    DrinkService drinkService = new DrinkService();
                    List<Drink> drinksList = drinkService.GetDrinks();

                    // clear the listview before filling it again
                    listViewDrinks.Clear();

                    listViewDrinks.FullRowSelect = true;

                    // Add columsn since .Clear() also deletes the columns
                    listViewDrinks.Columns.Add("Name", 100);
                    listViewDrinks.Columns.Add("Stock", 100);
                    listViewDrinks.Columns.Add("Price", 100);
                    listViewDrinks.Columns.Add("Status", 150);


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
                        s.SalesPrice.ToString("0.00 €"),
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
                pnlActivities.Hide();
                pnlActivitySupervisors.Hide();
                //pnlActivityParticipants.Hide();
                // show Cash Register
                pnlCashRegister.Show();

                try
                {
                    BuyService buyService = new BuyService();
                    List<Student> studentList = buyService.GetCashierStudents();

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
                            s.Name,
                            s.StudentID.ToString(),
                        });
                        listViewCashierStudents.Items.Add(li); // Add all the values to the listview
                    }

                    List<Drink> drinksList = buyService.GetCashierDrinks();
                    // clear the listview before filling it again
                    listViewCashierDrinks.Clear();

                    listViewCashierDrinks.FullRowSelect = true;

                    // Add columsn since .Clear() also deletes the columns
                    listViewCashierDrinks.Columns.Add("Name", 100);
                    listViewCashierDrinks.Columns.Add("Stock", 100);
                    listViewCashierDrinks.Columns.Add("Price", 100);

                    listViewCashierDrinks.View = View.Details;

                    foreach (SomerenModel.Drink s in drinksList)
                    {
                        ListViewItem li = new ListViewItem(new string[] {
                            s.Name.ToString(),
                            s.Stock.ToString(),
                            s.SalesPrice.ToString("0.00 €"),
                            s.DrinkID.ToString(),
                           });

                        listViewCashierDrinks.Items.Add(li); // Add all the values to the listview
                    }
                }
                catch (Exception e)
                {
                    appLog.Source = "Application";
                    appLog.WriteEntry(e.Message);
                    MessageBox.Show("Something went wrong while loading the students: " + e.Message);
                }
            }
            else if (panelName == "ActivityParticipants")
            {
                // hide all other panels
                pnlDashboard.Hide();
                imgDashboard.Hide();
                pnlLecturers.Hide();
                pnlStudents.Hide();
                pnlRooms.Hide();
                pnlDrinks.Hide();
                pnlActivities.Hide();
                pnlCashRegister.Hide();
                // show Cash Register
                //pnlActivityParticipants.Show();
                try
                {
                    // fill the students listview within the students panel with a list of students
                    /*StudentService studService = new StudentService(); ;
                    List<Student> studentList = studService.GetStudents(); ;

                    // clear the listview before filling it again
                    listActivityParticipants.Clear();

                    listActivityParticipants.Columns.Add("Student Number", 100);
                    listActivityParticipants.Columns.Add("First Name", 100);
                    listActivityParticipants.Columns.Add("Name", 100);
                    listActivityParticipants.View = View.Details;

                    foreach (SomerenModel.Student s in studentList)
                    {
                        ListViewItem li = new ListViewItem(new string[] {
                            s.StudentNumber.ToString(),
                            s.Firstname,
                            s.Name
                        });
                        listActivityParticipants.Items.Add(li); // Add all the values to the listview
                    }*/
                }
                catch (Exception e)
                {
                    appLog.Source = "Loading Panel Students";
                    appLog.WriteEntry(e.Message);
                    MessageBox.Show("Something went wrong while loading the students: " + e.Message);
                }
            }
            else if (panelName == "Activities")
            {
                // hide all other panels
                pnlDashboard.Hide();
                imgDashboard.Hide();
                pnlLecturers.Hide();
                pnlStudents.Hide();
                pnlRooms.Hide();
                pnlDrinks.Hide();
                pnlCashRegister.Hide();
                pnlActivitySupervisors.Hide();
                //pnlActivityParticipants.Hide();
                // show Activities
                pnlActivities.Show();

                try
                {
                    // fill the Activities listview within the Activities panel with a list of Activities
                    ActivityService activityService = new ActivityService();
                    List<Activity> activitiesList = activityService.GetActivities();

                    // clear the listview before filling it again
                    listViewActivities.Clear();

                    // Add columsn since .Clear() also deletes the columns
                    listViewActivities.Columns.Add("Activity ID", 100);
                    listViewActivities.Columns.Add("Name", 100);
                    listViewActivities.Columns.Add("Date", 100);

                    listViewActivities.View = View.Details;

                    foreach (SomerenModel.Activity s in activitiesList)
                    {
                        ListViewItem li = new ListViewItem(new string[] {
                        s.ActivityID.ToString(),
                        s.Name,
                        s.Date.ToString("dd-MM-yyyy"),

                    });
                        listViewActivities.Items.Add(li); // Add all the values to the listview
                    }
                }
                catch (Exception e)
                {
                    appLog.Source = "Application";
                    appLog.WriteEntry(e.Message);
                    MessageBox.Show("Something went wrong while loading the rooms: " + e.Message);
                }
            }

            else if (panelName == "ActivitySupervisors")
            {
                // hide all other panels
                pnlDashboard.Hide();
                imgDashboard.Hide();
                pnlLecturers.Hide();
                pnlStudents.Hide();
                pnlRooms.Hide();
                pnlDrinks.Hide();
                pnlCashRegister.Hide();
                pnlActivities.Hide();
                // show Activities
                pnlActivitySupervisors.Show();

                try
                {
                    // fill the lecturers listview within the lecturers panel with a list of lecturers
                    LecturerService lecturerService = new LecturerService();
                    List<Teacher> lecturersList = lecturerService.GetTeachers();

                    // clear the listview before filling it again
                    listViewActivityParticipants.Clear();

                    // Add columsn since .Clear() also deletes the columns
                    listViewActivityParticipants.Columns.Add("Lecturer ID", 100);
                    listViewActivityParticipants.Columns.Add("First Name", 100);
                    listViewActivityParticipants.Columns.Add("Name", 100);
                    listViewActivityParticipants.View = View.Details;

                    foreach (SomerenModel.Teacher s in lecturersList)
                    {
                        ListViewItem li = new ListViewItem(new string[] {
                        s.TeacherNumber.ToString(),
                        s.FirstName,
                        s.Name
                    });
                        listViewActivityParticipants.Items.Add(li); // Add all the values to the listview
                    }
                }
                catch (Exception e)
                {
                    appLog.Source = "Loading Panel Teachers";
                    appLog.WriteEntry(e.Message);
                    MessageBox.Show("Something went wrong while loading the teachers: " + e.Message);
                }

                try
                {
                    // fill the Activities listview within the Activities panel with a list of Activities
                    ActivityService activityService = new ActivityService();
                    List<Activity> activitiesList = activityService.GetActivities();

                    // clear the listview before filling it again
                    listViewActivitiesForActivitySup.Clear();

                    // Add columsn since .Clear() also deletes the columns
                    listViewActivitiesForActivitySup.Columns.Add("Activity ID", 100);
                    listViewActivitiesForActivitySup.Columns.Add("Name", 100);
                    listViewActivitiesForActivitySup.Columns.Add("Date", 100);

                    listViewActivitiesForActivitySup.View = View.Details;

                    foreach (SomerenModel.Activity s in activitiesList)
                    {
                        ListViewItem li = new ListViewItem(new string[] {
                        s.ActivityID.ToString(),
                        s.Name,
                        s.Date.ToString("dd-MM-yyyy"),

                    });
                        listViewActivitiesForActivitySup.Items.Add(li); // Add all the values to the listview
                    }
                }
                catch (Exception e)
                {
                    appLog.Source = "Application";
                    appLog.WriteEntry(e.Message);
                    MessageBox.Show("Something went wrong while loading the rooms: " + e.Message);
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

        private void cashRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("CashRegister");
        }

        private void activitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("Activities");
        }
        private void activityParticipantsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPanel("ActivityParticipants");
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
            {
                return;
            }

            try
            {
                txtName.Text = listViewDrinks.SelectedItems[0].SubItems[0].Text;
                txtStock.Text = listViewDrinks.SelectedItems[0].SubItems[1].Text;
                txtPrice.Text = listViewDrinks.SelectedItems[0].SubItems[2].Text.Remove(listViewDrinks.SelectedItems[0].SubItems[2].Text.Length - 1, 1);
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
            {
                return;
            }

            try
            {
                string drinkID = listViewDrinks.SelectedItems[0].SubItems[4].Text;

                // Set up Drink object
                Drink drink = new Drink
                {
                    DrinkID = int.Parse(drinkID),
                    Name = txtName.Text,
                    Stock = int.Parse(txtStock.Text),
                    SalesPrice = float.Parse(txtPrice.Text)
                };

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
            {
                return;
            }

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
                Drink drink = new Drink
                {
                    Name = txtName.Text,
                    Stock = int.Parse(txtStock.Text),
                    SalesPrice = double.Parse(txtPrice.Text),
                    DrinkType = txtDrinkType.SelectedItem.ToString(),
                };

                //Add
                DrinkService drinkService = new DrinkService();

                drinkService.AddDrink(drink);

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

        private void btnBuyDrink_Click(object sender, EventArgs e)
        {
            if (listViewCashierStudents.SelectedItems.Count != 1 && listViewCashierDrinks.SelectedItems.Count != 1)
            {
                return;
            }

            // Set up Drink and Student objects
            Drink drink = new Drink();
            Student student = new Student();

            try
            {
                student.StudentNumber = int.Parse(listViewCashierStudents.SelectedItems[0].SubItems[0].Text);
                student.Firstname = listViewCashierStudents.SelectedItems[0].SubItems[1].Text;
                student.Name = listViewCashierStudents.SelectedItems[0].SubItems[2].Text;
                student.StudentID = int.Parse(listViewCashierStudents.SelectedItems[0].SubItems[3].Text);

                drink.Name = listViewCashierDrinks.SelectedItems[0].SubItems[0].Text;
                drink.Stock = int.Parse(listViewCashierDrinks.SelectedItems[0].SubItems[1].Text);
                drink.SalesPrice = float.Parse(listViewCashierDrinks.SelectedItems[0].SubItems[2].Text.Remove(listViewCashierDrinks.SelectedItems[0].SubItems[2].Text.Length - 1, 1));
                drink.DrinkID = int.Parse(listViewCashierDrinks.SelectedItems[0].SubItems[3].Text);

                //Buy
                BuyService buyService = new BuyService();
                buyService.Buy(drink, student);

                //Reset everything after updating
                showPanel("CashRegister");
            }
            catch (Exception err)
            {
                appLog.Source = "Application";
                appLog.WriteEntry(err.Message);
                throw;
            }
        }

        /* ------------------   
         * ----Activities----
         * ------------------ */

        private void listViewActivities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewActivities.SelectedItems.Count != 1)
                return;

            try
            {
                txtActivityName.Text = listViewActivities.SelectedItems[0].SubItems[1].Text;
                dtTimeOfActivity.Value = DateTime.Parse(listViewActivities.SelectedItems[0].SubItems[2].Text);
            }
            catch (Exception err)
            {
                appLog.Source = "Application";
                appLog.WriteEntry(err.Message);
                lblErrorActivity.Text = err.Message;
            }
        }

        private void btnUpdateActivity_Click(object sender, EventArgs e)
        {
            if (listViewActivities.SelectedItems.Count != 1)
            {
                lblErrorActivity.Text = "Please select an Activity to update!";
                return;
            }

            try
            {
                int activityId = int.Parse(listViewActivities.SelectedItems[0].SubItems[0].Text);

                // Set up activity object
                Activity activity = new Activity
                {
                    ActivityID = activityId,
                    Name = txtActivityName.Text,
                    Date = dtTimeOfActivity.Value,
                };

                //Update
                ActivityService activityService = new ActivityService();
                activityService.UpdateActivities(activity);

                //Reset everything after updating
                showPanel("Activities");
                txtActivityName.Text = "";
                lblErrorActivity.Text = "";
            }
            catch (Exception err)
            {
                appLog.Source = "Application";
                appLog.WriteEntry(err.Message);
                lblErrorActivity.Text = err.Message;
            }
        }

        private void btnDeleteActivity_Click(object sender, EventArgs e)
        {
            if (listViewActivities.SelectedItems.Count < 1)
            {
                lblErrorActivity.Text = "Please select one or multiple activities to delete!";
                return;
            }

            try
            {
                int activityID = int.Parse(listViewActivities.SelectedItems[0].SubItems[0].Text);

                //Delete
                ActivityService activityService = new ActivityService();
                //Message Box to confirm 
                DialogResult result = MessageBox.Show("Are you sure you want to delete the selected items?", "Delete confirmation", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    foreach (ListViewItem item in listViewActivities.SelectedItems)
                    {
                        Activity activity = new Activity
                        {
                            ActivityID = int.Parse(item.SubItems[0].Text),
                        };

                        activityService.DeleteActivity(activity);
                    }

                    //Reset everything after updating
                    showPanel("Activities");
                    txtActivityName.Text = "";
                    lblErrorActivity.Text = "";
                }
                else
                {
                    return;
                }
            }
            catch (Exception err)
            {
                appLog.Source = "Application";
                appLog.WriteEntry(err.Message);
                lblErrorActivity.Text = err.Message;
            }
        }

        private void btnAddActivity_Click(object sender, EventArgs e)
        {
            if (txtActivityName.Text == "")
            {
                lblErrorActivity.Text = "Please enter a name for the activity!";
                return;
            }

            try
            {
                // Set up Activity object
                Activity activity = new Activity
                {
                    Name = txtActivityName.Text,
                    Date = dtTimeOfActivity.Value,
                };

                //Add
                ActivityService activityService = new ActivityService();
                activityService.AddActivity(activity);

                //Reset everything after updating
                showPanel("Activities");
                txtActivityName.Text = "";
                lblErrorActivity.Text = "";
            }
            catch (Exception err)
            {
                appLog.Source = "Application";
                appLog.WriteEntry(err.Message);
                lblErrorActivity.Text = err.Message;
            }
        }

        private void btn_addParticipant_Click(object sender, EventArgs e)
        {
                if (txtActivityName.Text == "")
                {
                    lblErrorActivity.Text = "Please enter a name for the participant!";
                    return;
                }

                try
                {
                    // Set up Activity object
                    Activity activity = new Activity
                    {
                        Name = txtActivityName.Text,
                        Date = dtTimeOfActivity.Value,
                    };

                    //Add
                    ActivityService activityService = new ActivityService();
                    activityService.AddActivity(activity);

                    //Reset everything after updating
                    showPanel("Activities");
                    txtActivityName.Text = "";
                    lblErrorActivity.Text = "";
                }
                catch (Exception err)
                {
                    appLog.Source = "Application";
                    appLog.WriteEntry(err.Message);
                    lblErrorActivity.Text = err.Message;
                }
        }

        private void btn_UpdatePart_Click(object sender, EventArgs e)
        {
            if (listViewActivities.SelectedItems.Count != 1)
            {
                lblErrorActivity.Text = "Please select an Activity to update!";
                return;
            }

            try
            {
                int activityId = int.Parse(listViewActivities.SelectedItems[0].SubItems[0].Text);

                // Set up activity object
                Activity activity = new Activity
                {
                    ActivityID = activityId,
                    Name = txtActivityName.Text,
                    Date = dtTimeOfActivity.Value,
                };

                //Update
                ActivityService activityService = new ActivityService();
                activityService.UpdateActivities(activity);

                //Reset everything after updating
                showPanel("Activities");
                txtActivityName.Text = "";
                lblErrorActivity.Text = "";
            }
            catch (Exception err)
            {
                appLog.Source = "Application";
                appLog.WriteEntry(err.Message);
                lblErrorActivity.Text = err.Message;
            }
        }
    }
}


