using System.Text.Json.Serialization;
using HolidaySearch.LoadDataModels;

namespace HolidaySearch.Models;

public class Flights
{
    [JsonPropertyName("id")]
    public int FlightId { get; set; }
    
    [JsonPropertyName("airline")]
    public string AirlineName { get; set; }
    
    [JsonPropertyName("from")]
    public string? OriginCity { get; set; }
    
    [JsonPropertyName("to")]
    public string DestinationCity { get; set; }
    
    [JsonPropertyName("price")]
    public decimal FlightPrice { get; set; }
    
    [JsonPropertyName("departure_date")]
    
    public DateTime DepartureDate { get; set; }

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


    private static List<string?> GetLondonAirports()
    {
        var listOfLondonAirport = new List<string?> { "LGW", "LTN" };
        return listOfLondonAirport;
    }
}