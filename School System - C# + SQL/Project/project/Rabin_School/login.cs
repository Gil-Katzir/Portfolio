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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }



        private void loginButton_Click(object sender, EventArgs e)
        {
            // נניח שמדובר במשתמש שזוהה במערכת
            Employee secretary = find_secretary();
            Employee teacher = find_teacher();
            Student student = find_student();

            if (student != null)
            {
                // מעבר למסך הבא עם המופע של המשתמש
                main_student nextForm = new main_student(student); //לשנותתתתתתתתת
                nextForm.Show();
                this.Hide(); // מסתיר את המסך הנוכחי                
                return;

            }
            if (secretary != null)
            {
                // מעבר למסך הבא עם המופע של המשתמש
                main_secretary nextForm = new main_secretary(secretary); nextForm.Show();
                this.Hide(); // מסתיר את המסך הנוכחי
                return;

            }

            if (teacher != null)
            {
                // מעבר למסך הבא עם המופע של המשתמש
                main_teacher nextForm = new main_teacher(teacher); //לשנותתתתתתתת
                nextForm.Show();
                this.Hide(); // מסתיר את המסך הנוכחי
                return;

            }



            MessageBox.Show("פרטי ההתחברות שגוים, נסה שנית");

        }


        public Employee find_secretary()
        {
            string firstName = firstNameText.Text;
            string lastName = lastNameText.Text;
            int id = int.Parse(idText.Text);

            for (int i = 0; i < Program.employees.Count; i++) {
                if (firstName.Equals(Program.employees[i].get_firstName()) && lastName.Equals(Program.employees[i].get_lastName()) &&
                    id==Program.employees[i].get_id() && Program.employees[i].get_role().ToString().Equals("Secretary"))
                {
                    return Program.employees[i];
                }
            }
            return null;
        }



        public Employee find_teacher()
        {
            string firstName = firstNameText.Text;
            string lastName = lastNameText.Text;
            int id = int.Parse(idText.Text);

            for (int i = 0; i < Program.employees.Count; i++)
            {
                if (firstName.Equals(Program.employees[i].get_firstName()) && lastName.Equals(Program.employees[i].get_lastName()) &&
                    id==Program.employees[i].get_id() && Program.employees[i].get_role().ToString().Equals("Teacher"))
                {
                    return Program.employees[i];
                }
            }
            return null;
        }



        public Student find_student()
        {
            string firstName = firstNameText.Text;
            string lastName = lastNameText.Text;
            int id = int.Parse(idText.Text);

            for (int i = 0; i < Program.students.Count; i++)
            {
                if (firstName.Equals(Program.students[i].get_firstName()) && lastName.Equals(Program.students[i].get_lastName()) &&
                    id==Program.students[i].get_id())
                {
                    return Program.students[i];
                }
            }
            Console.WriteLine("the student was not found");
            return null;
        }


    }
}
