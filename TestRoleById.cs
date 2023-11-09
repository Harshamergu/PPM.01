namespace PPM.Tests;

using PPM.Model;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

public class RoleByid
{
    private List<Role> roleObj = new List<Role>
    {
        new Role { RoleId = 1, RoleName = "Admin" },
        new Role { RoleId = 2, RoleName = "User" },
    };

    public Role GetRolesById(int roleId)
    {
        Role role = roleObj.FirstOrDefault(r => r.RoleId == roleId)!;
        return role;
    }
}



[TestFixture]
public class TestGetRolesById_Existing
{
    [Test]
    public void TestGetRolesById_ExistingRole()
    {
        RoleByid roleManager = new RoleByid();
        int roleIdToFind = 1; // Replace with an existing role ID in your test data

        Role result = roleManager.GetRolesById(roleIdToFind);

        Assert.IsNotNull(result);
        Assert.That(result.RoleId, Is.EqualTo(roleIdToFind));
    }

    [Test]
    public void TestGetRolesById_NonExistingRole()
    {
        RoleByid roleManager = new RoleByid();
        int roleIdToFind = 999; // Replace with a non-existing role ID

        Role result = roleManager.GetRolesById(roleIdToFind);

        Assert.IsNull(result);
    }
}

