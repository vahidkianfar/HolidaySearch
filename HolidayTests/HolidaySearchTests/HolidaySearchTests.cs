using HolidaySearch.SearchModels;
using FluentAssertions;
namespace HolidayTests.HolidaySearchTests;

public class HolidaySearchTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void HolidaySearch_Should_Return_All_Available_Flights_and_Hotels()
    {
        var holidaySearch = new HolidaySearch.SearchModels.HolidaySearch(
        departingFrom: "MAN",
        travelingTo: "AGP",
        departureDate: "2023/07/01",
        duration: 7
        );

        var expectedFlightId = 2;
        var expectedHotelId = 9;

        var resultFlightId = holidaySearch.Result().FlightsList.First().FlightId;
        var resultHotelId = holidaySearch.Result().HotelsList.First().HotelId;
        
        
        resultFlightId.Should().Be(expectedFlightId);
        resultHotelId.Should().Be(expectedHotelId);
        
    }
    
    
}