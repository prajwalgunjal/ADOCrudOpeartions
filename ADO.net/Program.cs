using System.Data.SqlClient;

namespace ADO.net
{
    public class Program
    {


        static void Main(string[] args)
        {
            EmployeeDBOperations employeeDBOperations = new EmployeeDBOperations();
            Employee employee = new(){
                Name = "Sarika",
                Age = 35,
                Email = "Sarika@gmail.com"
            };

            //employeeDBOperations.AddEmployee(employee);
            //employeeDBOperations.DeleteEmployee(3);

            /*Employee updaatedEmployeee = new() { 
            Name= "Prajkta"
            };
            employeeDBOperations.UpdateEmployee(1,updaatedEmployeee);
*/

            employeeDBOperations.GetAllEmployee();
        }
    }
}