using HolidaySearch.LoadDataModels;
using HolidaySearch.Models;

namespace HolidaySearch.SearchModels;

public class HolidaySearch
{
    public string DepartingFrom { get; set; }
    public string TravelingTo { get; set; }
    public string DepartureDate { get; set; }
    public int Duration { get; set; }
    
    public HolidaySearch(string departingFrom, string travelingTo, string departureDate, int duration)
    {
        DepartingFrom = departingFrom;
        TravelingTo = travelingTo;
        DepartureDate = departureDate;
        Duration = duration;
    }

    public int Result()
    {
        var listOfFlights = LoadDataFromJson.LoadFlights();
        var listOfHotels = LoadDataFromJson.LoadHotels();
        
        var matchFlight = listOfFlights.Where(flight =>
            flight.OriginCity == DepartingFrom &&
            flight.DestinationCity == TravelingTo &&
            flight.DepartureDate == DateTime.Parse(DepartureDate)).ToList();
        
        
        return matchFlight.First().FlightId;
    }
}