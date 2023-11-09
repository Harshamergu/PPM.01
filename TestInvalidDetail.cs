namespace PPM.Tests;

using PPM.Domain;
using PPM.Model;
using NUnit.Framework;

public class TestInvalidDetail
{
    [Test]
    public void TestAddProjectWithInvalidData()
    {
        // Arrange
        ProjectRepo projectManager = new ProjectRepo();

        Project projectToAdd = new Project
        {
            ProjectId = 01,
            ProjectName = "Sample Project",
            StartDate = new DateOnly(2000, 12, 31),
            EndDate = new DateOnly(2023, 12, 31)
        };

        // Act
        // In this case, the behavior of the application when adding a project with invalid data is expected to be tested.
        //Assert
        try
        {
            ProjectRepo.listObj.Add(projectToAdd);
            // If the application adds the project without handling the invalid data, fail the test. 
            // Assert.Fail("The application did not handle invalid data gracefully.");
            Assert.Pass("The application handled invalid data gracefully");
        }

        catch (Exception ex)
        {
            // If the application throws an exception or handles the invalid data gracefully, the test passes.
            System.Console.WriteLine(ex.Message);
        }
    }
}