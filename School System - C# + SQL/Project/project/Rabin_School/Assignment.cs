using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabin_School
{
    public class Assignment
    {
        public static int assignment_counter;
        public int assignment_id;
        public string assignment_name;
        public DateTime creating_date;
        public DateTime last_submission_date;
        public string description;
        public Employee teacher;
        public List<SubmissionBox> student_submissions;
        

        public Assignment(int assignment_id, string assignment_name, DateTime creating_date, DateTime last_submission_date, string description, Employee teacher, bool isNew)
        {
            this.assignment_id = assignment_id;
            this.assignment_name = assignment_name;
            this.creating_date = creating_date;
            this.last_submission_date = last_submission_date;
            this.description = description;
            this.teacher = teacher;
            student_submissions= new List<SubmissionBox>();

            if (isNew)
            {
                this.create_assignment();
            }

        }

        public void create_assignment()
        {

            // adding to database
            SqlCommand c = new SqlCommand();
            c.CommandText = @"EXECUTE SP_add_assignment
                      @assignemntId, @assignmentName, @creatingDate, @submissionDate, @assignmentDescription, @employeeId";

            c.Parameters.AddWithValue("@assignemntId", this.assignment_id);
            c.Parameters.AddWithValue("@assignmentName", this.assignment_name);
            c.Parameters.AddWithValue("@creatingDate", this.creating_date); 
            c.Parameters.AddWithValue("@submissionDate", this.last_submission_date);
            c.Parameters.AddWithValue("@assignmentDescription", this.description);
            c.Parameters.AddWithValue("@employeeId", this.teacher.get_id());
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(c);

            Program.assignments.Add(this); //adding to system

        }

        public int get_id()
        {
            return assignment_id;
        }
    }
}
