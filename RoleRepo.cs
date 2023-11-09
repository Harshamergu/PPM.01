using PPM.Model;

namespace PPM.Domain
{
    // Create class Rolerepo
    public class RoleRepo : IEntity<Role>
    {
        public static List<Role> listObj = new();

        // Implement Add Role Method
        public void Add(Role obj)
        {
            listObj.Add(obj);
            System.Console.WriteLine();
        }

        public bool IsRoleId(int RoleId)
        {
            bool result = listObj.Exists(x => x.RoleId == RoleId);
            return result;
        }

        public List<Role> ViewAll()
        {
            return listObj;
        }

        public List<Role> GetRoleByName(string roleName)
        {
            List<Role> role = listObj.FindAll(p => p.RoleName == roleName)!;
            return role;
        }

        public Role GetRoleById(int RoleId)
        {
            return listObj.FirstOrDefault(e => e.RoleId == RoleId)!;
        }

        public Role ViewById(int roleId)
        {
            Role roles = listObj.FirstOrDefault(r => r.RoleId == roleId)!;
            return roles;
        }

        public void Delete(int roleId)
        {
            Role roles = listObj.FirstOrDefault(e => e.RoleId == roleId)!;

            if (roles != null)
            {
                RoleRepo.listObj.Remove(roles);
            }
        }
    }
}