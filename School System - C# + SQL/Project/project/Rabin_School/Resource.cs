using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabin_School
{
    public class Resource
    {
        public string url;
        public string resource_name;
        public ResourceTypes resource_type;
        public DateTime creating_date;
        public DateTime last_update_date;
        public Student student_documented;
        public Employee teacher_documented;
        public SubmissionBox submission;
        public Assignment assignment;

        
        public Resource(string url, string resource_name, ResourceTypes resource_type, DateTime creating_date, DateTime last_update_date, Student student_documented, Employee teacher_documented, SubmissionBox submission, Assignment assignment,bool isNew)
        {
            this.url = url; 
            this.resource_type = resource_type;
            this.resource_name = resource_name;
            this.creating_date = creating_date;
            this.last_update_date = last_update_date;
            this.student_documented = student_documented;
            this.teacher_documented = teacher_documented;
            this.assignment = assignment;
            this.submission = submission;

            if (isNew)
            {
                this.create_resource();
            }
                    
        }

        public void create_resource()
        {
            // adding to database
            SqlCommand c = new SqlCommand();
            c.CommandText = @"EXECUTE SP_add_resource
                      @resourceUrl, @resourceType, @resourceName, @creatingDate, @lastUpdateDate,
                      @studentId, @employeeId, @assignmentId, @submissionAssignmentId, @submissionStudentId";

            c.Parameters.AddWithValue("@resourceUrl", this.url);
            c.Parameters.AddWithValue("@resourceType", this.resource_type.ToString()); 
            c.Parameters.AddWithValue("@resourceName", this.resource_name);
            c.Parameters.AddWithValue("@creatingDate", this.creating_date);
            c.Parameters.AddWithValue("@lastUpdateDate", this.last_update_date);

            if(this.student_documented!=null)
                c.Parameters.AddWithValue("@studentId", this.student_documented.get_id());
            else
                c.Parameters.AddWithValue("@studentId", DBNull.Value);

            if(this.teacher_documented!=null)
                c.Parameters.AddWithValue("@employeeId", this.teacher_documented.get_id());
            else
                c.Parameters.AddWithValue("@employeeId", DBNull.Value);

            if (this.assignment != null)
                c.Parameters.AddWithValue("@assignmentId", this.assignment.get_id());
            else
                c.Parameters.AddWithValue("@assignmentId", DBNull.Value);


            if (this.submission != null)
            {
                c.Parameters.AddWithValue("@submissionAssignmentId", this.submission.get_assignment_id());
                c.Parameters.AddWithValue("@submissionStudentId", this.submission.get_student_id());
            }
            else
            {
                c.Parameters.AddWithValue("@submissionAssignmentId", DBNull.Value);
                c.Parameters.AddWithValue("@submissionStudentId", DBNull.Value);
            }

            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(c);

            Program.resources.Add(this); //adding to system
        }






    }
}
