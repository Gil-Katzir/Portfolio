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
    public partial class all_students_voucher : Form
    {
        public Employee secretary;

        public all_students_voucher(Employee secretary)
        {
            InitializeComponent();
            this.secretary = secretary;
            voucher_type_combobox.DataSource = Enum.GetValues(typeof(VoucherTypes));//אתחול הקומבובוקס
        }

        private void produce2_button_Click(object sender, EventArgs e)
        {
            Voucher new_v = new Voucher(voucher_name_text.Text, (VoucherTypes)Enum.Parse(typeof(VoucherTypes), voucher_type_combobox.Text),
                                      DateTime.Parse(due_date_text.Text), float.Parse(cost_text.Text), this.secretary, true);

            main_secretary ms = new main_secretary(this.secretary);
            ms.Show();
            this.Close();
        }











        private void voucher_type_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cost_text_TextChanged(object sender, EventArgs e)
        {

        }

        private void due_date_text_TextChanged(object sender, EventArgs e)
        {

        }

        private void voucher_name_text_TextChanged(object sender, EventArgs e)
        {

        }


        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

      
    }
}
