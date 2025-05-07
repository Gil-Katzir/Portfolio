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
    public partial class publish_assignment : Form
    {
        public Employee teacher;
        public Assignment a;
        public publish_assignment(Employee teacher)
        {
            InitializeComponent();
            this.teacher = teacher;
            choose_students_button.Hide();

        }

        private void return_button_Click(object sender, EventArgs e)
        {
            publish_assignment go_back_form = new publish_assignment(this.teacher);
            go_back_form.Show();
            this.Hide();
        }

        private void choose_students_button_Click(object sender, EventArgs e)
        {
            choose_students choose_students = new choose_students(this.teacher, this.a);
            choose_students.Show();
            this.Hide();
        }

        private void create_assignment_button_Click(object sender, EventArgs e)
        {
            Assignment.assignment_counter++;
            int assignment_id = Assignment.assignment_counter;
            string assignment_name = assign_name_textbox.Text;
            DateTime creating_date= DateTime.Now;
            DateTime last_submission_date= DateTime.Parse(last_sub_date_textbox.Text);
            string description = description_textbox.Text;

            string url= url_textbox.Text;
            ResourceTypes type = (ResourceTypes)Enum.Parse(typeof(ResourceTypes), "AssignmentFile");


            a = new Assignment (assignment_id, assignment_name, creating_date, last_submission_date, description, this.teacher, true);
            Resource r = new Resource(url, assignment_name, type, creating_date, creating_date, null, null, null, a, true);

            choose_students_button.Show();
        }
    }
}
