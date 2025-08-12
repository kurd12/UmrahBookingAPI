using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Companies")]
public class CampaignLeader
{
    public virtual ICollection<Booking>? Bookings { get; set; }

    [Key]
    public int LeaderID { get; set; }
    public string? LeaderName { get; set; }
    public string? LeaderPhotoURL { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
}
