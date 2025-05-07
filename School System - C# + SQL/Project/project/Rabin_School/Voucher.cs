using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabin_School
{

    public class Voucher
    {
        public static int voucher_counter;
        private int voucherId; //להגיד להם!! ל ש נ ו ת לINT
        private string voucherName;
        private VoucherTypes voucherType;
        private DateTime dueDate;
        private float cost;
        private Employee producer;
        public List <Student> students;

        
        public Voucher(string voucherName, VoucherTypes voucherType, DateTime dueDate, float cost, Employee producer, bool is_new)
        {
            voucher_counter++;
            this.voucherId = voucher_counter;
            this.voucherName = voucherName;
            this.voucherType = voucherType;
            this.dueDate = dueDate;
            this.cost = cost;
            this.producer = producer;
            this.students = Program.students;

            if (is_new)
            {
                create_voucher();
            }
                    
        }

        public Voucher(string voucherName, VoucherTypes voucherType, DateTime dueDate, float cost, Employee producer,Student student, bool is_new)
        {
            voucher_counter++;
            this.voucherId = voucher_counter;
            this.voucherName = voucherName;
            this.voucherType = voucherType;
            this.dueDate = dueDate;
            this.cost = cost;
            this.producer = producer;
            this.students = new List<Student>();
            students.Add(student);

            if (is_new)
            {
               
                create_voucher();
            }

        }

        public Voucher(int id, string voucherName, VoucherTypes voucherType, DateTime dueDate, float cost, Employee producer, bool is_new)
        {
            this.voucherId = id;
            this.voucherName = voucherName;
            this.voucherType = voucherType;
            this.dueDate = dueDate;
            this.cost = cost;
            this.producer = producer;
            this.students = new List<Student>();

            if (is_new)
            {
                create_voucher();
            }

        }

        public int get_id()
        {
            return voucherId;
        }



        public void create_voucher()
        {

            // adding to database
            SqlCommand c = new SqlCommand();
            c.CommandText = @"EXECUTE SP_new_voucher_for_student 
                      @voucherId, @studentId, @voucherName, @voucherType, @dueDate, 
                      @cost, @producer ";
            c.Parameters.AddWithValue("@voucherId",this.voucherId);
            c.Parameters.AddWithValue("@studentId", this.students[0].get_id());
            c.Parameters.AddWithValue("@voucherName", this.voucherName); //??
            c.Parameters.AddWithValue("@voucherType", this.voucherType.ToString());
            c.Parameters.AddWithValue("@dueDate", this.dueDate);
            c.Parameters.AddWithValue("@cost", this.cost);
            c.Parameters.AddWithValue("@producer", this.producer.get_id());
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(c);

            this.students[0].add_student_voucher(this);

            for (int i=1; i<this.students.Count; i++)
            {
                c = new SqlCommand();
                c.CommandText = @"EXECUTE SP_voucher_for_student 
                      @voucherId, @studentId";
                c.Parameters.AddWithValue("@voucherId", this.voucherId);
                c.Parameters.AddWithValue("@studentId", this.students[i].get_id());
                this.students[i].add_student_voucher(this);
                SC = new SQL_CON();
                SC.execute_non_query(c);
            }


            Program.vouchers.Add(this); //adding to system

        }
    }
}
