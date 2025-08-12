using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("TripItinerary")]
public class TripItinerary
{
    [Key]
    public int ItineraryID { get; set; }
    public int TripID { get; set; }
    public DateTime EventDate { get; set; }
    public TimeSpan? EventTime { get; set; }
    public string? Location { get; set; }
    public string? ActivityDescription { get; set; }
}
