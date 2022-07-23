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
    public void HolidaySearch_Should_Return_All_Available_Flights_and_Hotels_From_Man_To_AGP()
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
    public void HolidaySearch_Should_Return_All_Available_Flights_and_Hotels_From_LGW_To_AGP()
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
    public void HolidaySearch_Should_Return_Cheapest_Flights_and_Hotels_From_LGW_To_AGP()
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

    [Test]

    public void HolidaySearch_Should_Return_Cheapest_Flights_and_Hotels_From_London_To_PMI()
    {
        var holidaySearch = new HolidaySearch.SearchModels.HolidaySearch(
            departingFrom: "Any London Airport",
            travelingTo: "PMI",
            departureDate: "2023/06/15",
            duration: 10
        );
        
        var expectedFlightId = 6;
        var expectedHotelId = 5;
        decimal expectedTotalPrice = 665;
        
        var resultFlightId = holidaySearch.Result().FlightsList.First().FlightId;
        var resultHotelId = holidaySearch.Result().HotelsList.First().HotelId;
        var resultTotalPrice = holidaySearch.Result().ListOfTotalPrices.First();
        
        resultFlightId.Should().Be(expectedFlightId);
        resultHotelId.Should().Be(expectedHotelId);
        resultTotalPrice.Should().Be(expectedTotalPrice);
    }

    [Test]
    public void HolidaySearch_Should_Return_Cheapest_Flights_and_Hotels_From_AnyAirport_To_LPA()
    {
        var holidaySearch = new HolidaySearch.SearchModels.HolidaySearch(
            departingFrom: "Any Airport",
            travelingTo: "LPA",
            departureDate: "2022/11/10",
            duration: 14
        );
        
        var expectedFlightId = 7;
        var expectedHotelId = 6;
        decimal expectedTotalPrice = 1175;
        
        var resultFlightId = holidaySearch.Result().FlightsList.First().FlightId;
        var resultHotelId = holidaySearch.Result().HotelsList.First().HotelId;
        var resultTotalPrice = holidaySearch.Result().ListOfTotalPrices.First();
        
        resultFlightId.Should().Be(expectedFlightId);
        resultHotelId.Should().Be(expectedHotelId);
        resultTotalPrice.Should().Be(expectedTotalPrice);
    }
    
    [Test]
    public void HolidaySearch_Should_Return_Cheapest_Flights_and_Hotels_From_MAN_To_LPA()
    {
        var holidaySearch = new HolidaySearch.SearchModels.HolidaySearch(
            departingFrom: "MAN",
            travelingTo: "LPA",
            departureDate: "2022/11/10",
            duration: 14
        );
        
        var expectedFlightId = 7;
        var expectedHotelId = 6;
        decimal expectedTotalPrice = 1175;
        
        var resultFlightId = holidaySearch.Result().FlightsList.First().FlightId;
        var resultHotelId = holidaySearch.Result().HotelsList.First().HotelId;
        var resultTotalPrice = holidaySearch.Result().ListOfTotalPrices.First();
        
        resultFlightId.Should().Be(expectedFlightId);
        resultHotelId.Should().Be(expectedHotelId);
        resultTotalPrice.Should().Be(expectedTotalPrice);
    }
    
    [Test]
    public void HolidaySearch_Should_Return_0_For_Available_Hotels_From_MAN_To_TFS_Because_There_No_Hotel()
    {
        //There is No Hotel Available on TFS at this Date.
        var holidaySearch = new HolidaySearch.SearchModels.HolidaySearch(
            departingFrom: "MAN",
            travelingTo: "TFS",
            departureDate: "2023/07/01",
            duration: 14
        );
        
        holidaySearch.Result().HotelsList?.Count.Should().Be(0);
    }
    
     
    [Test]
    public void HolidaySearch_Should_Return_FlightId_From_MAN_To_TFS()
    {
        var holidaySearch = new HolidaySearch.SearchModels.HolidaySearch(
            departingFrom: "MAN",
            travelingTo: "TFS",
            departureDate: "2023/07/01",
            duration: 14
        );
        
         var expectedFlightId = 1;
        
         var resultFlightId = holidaySearch.Result().FlightsList?.First().FlightId;
        
         resultFlightId.Should().Be(expectedFlightId);
        
    }
    
    [Test]
    public void HolidaySearch_Should_Return_Cheapest_Flights_and_Hotels_From_MAN_To_PMI()
    {
        var holidaySearch = new HolidaySearch.SearchModels.HolidaySearch(
            departingFrom: "MAN",
            travelingTo: "PMI",
            departureDate: "2023/06/15",
            duration: 14
        );
        
        var expectedFlightId = 5;
        var expectedHotelId = 3;
        decimal expectedTotalPrice = 956;
        
        var resultFlightId = holidaySearch.Result().FlightsList.First().FlightId;
        var resultHotelId = holidaySearch.Result().HotelsList.First().HotelId;
        var resultTotalPrice = holidaySearch.Result().ListOfTotalPrices.First();
        
        resultFlightId.Should().Be(expectedFlightId);
        resultHotelId.Should().Be(expectedHotelId);
        resultTotalPrice.Should().Be(expectedTotalPrice);
    }


}