namespace PPM.UiConsole
{
    public class RoleModule
    {
        public static void RoleModuleRepo()
        {
            int RoleModuleChoice;

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
                RoleModuleChoice = int.Parse(Console.ReadLine()!);
                Console.ForegroundColor = ConsoleColor.White;
                RoleUi Role = new();

                switch (RoleModuleChoice)
                {
                    case 1:
                        
                        Role.Add();
                        break;

                    case 2:
                        
                        Role.ViewAll();
                        break;

                    case 3:
                        
                        Role.ViewById();
                        break;

                    case 4:
                        
                        Role.Delete();
                        break;

                    case 5:
                        // Returns to Main-Menu
                        break;

                    default:
                        ConsoleUi.Default();
                        break;
                }
            }
            while (RoleModuleChoice != 5);
        }
    }
}