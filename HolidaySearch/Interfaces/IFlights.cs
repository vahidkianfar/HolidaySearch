namespace HolidaySearch.Interfaces;

public interface IFlights
{
    public int FlightId { get; set; }
    public string? AirlineName { get; set; }
    public string? DepartingFrom { get; set; }
    public string? TravelingTo { get; set; }
    public decimal FlightPrice { get; set; }
    public DateTime DepartureDate { get; set; }
}