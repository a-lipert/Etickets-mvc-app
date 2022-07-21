using etickets_web_app.Models;

namespace etickets_web_app.Data.Services
{
    public interface IOrdersService
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress);
        Task <List<Order>> GetOrdersByUserIdAsync (string userId);  
    }
}
