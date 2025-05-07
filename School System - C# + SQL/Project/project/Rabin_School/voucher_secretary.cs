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
    public partial class voucher_secretary : Form
    {
        public Employee secretary;
        public voucher_secretary(Employee secretary)
        {
            InitializeComponent();
            this.secretary = secretary;
        }

        private void student_voucher_Click(object sender, EventArgs e)
        {
            // מעבר למסך הבא עם המופע של המשתמש
            student_voucher nextForm = new student_voucher(this.secretary); 
            nextForm.Show();
            this.Hide(); // מסתיר את המסך הנוכחי
            return;
        }

        private void all_students_voucher_Click(object sender, EventArgs e)
        {
            // מעבר למסך הבא עם המופע של המשתמש
            all_students_voucher nextForm = new all_students_voucher(this.secretary); 
            nextForm.Show();
            this.Hide(); // מסתיר את המסך הנוכחי
            return;
        }

        private void go_back_button_Click(object sender, EventArgs e)
        {

        }
    }
}
