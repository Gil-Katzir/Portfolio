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
    public partial class main_teacher : Form
    {

        public Employee teacher;

        public main_teacher(Employee teacher)
        {
            InitializeComponent();
            this.teacher= teacher;
        }

        private void reutrn_button_Click(object sender, EventArgs e)
        {
            login go_back_form = new login();
            go_back_form.Show();
            this.Hide();
        }

        private void publish_button_Click(object sender, EventArgs e)
        {
            publish_assignment go_back_form = new publish_assignment(this.teacher);
            go_back_form.Show();
            this.Hide();
        }
    
    }
}
