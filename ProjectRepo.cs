using PPM.Model;

namespace PPM.Domain
{
    public class ProjectRepo : IEntity<Project>
    {
        // Storing the objects in Project
        public static List<Project> listObj = new List<Project>();

        public void Add(Project ProjectObj)
        {
            listObj.Add(ProjectObj);
        }

        public List<Project> ViewProject()
        {
            return listObj;
        }

        public List<Project> ViewAll()
        {
            return listObj;
        }

        public bool IsProjectId(int ProjectId)
        {
            bool result = listObj.Exists(x => x.ProjectId == ProjectId);
            return result;
        }

        public Project GetProjectById(int projectId)
        {
            return listObj.FirstOrDefault(p => p.ProjectId == projectId)!;
        }

        // Validate Add Employee to Project
        public void AddEmployeeToProject(int projectId, int employeeId)
        {
            try
            {
                Project project = listObj.FirstOrDefault(p => p.ProjectId == projectId)!;

                if (project != null)
                {
                    Employee employee = EmployeeRepo.listObj.FirstOrDefault(e => e.EmployeeId == employeeId)!;

                    if (employee != null)
                    {
                        project.EmployeeProject.Add(employee);
                        System.Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Employee added to the project successfully.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        System.Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Employee not found!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else
                {
                    System.Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Project not found!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("An error occurred: " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }


        // Validate Delete Employee from Project
        public void DeleteEmployeeFromProject(int projectId, int employeeId)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                System.Console.WriteLine();
                Project project = listObj.FirstOrDefault(p => p.ProjectId == projectId)!;

                if (project != null)
                {
                    Employee employee = project.EmployeeProject.FirstOrDefault(e => e.EmployeeId == employeeId)!;

                    if (employee != null)
                    {
                        project.EmployeeProject.Remove(employee);
                        System.Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Employee removed from the project successfully.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        System.Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Employee not found in the project.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else
                {
                    System.Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Project not found.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("An error occurred: " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void ViewProjectDetail(int projectId)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Project project = ProjectRepo.listObj.FirstOrDefault(p => p.ProjectId == projectId)!;

                System.Console.WriteLine();

                if (project != null)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    System.Console.WriteLine(" -------------------------------------------------------- ");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    System.Console.WriteLine(" Projects Detail's are as follows:");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    System.Console.WriteLine($" Project ID   : {project.ProjectId}");
                    System.Console.WriteLine($" Project Name : {project.ProjectName}");
                    System.Console.WriteLine($" Start Date   : {project.StartDate}");
                    System.Console.WriteLine($" End Date     : {project.EndDate}");
                    Console.ForegroundColor = ConsoleColor.White;
                    System.Console.WriteLine(" -------------------------------------------------------- ");

                    // Group employees by Role and Display Details
                    var employeesByRole = project.EmployeeProject.GroupBy(e => e.RoleId);

                    foreach (var roleGroup in employeesByRole)
                    {
                        Role role = RoleRepo.listObj.FirstOrDefault(r => r.RoleId == roleGroup.Key)!;

                        if (role != null)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            System.Console.WriteLine($" Role: {role.RoleName}");

                            foreach (var employee in roleGroup)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                System.Console.WriteLine(" ------------------------------------------------------- ");
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                System.Console.WriteLine($" << Employee: {employee.FirstName} {employee.LastName} >>");
                                Console.ForegroundColor = ConsoleColor.White;
                                System.Console.WriteLine(" ------------------------------------------------------- ");
                                System.Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            System.Console.WriteLine("Role not found for employee group.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("Project not found.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("An error occurred: " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void Delete(int projectId)
        {
            Project project = listObj.FirstOrDefault(p => p.ProjectId == projectId)!;
            if (project != null)
            {
                ProjectRepo.listObj.Remove(project);
            }
        }

        public Project ViewById(int projectId)

        {

            Project project = listObj.FirstOrDefault(p => p.ProjectId == projectId)!;
            return project;

        }

    }
}
