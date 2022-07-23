using System.Text.Json;
using HolidaySearch.Models;

namespace HolidaySearch.LoadDataModels;

public class LoadDataFromJson
{
    private static readonly  DirectoryInfo? DatasetPath =
        Directory.GetParent(Directory.GetParent(
            Directory.GetParent(
                Directory.GetParent(
                        Directory.GetCurrentDirectory())?
                    .ToString() ?? string.Empty)?.ToString()
            ?? string.Empty)?.ToString() ?? string.Empty);

    public static List<Flights>? LoadFlights()
    {
        var flightData = File.ReadAllText(DatasetPath + "/HolidaySearch/Datasets/Flights.json");
        var flights = JsonSerializer.Deserialize<List<Flights>>(flightData);
        return flights;
    }
    
    public static List<Hotels>? LoadHotels()
    {
        var hotelData = File.ReadAllText(DatasetPath + "/HolidaySearch/Datasets/Hotels.json");
        var hotels = JsonSerializer.Deserialize<List<Hotels>>(hotelData);
        return hotels;
    }

}