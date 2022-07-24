using Spectre.Console;

namespace HolidaySearch.UI;

public class SearchMenu
{
    public static void Start()
    {
        var departingFrom = AnsiConsole.Ask<string>("Departing from (e.g. [orange1]MAN[/]) : ").ToUpper();
        var travelingTo = AnsiConsole.Ask<string>("Traveling to (e.g. [orange1]AGP[/]) : ").ToUpper();
        var departureDate = AnsiConsole.Ask<string>("Departure date (e.g. [orange1]2023-07-01[/]) : ");
        var duration = AnsiConsole.Ask<int>("Duration (e.g. [orange1]7[/]) : ");
        
        var holidaySearch = new SearchModels.HolidaySearch(departingFrom, travelingTo, departureDate, duration);
        holidaySearch.PrettyPrint();
        
        
    }
}