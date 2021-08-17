using System;
using System.Collections.Generic;
using System.Text;

namespace PracticalTest
{
    /*main abstract class*/
    /// <summary>
    /// abstract class employee
    /// parameters involved are
    /// emp_id
    /// emp_name
    /// address
    /// basic_pay
    /// </summary>
    abstract class Employee
    {
        public string Emp_ID { get; set; }
        public string Emp_Name { get; set; }
        public string Address { get; set; }
        protected double BasicPay { get; set; }


        /*Constructor Class Employee*/
        /// <summary>
        /// constructor class definition
        /// </summary>
        /// <param name="empID"></param>
        /// <param name="empName"></param>
        /// <param name="Addr"></param>
        /// <param name="bpay"></param>

        public Employee(string empID, string empName, string Addr, double bpay)
        {
            Emp_ID = empID;
            Emp_Name = empName;
            Address = Addr;
            BasicPay = bpay;
        }


        /* Abstract Class to Calculate Total salary */
        /// <summary>
        /// abstract class definition
        /// </summary>
        /// <returns></returns>

        public abstract double CalculateSalary();

        /*overriding method*/
        /// <summary>
        /// overriding salary
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ("Emp_ID is " + Emp_ID + "\n" + " Emp Name is " + Emp_Name);
        }
    }

    class Technical_Employee : Employee

    {
        string[] TechnicalSkills;


        /* Constructor of Derived class Technical_Employee*/
        /// <summary>
        /// technical employee class
        /// </summary>
        /// <param name="emp_ID"></param>
        /// <param name="emp_Name"></param>
        /// <param name="Addr"></param>
        /// <param name="bpay"></param>
        /// <param name="language_Skills"></param>
        public Technical_Employee(string emp_ID, string emp_Name, string Addr, double bpay, string[] language_Skills) : base(emp_ID, emp_Name, Addr, bpay)
        {
            TechnicalSkills = language_Skills;
        }


        /* Overrided abstract method to Calculate Salary for Employee*/
        /// <summary>
        /// salary calculate for technical employee
        /// </summary>
        /// <returns></returns>

        public override double CalculateSalary()
        {
            return (base.BasicPay + 0.12 * base.BasicPay);  /*Salary = Basic Pay + HRA (12%)*/
        }
    }
    class StaffMember : Employee
    {
        string[] Title;


        /* Constructor of Derived Class StaffMember*/
        /// <summary>
        /// salary calculatioon for staff
        /// </summary>
        /// <param name="emp_ID"></param>
        /// <param name="Name"></param>
        /// <param name="Add"></param>
        /// <param name="Pay"></param>
        /// <param name="title"></param>
        public StaffMember(string emp_ID, string Name, string Add, double Pay, string[] title) : base(emp_ID, Name, Add, Pay)
        {
            Title = title;
        }

        /*Overrided Method to Calculate Salary for staff.*/
        /// <summary>
        /// overriding salary for staff
        /// </summary>
        /// <returns></returns>

        public override double CalculateSalary()
        {
            return (base.BasicPay + 0.18 * base.BasicPay); /*Salary = Basic Pay + HRA (18%)*/
        }

    }
    /*main driver class*/
    class UsingPeople
    {
        static void Main()


        {

            Technical_Employee t = new Technical_Employee("12345", "vikram",
                "Kodagu, Karnataka", 18000,
                new string[] { "c", "java", "c++" }); /*Calling Constructor to create Technical Employee*/
            Console.WriteLine("Creating Technical_Employee and Details : \n");/*Calling the Overrided technical_employee*/
            Console.WriteLine(t.ToString() + " and Salary is " + t.CalculateSalary());
            StaffMember s = new StaffMember("1234", "vikram",
                "Kodagu, Karnataka", 22000,
                new string[] { "Hose Keeping", "Security" });

            Console.WriteLine("Creating StaffMember and Details: \n");/* calling staff member function*/
            Console.WriteLine(s.ToString() +
                " and Salary is " + s.CalculateSalary()); /* Calling the Overrided to calculate salary*/
        }
    }
}
