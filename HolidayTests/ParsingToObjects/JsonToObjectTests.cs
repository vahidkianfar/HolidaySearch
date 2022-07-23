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
        flight.First().OriginCity.Should().Be("MAN");
    }
}