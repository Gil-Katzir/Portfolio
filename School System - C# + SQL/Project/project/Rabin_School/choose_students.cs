using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rabin_School
{
    public partial class choose_students : Form
    {
        public Employee teacher;
        public Assignment assignment;

        public choose_students(Employee teacher, Assignment a)
        {


            InitializeComponent();
            this.teacher = teacher;
            this.assignment = a;
            foreach (Student s in Program.students)
            {

                students_checkbox.Items.Add("Id:" + s.get_id() + " Name:"+s.get_firstName() + " "+ s.get_lastName() + " From:" + s.get_classRoom().getClassName());

            }
        }

        private void confirm_button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < students_checkbox.Items.Count; i++)
            {
                if (students_checkbox.GetItemChecked(i))
                {
                    Student s = null;
                    int student_id;
                    string student_details = students_checkbox.Items[i].ToString();
                    string[] parts = student_details.Split(' ');

                    // מציאת החלק שמתחיל ב-"Id:"
                    foreach (string part in parts)
                    {
                        if (part.StartsWith("Id:"))
                        {
                            string id = part.Substring(3); // חותכים את "Id:"
                            student_id = int.Parse(id);
                            s = Program.findStudent(student_id);
                            SubmissionBoxStatuses subStatus=(SubmissionBoxStatuses)Enum.Parse(typeof(SubmissionBoxStatuses), "OpenToSubmit");
                            SubmissionBox sub = new SubmissionBox(s,this.assignment, null , subStatus, true);
                            s.assignment_subbmisions.Add(sub);
                            this.assignment.student_submissions.Add(sub);
                        }
                    }

                }
            }
            
            MessageBox.Show("המטלה פורסמה בהצלחה עבור התלמידים שנבחרו");

            main_teacher nextForm = new main_teacher(teacher);
            nextForm.Show();
            this.Hide(); // מסתיר את המסך הנוכחי
            return;
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            // מעבר למסך הראשי עם המופע של המשתמש
            main_teacher nextForm = new main_teacher(teacher); 
            nextForm.Show();
            this.Hide(); // מסתיר את המסך הנוכחי
            return;
        }
    }
}
