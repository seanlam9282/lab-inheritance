using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_inheritance.Entity
{
    internal class Employee
    {
        protected string id;
        protected string name;
        protected string address;
        protected string phone;
        protected long sin;
        protected string birthdate;
        protected string department;

        public Employee() { }
        public Employee(string id, string name, string address, string phone, long sin, string birthdate, string department) 
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.phone = phone;
            this.sin = sin;
            this.birthdate = birthdate;
            this.department = department;
        }

        public string Id 
        {
            get => id; set => id = value;
        }
        public string Name 
        {
            get => name; set => name = value;
        }
        public string Address
        {
            get => address; set => address = value;
        }
        public string Phone
        {
            get => phone; set => phone = value;
        }
        public long Sin
        {
            get => sin; set => sin = value;
        }
        public string Birthdate
        {
            get => birthdate; set => birthdate = value;
        }
        public string Department
        {
            get => department; set => department = value;
        }
    }
    
}
