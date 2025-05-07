using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabin_School
{
    public class SubmissionBox
    {
        public Student student_submission;
        public Assignment submitted_assignment;
        public DateTime? last_upload;
        public SubmissionBoxStatuses status;


        public SubmissionBox(Student student_submission, Assignment submitted_assignment,DateTime? last_upload,SubmissionBoxStatuses status ,bool isNew)
        {
            this.student_submission = student_submission;
            this.submitted_assignment = submitted_assignment;
            this.last_upload = last_upload;
            this.status = status;

            if (isNew)
            {
                this.create_submission();
            }
        }

        public void create_submission()
        {
            // adding to database
            SqlCommand c = new SqlCommand();
            c.CommandText = @"EXECUTE SP_add_submission
                      @studentId, @assignmentId, @lastUpload, @submissionStatus";

            c.Parameters.AddWithValue("@studentId", this.student_submission.get_id());
            c.Parameters.AddWithValue("@assignmentId", this.submitted_assignment.get_id());
            
            if (this.last_upload!=null)
                c.Parameters.AddWithValue("@lastUpload", this.last_upload);
            else
                c.Parameters.AddWithValue("@lastUpload", DBNull.Value);

            c.Parameters.AddWithValue("@submissionStatus", this.status.ToString());
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(c);

            Program.submissions.Add(this); //adding to system
        }


        public int get_student_id()
        {
            return this.student_submission.get_id();
        }

        public int get_assignment_id()
        {
            return this.submitted_assignment.get_id();
        }

    }
}
