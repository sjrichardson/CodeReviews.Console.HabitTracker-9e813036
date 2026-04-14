using System.Globalization;

namespace habit_tracker.src;
public static class Dialogue
{
    public static string GetDateInput()
    {
        Console.WriteLine("Please insert the date: (Format: dd-mm-yy). Type 0 to return to Main Menu.");

        string? dateInput = Console.ReadLine();
        while(!DateTime.TryParseExact(dateInput, "dd-MM-yy",new CultureInfo("en-US"), DateTimeStyles.None, out _))
        {
            Console.WriteLine("Invalid date. (Format: dd-mm-yy) Try again or press 0 to return to Main Menu.");
            dateInput = Console.ReadLine();
        }

        return dateInput;
    }

    public static int GetNumberInput(string message)
    {
        Console.WriteLine(message);

        string? numberInput = Console.ReadLine();

        while(!Int32.TryParse(numberInput, out _) || Convert.ToInt32(numberInput) < 0)
        {
            Console.WriteLine("Invalid number. Try again or press 0 to return to Main Menu");
            numberInput = Console.ReadLine();
        }
        
        return Convert.ToInt32(numberInput);
    }
}