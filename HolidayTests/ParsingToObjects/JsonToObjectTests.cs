using HolidaySearch.LoadDataModels;
using FluentAssertions;
using HolidaySearch.Models;
namespace HolidayTests.ParsingToObjects;

public class JsonToObjectTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void LoadDataFromJson_Should_Successfully_Parse_JsonData_To_Flight_Object()
    {
        var flight = LoadDataFromJson.LoadFlights();
        Assert.That(flight, Is.Not.Null);
        Assert.IsInstanceOf<Flights>(flight.First());
        flight.Count.Should().Be(12);
        flight.First().FlightId.Should().Be(1);
        flight.First().DepartingFrom.Should().Be("MAN");
    }

    [Test]
    public void LoadDataFromJson_Should_Successfully_Parse_JsonData_To_Hotel_Object()
    {
        var hotel = LoadDataFromJson.LoadHotels();
        
        Assert.That(hotel, Is.Not.Null);
        Assert.IsInstanceOf<Hotels>(hotel.First());
        hotel.Count.Should().Be(13);
        hotel.First().HotelId.Should().Be(1);
        hotel.First().HotelName.Should().Be("Iberostar Grand Portals Nous");
    }
}