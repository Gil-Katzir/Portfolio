using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Rabin_School
{
    public partial class createEmployee : Form
    {
        public Employee secretary;

        public createEmployee(Employee secretary)
        {
            InitializeComponent();
            gender_combobox.DataSource = Enum.GetValues(typeof(GenderTypes));//אתחול הקומבובוקס
            status_combobox.DataSource = Enum.GetValues(typeof(EmployeeStatuses));//אתחול הקומבובוקס
            role_combobox.DataSource = Enum.GetValues(typeof(EmployeeRoles));//אתחול הקומבובוקס
            this.secretary = secretary;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void addEmployeeButton_Click(object sender, EventArgs e)
        {
            
            Employee emp = new Employee(int.Parse(id_textbox.Text), firstName_textbox.Text, lastName_textbox.Text,
                          (GenderTypes)Enum.Parse(typeof(GenderTypes), gender_combobox.Text), DateTime.Parse(birthdate_textbox.Text),
                          phone_textbox.Text, address_textbox.Text, email_textbox.Text, DateTime.Parse(startWorkingDate_textbox.Text),
                          (EmployeeStatuses)Enum.Parse(typeof(EmployeeStatuses), status_combobox.Text),
                          (EmployeeRoles)Enum.Parse(typeof(EmployeeRoles), role_combobox.Text), true); //לבדוק האם התז קיים

            manage_employee nextForm = new manage_employee(this.secretary);
            nextForm.Show();
            this.Hide(); // מסתיר את המסך הנוכחי
            return;
        }

        private void return_from_create_Click(object sender, EventArgs e)
        {
            manage_employee nextForm = new manage_employee(this.secretary);
            nextForm.Show();
            this.Hide(); // מסתיר את המסך הנוכחי
            return;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
