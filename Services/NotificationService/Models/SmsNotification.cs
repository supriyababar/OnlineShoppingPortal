namespace NotificationService.Models;

public class SmsNotification
{
    public int Id { get; set; }

    public string PhoneNumber { get; set; } = string.Empty;

    public string Message { get; set; } = string.Empty;

    public DateTime SentDate { get; set; } = DateTime.Now;

    public string Status { get; set; } = "Pending"; 

    public string? Provider { get; set; } 
}
