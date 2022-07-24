
using FluentAssertions;
using HolidaySearch.SearchModels;

namespace HolidayTests.HolidaySearchTests;

public class HolidaySearchTests
{
    [SetUp]
    public void Setup()
    {
    }
    
    [Test]
    public void ReturnFlightPriceByAscendingOrder_Should_Sort_and_Return_Matched_Flights()
    {
        //Arrange
        var holidaySearch = new HolidaySearch.SearchModels.HolidaySearch(
            departingFrom: "LGW",
            travelingTo: "AGP",
            departureDate: "2023/07/01",
            duration: 7
        );
        
        //Act
        var result= holidaySearch.ReturnFlightPriceByAscendingOrder();
        
        //Assert
        result.First().FlightPrice.Should().BeLessThan(result.Last().FlightPrice);
    }
    [Test]
    public void ReturnHotelPriceByAscendingOrder_Should_Sort_and_Return_Matched_Hotels()
    {
        var holidaySearch = new HolidaySearch.SearchModels.HolidaySearch(
            departingFrom: "",
            travelingTo: "TFS",
            departureDate: "2022/11/05",
            duration: 7
        );
        
        var result= holidaySearch.ReturnHotelPriceByAscendingOrder();
        
        result.First().HotelPricePerNight.Should().BeLessThan(result.Last().HotelPricePerNight);
    }
    
    [Test]
    public void CalculateTotalPrice_Should_Sort_and_Return_Total_Price_Of_Flights_Hotels()
    {
        var holidaySearch = new HolidaySearch.SearchModels.HolidaySearch(
            departingFrom: "",
            travelingTo: "AGP",
            departureDate: "2023/07/01",
            duration: 7
        );
        
        var result= holidaySearch.CalculateListOfTotalPrice();
        
        result.First().Should().BeLessThan(result.Last());
    }

    [Test]
    public void HolidaySearch_Should_Return_All_Available_Flights_and_Hotels_From_Man_To_AGP()
    {
        //Arrange
        var holidaySearch = new HolidaySearch.SearchModels.HolidaySearch(
        departingFrom: "MAN",
        travelingTo: "AGP",
        departureDate: "2023/07/01",
        duration: 7
        );

        var expectedFlightId = 2;
        var expectedHotelId = 9;
        
        //Act
        var resultFlightId = holidaySearch.Result().FlightsList.First().FlightId;
        var resultHotelId = holidaySearch.Result().HotelsList.First().HotelId;
        
        //Assert
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
    public void HolidaySearch_Should_Return_All_Available_Flights_and_Hotels_From_LGW_To_AGP_Correctly()
    {
        var holidaySearch = new HolidaySearch.SearchModels.HolidaySearch(
            departingFrom: "LGW",
            travelingTo: "AGP",
            departureDate: "2023/07/01",
            duration: 7
        );
        
        var expectedFlightId1 = 11;
        var expectedFlightId2 = 10;
        var expectedHotelId = 9;
        
        var resultFlightId1 = holidaySearch.Result().FlightsList.First().FlightId;
        var resultFlightId2 = holidaySearch.Result().FlightsList[1].FlightId;
        var resultHotelId = holidaySearch.Result().HotelsList.First().HotelId;
        
        resultFlightId1.Should().Be(expectedFlightId1);
        resultFlightId2.Should().Be(expectedFlightId2);
        resultHotelId.Should().Be(expectedHotelId);

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
        decimal expectedCheapestPrice = 736;
        decimal expectedSecondCheapestPrice = 806;

        var resultFlightId = holidaySearch.Result().FlightsList.First().FlightId;
        var resultHotelId = holidaySearch.Result().HotelsList.First().HotelId;
        var resultCheapestTotalPrice = holidaySearch.Result().ListOfTotalPrices.First();
        var resultSecondCheapestTotalPrice = holidaySearch.Result().ListOfTotalPrices[1];

        resultFlightId.Should().Be(expectedFlightId);
        resultHotelId.Should().Be(expectedHotelId);
        resultCheapestTotalPrice.Should().Be(expectedCheapestPrice);
        resultSecondCheapestTotalPrice.Should().Be(expectedSecondCheapestPrice);

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
    public void HolidaySearch_Should_Return_Cheapest_Flights_and_Hotels_From_Empty_DepartingFrom_To_LPA()
    {
        var holidaySearch = new HolidaySearch.SearchModels.HolidaySearch(
            departingFrom: "", //Equals to "Any Airport"
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
        
        holidaySearch.Result().HotelsList.Count.Should().Be(0);
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
        
         var resultFlightId = holidaySearch.Result().FlightsList.First().FlightId;
        
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
    
    [Test]
    public void HolidaySearch_Should_Return_Cheapest_Flights_and_Hotels_From_LTN_To_PMI()
    {
        var holidaySearch = new HolidaySearch.SearchModels.HolidaySearch(
            departingFrom: "LTN",
            travelingTo: "PMI",
            departureDate: "2023/06/15",
            duration: 14
        );
        
        var expectedFlightId = 4;
        var expectedHotelId = 3;
        decimal expectedTotalPrice = 979;
        
        var resultFlightId = holidaySearch.Result().FlightsList.First().FlightId;
        var resultHotelId = holidaySearch.Result().HotelsList.First().HotelId;
        var resultTotalPrice = holidaySearch.Result().ListOfTotalPrices.First();
        
        resultFlightId.Should().Be(expectedFlightId);
        resultHotelId.Should().Be(expectedHotelId);
        resultTotalPrice.Should().Be(expectedTotalPrice);
    }
    
    [Test]
    public void Number_Of_Flights_Should_Be_0_For_Unknown_Departure_Location()
    {
        var holidaySearch = new HolidaySearch.SearchModels.HolidaySearch(
            departingFrom: "ABC",
            travelingTo: "PMI",
            departureDate: "2023/06/15",
            duration: 14
        );
        
       holidaySearch.Result().FlightsList.Count.Should().Be(0);
    }
    [Test]
    public void Number_Of_Flights_Should_Be_0_For_Unknown_Destination_Location()
    {
        var holidaySearch = new HolidaySearch.SearchModels.HolidaySearch(
            departingFrom: "MAN",
            travelingTo: "ABC",
            departureDate: "2023/06/15",
            duration: 14
        );
        
        holidaySearch.Result().FlightsList.Count.Should().Be(0);
    }
    
    [Test]
    public void Number_Of_Flights_Should_Be_0_For_Out_Of_Scope_Departure_Date()
    {
        var holidaySearch = new HolidaySearch.SearchModels.HolidaySearch(
            departingFrom: "ABC",
            travelingTo: "PMI",
            departureDate: "2025/06/15",
            duration: 14
        );
        
        holidaySearch.Result().FlightsList.Count.Should().Be(0);
    }
    
    [Test]
    public void Number_Of_Hotels_Should_Be_0_For_Unknown_Destination_Location()
    {
        var holidaySearch = new HolidaySearch.SearchModels.HolidaySearch(
            departingFrom: "MAN",
            travelingTo: "ABC",
            departureDate: "2023/06/15",
            duration: 14
        );
        
        holidaySearch.Result().HotelsList.Count.Should().Be(0);
    }
    
    [Test]
    public void Number_Of_Hotels_Should_Be_0_For_Out_Of_Scope_Duration()
    {
        var holidaySearch = new HolidaySearch.SearchModels.HolidaySearch(
            departingFrom: "MAN",
            travelingTo: "PMI",
            departureDate: "2023/06/15",
            duration: 35
        );
        
        holidaySearch.Result().HotelsList.Count.Should().Be(0);
    }
    
    [Test]
    public void Number_Of_Hotels_Should_Be_0_For_Out_Of_Scope_Departure_Date()
    {
        var holidaySearch = new HolidaySearch.SearchModels.HolidaySearch(
            departingFrom: "MAN",
            travelingTo: "PMI",
            departureDate: "2025/06/15",
            duration: 14
        );
        holidaySearch.Result().HotelsList.Count.Should().Be(0);
    }
    
    
    
    
}