using System.Text.Json.Serialization;

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
    
    [JsonPropertyName("local_airport")]
    public List<string> LocalAirport { get; set; }
    
    [JsonPropertyName("nights")]
    public int DurationNights { get; set; }
    
}