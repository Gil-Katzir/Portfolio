using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rabin_School
{
    public class ClassRoom
    {
        private string className;
        public List<Employee> homeTeachers;

        public ClassRoom(string className, bool is_new)
        {
            this.className = className;
            this.homeTeachers = new List<Employee>();

            if (is_new)
            {
                this.create_class();

            }
        }

        public string getClassName()
        {
            return className;
        }
        public void setClassName(string className)
        {
            this.className = className;
        }


        public void create_class()
        {
            // adding to database
            SqlCommand c = new SqlCommand();
            c.CommandText = @"EXECUTE SP_add_class 
                      @className";
            c.Parameters.AddWithValue("@className", this.className);

            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(c);

            for (int i = 0; i < Program.employees.Count; i++)
            {
                c = new SqlCommand();
                c.CommandText = @"EXECUTE SP_class_for_teacher    
                                @className, @employeeId";
                c.Parameters.AddWithValue("@className", this.className);
                c.Parameters.AddWithValue("@employeeId", this.homeTeachers[i].get_id());
                this.homeTeachers[i].homeClasses.Add(this);

                SC = new SQL_CON();
                SC.execute_non_query(c);
            }
            Program.classes.Add(this); //adding to system

        }
    }
}
