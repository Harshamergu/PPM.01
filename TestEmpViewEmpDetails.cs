using PPM.Domain;
using PPM.Model;

namespace PPM.Tests;

[TestFixture]
public class TestEmpViewEmpDetails
{
    [Test]
    public void TestViewEmployees()
    {
        EmployeeRepo employeeRepo = new();
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

        // Act
        List<Employee> employees = employeeRepo.ViewEmployees();

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
    }
}

