using FluentAssertions;
using HolidaySearch.Models;
using HolidaySearch.SearchModels;

namespace HolidayTests.HolidaySearchTests;

public class FindMatchHotelsTests
{
    [Test]
    public void FindMatchHotels_Should_Return_List_of_Matched_Hotels_in_TFS_7_Days()
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
    public void FindMatchHotels_Should_Return_Two_Matched_Hotels_in_PMI_10_Days()
    {
        var result = MatchedFlightsAndHotels.FindMatchHotels("PMI", 10, "2023/06/15");
        
        result.Should().BeOfType<List<Hotels>>();
        result.Count.Should().Be(2);
        result[0].HotelId.Should().Be(5);
        result[1].HotelId.Should().Be(13);
    }
    
    [Test]
    public void FindMatchHotels_Should_Return_List_of_Matched_Hotels_in_LPA_14_Days_On_Month09_Day10()
    {
        var result = MatchedFlightsAndHotels.FindMatchHotels("LPA", 14, "2022/09/10");
        
        result.Should().BeOfType<List<Hotels>>();
        result.Count.Should().Be(1);
        result.First().HotelId.Should().Be(7);
    }
    
    [Test]
    public void FindMatchHotels_Should_Return_List_of_Matched_Hotels_in_LPA_14_Days_On_Month11_Day10()
    {
        var result = MatchedFlightsAndHotels.FindMatchHotels("LPA", 14, "2022/11/10");
        
        result.Should().BeOfType<List<Hotels>>();
        result.Count.Should().Be(1);
        result.First().HotelId.Should().Be(6);
    }
    
    [Test]
    public void FindMatchHotels_Should_Return_List_of_Matched_Hotels_in_LPA_14_Days_On_Month10_Day10()
    {
        var result = MatchedFlightsAndHotels.FindMatchHotels("LPA", 7, "2022/10/10");
        
        result.Should().BeOfType<List<Hotels>>();
        result.Count.Should().Be(1);
        result.First().HotelId.Should().Be(8);
    }
    
    [Test]
    public void FindMatchHotels_Should_Return_List_of_Matched_Hotels_in_AGP_14_Days_Month07_Day01()
    {
        var result = MatchedFlightsAndHotels.FindMatchHotels("AGP", 14, "2023/07/01");
        
        result.Should().BeOfType<List<Hotels>>();
        result.Count.Should().Be(1);
        result.First().HotelId.Should().Be(12);
    }
    
    
    [Test]
    public void FindMatchHotels_Should_Return_ZERO_Hotels_in_MAN()
    {
        var result = MatchedFlightsAndHotels.FindMatchHotels("MAN", 14, "2023/07/01");
        
        result.Should().BeOfType<List<Hotels>>();
        result.Count.Should().Be(0);
    }
    
    [Test]
    public void FindMatchHotels_Should_Return_ZERO_Hotels_in_AGP_For_Out_Of_Scope_Duration()
    {
        var result = MatchedFlightsAndHotels.FindMatchHotels("AGP", 24, "2023/07/01");
        
        result.Should().BeOfType<List<Hotels>>();
        result.Count.Should().Be(0);
    }
    
    [Test]
    public void FindMatchHotels_Should_Return_ZERO_Hotels_in_AGP_For_Out_Of_Scope_Date()
    {
        var result = MatchedFlightsAndHotels.FindMatchHotels("AGP", 14, "2025/07/01");
        
        result.Should().BeOfType<List<Hotels>>();
        result.Count.Should().Be(0);
    }
}