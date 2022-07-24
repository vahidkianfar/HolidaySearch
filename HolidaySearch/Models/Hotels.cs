using System.Text.Json.Serialization;
using HolidaySearch.Interfaces;

namespace HolidaySearch.Models;

public class Hotels:IHotels
{
    [JsonPropertyName("id")]
    public int HotelId { get; set; }
    
    [JsonPropertyName("name")]
    public string? HotelName { get; set; }
    
    [JsonPropertyName("arrival_date")]
    public DateTime ArrivalDate { get; set; }
    
    [JsonPropertyName("price_per_night")]
    public decimal HotelPricePerNight { get; set; }
    
    [JsonPropertyName("local_airports")]
    public List<string> LocalAirports { get; set; }
    
    [JsonPropertyName("nights")]
    public int DurationNights { get; set; }
}