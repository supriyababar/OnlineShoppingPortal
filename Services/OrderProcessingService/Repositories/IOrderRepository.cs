using MySql.Data.MySqlClient;
using OrderProcessingService.Models;

namespace OrderProcessingService.Repositories;

public interface IOrderRepository
{
    public List<Order> GetOrders();
    public void AddOrder(Order order);
    public List<OrderDetail> GetOrderDetails();
    public void AddOrderDetail(OrderDetail detail);
}
