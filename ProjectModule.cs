namespace PPM.UiConsole
{
    public class ProjectModule
    {
        public static void ProjectModuleRepo()
        {
            int ProjectModuleChoice;

            do
            {
                System.Console.WriteLine();
                System.Console.WriteLine(" ----------------------------------- ");
                System.Console.WriteLine("|       1. Add                      |");  
                System.Console.WriteLine("|       2. List all                 |");
                System.Console.WriteLine("|       3. List by Id               |");
                System.Console.WriteLine("|       4. Delete                   |");
                System.Console.WriteLine("|       5. Return to Main-menu      |");
                System.Console.WriteLine(" ----------------------------------- ");
                System.Console.WriteLine();

                System.Console.Write("Enter your choice : ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                ProjectModuleChoice = int.Parse(Console.ReadLine()!);
                Console.ForegroundColor = ConsoleColor.White;
                 ProjectUi projectUi = new();

                switch (ProjectModuleChoice)
                {
                    case 1:
                       
                        projectUi.Add();
                        break;

                    case 2:
                    
                        projectUi.ViewAll();
                        break;

                    case 3:
                    
                        projectUi.ViewById();
                        break;

                    case 4:
                       
                        projectUi.Delete();
                        break;

                    case 5:
                        // Returns to Main-Menu
                        break;

                    default:
                        ConsoleUi.Default();
                        break;
                }
            }
            while (ProjectModuleChoice != 5);
        }
    }
}