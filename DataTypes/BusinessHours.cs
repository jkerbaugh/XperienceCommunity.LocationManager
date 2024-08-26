namespace XperienceCommunity.Locator.Models;

public class BusinessHours
{
    public (TimeSpan? Open, TimeSpan? Close) MondayHours { get; set; }
    public (TimeSpan? Open, TimeSpan? Close) TuesdayHours { get; set; }
    public (TimeSpan? Open, TimeSpan? Close) WednesdayHours { get; set; }
    public (TimeSpan? Open, TimeSpan? Close) ThursdayHours { get; set; }
    public (TimeSpan? Open, TimeSpan? Close) FridayHours { get; set; }
    public (TimeSpan? Open, TimeSpan? Close) SaturdayHours { get; set; }
    public (TimeSpan? Open, TimeSpan? Close) SundayHours { get; set; }
}