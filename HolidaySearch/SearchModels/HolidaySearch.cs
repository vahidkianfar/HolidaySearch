
using System.Globalization;
using HolidaySearch.Models;
using Spectre.Console;

namespace HolidaySearch.SearchModels;

public class HolidaySearch
{
    private string DepartingFrom { get; set; }
    private string TravelingTo { get; set; }
    private string DepartureDate { get; set; }
    private int Duration { get; set; }
    
    public HolidaySearch(string departingFrom, string travelingTo, string departureDate, int duration)
    {
        DepartingFrom = departingFrom;
        TravelingTo = travelingTo;
        DepartureDate = departureDate;
        Duration = duration;
    }

    public MatchedFlightsAndHotels Result()
    {
        var cheapest = new MatchedFlightsAndHotels
        {
            FlightsList = ReturnFlightPriceByAscendingOrder(),
            HotelsList = ReturnHotelPriceByAscendingOrder(),
            ListOfTotalPrices = CalculateListOfTotalPrice()
        };

        if (cheapest.FlightsList.Count == 0 || cheapest.HotelsList.Count == 0)
            Console.WriteLine("No results found");
        
        return cheapest;
    }
    
    public List<Flights> ReturnFlightPriceByAscendingOrder()
    {
        var matchFlights = MatchedFlightsAndHotels.FindMatchFlights(DepartingFrom, TravelingTo, DepartureDate);
        matchFlights.Sort((flightA, flightB) => flightA.FlightPrice.CompareTo(flightB.FlightPrice));
        return matchFlights;
    }

    public List<Hotels> ReturnHotelPriceByAscendingOrder()
    {
        var matchHotels = MatchedFlightsAndHotels.FindMatchHotels(TravelingTo, Duration, DepartureDate);
        matchHotels.Sort((hotelA, hotelB) => hotelA.HotelPricePerNight.CompareTo(hotelB.HotelPricePerNight));
        return matchHotels;
    }
    
    public List<decimal> CalculateListOfTotalPrice()
    {
        var listOfAvailableFlights = ReturnFlightPriceByAscendingOrder();
        var flightPrice = listOfAvailableFlights.Select(flight => flight.FlightPrice).ToList();
        
        var listOfAvailableHotels = ReturnHotelPriceByAscendingOrder();
        var hotelPrice = listOfAvailableHotels.Select(hotel => hotel.HotelPricePerNight*Duration).ToList();
        
        if(flightPrice.Count == 0) flightPrice.Add(0);
        if(hotelPrice.Count == 0) hotelPrice.Add(0);
        
        var listOfTotalPrices=(from flight in flightPrice from hotel in hotelPrice select flight + hotel).Distinct().ToList();
        
        return listOfTotalPrices;
    }

    public void PrettyPrint()
    {
        Console.Clear();
        AnsiConsole.Write(
            new Table()
                .AddColumn(new TableColumn("Airline Name").Centered())
                .AddColumn(new TableColumn("Flight ID").Centered())
                .AddColumn(new TableColumn("Flight Price").Centered())
                .AddColumn(new TableColumn("Departure Date").Centered())
                .AddColumn(new TableColumn("Hotel Name").Centered())
                .AddColumn(new TableColumn("Hotel ID").Centered())
                .AddColumn(new TableColumn("Hotel Price per night").Centered())
                .AddColumn(new TableColumn("Duration").Centered())
                .AddColumn(new TableColumn("Total Price").Centered())
                
                .AddRow($"[skyblue1]{Result().FlightsList.First().AirlineName}[/]",
                    $"[skyblue1]{Result().FlightsList.First().FlightId}[/]",
                    $"[skyblue1]{Result().FlightsList.First().FlightPrice}[/]",
                    $"[skyblue1]{Result().FlightsList.First().DepartureDate:yyyy/MM/dd}[/]",
                    $"[skyblue1]{Result().HotelsList.First().HotelName}[/]",
                    $"[skyblue1]{Result().HotelsList.First().HotelId}[/]",
                    $"[skyblue1]{Result().HotelsList.First().HotelPricePerNight}[/]",
                    $"[skyblue1]{Result().HotelsList.First().DurationNights}[/]",
                    $"[green]{Result().ListOfTotalPrices.First().ToString("C", new CultureInfo("en-GB"))}[/]")
                .BorderColor(Color.Yellow2));
        
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.ResetColor();
        Console.Clear();
    }
}