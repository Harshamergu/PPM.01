using PPM.Domain;
using PPM.Model;

namespace PPM.Tests;

[TestFixture]
public class TestViewProjectDetails
{
    [Test]
    public void TestViewProjectDetail()
    {
        //employee details
        EmployeeRepo.listObj.Clear();
        // Arrange
        EmployeeRepo employeeManager = new EmployeeRepo();

        // Add sample employees to the data store or manager for testing
        Employee employee1 = new Employee
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com",
            Mobile = "123-456-7890"
        };
        Employee employee2 = new Employee
        {
            FirstName = "Jane",
            LastName = "Smith",
            Email = "jane.smith@example.com",
            Mobile = "987-654-3210"
        };

        EmployeeRepo.listObj.Add(employee1);
        EmployeeRepo.listObj.Add(employee2);

        //Project Details
        ProjectRepo.listObj.Clear();

        // Arrange
        ProjectRepo projectManager = new ProjectRepo();

        // Add sample projects to the data store or manager for testing
        Project project1 = new Project { ProjectName = "Project A" };
        Project project2 = new Project { ProjectName = "Project B" };
        Project project3 = new Project { ProjectName = "Project C" };

        ProjectRepo.listObj.Add(project1);
        ProjectRepo.listObj.Add(project2);
        ProjectRepo.listObj.Add(project3);

        //Roles Details
        RoleRepo.listObj.Clear();

        RoleRepo roleManager = new RoleRepo();

        Role rolesToAdd = new Role
        {
            RoleId = 1,
            RoleName = "Developer",
        };
        
        RoleRepo.listObj.Add(rolesToAdd);

        // Retrieve the added employee from your data storage or manager
        Role addedRoles = roleManager.GetRoleById(rolesToAdd.RoleId);

        // Act
        List<Employee> employees = employeeManager.ViewEmployees();
        // Act
        List<Project> projects = projectManager.ViewProjects();

        // Assert
        // Verify that the employees list is not null or empty
        Assert.IsNotNull(employees);
        Assert.IsNotEmpty(employees);

        // Verify that the employee details are correct
        Assert.That(employees.Count, Is.EqualTo(2));  // Assuming you added 2 sample employees
        Assert.That(employees[0].FirstName, Is.EqualTo("John"));
        Assert.That(employees[0].LastName, Is.EqualTo("Doe"));
        Assert.That(employees[0].Email, Is.EqualTo("john.doe@example.com"));
        Assert.That(employees[0].Mobile, Is.EqualTo("123-456-7890"));

        Assert.That(employees[1].FirstName, Is.EqualTo("Jane"));
        Assert.That(employees[1].LastName, Is.EqualTo("Smith"));
        Assert.That(employees[1].Email, Is.EqualTo("jane.smith@example.com"));
        Assert.That(employees[1].Mobile, Is.EqualTo("987-654-3210"));

        // Assert
        // Verify that the projects list is not null or empty
        Assert.IsNotNull(projects);
        Assert.IsNotEmpty(projects);

        // Verify that the project details are correct
        Assert.That(projects.Count, Is.EqualTo(3)); // Assuming you added 3 sample projects
        Assert.That(projects[0].ProjectName, Is.EqualTo("Project A"));
        Assert.That(projects[1].ProjectName, Is.EqualTo("Project B"));
        Assert.That(projects[2].ProjectName, Is.EqualTo("Project C"));

        // Assert
        // Verify that the added employee is not null
        Assert.IsNotNull(addedRoles);

        // Verify that the added employee details match the expected details
        Assert.That(addedRoles.RoleId, Is.EqualTo(1));
        Assert.That(addedRoles.RoleName, Is.EqualTo("Developer"));
    }
}
