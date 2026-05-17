namespace NotificationService.Models;

public class EmailNotification
{
    public int Id { get; set; }

    public string RecipientEmail { get; set; } = string.Empty;

    public string Subject { get; set; } = string.Empty;

    public string Body { get; set; } = string.Empty;

    public DateTime SentDate { get; set; } = DateTime.Now;

    public bool IsHtml { get; set; } = false;

    public string? CcEmail { get; set; }

    public string? BccEmail { get; set; }
}
