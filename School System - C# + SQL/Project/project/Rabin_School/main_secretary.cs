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
    public partial class main_secretary : Form
    {
        public Employee secretary;
        public main_secretary(Employee secretary)
        {
            InitializeComponent();
            this.secretary = secretary;

        }

        private void vouchers_button_Click(object sender, EventArgs e)
        {
            voucher_secretary nextForm = new voucher_secretary(this.secretary);
            nextForm.Show();
            this.Hide(); // מסתיר את המסך הנוכחי
            return;
        }

        private void manage_employees_button_Click(object sender, EventArgs e)
        {
            manage_employee nextForm = new manage_employee(this.secretary);
            nextForm.Show();
            this.Hide(); // מסתיר את המסך הנוכחי
            return;
        }

        private void logOut_button_Click(object sender, EventArgs e)
        {
            login go_back_form = new login();
            go_back_form.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
