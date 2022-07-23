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
    public void HolidaySearch_Should_Return_All_Available_Flights_and_Hotels_From_Man_To_AGP_On_Specific_Date()
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
        
        holidaySearch.Result().FlightsList.Count.Should().Be(1);
        holidaySearch.Result().HotelsList.Count.Should().Be(1);
        
    }
    
    [Test]
    public void HolidaySearch_Should_Return_All_Available_Flights_and_Hotels_From_LGW_To_AGP_On_Specific_Date()
    {
        var holidaySearch = new HolidaySearch.SearchModels.HolidaySearch(
        departingFrom: "LGW",
        travelingTo: "AGP",
        departureDate: "2023/07/01",
        duration: 7
        );
        holidaySearch.Result().FlightsList.Count.Should().Be(2);
        holidaySearch.Result().HotelsList.Count.Should().Be(1);
        
        
    }

    [Test]
    public void HolidaySearch_Should_Return_Cheapest_Flights_and_Hotels_From_LGW_To_AGP_On_Specific_Date()
    {
        var holidaySearch = new HolidaySearch.SearchModels.HolidaySearch(
            departingFrom: "LGW",
            travelingTo: "AGP",
            departureDate: "2023/07/01",
            duration: 7
        );

        var expectedFlightId = 11;
        var expectedHotelId = 9;
        decimal expectedTotalPrice = 736;

        var resultFlightId = holidaySearch.Result().FlightsList.First().FlightId;
        var resultHotelId = holidaySearch.Result().HotelsList.First().HotelId;
        var resultTotalPrice = holidaySearch.Result().ListOfTotalPrices.First();

        resultFlightId.Should().Be(expectedFlightId);
        resultHotelId.Should().Be(expectedHotelId);
        resultTotalPrice.Should().Be(expectedTotalPrice);

    }

}