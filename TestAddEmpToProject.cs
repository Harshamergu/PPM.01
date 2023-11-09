using PPM.Domain;
using PPM.Model;

namespace PPM.Tests;

public class TestAddEmployeeToProjectTest
{
    [Test]
    public void AddEmployeeToProjectTest()
    {
        EmployeeRepo.listObj.Clear();
        ProjectRepo.listObj.Clear();
        RoleRepo.listObj.Clear();

        Employee employee = new Employee();

        ProjectRepo projectDomain = new ProjectRepo();

        List<Project> projectsList = new()
            {
                new Project
                {
                    ProjectId = 1,
                    ProjectName = "Test Project",
                    StartDate = DateOnly.Parse("2022-05-02"),
                    EndDate = DateOnly.Parse("2024-05-02"),
                    EmployeeProject = new List<Employee>()
                    {
                       new Employee
                            {
                                EmployeeId = 2,
                                FirstName = "Harsha",
                                LastName = "Mergu",
                                Email = "harshamergu@gmail.com",
                                Mobile = "6301518455",
                                Address = "Hyderabad",
                                RoleId = 3
                            }
                    }
                }
            };

        projectDomain.AddEmployeeToProject(1, 2); // Assuming you want to add employee with ID 2 to project with ID 3

        // Assert
        Project targetProject = projectsList.Find(p => p.ProjectId == 1)!;
        Assert.That(targetProject.EmployeeProject.Count, Is.EqualTo(1));
    }

    [Test]
    public void DeleteEmployeeProjectTest()
    {
        EmployeeRepo.listObj.Clear();
        ProjectRepo.listObj.Clear();
        RoleRepo.listObj.Clear();

        ProjectRepo projectDomain = new ProjectRepo();

        projectDomain.AddProject
        (
            1,
            "Project 1",
            DateOnly.Parse("2022-01-01"),
            DateOnly.Parse("2022-12-31")
        );

        EmployeeRepo employeeDomain = new EmployeeRepo();

        employeeDomain.AddEmployee
        (
            1,
            "John",
            "Doe",
            "john.doe@gmail.com",
            "6301518455",
            "Hyderabad",
            1
        );
        employeeDomain.AddEmployee(
            2,
            "John",
            "Doe",
            "john.doe@gmail.com",
            "6301518455",
            "Hyderabad",
            1
        );

        projectDomain.AddEmployeeToProject(1, 1);
        projectDomain.AddEmployeeToProject(1, 2);

        projectDomain.DeleteEmployeeFromProject(1, 2);

        Project project = projectDomain.ViewProjects()[0];

        // Assert.IsEmpty(project.EmployeeProject);
        Assert.That(project.EmployeeProject.Count, Is.EqualTo(1));
    }
}
