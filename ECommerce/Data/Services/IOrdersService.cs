using ECommerce.Models;

namespace ECommerce.Data.Services
{
    public interface IOrdersService
    {
        Task StoreOrdersAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress);
        Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole);
        Task StoreOrderAsync(ShoppingCartItem item, string userId, string userEmailAddress);
    }
}
