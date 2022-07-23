using HolidaySearch.Models;
using FluentAssertions;

namespace HolidayTests.HotelsTests;

public class HotelsTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Create_an_Object_of_Hotels()
    {
        var hotel = new Hotels
        {
            HotelId = 1,
            HotelName = "Iberostar Grand Portals Nous",
            ArrivalDate = Convert.ToDateTime("2022-11-05"),
            HotelPricePerNight = 100,
            LocalAirport = new List<string> { "TFS" },
            DurationNights = 7
        };
        Assert.Multiple(() =>
        {
            Assert.That(hotel.HotelId, Is.EqualTo(1));
            Assert.That(hotel.HotelName, Is.EqualTo("Iberostar Grand Portals Nous"));
            Assert.That(hotel.ArrivalDate, Is.EqualTo(DateTime.Parse("2022-11-05")));
            Assert.That(hotel.HotelPricePerNight, Is.EqualTo(100));
            Assert.That(hotel.DurationNights, Is.EqualTo(7));
        });
    }
}