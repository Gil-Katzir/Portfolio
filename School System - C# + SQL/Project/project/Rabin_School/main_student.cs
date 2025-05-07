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
    public partial class main_student : Form
    {
        public Student student;
        public main_student(Student student)
        {
            InitializeComponent();
            this.student = student; 
        }

        private void show_activities_to_sign_button_Click(object sender, EventArgs e)
        {
            sign_activity nextForm=new sign_activity(this.student);
            nextForm.Show();
            this.Hide();
            return;
        }

        private void logOut_button_Click(object sender, EventArgs e)
        {
            login go_back_form = new login();
            go_back_form.Show();
            this.Hide();
        }

        private void show_assignments_button_Click(object sender, EventArgs e)
        {
            assignment_to_submit next_form=new assignment_to_submit(this.student);
            next_form.Show();
            this.Hide();
        }
    }
}
