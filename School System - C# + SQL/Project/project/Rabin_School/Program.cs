using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rabin_School
{
     static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>\
        public static System.Collections.Generic.List<Employee> employees;
        public static System.Collections.Generic.List<ClassRoom> classes;
        public static System.Collections.Generic.List<Student> students;
        public static System.Collections.Generic.List<Voucher> vouchers;
        public static System.Collections.Generic.List<ExternalActivity> activities;
        public static System.Collections.Generic.List<ConsentForm> consent_forms;
        public static System.Collections.Generic.List<Resource> resources;
        public static System.Collections.Generic.List<Assignment> assignments;
        public static System.Collections.Generic.List<SubmissionBox> submissions;

        [STAThread]



        //שיטה שמחפשת עובד ברשימה לפי תעודת זהות
        public static Employee seekEmployee(int id)
        {
            foreach (Employee w in employees)
            {
                if (w.get_id() == id)
                    return w;
            }
            return null;
        }

        //שיטה שמחפשת סטודנט ברשימה לפי תעודת זהות
        public static Student seekStudent(int id)
        {
            foreach (Student s in students)
            {
                if (s.get_id() == id)
                    return s;
            }
            return null;
        }

        public static void initLists()//מילוי הרשימות מתוך בסיס הנתונים
        {
            
            init_employees();//אתחול הרשימה של העובדים 
            init_classes();//אתחול הרשימה של הכיתות
            init_students();//אתחול הרשימה של הסטודנטים
            init_vouchers();//אתחול הרשימה של השוברים
            init_external_activities();// אתחול הרשימה של פעילויות החוץ
            init_consent_forms(); // אתחול רשימת אישורי יציאה לפעילויות חוץ
            init_assignments();//אתחול רשימת המטלות
            init_submissions();// אתחול רשימת הגשת מטלות
            init_resources();//אתחול רשימת קבצי המערכת


        }


        public static void init_employees()//מילוי המערך מתוך בסיס הנתונים
        {
            SqlCommand c = new SqlCommand();
            c.CommandText = "EXECUTE dbo.SP_get_all_employees";
            SQL_CON SC = new SQL_CON();
            SqlDataReader rdr = SC.execute_query(c);

            employees = new List<Employee>();

            while (rdr.Read())
            {
                GenderTypes gender = (GenderTypes)Enum.Parse(typeof(GenderTypes), rdr.GetValue(3).ToString());
                EmployeeStatuses status = (EmployeeStatuses)Enum.Parse(typeof(EmployeeStatuses), rdr.GetValue(9).ToString());
                EmployeeRoles e_role = (EmployeeRoles)Enum.Parse(typeof(EmployeeRoles), rdr.GetValue(10).ToString());

                Employee employee=new Employee(int.Parse(rdr.GetValue(0).ToString()), rdr.GetValue(1).ToString(), rdr.GetValue(2).ToString(),
                     gender, DateTime.Parse(rdr.GetValue(4).ToString()), rdr.GetValue(5).ToString(), rdr.GetValue(6).ToString(), rdr.GetValue(7).ToString(), DateTime.Parse(rdr.GetValue(8).ToString()), status,e_role, false) ;

                employees.Add(employee);
            }
        }

        public static void init_students()//מילוי המערך מתוך בסיס הנתונים
        {
            SqlCommand c = new SqlCommand();
            c.CommandText = "EXECUTE dbo.SP_get_all_students";
            SQL_CON SC = new SQL_CON();
            SqlDataReader rdr = SC.execute_query(c);

            students = new List<Student>();

            while (rdr.Read())
            {
                GenderTypes gender = (GenderTypes)Enum.Parse(typeof(GenderTypes), rdr.GetValue(3).ToString());

                ClassRoom student_class = findClass(rdr.GetValue(9).ToString());
                Student student = new Student(int.Parse(rdr.GetValue(0).ToString()), rdr.GetValue(1).ToString(), rdr.GetValue(2).ToString(),
                     gender, DateTime.Parse(rdr.GetValue(4).ToString()), rdr.GetValue(5).ToString(), rdr.GetValue(6).ToString(), rdr.GetValue(7).ToString(), rdr.GetValue(8).ToString(), student_class, false);

                students.Add(student);
            }
        }

        public static void init_classes()//מילוי המערך מתוך בסיס הנתונים
        {
            SqlCommand c = new SqlCommand();
            c.CommandText = "EXECUTE dbo.SP_get_all_classes";
            SQL_CON SC = new SQL_CON();
            SqlDataReader rdr = SC.execute_query(c);

            classes = new List<ClassRoom>();

            while (rdr.Read())
            {
                ClassRoom cr = new ClassRoom(rdr.GetValue(0).ToString(), false);
                classes.Add(cr);
                for (int j = 0; j < Program.employees.Count; j++)
                {
                    SqlCommand cc = new SqlCommand();
                    cc.CommandText = "EXECUTE dbo.SP_check_employee_homeclass @employeeId, @className";
                    cc.Parameters.AddWithValue("@employeeId", Program.employees[j].get_id());
                    cc.Parameters.AddWithValue("@className", cr.getClassName());
                    SQL_CON SC2 = new SQL_CON();
                    SqlDataReader rdr2 = SC2.execute_query(cc);
                    if (rdr2.Read())
                    {
                        if (int.Parse(rdr2.GetValue(0).ToString()) == 1)
                        {
                            Program.employees[j].homeClasses.Add(cr);
                            cr.homeTeachers.Add(Program.employees[j]);
                        }
                    }
                }
            }
        }

        public static void init_vouchers()//מילוי המערך מתוך בסיס הנתונים
        {
            int maxVoucherId=0;
            SqlCommand c = new SqlCommand();
            c.CommandText = "EXECUTE dbo.SP_get_all_vouchers";
            SQL_CON SC = new SQL_CON();
            SqlDataReader rdr = SC.execute_query(c);

            vouchers = new List<Voucher>();

            while (rdr.Read())
            {
                Employee s = findEmployee(int.Parse(rdr.GetValue(5).ToString()));
                VoucherTypes types = (VoucherTypes)Enum.Parse(typeof(VoucherTypes), rdr.GetValue(2).ToString());

                Voucher v = new Voucher(int.Parse(rdr.GetValue(0).ToString()), rdr.GetValue(1).ToString(), types 
                     ,DateTime.Parse(rdr.GetValue(3).ToString()), float.Parse(rdr.GetValue(4).ToString()), s , false);

                vouchers.Add(v);
                if(maxVoucherId<v.get_id())
                {
                    maxVoucherId = v.get_id();
                }

                for (int j=0; j<Program.students.Count; j++)
                {
                    SqlCommand cc = new SqlCommand();
                    cc.CommandText = "EXECUTE dbo.SP_check_student_voucher @studentId, @voucherId";
                    cc.Parameters.AddWithValue("@studentId", Program.students[j].get_id());
                    cc.Parameters.AddWithValue("@voucherId", v.get_id());
                    SQL_CON SC2 = new SQL_CON();
                    SqlDataReader rdr2 = SC2.execute_query(cc);

                    if (rdr2.Read())
                    {
                        if (int.Parse(rdr2.GetValue(0).ToString()) == 1)
                        {
                            Program.students[j].add_student_voucher(v);
                            v.students.Add(Program.students[j]);
                        }
                    }

                }
            }
            Voucher.voucher_counter=maxVoucherId;
        }

        public static void init_external_activities()
        {
            SqlCommand c = new SqlCommand();
            c.CommandText = "EXECUTE dbo.SP_get_all_external_activities";
            SQL_CON SC = new SQL_CON();
            SqlDataReader rdr = SC.execute_query(c);
            activities = new List<ExternalActivity>();


            while (rdr.Read())
            {
                ActivityTypes activityType = (ActivityTypes)Enum.Parse(typeof(ActivityTypes), rdr.GetValue(4).ToString());
                ExternalActivity a =new ExternalActivity(int.Parse(rdr.GetValue(0).ToString()), DateTime.Parse(rdr.GetValue(1).ToString()), int.Parse(rdr.GetValue(2).ToString()), float.Parse(rdr.GetValue(3).ToString()), activityType, DateTime.Parse(rdr.GetValue(5).ToString()));
                activities.Add(a);

                for (int j = 0; j < Program.students.Count; j++)
                {
                    SqlCommand cc = new SqlCommand();
                    cc.CommandText = "EXECUTE dbo.SP_check_invited_student_activity @studentId, @activityId";
                    cc.Parameters.AddWithValue("@studentId", Program.students[j].get_id());
                    cc.Parameters.AddWithValue("@activityId", a.get_id());
                    SQL_CON SC2 = new SQL_CON();
                    SqlDataReader rdr2 = SC2.execute_query(cc);

                    if (rdr2.Read())
                    {
                        if (int.Parse(rdr2.GetValue(0).ToString()) == 1)
                        {
                            Program.students[j].add_student_activity(a);
                            a.students_invited.Add(Program.students[j]);
                        }
                    }

                }

            }
        }

        public static void init_assignments()
        {
            int maxAssignmentId = 0;
            SqlCommand c = new SqlCommand();
            c.CommandText = "EXECUTE dbo.SP_get_all_assignments";
            SQL_CON SC = new SQL_CON();
            SqlDataReader rdr = SC.execute_query(c);
            assignments = new List<Assignment>();


            while (rdr.Read())
            {

                Employee e = findEmployee(int.Parse(rdr.GetValue(5).ToString()));
                Assignment a = new Assignment(int.Parse(rdr.GetValue(0).ToString()), rdr.GetValue(1).ToString(), DateTime.Parse(rdr.GetValue(2).ToString()), DateTime.Parse(rdr.GetValue(3).ToString()), rdr.GetValue(4).ToString(), e, false);
                assignments.Add(a);
                if (maxAssignmentId < a.get_id())
                {
                    maxAssignmentId = a.get_id();
                }

            }
            Assignment.assignment_counter = maxAssignmentId;

        }

        public static void init_consent_forms()
        {
            SqlCommand c = new SqlCommand();
            c.CommandText = "EXECUTE dbo.SP_get_all_consent_forms";
            SQL_CON SC = new SQL_CON();
            SqlDataReader rdr = SC.execute_query(c);
            consent_forms = new List<ConsentForm>();

            while (rdr.Read())
            {
                Student s = findStudent(int.Parse(rdr.GetValue(3).ToString()));
                ExternalActivity a = findActivity(int.Parse(rdr.GetValue(2).ToString()));
                ConsentForm c_f = new ConsentForm(DateTime.Parse(rdr.GetValue(0).ToString()), rdr.GetValue(1).ToString(), a, s, false);
                consent_forms.Add(c_f);
                s.add_activity_consent_form(c_f);
                a.add_student_consent_form(c_f);
            }
        }


        public static void init_submissions()
        {
            SqlCommand c = new SqlCommand();
            c.CommandText = "EXECUTE dbo.SP_get_all_submissions";
            SQL_CON SC = new SQL_CON();
            SqlDataReader rdr = SC.execute_query(c);
            submissions = new List<SubmissionBox>();

            while (rdr.Read())
            {
                Student s = findStudent(int.Parse(rdr.GetValue(1).ToString()));
                Assignment a = findAssignment(int.Parse(rdr.GetValue(2).ToString()));
                SubmissionBoxStatuses submission_status = (SubmissionBoxStatuses)Enum.Parse(typeof(SubmissionBoxStatuses), rdr.GetValue(3).ToString());
                SubmissionBox sub;
                if (rdr.GetValue(0)== DBNull.Value)
                    sub = new SubmissionBox(s, a, null, submission_status, false);
                else
                    sub = new SubmissionBox(s, a, DateTime.Parse(rdr.GetValue(0).ToString()), submission_status, false);

                submissions.Add(sub);
                s.assignment_subbmisions.Add(sub);
                a.student_submissions.Add(sub);
            }
        }

        public static void init_resources()//מילוי המערך מתוך בסיס הנתונים
        {
            SqlCommand c = new SqlCommand();
            c.CommandText = "EXECUTE dbo.SP_get_all_resources";
            SQL_CON SC = new SQL_CON();
            SqlDataReader rdr = SC.execute_query(c);

            resources = new List<Resource>();

            while (rdr.Read())
            {
                ResourceTypes resource_type = (ResourceTypes)Enum.Parse(typeof(ResourceTypes), rdr.GetValue(1).ToString());
                Student student_doc;
                if (rdr.GetValue(5) != DBNull.Value)
                    student_doc = findStudent(int.Parse(rdr.GetValue(5).ToString()));
                else
                    student_doc = null;
                Employee emp_doc;
                if (rdr.GetValue(6) != DBNull.Value)
                    emp_doc = findEmployee(int.Parse(rdr.GetValue(6).ToString()));
                else
                    emp_doc = null;
                SubmissionBox sub;
                if (rdr.GetValue(9) != DBNull.Value && rdr.GetValue(8)!= DBNull.Value)
                    sub = findSubmission(int.Parse(rdr.GetValue(9).ToString()), int.Parse(rdr.GetValue(8).ToString()));
                else
                    sub = null;
                Assignment a;
                if (rdr.GetValue(7) != DBNull.Value)
                    a = findAssignment(int.Parse(rdr.GetValue(7).ToString()));
                else
                    a = null;

                Resource r = new Resource(rdr.GetValue(0).ToString(), rdr.GetValue(2).ToString(), resource_type, DateTime.Parse(rdr.GetValue(3).ToString()), DateTime.Parse(rdr.GetValue(4).ToString()), student_doc, emp_doc, sub, a, false);
                resources.Add(r);

            }
        }

        public static ClassRoom findClass(string Class_name)
        {
            foreach (ClassRoom c in classes)
            {
                if (c.getClassName() == Class_name)
                    return c;
            }
            return new ClassRoom(Class_name, true);
        }

        public static Employee findEmployee(int id)
        {
            foreach (Employee e in employees)
            {
                if (e.get_id() == id)
                    return e;
            }
            return null;
        }

        public static Student findStudent(int id)
        {
            foreach (Student s in students)
            {
                if (s.get_id() == id)
                    return s;
            }
            return null;
        }

        public static ExternalActivity findActivity(int id)
        {
            foreach (ExternalActivity a in activities)
            {
                if (a.get_id() == id)
                    return a;
            }
            return null;
        }

        public static Assignment findAssignment(int id)
        {
            foreach (Assignment a in assignments)
            {
                if (a.get_id() == id)
                    return a;
            }
            return null;
        }
        public static SubmissionBox findSubmission(int student_id, int assignment_id)
        {
            foreach (SubmissionBox s in submissions)
            {
                if (s.get_assignment_id() == assignment_id && s.get_student_id() == student_id)
                    return s;
            }
            return null;
        }

        public static Resource find_resource_by_sub(SubmissionBox submission)
        {
            foreach(Resource r in resources)
            {
                if(r.submission==submission)
                    return r;
            }
            return null;
        }

        public static bool is_duplicate_url(string url)
        {
            foreach(Resource r in resources)
            {
                if(r.url.Equals(url))
                    return true;
            }
            return false;
        }
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            initLists();//אתחול כל הרשימות
            Application.Run(new login()); //Main
            Application.Exit();

        }
    }
}
