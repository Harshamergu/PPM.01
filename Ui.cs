namespace PPM.UiConsole
{
    public class ConsoleUi
    {
        public static void Title()
        {
            // Clear the Console 
            Console.Clear();
            Thread.Sleep(1000);
            System.Console.WriteLine("     _____________________________________________________     ");
            System.Console.WriteLine(" << |                                                     | >> ");
            System.Console.WriteLine(" << |     << Welcome to Prolifics Project Manager! >>     | >> ");
            System.Console.WriteLine(" << |_____________________________________________________| >> ");
        }

        public static int Menu()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            System.Console.WriteLine(" ____________________________________________________________");
            System.Console.WriteLine("|                                                            |");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            System.Console.WriteLine("|                        << Menu >>                          |");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            System.Console.WriteLine("|____________________________________________________________|");
            System.Console.WriteLine("|                                                            |");
            System.Console.WriteLine("|                -> 1 : Project Module                       |");
            System.Console.WriteLine("|                -> 2 : Employee Module                      |");
            System.Console.WriteLine("|                -> 3 : Role Module                          |");
            System.Console.WriteLine("|                -> 4 : Save Data                            |");
            System.Console.WriteLine("|                -> 5 : Quit                                 |");
            System.Console.WriteLine("|____________________________________________________________|");

            Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine();
            System.Console.Write("Select your choice and Enter here : ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            int choice = int.Parse(Console.ReadLine()!);
            Console.ForegroundColor = ConsoleColor.White;

            return choice;
        }

        public static void Quit()
        {
            // Quit
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine();
            System.Console.WriteLine("^ ^ ^ ^ ^ ^ ^ ^ ^ ^ ^ ^ ^ ^ ^ ^ ^ ^ ^ ^ ^ ^ ^ ^ ^ ^ ^ ^");
            System.Console.WriteLine("^                                                     ^");
            System.Console.WriteLine("^                Thank you for using PPM :)           ^");
            System.Console.WriteLine("^                                                     ^");
            System.Console.WriteLine("^ ^ ^ ^ ^ ^ ^ ^^ ^ ^ ^ ^ ^ ^ ^ ^ ^ ^ ^ ^ ^^ ^ ^ ^ ^ ^ ^");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Default()
        {
            // Default
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine();
            System.Console.WriteLine("Wrong choice! Try again :(");
            System.Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
