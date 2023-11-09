namespace PPM.Tests;
using PPM.Domain;
using PPM.Model;
using NUnit.Framework;

public class TestViewProjects
{
    [Test]
    public void TestViewProject()
    {
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

        // Act
        List<Project> projects = projectManager.ViewProjects();

        // Assert
        // Verify that the projects list is not null or empty
        Assert.IsNotNull(projects);
        Assert.IsNotEmpty(projects);

        // Verify that the project details are correct
        Assert.That(projects.Count, Is.EqualTo(3));

        // Assert.That(projects, Is.Not.Null);
       
        // Assuming you added 3 sample projects
        Assert.That(projects[0].ProjectName, Is.EqualTo("Project A"));
        Assert.That(projects[1].ProjectName, Is.EqualTo("Project B"));
        Assert.That(projects[2].ProjectName, Is.EqualTo("Project C"));
    }
}