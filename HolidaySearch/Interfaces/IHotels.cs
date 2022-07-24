namespace HolidaySearch.Interfaces;

public interface IHotels
{
    public int HotelId { get; set; }
    public string? HotelName { get; set; }
    public DateTime ArrivalDate { get; set; }
    public decimal HotelPricePerNight { get; set; }
    public List<string> LocalAirports { get; set; }
    public int DurationNights { get; set; }
}