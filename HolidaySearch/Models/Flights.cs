﻿using System.Text.Json.Serialization;
using HolidaySearch.LoadDataModels;

namespace HolidaySearch.Models;

public class Flights
{
    [JsonPropertyName("id")]
    public int FlightId { get; set; }
    
    [JsonPropertyName("airline")]
    public string? AirlineName { get; set; }
    
    [JsonPropertyName("from")]
    public string? OriginCity { get; set; }
    
    [JsonPropertyName("to")]
    public string? DestinationCity { get; set; }
    
    [JsonPropertyName("price")]
    public decimal FlightPrice { get; set; }
    
    [JsonPropertyName("departure_date")]
    public DateTime DepartureDate { get; set; }
}