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
        {
            var listOfLondonAirport = GetLondonAirports();
            match =
                flights!.Where(flight =>
                    listOfLondonAirport.Contains(flight.OriginCity!)
                    && flight.DestinationCity == destinationCity &&
                    flight.DepartureDate == DateTime.Parse(departureDate)).ToList();
        }
        
        else if (originCity=="Any Airport" || string.IsNullOrEmpty(originCity))
        {
            match =
                flights!.Where(flight =>
                    flight.DestinationCity == destinationCity &&
                    flight.DepartureDate == DateTime.Parse(departureDate)).ToList();
        }
        
        else
        {
            match =
                flights!.Where(flight =>
                    flight.OriginCity == originCity && flight.DestinationCity == destinationCity &&
                    flight.DepartureDate == DateTime.Parse(departureDate)).ToList();
        }

        return match;
    }


    private static List<string> GetLondonAirports()
    {
        var listOfLondonAirport = new List<string> { "LGW", "LTN" };
        return listOfLondonAirport;
    }
}