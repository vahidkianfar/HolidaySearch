using FluentAssertions;
using HolidaySearch.Models;
using HolidaySearch.SearchModels;

namespace HolidayTests.HolidaySearchTests;

public class MatchedFlightsAndHotelsTest
{
    [Test]
    public void FindMatchFlights_Should_Return_List_of_Matched_Flights_LGW_To_AGP()
    {
        var result = MatchedFlightsAndHotels.FindMatchFlights("LGW", "AGP", "2023/07/01");
        
        result.Should().BeOfType<List<Flights>>();
        result.Count.Should().Be(2);
        result[0].FlightId.Should().Be(10);
        result[1].FlightId.Should().Be(11);
    }
    [Test]
    public void FindMatchFlights_Should_Return_List_of_Matched_Flights_MAN_To_AGP()
    {
        var result = MatchedFlightsAndHotels.FindMatchFlights("MAN", "AGP", "2023/07/01");
        
        result.Should().BeOfType<List<Flights>>();
        result.Count.Should().Be(1);
        result.First().FlightId.Should().Be(2);
    }
    [Test]
    public void FindMatchFlights_Should_Return_List_of_Matched_Flights_LTN_To_PMI()
    {
        var result = MatchedFlightsAndHotels.FindMatchFlights("LTN", "PMI", "2023/06/15");
        
        result.Should().BeOfType<List<Flights>>();
        result.Count.Should().Be(1);
        result.First().FlightId.Should().Be(4);
    }
    
    [Test]
    public void FindMatchHotels_Should_Return_List_of_Matched_Hotels_in_TFS()
    {
        var result = MatchedFlightsAndHotels.FindMatchHotels("TFS", 7, "2022/11/05");
        
        result.Should().BeOfType<List<Hotels>>();
        result.Count.Should().Be(2);
        result[0].HotelId.Should().Be(1);
        result[1].HotelId.Should().Be(2);
    }
    [Test]
    public void FindMatchHotels_Should_Return_List_of_Matched_Hotels_in_PMI_14_Days()
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