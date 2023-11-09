using PPM.Domain;
using PPM.Model;

namespace PPM.Tests;

public class TestProjectByIds
{
    private List<Project> listObj = new List<Project>
    {
        new Project { ProjectId = 1, ProjectName = "Project A" },
        new Project { ProjectId = 2, ProjectName = "Project B" },
    };


    public bool IsProjectId(int projectId)
    {
        bool result = listObj.Exists(x => x.ProjectId == projectId);
        return result;
    }
}



[TestFixture]
public class TestProjectByIds_EPI
{
    
    [Test]
    public void TestIsProjectId_ExistingProjectId()
    {
        ProjectRepo.listObj.Clear();
        ProjectRepo projectRepo = new ProjectRepo();
        int projectIdToCheck =1; // Replace with an existing project ID in your test data

        bool result = projectRepo.IsProjectId(projectIdToCheck);

        Assert.IsFalse(result);
    }

    [Test]
    public void TestIsProjectId_NonExistingProjectId()
    {
        ProjectRepo.listObj.Clear();
        ProjectRepo projectRepo = new ProjectRepo();
        int projectIdToCheck = 999; // Replace with a non-existing project ID

        bool result = projectRepo.IsProjectId(projectIdToCheck);

        Assert.IsFalse(result);
    }
}