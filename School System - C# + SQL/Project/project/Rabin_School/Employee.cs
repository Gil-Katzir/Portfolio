using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;


namespace Rabin_School
{
    public class Employee
    {
        private string firstName;
        private int id;
        private string lastName;
        private GenderTypes gender;  
        private DateTime birthdate;
        private string phone;
        private string address;
        private string email;
        private DateTime startWorkingDate; //date
        private EmployeeStatuses employeeStatus; 
        private EmployeeRoles role;
        public List<ClassRoom> homeClasses;


        public Employee(int id, string firstName,  string lastName, GenderTypes gender, DateTime birthdate,
                        string phone, string address, string email, DateTime startWorkingDate,
                        EmployeeStatuses employeeStatus, EmployeeRoles role, bool is_new)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.gender = gender;
            this.birthdate = birthdate;
            this.phone = phone;
            this.address = address;
            this.email = email;
            this.startWorkingDate = startWorkingDate;
            this.employeeStatus = employeeStatus;
            this.role = role;
            this.homeClasses = new List<ClassRoom>();

            if (is_new)
            {
                this.create_employee();
            }
        }

        // Get and Set for FirstName
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

        // Get and Set for StartWorkingDate
        public DateTime get_startWorkingDate()
        {
            return this.startWorkingDate;
        }

        public void set_startWorkingDate(DateTime date)
        {
            this.startWorkingDate = date;
        }

        // Get and Set for TeacherStatus
        public EmployeeStatuses get_employeeStatus()
        {
            return this.employeeStatus;
        }

        public void set_employeeStatus(EmployeeStatuses status)
        {
            this.employeeStatus = status;
        }

        // Get and Set for Role
        public EmployeeRoles get_role()
        {
            return this.role;
        }

        public void set_role(EmployeeRoles role)
        {
            this.role = role;
        }

        public void set_all(int id, string firstName,  string lastName, GenderTypes gender, DateTime birthdate,
                        string phone, string address, string email, DateTime startWorkingDate,
                        EmployeeStatuses employeeStatus, EmployeeRoles role)
            {
                this.firstName = firstName;
                this.id = id;
                this.lastName = lastName;
                this.gender = gender;
                this.birthdate = birthdate;
                this.phone = phone;
                this.address = address;
                this.email = email;
                this.startWorkingDate = startWorkingDate;
                this.employeeStatus = employeeStatus;
                this.role = role;
        }

        /*
        public System.Collections.Generic.List<Order> orders;

        /// <summary>
        /// Property for collection of Order
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public System.Collections.Generic.List<Order> Orders
        {
            get
            {
                if (orders == null)
                    orders = new System.Collections.Generic.List<Order>();
                return orders;
            }
            set
            {
                RemoveAllOrders();
                if (value != null)
                {
                    foreach (Order oOrder in value)
                        AddOrders(oOrder);
                }
            }
        }

        /// <summary>
        /// Add a new Order in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        /// 
        
        public void AddOrders(Order newOrder)
        {
            if (newOrder == null)
                return;
            if (this.orders == null)
                this.orders = new System.Collections.Generic.List<Order>();
            if (!this.orders.Contains(newOrder))
            {
                this.orders.Add(newOrder);
                newOrder.Worker = this;
            }
        }

        /// <summary>
        /// Remove an existing Order from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveOrders(Order oldOrder)
        {
            if (oldOrder == null)
                return;
            if (this.orders != null)
                if (this.orders.Contains(oldOrder))
                {
                    this.orders.Remove(oldOrder);
                    oldOrder.Worker = null;
                }
        }

        /// <summary>
        /// Remove all instances of Order from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllOrders()
        {
            if (orders != null)
            {
                System.Collections.ArrayList tmpOrders = new System.Collections.ArrayList();
                foreach (Order oldOrder in orders)
                    tmpOrders.Add(oldOrder);
                orders.Clear();
                foreach (Order oldOrder in tmpOrders)
                    oldOrder.Worker = null;
                tmpOrders.Clear();
            }
        }

        public string getID()
        {
            return this.WorkerId;
        }
        */

        public void create_employee()
        {

            // adding to database
            SqlCommand c = new SqlCommand();
            c.CommandText = @"EXECUTE SP_add_employee 
                      @id, @firstName, @lastName, @gender, @birthdate, 
                      @phone, @employeeAddress, @email, 
                      @startWorkingDate, @employeeStatus, @employeeRole";
            c.Parameters.AddWithValue("@firstName", this.firstName);
            c.Parameters.AddWithValue("@id", this.id);
            c.Parameters.AddWithValue("@lastName", this.lastName);
            c.Parameters.AddWithValue("@gender", this.gender.ToString()); //??
            c.Parameters.AddWithValue("@birthdate", this.birthdate);
            c.Parameters.AddWithValue("@phone", this.phone);
            c.Parameters.AddWithValue("@employeeAddress", this.address);
            c.Parameters.AddWithValue("@email", this.email);
            c.Parameters.AddWithValue("@startWorkingDate", this.startWorkingDate); //??
            c.Parameters.AddWithValue("@employeeStatus", this.employeeStatus.ToString());
            c.Parameters.AddWithValue("@employeeRole", this.role.ToString());
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(c);

            Program.employees.Add(this); //adding to system

        }

        public void Update_employee()
        {
            
            SqlCommand c = new SqlCommand();
            c.CommandText = @"EXECUTE dbo.SP_update_employee 
                      @id, @firstName, @lastName, @gender, @birthdate, 
                      @phone, @employeeAddress, @email, 
                      @startWorkingDate, @employeeStatus, @employeeRole";
            c.Parameters.AddWithValue("@firstName", this.firstName);
            c.Parameters.AddWithValue("@id", this.id);
            c.Parameters.AddWithValue("@lastName", this.lastName);
            c.Parameters.AddWithValue("@gender", this.gender.ToString()); //??
            c.Parameters.AddWithValue("@birthdate", this.birthdate);
            c.Parameters.AddWithValue("@phone", this.phone);
            c.Parameters.AddWithValue("@employeeAddress", this.address);
            c.Parameters.AddWithValue("@email", this.email);
            c.Parameters.AddWithValue("@startWorkingDate", this.startWorkingDate);
            c.Parameters.AddWithValue("@employeeStatus", this.employeeStatus.ToString()); //??
            c.Parameters.AddWithValue("@employeeRole", this.role.ToString()); //??
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(c);
        }

        public void Delete_employee()
        {
            Program.employees.Remove(this); ///??
            SqlCommand c = new SqlCommand();
            c.CommandText = "EXECUTE dbo.SP_delete_employee @id";
            c.Parameters.AddWithValue("@id", this.id);
            SQL_CON SC = new SQL_CON();
            SC.execute_non_query(c);
        }


    }
}


