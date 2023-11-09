namespace PPM.UiConsole
{
    public class EmployeeModule
    {
        public static void EmployeeModuleRepo()
        {
            int EmployeeModuleChoice;

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
                EmployeeModuleChoice = int.Parse(Console.ReadLine()!);
                Console.ForegroundColor = ConsoleColor.White;
                EmployeeUi Employee = new();

                switch (EmployeeModuleChoice)
                {
                    case 1:

                        Employee.Add();
                        break;

                    case 2:
               
                        Employee.ViewAll();
                        break;

                    case 3:
                       
                        Employee.ViewById();
                        break;

                    case 4:
                        
                        Employee.Delete();
                        break;

                    case 5:
                        // Returns to Main-Menu
                        break;

                    default:
                        ConsoleUi.Default();
                        break;
                }
            }
            while (EmployeeModuleChoice != 5);
        }
    }
}