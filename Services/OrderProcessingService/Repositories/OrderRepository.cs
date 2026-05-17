using MySql.Data.MySqlClient;
using OrderProcessingService.Models;

namespace OrderProcessingService.Repositories;

public class OrderRepository:IOrderRepository
{
    private readonly string _connectionString;

    public OrderRepository(IConfiguration configuration)
    {
        _connectionString =
            configuration.GetConnectionString("DefaultConnection")!;
    }

    // ---------------- Orders ----------------

    public List<Order> GetOrders()
    {
        List<Order> orders = new();

        using MySqlConnection con =
            new MySqlConnection(_connectionString);

        string query = "SELECT * FROM Orders";

        MySqlCommand cmd = new(query, con);

        con.Open();

        using MySqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            orders.Add(new Order
            {
                OrderId = Convert.ToInt32(reader["OrderId"]),
                CustomerName = reader["CustomerName"].ToString()!,
                OrderDate = Convert.ToDateTime(reader["OrderDate"]),
                TotalAmount = Convert.ToDecimal(reader["TotalAmount"])
            });
        }

        return orders;
    }

    public void AddOrder(Order order)
    {
        using MySqlConnection con =
            new MySqlConnection(_connectionString);

        string query =
        @"INSERT INTO Orders
        (CustomerName, OrderDate, TotalAmount)
        VALUES
        (@CustomerName, @OrderDate, @TotalAmount)";

        MySqlCommand cmd = new(query, con);

        cmd.Parameters.AddWithValue("@CustomerName",
                                    order.CustomerName);

        cmd.Parameters.AddWithValue("@OrderDate",
                                    order.OrderDate);

        cmd.Parameters.AddWithValue("@TotalAmount",
                                    order.TotalAmount);

        con.Open();

        cmd.ExecuteNonQuery();
    }

    // ---------------- Order Details ----------------

    public List<OrderDetail> GetOrderDetails()
    {
        List<OrderDetail> details = new();

        using MySqlConnection con =
            new MySqlConnection(_connectionString);

        string query = "SELECT * FROM OrderDetails";

        MySqlCommand cmd = new(query, con);

        con.Open();

        using MySqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            details.Add(new OrderDetail
            {
                OrderDetailId =
                    Convert.ToInt32(reader["OrderDetailId"]),

                OrderId =
                    Convert.ToInt32(reader["OrderId"]),

                ProductName =
                    reader["ProductName"].ToString()!,

                Quantity =
                    Convert.ToInt32(reader["Quantity"]),

                Price =
                    Convert.ToDecimal(reader["Price"])
            });
        }

        return details;
    }

    public void AddOrderDetail(OrderDetail detail)
    {
        using MySqlConnection con =
            new MySqlConnection(_connectionString);

        string query =
        @"INSERT INTO OrderDetails
        (OrderId, ProductName, Quantity, Price)
        VALUES
        (@OrderId, @ProductName, @Quantity, @Price)";

        MySqlCommand cmd = new(query, con);

        cmd.Parameters.AddWithValue("@OrderId",
                                    detail.OrderId);

        cmd.Parameters.AddWithValue("@ProductName",
                                    detail.ProductName);

        cmd.Parameters.AddWithValue("@Quantity",
                                    detail.Quantity);

        cmd.Parameters.AddWithValue("@Price",
                                    detail.Price);

        con.Open();

        cmd.ExecuteNonQuery();
    }
}
