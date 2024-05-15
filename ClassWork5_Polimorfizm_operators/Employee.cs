using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassWork5_Polimorfizm_operators
{
    internal class Employee
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public string Responsibilities {get; set;}
        public decimal Salary { get; set; }
        public Employee(string fullName, DateTime dateOfBirth, string phoneNumber, string email, string position, string responsibilities, decimal salary)
        {
            this.Name = fullName;
            this.DateOfBirth = dateOfBirth;
            this.Phone = phoneNumber;
            this.Email = email;
            this.Position = position;
            this.Responsibilities = responsibilities;
            this.Salary = salary;
        }
        public static decimal operator +(Employee a, decimal salary) 
        {
            return a.Salary + salary;
        }
        public static decimal operator -(Employee a, decimal salary)
        {
            return a.Salary - salary;
        }
        public static bool operator ==(Employee a, Employee b)
        {
            return a.Salary == b.Salary;
        }
        public static bool operator !=(Employee a, Employee b)
        {
            return a.Salary != b.Salary;
        }
        public static bool operator >(Employee a, Employee b)
        {
            return a.Salary > b.Salary;
        }
        public static bool operator <(Employee a, Employee b)
        {
            return a.Salary < b.Salary;
        }
        public override bool Equals(object? obj)
        {
            if (obj is Employee other)
            {
                return this.Salary == other.Salary;
            }
            return false;
        }
        public override string ToString()
        {
            return $"Name: {Name}, date: {DateOfBirth}, phone: {Phone}, Email: {Email}, position: {Position}, " +
                $"responsibilities: {Responsibilities}, Salary: {Salary}";
        }
    }
}
