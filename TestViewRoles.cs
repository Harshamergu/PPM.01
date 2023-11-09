using PPM.Domain;
using PPM.Model;
namespace PPM.Tests;

[TestFixture]
public class TestViewRoles
{
    [Test]
    public void TestViewRole()
    {
        RoleRepo roleManager = new RoleRepo();

        Role rolesToAdd = new Role
        {
            RoleId = 1,
            RoleName = "Developer",
        };

        // Act
        RoleRepo.listObj.Add(rolesToAdd);

        // Retrieve the added employee from your data storage or manager
        Role addedRoles = roleManager.GetRoleById(rolesToAdd.RoleId);

        // Assert
        // Verify that the added employee is not null
        Assert.IsNotNull(addedRoles);

        // Verify that the added employee details match the expected details
        Assert.That(addedRoles.RoleId, Is.EqualTo(1));
        Assert.That(addedRoles.RoleName, Is.EqualTo("Developer"));
    }
}
