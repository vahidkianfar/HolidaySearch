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

    public List<int> Result()
    {
        var listOfFlights = LoadDataFromJson.LoadFlights();
        var listOfHotels = LoadDataFromJson.LoadHotels();
        
        var matchFlight = listOfFlights.Where(flight =>
            flight.OriginCity == DepartingFrom &&
            flight.DestinationCity == TravelingTo &&
            flight.DepartureDate == DateTime.Parse(DepartureDate)).ToList();
        
        matchFlight.Sort((flightA, flightB) => flightA.FlightPrice.CompareTo(flightB.FlightPrice));
        
        var matchHotel=listOfHotels.Where(hotel=>
            hotel.LocalAirports.First()==TravelingTo &&
            hotel.DurationNights==Duration &&
            hotel.ArrivalDate == DateTime.Parse(DepartureDate)).ToList();
        
        matchHotel.Sort((hotelA, hotelB) => hotelA.HotelPricePerNight.CompareTo(hotelB.HotelPricePerNight));
        
        var result = new List<int>();
        result.Add(matchFlight.First().FlightId);
        result.Add(matchHotel.First().HotelId);

        return result;
    }
    
}