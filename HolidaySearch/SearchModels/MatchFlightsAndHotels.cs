using HolidaySearch.Models;

namespace HolidaySearch.SearchModels;

public class MatchFlightsAndHotels
{
    public List<Flights>? FlightsList { get; set; }
    public List<Hotels>? HotelsList { get; set; }
    public List<decimal>? ListOfTotalPrices { get; set; }
}