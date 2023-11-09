using System.Text.RegularExpressions;

using PPM.Domain;
using PPM.Model;

namespace PPM.UiConsole
{

    //Create class EmployeeUi
    public class EmployeeUi
    {
        public bool IsValidPhoneNumber(string phoneNumber)
        {
            if (phoneNumber != null)
            {
                string phoneExpression = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";

                try
                {
                    return Regex.IsMatch(phoneNumber, phoneExpression);
                }
                catch (ArgumentException ex)
                {
                    // Handle the regular expression pattern compilation exception as needed.
                    // For example, you can log the error or return false to indicate the phone number is invalid.
                    Console.WriteLine("Regular expression pattern compilation error: " + ex.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool IsValidEmail(string email)
        {
            if (email != null)
            {
                string emailExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)";

                try
                {
                    return Regex.IsMatch(email, emailExpression);
                }
                catch (ArgumentException ex)
                {
                    // Handle the regular expression pattern compilation exception as needed.
                    // For example, you can log the error or return false to indicate the email is invalid.
                    Console.WriteLine("Regular expression pattern compilation error: " + ex.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        // Implement Add Employee Method
        public void Add()
        {
            EmployeeRepo obj = new EmployeeRepo();

            System.Console.WriteLine();

            try
            {
                System.Console.Write("Enter the number of Employees you want to add: ");
                Console.ForegroundColor = ConsoleColor.DarkRed;

                int number = int.Parse(System.Console.ReadLine()!);
                Console.ForegroundColor = ConsoleColor.White;

                System.Console.WriteLine();

                System.Console.WriteLine("      << Give Details of Employee >>     ");
                System.Console.WriteLine();

                for (int i = 0; i < number; i++)
                {
                    Employee emp = new Employee();
                    EmployeeRepo employeeRepo = new EmployeeRepo();

                    int employeeId = 0;
                    bool isEmployeeIdValid = false;

                    do
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        System.Console.Write("Employee Id  : ");
                        Console.ForegroundColor = ConsoleColor.DarkCyan;

                        try
                        {
                            if (int.TryParse(System.Console.ReadLine(), out employeeId))
                            {
                                if (!employeeRepo.IsEmployeeId(employeeId))
                                {
                                    isEmployeeIdValid = true;
                                    emp.EmployeeId = employeeId;
                                }
                                else
                                {
                                    System.Console.WriteLine("Employee ID already exists. Please enter a unique ID.");
                                }
                            }
                            else
                            {
                                throw new FormatException("Please enter a valid number for Employee ID.");
                            }
                        }
                        catch (FormatException ex)
                        {
                            System.Console.WriteLine("Invalid input: " + ex.Message);
                        }
                    } while (!isEmployeeIdValid);

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    System.Console.Write("First Name   : ");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    emp.FirstName = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    System.Console.Write("Last Name    : ");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    emp.LastName = Console.ReadLine();

                    string mobileNumber = "";
                    while (string.IsNullOrEmpty(mobileNumber) || !IsValidPhoneNumber(mobileNumber))
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        System.Console.Write("Mobile       : ");
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        mobileNumber = Console.ReadLine()!;
                        if (!IsValidPhoneNumber(mobileNumber))
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            System.Console.WriteLine("Please! Give a valid number.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    emp.Mobile = mobileNumber;

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    System.Console.Write("Address      : ");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    emp.Address = Console.ReadLine();

                    string email = "";
                    while (string.IsNullOrEmpty(email) || !IsValidEmail(email))
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        System.Console.Write("Email        : ");
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        email = Console.ReadLine()!;
                        if (!IsValidEmail(email))
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            System.Console.WriteLine("Please! Enter a valid Email-Id.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    emp.Email = email;

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    System.Console.Write("Role Id      : ");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    emp.RoleId = int.Parse(Console.ReadLine()!);

                    if (RoleRepo.listObj.Exists(r => r.RoleId == emp.RoleId))
                    {
                        obj.Add(emp);

                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        System.Console.WriteLine(" -------------------------------------------------------- ");
                        System.Console.WriteLine("|           Employees are added Successfully :)         |");
                        System.Console.WriteLine(" -------------------------------------------------------- ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        System.Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        System.Console.WriteLine("Role ID doesn't exist... Need to add a role and then assign it to the employee ;(  ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    System.Console.WriteLine();
                }
            }
            catch (FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input: " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void ViewById()
        {
            EmployeeRepo employeeRepo = new();

            while (true)
            {
                System.Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Employee Id : ");
                Console.ForegroundColor = ConsoleColor.Cyan;

                try
                {
                    if (int.TryParse(Console.ReadLine(), out int employeeId))
                    {
                        if (EmployeeRepo.listObj.Count == 0)
                        {
                            System.Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            System.Console.WriteLine("No Employee's to display!");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        }

                        var employee = EmployeeRepo.listObj.FirstOrDefault(e => e.EmployeeId == employeeId);
                        if (employee != null)
                        {
                            System.Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.White;
                            System.Console.WriteLine("Project Details are following below:");
                            Console.ForegroundColor = ConsoleColor.Green;
                            System.Console.WriteLine($" -> EmployeeId    : {employee.EmployeeId}");
                            System.Console.WriteLine($" -> Employee Name : {employee.FirstName} {employee.LastName}");
                            System.Console.WriteLine($" -> Email         : {employee.Email}");
                            System.Console.WriteLine($" -> MobileNumber  : {employee.Mobile}");
                            Console.ForegroundColor = ConsoleColor.White;

                            break; // Exit the loop when the employee is found and displayed.
                        }
                        else
                        {
                            System.Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Employee Id not found.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    else
                    {
                        System.Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a valid number.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                catch (FormatException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input: " + ex.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        // Implement View Employee Method
        public void ViewAll()
        {
            try
            {
                EmployeeRepo employeeRepo = new();
                System.Console.WriteLine();
                var obj = employeeRepo.ViewAll();

                if (obj.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    System.Console.WriteLine("No employees are available.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    var empObj = employeeRepo.ViewAll();
                    foreach (var list in empObj)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        // Display all details of Employee
                        System.Console.WriteLine($"Employee Id : {list.EmployeeId}");
                        System.Console.WriteLine($"First Name  : {list.FirstName}");
                        System.Console.WriteLine($"Last Name   : {list.LastName}");
                        System.Console.WriteLine($"Email       : {list.Email}");
                        System.Console.WriteLine($"Mobile      : {list.Mobile}");
                        System.Console.WriteLine($"Address     : {list.Address}");
                        System.Console.WriteLine($"Role Id     : {list.RoleId}");
                        Console.ForegroundColor = ConsoleColor.White;
                        System.Console.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                System.Console.WriteLine($"An error occurred: {ex.Message}");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public bool IsEmployeeAssociatedWithProject(int employeeId)
        {
            foreach (var project in ProjectRepo.listObj)
            {
                foreach (var employeeInProject in project.EmployeeProject)
                {
                    if (employeeInProject.EmployeeId == employeeId)
                    {
                        return true; // Employee is associated with at least one project
                    }
                }
            }
            return false; // Employee is not associated with any project
        }

        public void Delete()
        {
            EmployeeRepo employeeRepo = new();
            ProjectUi projectUi = new();

            System.Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Employee Id : ");
            Console.ForegroundColor = ConsoleColor.Cyan;

            try
            {
                if (int.TryParse(Console.ReadLine(), out int employeeId))
                {
                    Employee employee = employeeRepo.GetEmployeeById(employeeId);

                    if (EmployeeRepo.listObj.Count == 0)
                    {
                        System.Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        System.Console.WriteLine("--------------------------------");
                        Console.ForegroundColor = ConsoleColor.Red;
                        System.Console.WriteLine("  No Employees found to delete! ");
                        Console.ForegroundColor = ConsoleColor.White;
                        System.Console.WriteLine("--------------------------------");
                        return;
                    }

                    if (employee == null)
                    {
                        System.Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        System.Console.WriteLine("------------------------------");
                        Console.ForegroundColor = ConsoleColor.Red;
                        System.Console.WriteLine("Invalid employee ID. Employee not found.");
                        Console.ForegroundColor = ConsoleColor.White;
                        System.Console.WriteLine("------------------------------");
                        return; // Exit the method if the employee ID is invalid.
                    }

                    bool isEmployeeAssociated = IsEmployeeAssociatedWithProject(employeeId);

                    if (isEmployeeAssociated)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine(" Access Denied! ");
                        Thread.Sleep(1000);
                        System.Console.WriteLine(" Employee has been associated with a project. ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        employeeRepo.Delete(employeeId);
                        System.Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        System.Console.WriteLine("------------------------------");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Employee Removed successfully.");
                        Console.ForegroundColor = ConsoleColor.White;
                        System.Console.WriteLine("------------------------------");
                    }

                    try
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        System.Console.WriteLine("Do you still want to Remove Employee from Project?");
                        Console.ForegroundColor = ConsoleColor.White;

                        bool var2 = bool.Parse(Console.ReadLine()!);

                        if (var2)
                        {
                            projectUi.DeleteEmployeeFromProject();
                        }
                        else
                        {
                            return;
                        }
                    }
                    catch (FormatException ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input: " + ex.Message);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            }
            catch (FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input: " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}