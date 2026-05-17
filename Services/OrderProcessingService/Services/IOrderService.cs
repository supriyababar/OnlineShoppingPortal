namespace OrderProcessingService.Services;
using OrderProcessingService.Models;
public interface IOrderService{
      bool ProcessOrder(Order order);
      bool CancelOrder(Order order);
}
