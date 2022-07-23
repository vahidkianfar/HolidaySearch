using Spectre.Console;

namespace HolidaySearch.UI;

public class SearchMenu
{
    public static void Start()
    {
        var departingFrom = AnsiConsole.Ask<string>("Departing from (e.g. [orange1]MAN[/]) : ");
        var travelingTo = AnsiConsole.Ask<string>("Traveling to (e.g. [orange1]PMI[/]) : ");
        var departureDate = AnsiConsole.Ask<string>("Departure date (e.g. [orange1]2023-06-15[/]) : ");
        var duration = AnsiConsole.Ask<int>("Duration (e.g. [orange1]10[/]) : ");
        
        var holidaySearch = new SearchModels.HolidaySearch(departingFrom, travelingTo, departureDate, duration);
        holidaySearch.PrettyPrint();
        
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.ResetColor();
        Console.Clear();
    }
}