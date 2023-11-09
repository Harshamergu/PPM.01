using PPM.Domain;
using PPM.Model;

namespace PPM.Tests;

public class TestEmployeeById
{
    private static List<Employee> empObj = new List<Employee>
    {
        new Employee { EmployeeId = 1, FirstName = "Employee A" },
        new Employee { EmployeeId = 2, FirstName = "Employee B" },
    };

    public static Employee GetEmployeeById(int employeeId)
    {
        return empObj.FirstOrDefault(e => e.EmployeeId == employeeId)!;
    }
}



[TestFixture]
public class TestGetEmployeeById
{

    [Test]
    public void TestGetEmployeeById_ExistingEmployee()
    {
        int employeeId = 1; // Replace with an existing employee ID in your test data

        Employee employee = TestEmployeeById.GetEmployeeById(employeeId);

        Assert.IsNotNull(employee);
        Assert.That(employee.EmployeeId, Is.EqualTo(employeeId));
    }

    [Test]
    public void TestGetEmployeeById_NonExistingEmployee()
    {
        EmployeeRepo employeeRepo = new();
        ProjectRepo projectRepo = new ProjectRepo();
        int employeeId = 999; // Replace with a non-existing employee ID

        Employee employee = employeeRepo.GetEmployeeById(employeeId);
        Assert.IsNull(employee);
    }
}
