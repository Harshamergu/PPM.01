using System;
using System.Xml;
using System.Xml.Serialization;
using PPM.Domain;
using PPM.Model;
 
public class SaveData
{
    public void saveToFile()
    {
        string employeePath = @"C:\Users\HMergu\Desktop\PPM\PPM.Xml\Employee.xml";
        string rolePath = @"C:\Users\HMergu\Desktop\PPM\PPM.Xml\Role.xml";
        string projectpath = @"C:\Users\HMergu\Desktop\PPM\PPM.Xml\Project.xml";
 
        using (TextWriter textWriter = new StreamWriter(employeePath, true))
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Employee>));
            xmlSerializer.Serialize(textWriter, EmployeeRepo.listObj);
        }
 
        using (TextWriter textWriter = new StreamWriter(rolePath))
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Role>));
            xmlSerializer.Serialize(textWriter, RoleRepo.listObj);
        }
 
        using (TextWriter textWriter = new StreamWriter(projectpath))
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Project>));
            xmlSerializer.Serialize(textWriter, ProjectRepo.listObj);
        }
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        System.Console.WriteLine(" Data Saved :)");
    }
}