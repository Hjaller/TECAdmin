using TECAdmin.enums;

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
                // Display any previous error message
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(errorMessage + "\n");
                    Console.ResetColor();
                    errorMessage = string.Empty;
                }

                // Display the menu
                foreach (SearchCriteria searchCriteria in Enum.GetValues(typeof(SearchCriteria)))
                {
                    Console.WriteLine($"{(int)searchCriteria + 1}) {Utils.GetEnumDescription(searchCriteria)}");
                }

                Console.Write("\nSelect 1, 2, or 3");
                var keyPressed = Console.ReadKey(intercept: true).KeyChar;  // Read key without showing it in console
                Console.WriteLine();  // Move to the next line after the key press

                // Check if the input is valid
                if (int.TryParse(keyPressed.ToString(), out int choice) &&
                    Enum.IsDefined(typeof(SearchCriteria), choice - 1))
                {
                    SearchCriteria selectedCriteria = (SearchCriteria)(choice - 1);
                    switch (selectedCriteria)
                    {
                        case SearchCriteria.Teacher:
                            Console.WriteLine("Teacher search");
                            Console.ReadKey();
                            break;
                        case SearchCriteria.Student:
                            Console.WriteLine("Student search");
                            Console.ReadKey();
                            break;
                        case SearchCriteria.Subject:
                            Console.WriteLine("Subject search");
                            Console.ReadKey();
                            break;
                        default:
                            errorMessage = "Invalid choice. Please try again!";
                            break;
                    }
                }
                else
                {
                    errorMessage = "Invalid choice. Please try again!";
                }
            }
        }
    }
}
