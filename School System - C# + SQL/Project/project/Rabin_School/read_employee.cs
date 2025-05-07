using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rabin_School
{
    public partial class read_employee : Form
    {
        public Employee secretary;
        private Employee exist_employee;

        public read_employee(Employee secretary)
        {
            InitializeComponent();
            this.secretary = secretary;
            //נטרול תיבות הטקסט כך שלא ניתן יהיה לרשום בהן
            firstname_textbox.Enabled = false;
            lastname_textbox.Enabled = false;
            birthdate_textbox.Enabled = false;
            gender_combobox.Enabled = false;
            phone_textbox.Enabled = false;
            status_combobox.Enabled = false;
            address_textbox.Enabled = false;
            email_textbox.Enabled = false;
            startingdate_textbox.Enabled = false;
            role_combobox.Enabled = false;


            //הסתרת הכפתורים
            button_delete.Hide();
            button_update.Hide();
        }


        private void search_button_Click(object sender, EventArgs e)
        {
            // בדיקה אם תעודת הזהות שהוזנה תקינה
            if (string.IsNullOrWhiteSpace(search_employee_textbox.Text) || !int.TryParse(search_employee_textbox.Text, out int id))
            {
                MessageBox.Show("אנא הזן תעודת זהות חוקית.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            exist_employee = Program.seekEmployee(int.Parse(search_employee_textbox.Text));

            // אם העובד לא נמצא
            if (exist_employee == null)
            {
                MessageBox.Show("העובד לא נמצא במערכת. אנא בדוק את תעודת הזהות שהוזנה.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            //הצגת הכפתורים
            button_delete.Show();
            button_update.Show();
            //איתור המופע המתאים והצגת הפרטים

            firstname_textbox.Text = exist_employee.get_firstName();
            lastname_textbox.Text = exist_employee.get_lastName();
            birthdate_textbox.Text = exist_employee.get_birthdate().ToString();
            gender_combobox.Text = exist_employee.get_gender().ToString();
            phone_textbox.Text = exist_employee.get_phone();
            status_combobox.Text = exist_employee.get_employeeStatus().ToString();
            address_textbox.Text = exist_employee.get_address();
            email_textbox.Text = exist_employee.get_email();
            startingdate_textbox.Text = exist_employee.get_startWorkingDate().ToString();
            role_combobox.Text = exist_employee.get_role().ToString();


            firstname_textbox.Enabled = true;
            lastname_textbox.Enabled = true;
            birthdate_textbox.Enabled = true;
            gender_combobox.Enabled = true;
            phone_textbox.Enabled = true;
            status_combobox.Enabled = true;
            address_textbox.Enabled = true;
            email_textbox.Enabled = true;
            startingdate_textbox.Enabled = true;
            role_combobox.Enabled = true;

            gender_combobox.DataSource = Enum.GetValues(typeof(GenderTypes));
            gender_combobox.Text = exist_employee.get_gender().ToString();
            status_combobox.DataSource = Enum.GetValues(typeof(EmployeeStatuses));
            status_combobox.Text = exist_employee.get_employeeStatus().ToString();
            role_combobox.DataSource = Enum.GetValues(typeof(EmployeeRoles));
            role_combobox.Text = exist_employee.get_role().ToString();


        }


        private void button_update_Click(object sender, EventArgs e)
        {
            exist_employee.set_firstName(firstname_textbox.Text);
            exist_employee.set_lastName(lastname_textbox.Text);
            exist_employee.set_birthdate(DateTime.Parse(birthdate_textbox.Text));
            exist_employee.set_gender((GenderTypes)Enum.Parse(typeof(GenderTypes), gender_combobox.Text));
            exist_employee.set_phone(phone_textbox.Text);
            exist_employee.set_employeeStatus((EmployeeStatuses)Enum.Parse(typeof(EmployeeStatuses), status_combobox.Text));
            exist_employee.set_address(address_textbox.Text);
            exist_employee.set_email(email_textbox.Text);
            exist_employee.set_startWorkingDate(DateTime.Parse(startingdate_textbox.Text));
            exist_employee.set_role((EmployeeRoles)Enum.Parse(typeof(EmployeeRoles), role_combobox.Text));

            exist_employee.Update_employee();

            MessageBox.Show(" העדכון בוצע בהצלחה", "המשך", MessageBoxButtons.OK);
            manage_employee nextForm = new manage_employee(this.secretary);
            nextForm.Show();
            this.Hide(); // מסתיר את המסך הנוכחי
            return;

        }



        private void button_delete_Click(object sender, EventArgs e)
        {
            exist_employee.Delete_employee();

            MessageBox.Show(" המחיקה בוצעה בהצלחה", "המשך", MessageBoxButtons.OK);
            manage_employee nextForm = new manage_employee(this.secretary);
            nextForm.Show();
            this.Hide(); // מסתיר את המסך הנוכחי
            return;
        }


        private void return_button_Click(object sender, EventArgs e)
        {
            manage_employee nextForm = new manage_employee(this.secretary);
            nextForm.Show();
            this.Hide(); // מסתיר את המסך הנוכחי
            return;
        }
    }





}

