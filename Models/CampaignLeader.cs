// Faili: Models/CampaignLeader.cs
using System.ComponentModel.DataAnnotations;

public class CampaignLeader
{
    [Key]
    public int LeaderID { get; set; }
    public string? LeaderName { get; set; }
    public string? LeaderPhotoURL { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
}
