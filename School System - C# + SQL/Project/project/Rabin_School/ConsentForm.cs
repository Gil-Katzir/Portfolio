using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabin_School
{
    public class ConsentForm
    {
        public Student student;
        public ExternalActivity activity;
        private DateTime signDate;
        private string healthIssues;

        public ConsentForm(DateTime signDate, string healthIssues, ExternalActivity activity, Student student, bool is_new)
        {
            this.student = student;
            this.activity = activity;
            this.signDate = signDate;
            this.healthIssues = healthIssues;

            if (is_new)
            {
                this.create_consent_form();
                this.student.activities_consent_forms.Add(this);
                this.activity.add_student_consent_form(this);
            }
            
        }

        public ExternalActivity get_activity()
        {
            return this.activity;
        }

        public void create_consent_form()
        {
            // adding to database
            SqlCommand c = new SqlCommand();
            c.CommandText = @"EXECUTE SP_add_consent_form 
                      @dateOfSign, @healthIssues, @activityId, @studentId";
            c.Parameters.AddWithValue("@dateOfSign", this.signDate);
            c.Parameters.AddWithValue("@healthIssues", this.healthIssues);
            c.Parameters.AddWithValue("@activityId", this.activity.get_id());
            c.Parameters.AddWithValue("@studentId", this.student.get_id()); //??


            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(c);

            Program.consent_forms.Add(this);

        }

    }
}
