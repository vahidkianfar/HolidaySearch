using FluentAssertions;

namespace HolidayTests.HolidaySearchTests;

public class SortingMethodsTests
{
    [Test]
    public void ReturnFlightPriceByAscendingOrder_Should_Sort_and_Return_Matched_Flights()
    {
        //---Arrange
        var holidaySearch = new HolidaySearch.SearchModels.HolidaySearch(
            departingFrom: "LGW",
            travelingTo: "AGP",
            departureDate: "2023/07/01",
            duration: 7
        );
        
        //---Act
        var result= holidaySearch.ReturnFlightPriceByAscendingOrder();
        
        //---Assert
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

}