using ECommerce.Models;

namespace ECommerce.Data.Services;

public interface IWishListService
{
    Task<List<WishListModel>> GetWishListByUserIdAndRoleAsync(string userId);
    Task StoreWishListAsync(List<WishListItem> items, string userId, string userEmailAddress);
}