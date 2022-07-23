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
        
        var matchFlight = listOfFlights.Where(flight =>
            flight.OriginCity == DepartingFrom &&
            flight.DestinationCity == TravelingTo &&
            flight.DepartureDate == DateTime.Parse(DepartureDate)).ToList();

        return matchFlight.First().FlightId;
    }

    public int ResultHotel()
    {
        
        var listOfHotels = LoadDataFromJson.LoadHotels();
        var matchHotel=listOfHotels.Where(hotel=>
            hotel.LocalAirports.First()==TravelingTo &&
            hotel.DurationNights==Duration &&
            hotel.ArrivalDate == DateTime.Parse(DepartureDate)).ToList();
        
        return matchHotel.First().HotelId;
    }
}