using PPM.Domain;
using PPM.Model;

namespace PPM.Tests;

[TestFixture]
public class TestEmpDetails
{
    [Test]
    public void TestAddEmployeeWithValidDetails()
    {
        EmployeeRepo employeeRepo = new();
        EmployeeRepo.listObj.Clear();
        ProjectRepo.listObj.Clear();
        RoleRepo.listObj.Clear();

        // Arrange
        EmployeeRepo employeeManager = new EmployeeRepo();
        Employee employeeToAdd = new Employee
        {
            EmployeeId = 01,
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@xyz.com",
            Mobile = "123-456-7890"
        };

        // Act
        EmployeeRepo.listObj.Add(employeeToAdd);

        // Retrieve the added employee from your data storage or manager
        Employee addedEmployee = employeeRepo.GetEmployeeById(employeeToAdd.EmployeeId);

        // Assert
        // Verify that the added employee is not null
        Assert.IsNotNull(addedEmployee);

        // Verify that the added employee details match the expected detail
        Assert.That(addedEmployee.EmployeeId, Is.EqualTo(01));
        Assert.That(addedEmployee.FirstName, Is.EqualTo("John"));
        Assert.That(addedEmployee.LastName, Is.EqualTo("Doe"));
        Assert.That(addedEmployee.Email, Is.EqualTo("john.doe@xyz.com"));
        Assert.That(addedEmployee.Mobile, Is.EqualTo("123-456-7890"));
    }
}