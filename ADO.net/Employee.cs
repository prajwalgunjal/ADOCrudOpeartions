using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.net
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name{get; set;}
        public int Age{get;set;}
        public string Email{get; set;}


        public Employee(string name ,int age, string email) { 
            Name = name;
            Age = age;
            Email = email;
        }

        public Employee()
        {
        }
    }
}
