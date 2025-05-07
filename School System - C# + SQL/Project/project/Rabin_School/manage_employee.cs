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
    public partial class manage_employee : Form
    {
        public Employee secretary;

        public manage_employee(Employee secretary)
        {
            InitializeComponent();
            this.secretary = secretary;
        }

        private void create_employee_button_Click(object sender, EventArgs e)
        {
            createEmployee nextForm = new createEmployee(this.secretary);
            nextForm.Show();
            this.Hide(); // מסתיר את המסך הנוכחי
            return;
        }

        private void read_employee_button_Click(object sender, EventArgs e)
        {
            read_employee nextForm = new read_employee(this.secretary);
            nextForm.Show();
            this.Hide(); // מסתיר את המסך הנוכחי
            return;
        }

        private void go_back_button_Click(object sender, EventArgs e)
        {
            main_secretary nextForm = new main_secretary(this.secretary);
            nextForm.Show();
            this.Hide(); // מסתיר את המסך הנוכחי
            return;

        }

        private void update_hoom_classes_button_Click(object sender, EventArgs e)
        {
            update_hoom_classes nextForm = new update_hoom_classes(this.secretary);
            nextForm.Show();
            this.Hide(); // מסתיר את המסך הנוכחי
            return;

        }
    }
}
