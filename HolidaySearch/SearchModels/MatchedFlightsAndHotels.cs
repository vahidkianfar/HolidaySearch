using HolidaySearch.LoadDataModels;
using HolidaySearch.Models;

namespace HolidaySearch.SearchModels;

public class MatchedFlightsAndHotels
{
    public List<Flights> FlightsList { get; set; }
    public List<Hotels> HotelsList { get; set; }
    public List<decimal> ListOfTotalPrices { get; set; }

    public static List<Hotels> FindMatchHotels(string travelingTo, int duration , string departureDate)
    {
        var hotels = LoadDataFromJson.LoadHotels();
        var match = hotels!.Where(hotel => hotel.LocalAirports.First() == travelingTo
                                           && hotel.DurationNights == duration && 
                                           hotel.ArrivalDate == DateTime.Parse(departureDate)).ToList();
        
        return match;
    }

    public static List<Flights> FindMatchFlights(string departingFrom, string travelingTo, string departureDate)
    {
        var flights = LoadDataFromJson.LoadFlights();
        List<Flights> match;

        if (departingFrom.Contains("London")) 
            match = ReturnAnyAvailableLondonAirport(flights, travelingTo, departureDate);

        else if (departingFrom=="Any Airport" || string.IsNullOrEmpty(departingFrom))
            match = ReturnAnyAvailableAirport(flights, travelingTo, departureDate);

        else
        {
            match =
                flights!.Where(flight =>
                    flight.DepartingFrom == departingFrom && flight.TravelingTo == travelingTo &&
                    flight.DepartureDate == DateTime.Parse(departureDate)).ToList();
        }

        return match;
    }



    private static List<Flights> ReturnAnyAvailableLondonAirport(List<Flights> flights , string travelingTo, string departureDate)
    {
        var listOfLondonAirport = GetLondonAirports();
        var match = flights.Where(flight =>
                listOfLondonAirport.Contains(flight.DepartingFrom!)
                && flight.TravelingTo == travelingTo &&
                flight.DepartureDate == DateTime.Parse(departureDate)).ToList();
        
        return match;
    }
    private static List<Flights> ReturnAnyAvailableAirport(List<Flights> flights , string travelingTo, string departureDate)
    {
        var match =
            flights.Where(flight =>
                flight.TravelingTo == travelingTo &&
                flight.DepartureDate == DateTime.Parse(departureDate)).ToList();
        
        return match;
    }
    private static List<string> GetLondonAirports()
    {
        var listOfLondonAirport = new List<string> { "LGW", "LTN" };
        return listOfLondonAirport;
    }
}