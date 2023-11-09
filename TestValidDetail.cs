namespace PPM.Tests;

using PPM.Domain;
using PPM.Model;
using NUnit.Framework;

public class ProjectManagerTests
{
    [Test]
    public void TestAddProjectWithValidDetails()
    {
        // Arrange
        ProjectRepo projectManager = new ProjectRepo();
        Project projectToAdd = new Project
        {
            ProjectId = 01,
            ProjectName = "Sample Project",
            StartDate = new DateOnly(2023, 1, 1),
            EndDate = new DateOnly(2023, 12, 31)
        };

        // Act
        ProjectRepo.listObj.Add(projectToAdd);

        // Assert
        // Get the added project from your data storage or manager
        Project addedProject = projectManager.GetProjectById(projectToAdd.ProjectId);

        // Verify that the added project is not null
        Assert.IsNotNull(addedProject);

        // Verify that the added project details match the expected details
        Assert.That(addedProject.ProjectName, Is.EqualTo(projectToAdd.ProjectName));
        Assert.That(addedProject.StartDate, Is.EqualTo(projectToAdd.StartDate));
        Assert.That(addedProject.EndDate, Is.EqualTo(projectToAdd.EndDate));
    }
}