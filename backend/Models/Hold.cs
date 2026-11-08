namespace SchoolAdmission.Models;

public class Hold
{
    public string Id { get; set; } = Guid.NewGuid().ToString("N");
    public string ClassId { get; set; } = "";
    public string StudentId { get; set; } = "";

    // Database-e shudhu 3 ta value thakbe: HELD, CONFIRMED, CANCELLED
    // EXPIRED database-e lekha hobe na, shomoy dekhe hishab hobe
    public string Status { get; set; } = "HELD";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime ExpiresAt { get; set; }
}