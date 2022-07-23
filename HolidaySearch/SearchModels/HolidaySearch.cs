using HolidaySearch.LoadDataModels;
using HolidaySearch.Models;

namespace HolidaySearch.SearchModels;

public class HolidaySearch
{
    private string DepartingFrom { get; set; }
    private string TravelingTo { get; set; }
    private string DepartureDate { get; set; }
    private int Duration { get; set; }
    
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
            FlightsList = ReturnFlightPriceByAscendingOrder(),
            HotelsList = ReturnHotelPriceByAscendingOrder(),
            ListOfTotalPrices = CalculateListOfTotalPrice()
        };

        return cheapest;
    }
    
    private List<Flights> ReturnFlightPriceByAscendingOrder()
    {
        var matchFlights = Flights.FindMatchFlights(DepartingFrom, TravelingTo, DepartureDate);
        matchFlights.Sort((flightA, flightB) => flightA.FlightPrice.CompareTo(flightB.FlightPrice));
        return matchFlights;
    }

    private List<Hotels> ReturnHotelPriceByAscendingOrder()
    {
        var matchHotels = Hotels.FindMatchHotels(TravelingTo, Duration, DepartureDate);
        matchHotels.Sort((hotelA, hotelB) => hotelA.HotelPricePerNight.CompareTo(hotelB.HotelPricePerNight));
        return matchHotels;
    }
    
    private List<decimal> CalculateListOfTotalPrice()
    {
        var flightPrice = ReturnFlightPriceByAscendingOrder().Select(flight => flight.FlightPrice).ToList();
        var hotelPrice = ReturnHotelPriceByAscendingOrder().Select(hotel => hotel.HotelPricePerNight*Duration).ToList();
       
        return (from flight in flightPrice from hotel in hotelPrice select flight + hotel).Distinct().ToList();
    }
}