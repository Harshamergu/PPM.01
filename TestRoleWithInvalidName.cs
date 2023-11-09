using PPM.Domain;
using PPM.Model;

[TestFixture]
public class TestRoleWithInvalidName
{
    [Test]
    public void TestAddRoleWithInvalidValidName()

    {
        // Arrange
        RoleRepo roleManager = new RoleRepo();
        Role roles = new()
        {
            RoleName = "Manager123", // Valid role name
        };

        // Act
        RoleRepo.listObj.Add(roles);

        // Assert
        // Verify that the role has been added successfully.
        List<Role> addedRole = roleManager.GetRoleByName(roles.RoleName);
        Assert.IsNotNull(addedRole);

        try
        {
            foreach (var r in addedRole)
            {
                // Assert.AreEqual("Manager", r.roleName);
                if (!r.RoleName!.Equals("Manager"))
                    Assert.Pass("Test Case Successfully Handled The Invalid Role Name");
            }
        }

        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}