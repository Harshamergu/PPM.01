namespace PPM.Model
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string? ProjectName { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public List<Employee> EmployeeProject = new List<Employee>();
        public int EmployeeId;
    }
}
