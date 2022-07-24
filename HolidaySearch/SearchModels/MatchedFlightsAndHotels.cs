using HolidaySearch.LoadDataModels;
using HolidaySearch.Models;

namespace HolidaySearch.SearchModels;

public class MatchedFlightsAndHotels
{
    public List<Flights> FlightsList { get; set; }
    public List<Hotels> HotelsList { get; set; }
    public List<decimal> ListOfTotalPrices { get; set; }

    public static List<Hotels> FindMatchHotels(string destinationCity, int duration , string departureDate)
    {
        var hotels = LoadDataFromJson.LoadHotels();
        var match = hotels!.Where(hotel => hotel.LocalAirports.First() == destinationCity
                                           && hotel.DurationNights == duration && 
                                           hotel.ArrivalDate == DateTime.Parse(departureDate)).ToList();
        
        return match;
    }

    public static List<Flights> FindMatchFlights(string originCity, string destinationCity, string departureDate)
    {
        var flights = LoadDataFromJson.LoadFlights();
        List<Flights> match;

        if (originCity.Contains("London")) 
            match = ReturnAnyAvailableLondonAirport(flights, destinationCity, departureDate);

        else if (originCity=="Any Airport" || string.IsNullOrEmpty(originCity))
            match = ReturnAnyAvailableAirport(flights, destinationCity, departureDate);

        else
        {
            match =
                flights!.Where(flight =>
                    flight.DepartingFrom == originCity && flight.TravelingTo == destinationCity &&
                    flight.DepartureDate == DateTime.Parse(departureDate)).ToList();
        }

        return match;
    }



    private static List<Flights> ReturnAnyAvailableLondonAirport(List<Flights> flights , string destinationCity, string departureDate)
    {
        var listOfLondonAirport = GetLondonAirports();
        var match = flights.Where(flight =>
                listOfLondonAirport.Contains(flight.DepartingFrom!)
                && flight.TravelingTo == destinationCity &&
                flight.DepartureDate == DateTime.Parse(departureDate)).ToList();
        
        return match;
    }
    private static List<Flights> ReturnAnyAvailableAirport(List<Flights> flights , string destinationCity, string departureDate)
    {
        var match =
            flights.Where(flight =>
                flight.TravelingTo == destinationCity &&
                flight.DepartureDate == DateTime.Parse(departureDate)).ToList();
        
        return match;
    }
    private static List<string> GetLondonAirports()
    {
        var listOfLondonAirport = new List<string> { "LGW", "LTN" };
        return listOfLondonAirport;
    }
}