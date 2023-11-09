using PPM.Domain;
using PPM.Model;

namespace PPM.UiConsole
{
    public class ProjectUi
    {

        // Implement Add Employee To Project Method
        public static void AddEmployeeToProject()
        {
            ProjectRepo projectRepo = new ProjectRepo();

            System.Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("Project Id  : ");

            try
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                if (int.TryParse(Console.ReadLine(), out int projectId))
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write("Employee Id : ");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;

                    if (int.TryParse(Console.ReadLine(), out int employeeId))
                    {
                        projectRepo.AddEmployeeToProject(projectId, employeeId);
                    }
                    else
                    {
                        throw new FormatException("Please provide a valid Employee Id.");
                    }
                }
                else
                {
                    throw new FormatException("Please provide a valid Project Id.");
                }
            }
            catch (FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input: " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }


        // Implement Add Project Method
        public void Add()
        {
            ProjectRepo obj = new ProjectRepo();

            System.Console.WriteLine();

            try
            {
                System.Console.Write("Enter the number of projects you want: ");
                Console.ForegroundColor = ConsoleColor.DarkRed;

                int number = int.Parse(Console.ReadLine()!);
                Console.ForegroundColor = ConsoleColor.White;

                System.Console.WriteLine();

                for (int i = 0; i < number; i++)
                {
                    int projectId = 0;
                    bool projectExists = true; // Initialize to true to enter the loop.

                    while (projectExists)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        System.Console.Write("Project Id   : ");
                        Console.ForegroundColor = ConsoleColor.DarkCyan;

                        try
                        {
                            projectId = int.Parse(Console.ReadLine()!);
                            projectExists = obj.IsProjectId(projectId);

                            if (projectExists)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                System.Console.WriteLine("ID is already existing! Try with a unique ID...");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        catch (FormatException ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid input: " + ex.Message);
                            Console.ForegroundColor = ConsoleColor.White;
                            projectExists = true; // Set to true to continue the loop.
                        }
                    }


                    Console.ForegroundColor = ConsoleColor.Magenta;
                    System.Console.Write("Project Name : ");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    string projectName = Console.ReadLine()!;

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    System.Console.Write("Start Date   : ");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    DateOnly startDate = DateOnly.Parse(Console.ReadLine()!);

                    bool validEndDate = false;
                    DateOnly endDate = default;

                    while (!validEndDate)
                    {
                        try
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            System.Console.Write("End Date     : ");
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            endDate = DateOnly.Parse(Console.ReadLine()!);

                            if (IsValidEndDate(endDate, startDate))
                            {
                                validEndDate = true;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                System.Console.WriteLine("Invalid Date Entered!");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        catch (FormatException ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid input: " + ex.Message);
                            Console.ForegroundColor = ConsoleColor.White;
                            validEndDate = false; // Set to false to continue the loop.
                        }
                    }
                    Project ProjectObj = new Project
                    {
                        ProjectId = projectId,
                        ProjectName = projectName,
                        StartDate = startDate,
                        EndDate = endDate
                    };

                    obj.Add(ProjectObj);
                    System.Console.WriteLine();
                }

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                System.Console.WriteLine(" ------------------------------------------------------");
                System.Console.WriteLine("|        Project's have been added successfully :)      |");
                System.Console.WriteLine(" ------------------------------------------------------");
                System.Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                System.Console.WriteLine("Do you want to add employees to projects?");
                Console.ForegroundColor = ConsoleColor.White;

                bool addEmployees = bool.Parse(Console.ReadLine()!);

                if (addEmployees)
                {
                    for (int i = 0; i < number; i++)
                    {
                        ProjectUi.AddEmployeeToProject();
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


        // Implement Delete Employee From Project Method
        public void DeleteEmployeeFromProject()
        {
            ProjectRepo projectRepo = new ProjectRepo();

            try
            {
                System.Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("Project Id : ");

                if (int.TryParse(Console.ReadLine(), out int projectId))
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write("Employee Id : ");

                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    if (int.TryParse(Console.ReadLine(), out int employeeId))
                    {
                        projectRepo.DeleteEmployeeFromProject(projectId, employeeId);
                    }
                    else
                    {
                        throw new FormatException("Please provide a valid Employee Id.");
                    }
                }
                else
                {
                    throw new FormatException("Please provide a valid Project Id.");
                }
            }
            catch (FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input: " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        // Validate the End Date
        public static bool IsValidEndDate(DateOnly enddate, DateOnly startdate)
        {
            try
            {
                if (enddate > startdate)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // Handle the exception as needed, e.g., log it, display an error message, or rethrow it.
                // For example:
                Console.WriteLine("Error comparing dates: " + ex.Message);
                return false; // Indicate that the comparison failed due to the exception.
            }
        }

        // Implement View Project Detail Method
        public void ViewProjectDetail()
        {
            ProjectRepo projectRepo = new ProjectRepo();
            while (true)
            {
                System.Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Project Id : ");

                try
                {
                    if (int.TryParse(Console.ReadLine(), out int projectId))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        var check = ProjectRepo.listObj.Any(p => p.ProjectId == projectId);
                        if (check)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            projectRepo.ViewProjectDetail(projectId);
                            Console.ForegroundColor = ConsoleColor.White;
                            break; // Exit the loop when the project is found
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Project not found! Try again...");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    else
                    {
                        throw new FormatException("Invalid input. Please enter a valid Project ID.");
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

        public void Delete()
        {
            ProjectRepo projectRepo = new ProjectRepo();
            try
            {
                if (ProjectRepo.listObj.Count == 0)
                {
                    System.Console.WriteLine();
                    System.Console.WriteLine("-------------------------------");
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("  No projects found to delete! ");
                    Console.ForegroundColor = ConsoleColor.White;
                    System.Console.WriteLine("-------------------------------");
                }
                else
                {
                    System.Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("Project Id : ");
                    Console.ForegroundColor = ConsoleColor.Cyan;

                    if (int.TryParse(Console.ReadLine(), out int projectId))
                    {
                        Project project = projectRepo.GetProjectById(projectId);

                        if (project != null)
                        {
                            // Check if the Project has already been removed
                            if (!ProjectRepo.listObj.Contains(project))
                            {
                                System.Console.WriteLine();
                                System.Console.WriteLine("------------------------------");
                                Console.ForegroundColor = ConsoleColor.Red;
                                System.Console.WriteLine("    Project Already deleted!  ");
                                Console.ForegroundColor = ConsoleColor.White;
                                System.Console.WriteLine("------------------------------");
                            }
                            else
                            {
                                System.Console.WriteLine();
                                projectRepo.Delete(projectId);
                                Console.ForegroundColor = ConsoleColor.White;
                                System.Console.WriteLine("-------------------------------");
                                Console.ForegroundColor = ConsoleColor.Green;
                                System.Console.WriteLine(" PROJECT DELETED SUCCESSFULLY! ");
                                Console.ForegroundColor = ConsoleColor.White;
                                System.Console.WriteLine("-------------------------------");
                            }
                        }
                        else
                        {
                            System.Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.White;
                            System.Console.WriteLine("-------------------------------------------------------");
                            Console.ForegroundColor = ConsoleColor.Red;
                            System.Console.WriteLine("   Project does not exist or has already been deleted! ");
                            Console.ForegroundColor = ConsoleColor.White;
                            System.Console.WriteLine("-------------------------------------------------------");
                        }
                    }
                    else
                    {
                        throw new FormatException("Please enter a valid Project Id.");
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

        // Implementing view project method
        public void ViewAll()
        {
            ProjectRepo projectRepo = new ProjectRepo();
            ProjectUi projectUi = new ProjectUi();
            System.Console.WriteLine();

            try
            {
                var obj = projectRepo.ViewProject();

                if (obj.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    System.Console.WriteLine("No projects are available.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    foreach (var Project in obj)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        // Display all details of Project
                        System.Console.WriteLine($"Project Id   : {Project.ProjectId}");
                        System.Console.WriteLine($"Project Name : {Project.ProjectName}");
                        System.Console.WriteLine($"StartDate    : {Project.StartDate}");
                        System.Console.WriteLine($"End Date     : {Project.EndDate}");
                        Console.ForegroundColor = ConsoleColor.White;
                        System.Console.WriteLine();
                    }

                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    System.Console.WriteLine("Do you want to see project details?");
                    Console.ForegroundColor = ConsoleColor.White;

                    bool viewDetails = bool.Parse(Console.ReadLine()!);

                    if (viewDetails)
                    {
                        projectUi.ViewProjectDetail();
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

        public void ViewById()
        {
            ProjectRepo projectRepo = new ProjectRepo();

            try
            {
                System.Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Project Id : ");
                Console.ForegroundColor = ConsoleColor.Cyan;

                if (int.TryParse(Console.ReadLine(), out int projectId))
                {
                    var project = ProjectRepo.listObj.FirstOrDefault(p => p.ProjectId == projectId);

                    if (ProjectRepo.listObj.Count == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("       No Projects To Display!      ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    }
                    else if (project != null)
                    {
                        projectRepo.ViewById(projectId);
                        System.Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        System.Console.WriteLine("Project Details are following below:");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        System.Console.WriteLine($" -> Project Id   : {project.ProjectId}");
                        System.Console.WriteLine($" -> Project Name : {project.ProjectName}");
                        System.Console.WriteLine($" -> Start Date   : {project.StartDate}");
                        System.Console.WriteLine($" -> End Date     : {project.EndDate}");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid Project ID.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else
                {
                    throw new FormatException("Please enter a valid number.");
                }
            }
            catch (FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}