using System.Data.SqlClient;

namespace ADO.net
{
    public class Program
    {


        static void Main(string[] args)
        {
            EmployeeDBOperations employeeDBOperations = new EmployeeDBOperations();

            while (true) {
                Console.WriteLine("Which Operation you want to perfrom");
                Console.WriteLine("press 1: Add Contact ");
                Console.WriteLine("press 2: Edit Name Of Contact");
                Console.WriteLine("press 3: Display Contact ");
                Console.WriteLine("press 4: Display Contact By ID ");
                Console.WriteLine("press 5: Delete Contact ");
                Console.Write("Enter Your Choice ");
                int Choice = int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (Choice)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter name: - ");
                            string name = Console.ReadLine();
                            Console.WriteLine("Enter Age: - ");
                            int age = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Email: - ");
                            string email = Console.ReadLine();
                            Employee employee = new(name, age, email)
                            {
                                Name = name,
                                Age = age,
                                Email = email
                            };
                            employeeDBOperations.AddEmployee(employee);
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Enter name: - ");
                            string name = Console.ReadLine();
                            Employee updaatedEmployeee = new(name) {
                                Name = name
                            };
                            employeeDBOperations.UpdateEmployee(1, updaatedEmployeee);
                            break;
                        }
                    case 3:
                        {
                            employeeDBOperations.GetAllEmployee();
                            Console.WriteLine();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Enter ID Of the Employee Which You want to Display");
                            int id = int.Parse(Console.ReadLine());
                            employeeDBOperations.GetEmployeeByID(id);
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Enter ID Of the Employee Which You want to Delete");
                            int id = int.Parse(Console.ReadLine());
                            employeeDBOperations.DeleteEmployee(id);
                            break;

                        }

                    default:
                        {
                            Console.WriteLine("Enter valid Choice");
                            break;
                        }
                }
            }

        }
    }
}