namespace TECAdmin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string errorMessage = string.Empty;

            while (true)
            {
                Console.Clear();
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(errorMessage + "\n");
                    Console.ResetColor();
                    errorMessage = string.Empty;
                }

                Console.WriteLine("Vælg:");
                Console.WriteLine("1) Søg på fag");
                Console.WriteLine("2) Søg på lærer");
                Console.WriteLine("3) Søg på elev");
                Console.Write("\nVælg 1, 2 eller 3: ");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        // Logik for at søge på fag
                        break;
                    case "2":
                        // Logik for at søge på lærer
                        break;
                    case "3":
                        // Logik for at søge på elev
                        break;
                    default:
                        errorMessage = "Menupunkt ikke fundet";
                        break;
                }
            }
        }
    }
}