using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabin_School
{
    public class Student
    {
        private string firstName;
        private int id;
        private string lastName;
        private GenderTypes gender;
        private DateTime birthdate;
        private string phone;
        private string address;
        private string email;
        private string learning_difficulties;
        private ClassRoom classRoom;
        public List<Voucher> vouchers;
        public List<ExternalActivity> activities_invitations;
        public List<ConsentForm> activities_consent_forms; 
        public List<SubmissionBox> assignment_subbmisions;

        public Student(int id, string firstName, string lastName, GenderTypes gender, DateTime birthdate,
                string phone, string address, string email, string learning_difficulties, ClassRoom classRoom, bool is_new)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.gender = gender;
            this.birthdate = birthdate;
            this.phone = phone;
            this.address = address;
            this.email = email;
            this.learning_difficulties = learning_difficulties;
            this.classRoom = classRoom;
            this.vouchers= new List<Voucher>();
            this.activities_invitations = new List<ExternalActivity>();
            this.activities_consent_forms=new List<ConsentForm>();
            this.assignment_subbmisions= new List<SubmissionBox>();



            if (is_new)
            {
                this.create_student();
            }
        }

        // Get and Set for FirstName

        public void add_student_activity(ExternalActivity activity)
        {
            this.activities_invitations.Add(activity);
        }
        public string get_firstName()
        {
            return this.firstName;
        }

        public void set_firstName(string name)
        {
            this.firstName = name;
        }

        // Get and Set for ID
        public int get_id()
        {
            return this.id;
        }



        // Get and Set for LastName
        public string get_lastName()
        {
            return this.lastName;
        }

        public void set_lastName(string name)
        {
            this.lastName = name;
        }

        // Get and Set for Gender
        public GenderTypes get_gender()
        {
            return this.gender;
        }

        public void set_gender(GenderTypes gender)
        {
            this.gender = gender;
        }

        // Get and Set for Birthdate
        public DateTime get_birthdate()
        {
            return this.birthdate;
        }

        public void set_birthdate(DateTime date)
        {
            this.birthdate = date;
        }

        // Get and Set for Phone
        public string get_phone()
        {
            return this.phone;
        }

        public void set_phone(string phone)
        {
            this.phone = phone;
        }


        // Get and Set for Address
        public string get_address()
        {
            return this.address;
        }

        public void set_address(string address)
        {
            this.address = address;
        }

        // Get and Set for Email
        public string get_email()
        {
            return this.email;
        }

        public void set_email(string email)
        {
            this.email = email;
        }

        // Get and Set for learning_difficulties
        public string get_learning_difficulties()
        {
            return this.learning_difficulties;
        }

        public void set_learning_difficulties(string learning_difficulties)
        {
            this.learning_difficulties = learning_difficulties;
        }

        // Get and Set for classRoom
        public ClassRoom get_classRoom()
        {
            return this.classRoom;
        }

        public void set_classRoom(ClassRoom classRoom)
        {
            this.classRoom = classRoom;
        }

        public void create_student()
        {
            // adding to database
            SqlCommand c = new SqlCommand();
            c.CommandText = @"EXECUTE SP_add_employee 
                      @id, @firstName, @lastName, @gender, @birthdate, 
                      @phone, @studentAddress, @email, 
                      @learningDifficulties, @className";
            c.Parameters.AddWithValue("@id", this.id);
            c.Parameters.AddWithValue("@firstName", this.firstName);
            c.Parameters.AddWithValue("@lastName", this.lastName);
            c.Parameters.AddWithValue("@gender", this.gender.ToString()); //??
            c.Parameters.AddWithValue("@birthdate", this.birthdate);
            c.Parameters.AddWithValue("@phone", this.phone);
            c.Parameters.AddWithValue("@studentAddress", this.address);
            c.Parameters.AddWithValue("@email", this.email);
            c.Parameters.AddWithValue("@learningDifficulties", this.learning_difficulties); //??
            c.Parameters.AddWithValue("@className", this.classRoom); //??


            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(c);

            Program.students.Add(this); //adding to system

        }

        public void add_student_voucher(Voucher voucher)
        {
            this.vouchers.Add(voucher);
        }

        public void add_activity_consent_form(ConsentForm c_f)
        {
            this.activities_consent_forms.Add(c_f);
        }

        public List<int> get_activities_to_sign()
        {
            List<int> activities_to_sign= new List<int>();
            foreach(ExternalActivity a in this.activities_invitations)
            {
                bool is_in_cf_list = false;
                foreach (ConsentForm cf in this.activities_consent_forms)
                {
                    if(cf.get_activity().get_id()==a.get_id())
                    {
                        is_in_cf_list = true;
                    }

                }
                if(!is_in_cf_list)
                    activities_to_sign.Add(a.get_id());
            }
            return activities_to_sign;
        }

        public List<int> get_assignments_to_submit()
        {
            List<int> assignments_to_submit = new List<int>();
            foreach(SubmissionBox sub in this.assignment_subbmisions)
            {
                if(sub.submitted_assignment.last_submission_date>DateTime.Now)
                {
                    assignments_to_submit.Add(sub.submitted_assignment.get_id());
                }
            }
            return assignments_to_submit;

        }

        public SubmissionBox find_sub_by_assignment(Assignment assignment)
        {
            foreach(SubmissionBox sub in this.assignment_subbmisions)
            {
                if(sub.submitted_assignment== assignment)
                    return sub;
            }
            return null;
        }

    }
}
