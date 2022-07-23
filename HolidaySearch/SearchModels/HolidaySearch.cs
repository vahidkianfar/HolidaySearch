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

    public MatchFlightsAndHotels Result()
    {
        var cheapest = new MatchFlightsAndHotels
        {
            
            // FlightsList = ReturnFlightPriceByAscendingOrder(),
            // HotelsList = ReturnHotelPriceByAscendingOrder(),
            // ListOfTotalPrices = CalculateListOfTotalPrice

        };

        return cheapest;
    }
    
    public static List<Flights> FindMatchFlights(string originCity, string destinationCity, string departureDate)
    {
        var flights = LoadDataFromJson.LoadFlights();
        List<Flights> match;

        if (originCity.Contains("London"))
        {
            var listOfLondonAirport = GetLondonAirports();
            match =
                flights.Where(flight =>
                    listOfLondonAirport.Contains(flight.OriginCity)
                    && flight.DestinationCity == destinationCity &&
                    flight.DepartureDate == DateTime.Parse(departureDate)).ToList();
        }
        
        else if (originCity=="Any Airport")
        {
            match =
                flights.Where(flight =>
                    flight.DestinationCity == destinationCity &&
                    flight.DepartureDate == DateTime.Parse(departureDate)).ToList();
        }
        
        else
        {
            match =
                flights.Where(flight =>
                    flight.OriginCity == originCity && flight.DestinationCity == destinationCity &&
                    flight.DepartureDate == DateTime.Parse(departureDate)).ToList();
        }

        return match;
    }

    public static List<Hotels> FindMatchHotels(string destinationCity, int duration , string departureDate)
    {
        var hotels = LoadDataFromJson.LoadHotels();
        var match = hotels.Where(hotel => hotel.LocalAirports.First() == destinationCity
                                          && hotel.DurationNights == duration && 
                                          hotel.ArrivalDate == DateTime.Parse(departureDate)).ToList() ;
        return match;
    }
    
    private static List<string> GetLondonAirports()
    {
        var listOfLondonAirport = new List<string> { "LGW", "LTN" };
        return listOfLondonAirport;
    }
    
    

    public List<int> OldResult()
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