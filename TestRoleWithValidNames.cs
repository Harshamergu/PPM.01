using PPM.Domain;
using PPM.Model;

[TestFixture]

public class TestRoleWithValidNames
{
    [Test]
    public void TestAddRoleWithValidName()
    {
        // Arrange
        RoleRepo roleManager = new RoleRepo();

        Role roles = new()
        {
            RoleName = "Manager", // Valid role name
        };

        // Act
        RoleRepo.listObj.Add(roles);

        // Assert
        // Verify that the role has been added successfully.
        List<Role> addedRole = roleManager.GetRoleByName(roles.RoleName);

        Assert.IsNotNull(addedRole);

        foreach (var r in addedRole)
        {
            Assert.That(r.RoleName, Is.EqualTo(roles.RoleName));
            // Assert.AreEqual(roles.RoleName, r.RoleName);
        }
    }
}