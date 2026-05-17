namespace OrderProcessingService.Models;

public class Order
{
    public int OrderId { get; set; }

    public string CustomerName { get; set; } = string.Empty;

    public DateTime OrderDate { get; set; }

    public decimal TotalAmount { get; set; }
}
