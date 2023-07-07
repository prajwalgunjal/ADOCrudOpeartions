using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.net
{
    public class EmployeeDBOperations
    {
        private string connectionString = @"Data source = PRAJWAL; Database = EmployeeDB; Integrated Security = true; TrustServerCertificate = true";
        private SqlConnection sqlConnection;

        public EmployeeDBOperations()
        {
            sqlConnection = new SqlConnection(connectionString);
        }
        public bool AddEmployee(Employee newEmployee)
        {
            try
            {    
                sqlConnection.Open();  

                string query = $"INSERT INTO Employees VALUES ('{newEmployee.Name}',{newEmployee.Age},'{newEmployee.Email}')";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                int result = sqlCommand.ExecuteNonQuery();     /// return int 0 means fail 1 means success 

                if (result > 0)
                {
                    Console.WriteLine($"{result} number of rows affected");
                    sqlConnection.Close();
                    return true;
                }
                else
                {
                    Console.WriteLine("Something went wrong");
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            return false;    
        }


        public void DeleteEmployee(int id)
        {
            sqlConnection.Open();
            string query = $"DELETE FROM Employees WHERE Id = {id}";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            int result = sqlCommand.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Deleted Successfully ");
            }
            else
            {
                Console.WriteLine("Not deleted");
            }
        }


        public void UpdateEmployee()
        {

        }

       /* public List<Employee> GetAllEmployee()
        {

        }*/
        

        public void GetEmployeeByID(int id)
        {

        }
    
    }
}
