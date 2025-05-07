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
    public partial class sign_activity : Form
    {
        public Student student;
        public sign_activity(Student student)
        {
            InitializeComponent();
            this.student = student;
            show_activities_combobox.DataSource=student.get_activities_to_sign();
            startDate.Hide();
            endDate.Hide();
            activityType.Hide();
            cost.Hide();
            healthIssues.Hide();
            healthIssuesValue.Hide();   
            consent_button.Hide();
        }

        private void show_activity_details_button_Click(object sender, EventArgs e)
        {
            int activity_id = int.Parse(show_activities_combobox.Text.ToString());
            ExternalActivity a= this.get_activity_by_id(activity_id);
            startDate.Show();
            endDate.Show();         
            activityType.Show();    
            cost.Show(); 
            healthIssues.Show();
            healthIssuesValue.Show();
            consent_button.Show();  
            startDateValue.Text = a.get_startDate().ToString();
            endDateValue.Text = a.get_endDateTime().ToString();
            activityTypeValue.Text= a.get_activityType().ToString();
            costValue.Text = a.get_cost().ToString();
                

        }

        public ExternalActivity get_activity_by_id(int id)
        {
            foreach (ExternalActivity a in Program.activities)
            {
                if (a.get_id() == id)
                {
                    return a;
                }
            }
            return null;
        }

        private void consent_button_Click(object sender, EventArgs e)
        {
            int activity_id = int.Parse(show_activities_combobox.Text.ToString());
            ExternalActivity a = this.get_activity_by_id(activity_id);

            ConsentForm cf = new ConsentForm(DateTime.Now, healthIssuesValue.Text, a, this.student, true);

            main_student go_back_form = new main_student(this.student);
            go_back_form.Show();
            this.Hide();


        }

        private void go_back_button_Click(object sender, EventArgs e)
        {
            main_student go_back_form = new main_student(this.student);
            go_back_form.Show();
            this.Hide();
        }
    }
}
