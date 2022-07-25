using FluentAssertions;
using HolidaySearch.Models;
using HolidaySearch.SearchModels;

namespace HolidayTests.HolidaySearchTests;

public class FindMatchFlightsTests
{
    [Test]
    public void FindMatchFlights_Should_Return_Two_Matched_Flights_LGW_To_AGP()
    {
        //---Arrange
        List<Flights> result;
        
        //---Act
        result = MatchedFlightsAndHotels.FindMatchFlights("LGW", "AGP", "2023/07/01");
        
        //---Assert
        result.Should().BeOfType<List<Flights>>();
        result.Count.Should().Be(2);
        result[0].FlightId.Should().Be(10);
        result[1].FlightId.Should().Be(11);
    }
    [Test]
    public void FindMatchFlights_Should_Return_List_of_Matched_Flights_MAN_To_AGP_Month07_Day_01()
    {
        var result = MatchedFlightsAndHotels.FindMatchFlights("MAN", "AGP", "2023/07/01");
        
        result.Should().BeOfType<List<Flights>>();
        result.Count.Should().Be(1);
        result.First().FlightId.Should().Be(2);
    }
    [Test]
    public void FindMatchFlights_Should_Return_List_of_Matched_Flights_MAN_To_AGP_Month10_Day25()
    {
        var result = MatchedFlightsAndHotels.FindMatchFlights("MAN", "AGP", "2023/10/25");
        
        result.Should().BeOfType<List<Flights>>();
        result.Count.Should().Be(1);
        result.First().FlightId.Should().Be(12);
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
    public void FindMatchFlights_Should_Return_Four_Matched_Flights_AnyAirport_To_PMI()
    {
        var result = MatchedFlightsAndHotels.FindMatchFlights("", "PMI", "2023/06/15");
        
        result.Should().BeOfType<List<Flights>>();
        result.Count.Should().Be(4);
        
        result[0].FlightId.Should().Be(3);
        result[1].FlightId.Should().Be(4);
        result[2].FlightId.Should().Be(5);
        result[3].FlightId.Should().Be(6);
    }
    [Test]
    public void FindMatchFlights_Should_Return_Two_Matched_Flights_Any_London_Airport_To_PMI()
    {
        var result = MatchedFlightsAndHotels.FindMatchFlights("Any London Airport", "PMI", "2023/06/15");
        
        result.Should().BeOfType<List<Flights>>();
        result.Count.Should().Be(2);
        
        result[0].FlightId.Should().Be(4);
        result[1].FlightId.Should().Be(6);
    }
    
    [Test]
    public void FindMatchFlights_Should_Return_ZERO_Matched_Flights_To_MAN()
    {
        var result = MatchedFlightsAndHotels.FindMatchFlights("", "MAN", "2023/06/15");
        
        result.Should().BeOfType<List<Flights>>();
        
        result.Count.Should().Be(0);
        
    }
    
    [Test]
    public void FindMatchFlights_Should_Return_ZERO_Matched_Flights_To_AGP_For_Out_Of_Scope_Date()
    {
        var result = MatchedFlightsAndHotels.FindMatchFlights("", "AGP", "2025/06/15");
        
        result.Should().BeOfType<List<Flights>>();
        
        result.Count.Should().Be(0);
        
    }
    
    [Test]
    public void FindMatchFlights_Should_Return_ZERO_Matched_Flights_From_Undefined_DepartureCity_To_AGP()
    {
        var result = MatchedFlightsAndHotels.FindMatchFlights("ABC", "AGP", "2023/06/15");
        
        result.Should().BeOfType<List<Flights>>();
        
        result.Count.Should().Be(0);
        
    }
}