using HolidaySearch.Models;
using FluentAssertions;

namespace HolidayTests.FlightsTests;

public class FlightsTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Create_an_Object_of_Flights()
    {
        var flight = new Flights
        {
            FlightId = 1,
            AirlineName = "First Class Air",
            DepartingFrom = "MAN",
            TravelingTo = "TSF",
            FlightPrice = 470,
            DepartureDate = Convert.ToDateTime("2023-07-01"),
        };
        
        Assert.Multiple(() =>
        {
            Assert.That(flight.FlightId, Is.EqualTo(1));
            Assert.That(flight.AirlineName, Is.EqualTo("First Class Air"));
            Assert.That(flight.DepartingFrom, Is.EqualTo("MAN"));
            Assert.That(flight.TravelingTo, Is.EqualTo("TSF"));
            Assert.That(flight.FlightPrice, Is.EqualTo(470));
            Assert.That(flight.DepartureDate, Is.EqualTo(DateTime.Parse("2023-07-01")));
        });
        


    }
}