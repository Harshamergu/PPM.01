using PPM.Domain;
using PPM.Model;

namespace PPM.UiConsole
{
    public class RoleUi
    {
        public void Add()
        {
            // Creating object in RoleRepo
            RoleRepo obj = new RoleRepo();

            System.Console.WriteLine();

            System.Console.Write("Enter number of Role's you want to add : ");
            Console.ForegroundColor = ConsoleColor.Red;

            int number = int.Parse(System.Console.ReadLine()!);
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < number; i++)
            {
                // Store objects in Role
                Role role = new Role();

                System.Console.WriteLine();

                int roleId;
                bool isRoleIdValid = false;

                do
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    System.Console.Write("Role Id    : ");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;

                    try
                    {
                        if (int.TryParse(System.Console.ReadLine(), out roleId))
                        {
                            if (!obj.IsRoleId(roleId))
                            {
                                isRoleIdValid = true;
                                role.RoleId = roleId;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                System.Console.WriteLine("Role ID already exists. Please enter a unique id.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        else
                        {
                            throw new FormatException("Please enter a valid number for Role Id.");
                        }
                    }
                    catch (FormatException ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        System.Console.WriteLine("Invalid input: " + ex.Message);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                } while (!isRoleIdValid);

                Console.ForegroundColor = ConsoleColor.Magenta;
                System.Console.Write("Role Name  : ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                role.RoleName = Console.ReadLine();

                obj.Add(role);
                System.Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            System.Console.WriteLine(" ------------------------------------------------------");
            System.Console.WriteLine("|          Role's has been added successfully :)       |");
            System.Console.WriteLine(" ------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;

            System.Console.WriteLine();
        }

        public void ViewById()
        {
            RoleRepo roleRepo = new();

            while (true)
            {
                System.Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Role Id : ");
                Console.ForegroundColor = ConsoleColor.Cyan;

                try
                {
                    if (int.TryParse(Console.ReadLine(), out int roleId))
                    {
                        var project = RoleRepo.listObj.FirstOrDefault(r => r.RoleId == roleId);

                        if (RoleRepo.listObj.Count == 0)
                        {
                            System.Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            System.Console.WriteLine("    No Roles To Display!    ");
                            System.Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        }
                        if (project != null)
                        {
                            var roles = roleRepo.ViewById(roleId);
                            if (roles != null)
                            {
                                System.Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.White;
                                System.Console.WriteLine($"Roles Details are following below:");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                System.Console.WriteLine($" -> Role Id   : {roles.RoleId}");
                                System.Console.WriteLine($" -> Role Name : {roles.RoleName}");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Roles Not Found!");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            break;  // Exit the loop when the project is found and displayed.
                        }
                        else
                        {
                            throw new FormatException("Invalid Role ID.");
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                catch (FormatException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: " + ex.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        public bool IsRoleAssociatedWithEmployee(int roleId)
        {
            foreach (var employee in EmployeeRepo.listObj)
            {
                if (employee.RoleId == roleId)
                {
                    return true; // Role is associated with at least one employee
                }
            }
            return false; // Role is not associated with any employee
        }

        public void Delete()
        {
            RoleRepo roleRepo = new();

            System.Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Role Id : ");
            Console.ForegroundColor = ConsoleColor.Cyan;

            try
            {
                if (int.TryParse(Console.ReadLine(), out int roleId))
                {
                    Role roles = roleRepo.GetRoleById(roleId);

                    if (RoleRepo.listObj.Count == 0)
                    {
                        System.Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        System.Console.WriteLine("------------------------------");
                        Console.ForegroundColor = ConsoleColor.Red;
                        System.Console.WriteLine("   No Roles found to delete!  ");
                        Console.ForegroundColor = ConsoleColor.White;
                        System.Console.WriteLine("------------------------------");
                        return;
                    }

                    if (roles == null)
                    {
                        System.Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        System.Console.WriteLine("------------------------------");
                        Console.ForegroundColor = ConsoleColor.Red;
                        System.Console.WriteLine("Invalid Role ID. Role not found.");
                        Console.ForegroundColor = ConsoleColor.White;
                        System.Console.WriteLine("------------------------------");
                        return; // Exit the method if the role ID is invalid.
                    }

                    bool roleValid = IsRoleAssociatedWithEmployee(roleId);

                    if (roleValid)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        System.Console.WriteLine("Cannot Delete Role As it's mapped with an Employee.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        System.Console.WriteLine();
                        roleRepo.Delete(roleId);
                        Console.ForegroundColor = ConsoleColor.White;
                        System.Console.WriteLine("------------------------------");
                        Console.ForegroundColor = ConsoleColor.Green;
                        System.Console.WriteLine("   Role deleted successfully. ");
                        Console.ForegroundColor = ConsoleColor.White;
                        System.Console.WriteLine("------------------------------");
                    }
                }
                else
                {
                    throw new FormatException("Invalid input. Please enter a valid Role ID.");
                }
            }
            catch (FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        // Implement View Role Method
        public void ViewAll()
        {
            RoleRepo roleRepo = new();

            try
            {
                System.Console.WriteLine();
                var obj = roleRepo.ViewAll();

                if (obj.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    System.Console.WriteLine("No roles are available.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    foreach (var list in obj)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        // Display all details of Role
                        System.Console.WriteLine($"Role Id   : {list.RoleId}");
                        System.Console.WriteLine($"Role Name : {list.RoleName}");
                        Console.ForegroundColor = ConsoleColor.White;
                        System.Console.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("An error occurred: " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}

