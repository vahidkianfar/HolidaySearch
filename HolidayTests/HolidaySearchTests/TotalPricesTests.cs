using FluentAssertions;

namespace HolidayTests.HolidaySearchTests;

public class TotalPricesTests
{
    [Test]
    public void CalculateTotalPrice_Should_Return_Correct_Total_Price_Of_Any_Airport_Flights_To_AGP_Hotels()
    {
        //---Arrange
        var holidaySearch = new HolidaySearch.SearchModels.HolidaySearch(
            departingFrom: "",
            travelingTo: "AGP",
            departureDate: "2023/07/01",
            duration: 7
        );
        
        decimal expectedTotalPrice = 736;
        
        //---Act
        var result= holidaySearch.CalculateListOfTotalPrice();
        
        //---Assert
        result.First().Should().Be(expectedTotalPrice);
    }
    
    [Test]
    public void CalculateTotalPrice_Should_Return_Total_Price_Of_Flights_Hotels()
    {
        var holidaySearch = new HolidaySearch.SearchModels.HolidaySearch(
            departingFrom: "LTN",
            travelingTo: "PMI",
            departureDate: "2023/06/15",
            duration: 14
        );
        decimal expectedTotalPrice = 979;
        
        var result= holidaySearch.CalculateListOfTotalPrice();
        
        
        result.First().Should().Be(expectedTotalPrice);
    }
    
    [Test]
    public void CalculateTotalPrice_Should_Return_Total_Price_Of_Any_London_Airport_Flights_To_PMI_Hotels()
    {
        var holidaySearch = new HolidaySearch.SearchModels.HolidaySearch(
            departingFrom: "Any London Airport",
            travelingTo: "PMI",
            departureDate: "2023/06/15",
            duration: 14
        );
        decimal expectedTotalPrice = 901;
        
        var result= holidaySearch.CalculateListOfTotalPrice();
        
        
        result.First().Should().Be(expectedTotalPrice);
    }

    [Test]
    public void CalculateTotalPrice_Should_Be_0_For_No_Flights_and_Hotels_Available()
    {
        var holidaySearch = new HolidaySearch.SearchModels.HolidaySearch(
            departingFrom: "MAN",
            travelingTo: "PMI",
            departureDate: "2025/06/15",
            duration: 35
        );
        
        int expectedTotalPrice = 0;
        
        var result= holidaySearch.CalculateListOfTotalPrice();
        
        result.First().Should().Be(expectedTotalPrice);
    }
    [Test]
    public void CalculateTotalPrice_Should_Be_Only_FlightPrice_For_Available_Flights_But_NotAvailable_Hotels()
    {
        var holidaySearch = new HolidaySearch.SearchModels.HolidaySearch(
            departingFrom: "MAN",
            travelingTo: "PMI",
            departureDate: "2023/06/15",
            duration: 35
        );
        
        var expectedTotalPrice = holidaySearch.ReturnFlightPriceByAscendingOrder().First().FlightPrice;
        
        var result= holidaySearch.CalculateListOfTotalPrice();
        
        result.First().Should().Be(expectedTotalPrice);
    }
}