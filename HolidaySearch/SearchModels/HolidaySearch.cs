namespace HolidaySearch.SearchModels;

public class HolidaySearch
{
    public string DepartingFrom { get; set; }
    public string TravelingTo { get; set; }
    public string DepartingDate { get; set; }
    public int Duration { get; set; }
    
    public HolidaySearch(string departingFrom, string travelingTo, string departingDate, int duration)
    {
        DepartingFrom = departingFrom;
        TravelingTo = travelingTo;
        DepartingDate = departingDate;
        Duration = duration;
    }
}