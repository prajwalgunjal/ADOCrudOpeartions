﻿using System;
using System.Collections.Concurrent;
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

                }
                else
                {
                    Console.WriteLine("Something went wrong");
                    sqlConnection.Close();
                }
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }   
        }


        public bool DeleteEmployee(int id)
        {
            try
            {
                sqlConnection.Open();
                string query = $"DELETE FROM Employees WHERE Id = {id}";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                int result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Deleted..");
                    Console.WriteLine($"{result} number of rows affected");

                }
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public bool UpdateEmployee(int id,Employee employee)
        {
            try
            {
                sqlConnection.Open();
                string query = $"UPDATE Employees SET Name = '{employee.Name}' WHERE Id={id}";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                int result = sqlCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Updated..");
                    Console.WriteLine($"{result} number of rows affected");

                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;   
            }
            finally
            {
                sqlConnection.Close();  
            }
        }

        public List<Employee> GetAllEmployee()
        {
            List<Employee> list = new List<Employee>();
            
                sqlConnection.Open();
                string query = $"SELECT * From Employees";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Employee emp = new Employee()
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Age = (int)reader["Age"],
                        Email = (string)reader["Email"]
                    };
                    list.Add(emp);
                }

                // sir printed in main method
                foreach (Employee emp in list)
                {
                    Console.WriteLine($"Id: {emp.Id}\t Name:- {emp.Name}\t Age:- {emp.Age}\t Email:- {emp.Email}");
                }
                sqlConnection.Close();
                return list; 
        }


        public Employee GetEmployeeByID(int id)
        {
            sqlConnection.Open();
            string query = $"select * from Employees where Id = {id}";
            SqlCommand sqlCommand = new SqlCommand( query, sqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.HasRows)
            {
                Employee emp = new()
                {
                    Id = (int)reader["Id"],
                    Name = (string)reader["Name"],
                    Age = (int)reader["Age"],
                    Email = (string)reader["Email"]
                };
                Console.WriteLine($"Id: {emp.Id}\t Name:- {emp.Name}\t Age:- {emp.Age}\t Email:- {emp.Email}");
                return emp;
            }
            return null;
        }
    
    }
}
