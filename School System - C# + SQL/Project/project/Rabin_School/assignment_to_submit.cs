using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rabin_School
{
    public partial class assignment_to_submit : Form
    {
        public Student student;
        private string old_url;
        private SubmissionBox sub;
        private Resource r;

        public assignment_to_submit(Student student)
        {
            InitializeComponent();
            this.student = student;
            
            assignment_name.Hide();
            last_date.Hide();
            description.Hide();
            teacher_name.Hide();
            url.Hide();
            url_textbox.Hide();
            submit_assignment_button.Hide();
            update_url_button.Hide();

            assignments_to_sub_combobox.DataSource = student.get_assignments_to_submit();//change to getassignments

        }

        private void show_details_button_Click(object sender, EventArgs e)
        {
            int assignment_id = int.Parse(assignments_to_sub_combobox.Text.ToString());
            Assignment a = Program.findAssignment(assignment_id);
            this.sub = this.student.find_sub_by_assignment(a);
            this.r = Program.find_resource_by_sub(sub);
            url_textbox.Text = "";

            assignment_name.Show();
            last_date.Show();
            description.Show();
            teacher_name.Show();
            url.Show();
            url_textbox.Show();

            assignment_name_value.Text = a.assignment_name;
            last_date_value.Text = a.last_submission_date.ToString();
            description_value.Text = a.description;
            teacher_name_value.Text = a.teacher.get_firstName() + " " + a.teacher.get_lastName();


            if (r != null)
            {
                submit_assignment_button.Hide();
                update_url_button.Show();
                url_textbox.Text = r.url;
                this.old_url = r.url;
            }
            else
            {
                update_url_button.Hide();
                submit_assignment_button.Show();
            }
        }
        private void update_url_button_Click(object sender, EventArgs e)
        {

            string new_url = url_textbox.Text;
            if(new_url != "")
            {
                if (!IsValidPdfUrl(new_url))
                {
                    MessageBox.Show(" pdf כתובת קובץ הפתרון אינה בפורמט מתאים, העלה קובץ תקין מסוג ");
                    return;
                }
                if (Program.is_duplicate_url(new_url))
                {
                    MessageBox.Show("קובץ הפתרון הזה כבר קיים במערכת, יש להעלות קובץ אחר");
                    return;
                }
                DateTime lastUpdateDate = DateTime.Now;

                SqlCommand c = new SqlCommand();
                c.CommandText = @"EXECUTE dbo.SP_update_resource_url 
                      @oldUrl, @newUrl, @lastUpdateDate";
                c.Parameters.AddWithValue("@oldUrl", this.old_url);
                c.Parameters.AddWithValue("@newUrl", new_url);
                c.Parameters.AddWithValue("@lastUpdateDate", lastUpdateDate);

                SQL_CON SC = new SQL_CON();
                SC.execute_non_query(c);

                this.r.url = new_url;
                this.r.last_update_date = lastUpdateDate;

                SqlCommand c1 = new SqlCommand();
                c1.CommandText = @"EXECUTE dbo.SP_update_last_submission_date 
                      @studentId, @assignmentId, @lastUpdateDate";
                c1.Parameters.AddWithValue("@studentId", this.sub.get_student_id());
                c1.Parameters.AddWithValue("@assignmentId", this.sub.get_assignment_id());
                c1.Parameters.AddWithValue("@lastUpdateDate", lastUpdateDate);

                SQL_CON SC1 = new SQL_CON();
                SC1.execute_non_query(c1);

                this.sub.last_upload = lastUpdateDate;
                MessageBox.Show("קובץ פתרון המטלה עודכן בהצלחה");

                main_student nextForm = new main_student(this.student);
                nextForm.Show();
                this.Hide(); // מסתיר את המסך הנוכחי
                return;
            }
            else
            {
                MessageBox.Show("לא ניתן להגיש מטלה ללא מילוי כתובת Url");
            }
           
        }

        private void submit_assignment_button_Click(object sender, EventArgs e)
        {
            string url = url_textbox.Text;
            if (url != "")
            {
                if (!IsValidPdfUrl(url))
                {
                    MessageBox.Show(" pdf כתובת קובץ הפתרון אינה בפורמט מתאים, העלה קובץ תקין מסוג ");
                    return;
                }
                if(Program.is_duplicate_url(url))
                {
                    MessageBox.Show("קובץ הפתרון הזה כבר קיים במערכת, יש להעלות קובץ אחר");
                    return;
                }
                DateTime upload_date = DateTime.Now;
                string r_name = this.sub.submitted_assignment.assignment_name + " " + this.student.get_firstName();
                ResourceTypes r_type=(ResourceTypes)Enum.Parse(typeof(ResourceTypes),"AnswerFile");

                this.sub.last_upload=upload_date;
                Resource new_r = new Resource(url, r_name, r_type, upload_date, upload_date, null, null, this.sub, null, true);


                SqlCommand c1 = new SqlCommand();
                c1.CommandText = @"EXECUTE dbo.SP_update_last_submission_date 
                      @studentId, @assignmentId, @lastUpdateDate";
                c1.Parameters.AddWithValue("@studentId", this.sub.get_student_id());
                c1.Parameters.AddWithValue("@assignmentId", this.sub.get_assignment_id());
                c1.Parameters.AddWithValue("@lastUpdateDate", upload_date);

                SQL_CON SC1 = new SQL_CON();
                SC1.execute_non_query(c1);

                MessageBox.Show("קובץ פתרון המטלה הועלה בהצלחה");

                main_student nextForm = new main_student(this.student);
                nextForm.Show();
                this.Hide(); // מסתיר את המסך הנוכחי
                return;

            }
            else
            {
                MessageBox.Show(" Url לא ניתן להגיש מטלה ללא מילוי כתובת");
            }

        }

        private void return_button_Click(object sender, EventArgs e)
        {
            main_student nextForm = new main_student(this.student);
            nextForm.Show();
            this.Hide(); // מסתיר את המסך הנוכחי
            return;

        }

        private static bool IsValidPdfUrl(string url)
        {
            // בדיקה אם הטקסט שהוזן הוא URL חוקי
            if (Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult))
            {
                // בדיקה אם ה-URL מתחיל עם http או https
                if ((uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps) &&
                    uriResult.AbsolutePath.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void assignment_name_Click(object sender, EventArgs e)
        {

        }

        private void last_date_Click(object sender, EventArgs e)
        {

        }

        private void description_Click(object sender, EventArgs e)
        {

        }

        private void teacher_name_Click(object sender, EventArgs e)
        {

        }

        private void url_Click(object sender, EventArgs e)
        {

        }
    }
}

