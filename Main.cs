using PPM.UiConsole;

namespace PPM.Main
{
    public class Program
    {
        // Main Method
        public static void Main(string[] args)
        {
            ConsoleUi.Title();
            int choice;

            do
            {
                choice = ConsoleUi.Menu();

                switch (choice)
                {

                    case 1:
                        ProjectModule.ProjectModuleRepo();
                        break;

                    case 2:
                        EmployeeModule.EmployeeModuleRepo();
                        break;

                    case 3:
                        RoleModule.RoleModuleRepo();
                        break;

                    case 4:
                    SaveData saveData = new();
                        saveData.saveToFile();
                        break;

                    case 5:
                        ConsoleUi.Quit();
                        break;

                    default:
                        ConsoleUi.Default();
                        break;
                }

            } while (choice != 5);
        }
    }
}
