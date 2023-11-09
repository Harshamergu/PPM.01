using PPM.Model;

namespace PPM.Domain
{
    public class EmployeeRepo : IEntity<Employee>
    {
        public static List<Employee> listObj = new(); // Create Object to store list of Employees

        // Implement Add Employee Method
        public void Add(Employee obj)
        {
            listObj.Add(obj);
            System.Console.WriteLine();
        }
        
        public List<Employee> ViewAll()
        {
            return listObj;
        }
       
        public bool IsEmployeeId(int employeeId)
        {
            bool result = EmployeeRepo.listObj.Exists(x => x.EmployeeId == employeeId);
            return result;
        }

        public Employee GetEmployeeById(int employeeId)
        {
            return listObj.FirstOrDefault(e => e.EmployeeId == employeeId)!;
        }

        public List<Employee> ViewEmployees()
        {
            return listObj;
        }

        public void Delete(int employeeId)
        {
            Employee employee = listObj.FirstOrDefault(e => e.EmployeeId == employeeId)!;
            if (employee != null)
            {
                EmployeeRepo.listObj.Remove(employee);
            }
        }

        public Employee ViewById(int employeeId)
        {

            Employee employee = listObj.FirstOrDefault(e => e.EmployeeId == employeeId)!;
            return employee;

        }
    }
}