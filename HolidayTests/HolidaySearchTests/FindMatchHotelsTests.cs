using FluentAssertions;
using HolidaySearch.Models;
using HolidaySearch.SearchModels;

namespace HolidayTests.HolidaySearchTests;

public class FindMatchHotelsTests
{
    [Test]
    public void FindMatchHotels_Should_Return_List_of_Matched_Hotels_in_TFS()
    {
        //---Arrange
        List<Hotels> result;
        
        //---Act
        result = MatchedFlightsAndHotels.FindMatchHotels("TFS", 7, "2022/11/05");
        
        //---Assert
        result.Should().BeOfType<List<Hotels>>();
        result.Count.Should().Be(2);
        result[0].HotelId.Should().Be(1);
        result[1].HotelId.Should().Be(2);
    }
    [Test]
    public void FindMatchHotels_Should_Return_Two_Matched_Hotels_in_PMI_14_Days()
    {
        var result = MatchedFlightsAndHotels.FindMatchHotels("PMI", 14, "2023/06/15");
        
        result.Should().BeOfType<List<Hotels>>();
        result.Count.Should().Be(2);
        result[0].HotelId.Should().Be(3);
        result[1].HotelId.Should().Be(4);
    }
    
    [Test]
    public void FindMatchHotels_Should_Return_List_of_Matched_Hotels_in_LPA_14_Days()
    {
        var result = MatchedFlightsAndHotels.FindMatchHotels("LPA", 14, "2022/11/10");
        
        result.Should().BeOfType<List<Hotels>>();
        result.Count.Should().Be(1);
        result.First().HotelId.Should().Be(6);
    }
    [Test]
    public void FindMatchHotels_Should_Return_List_of_Matched_Hotels_in_AGP_14_Days()
    {
        var result = MatchedFlightsAndHotels.FindMatchHotels("AGP", 14, "2023/07/01");
        
        result.Should().BeOfType<List<Hotels>>();
        result.Count.Should().Be(1);
        result.First().HotelId.Should().Be(12);
    }
}