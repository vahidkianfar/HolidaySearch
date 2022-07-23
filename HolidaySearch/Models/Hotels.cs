using System.Text.Json.Serialization;
using HolidaySearch.LoadDataModels;

namespace HolidaySearch.Models;

public class Hotels
{
    [JsonPropertyName("id")]
    public int HotelId { get; set; }
    
    [JsonPropertyName("name")]
    public string HotelName { get; set; }
    
    [JsonPropertyName("arrival_date")]
    public DateTime ArrivalDate { get; set; }
    
    [JsonPropertyName("price_per_night")]
    public decimal HotelPricePerNight { get; set; }
    
    [JsonPropertyName("local_airports")]
    public List<string> LocalAirports { get; set; }
    
    [JsonPropertyName("nights")]
    public int DurationNights { get; set; }

    public static List<Hotels> FindMatchHotels(string destinationCity, int duration , string departureDate)
    {
        var hotels = LoadDataFromJson.LoadHotels();
        var match = hotels.Where(hotel => hotel.LocalAirports.First() == destinationCity
                                          && hotel.DurationNights == duration && 
                                          hotel.ArrivalDate == DateTime.Parse(departureDate)).ToList() ;
        return match;
    }
}