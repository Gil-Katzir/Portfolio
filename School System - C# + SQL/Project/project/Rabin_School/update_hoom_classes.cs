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
    public partial class update_hoom_classes : Form
    {
        public Employee secretary;
        public Employee teacher;
        public update_hoom_classes(Employee secretary)
        {
            InitializeComponent();
            this.secretary = secretary;
            classes_checkedListBox.Hide();
            label4.Hide();
            update_confirm_button.Hide();
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            // בדיקה אם תעודת הזהות שהוזנה תקינה
            if (string.IsNullOrWhiteSpace(teacher_id_textbox.Text) || !int.TryParse(teacher_id_textbox.Text, out int id))
            {
                MessageBox.Show("אנא הזן תעודת זהות חוקית.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            teacher = Program.seekEmployee(int.Parse(teacher_id_textbox.Text));

            // אם העובד לא נמצא
            if (teacher == null)
            {
                MessageBox.Show("העובד לא נמצא במערכת. אנא בדוק את תעודת הזהות שהוזנה.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (teacher.get_role().ToString() != "Teacher")
            {
                MessageBox.Show("העובד שנמצא אינו מורה. ודא כי תעודת הזהות שהזנת הינה של מורה.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            label4.Show();
            teacher_name_value.Text = teacher.get_firstName()+" "+teacher.get_lastName();
            /////שיטה להכנסת כלל הכיתות לצק בוקס בסימון כיתות שכבר מלמד ואחר כך דיםק לצק בוקס
            int i = 0;
            foreach(ClassRoom c in Program.classes)
            {

                classes_checkedListBox.Items.Add(c.getClassName());
                if (teacher.homeClasses.Contains(c))
                {
                    classes_checkedListBox.SetItemChecked(i, true);
                }
                i++;

            }

            classes_checkedListBox.Show();
            update_confirm_button.Show();


        }

        private void update_confirm_button_Click(object sender, EventArgs e)
        {
            for (int i=0; i< classes_checkedListBox.Items.Count;i++)
            {
                string class_name = classes_checkedListBox.Items[i].ToString();
                int flag;
                ClassRoom classroom = this.find_class_by_name(class_name);
                if (classes_checkedListBox.GetItemChecked(i)) // true-מסומן false-לא מוסמן
                {
                    flag = 1;
                    if(!teacher.homeClasses.Contains(classroom))
                    {
                        teacher.homeClasses.Add(classroom);
                        classroom.homeTeachers.Add(teacher);
                    }
                }
                else
                {
                    flag = 0;
                    if(teacher.homeClasses.Contains(classroom))
                    {
                        teacher.homeClasses.Remove(classroom);
                        classroom.homeTeachers.Remove(teacher);
                    }
                }
                    
                // update ho database
                SqlCommand c = new SqlCommand();
                c.CommandText = @"EXECUTE SP_update_teacher_homerooms 
                      @teacherId, @className, @flag";
                c.Parameters.AddWithValue("@teacherId", teacher.get_id());
                c.Parameters.AddWithValue("@className", class_name);
                c.Parameters.AddWithValue("@flag", flag);

                SQL_CON SC = new SQL_CON();
                SC.execute_non_query(c);

            }
            MessageBox.Show("העדכון בוצע בהצלחה!");
            
            manage_employee nextForm = new manage_employee(this.secretary);
            nextForm.Show();
            this.Hide(); // מסתיר את המסך הנוכחי
            return;
        }
        private ClassRoom find_class_by_name(string name)
        {
            foreach (ClassRoom c in Program.classes)
            {
                if (c.getClassName().Equals(name))
                    return c;
            }
            return null;
        }

        private void go_back_button_Click(object sender, EventArgs e)
        {
            manage_employee nextForm = new manage_employee(this.secretary);
            nextForm.Show();
            this.Hide(); // מסתיר את המסך הנוכחי
            return;
        }
    }
}
