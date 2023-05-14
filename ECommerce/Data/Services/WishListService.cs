using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Services
{
    public class WishListService : IWishListService
    {
        public AppDbContext _context { get; set; }

        public WishListService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<WishListModel>> GetWishListByUserIdAndRoleAsync(string userId)
        {
            var wishList = await _context.WishListModels
                .Include(n => n.WishListItems)
                .ThenInclude(n => n.Lot)
                .Include(n => n.User)
                .Where(n => n.UserId == userId)
                .ToListAsync();

            return wishList;
        }

        public async Task StoreWishListAsync(List<WishListItem> items, string userId, string userEmailAddress)
        {
            var wishList = new WishListModel()
            {
                UserId = userId,
                Email = userEmailAddress
            };
            await _context.WishListModels.AddAsync(wishList);
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                var wishListItem = new WishListItem()
                {
                    Amount = item.Amount,
                    LotId = item.Lot.Id,
                    WishListId = item.WishListId,
                    DealType = item.Lot.DealType
                };
                await _context.WishListItems.AddAsync(wishListItem);
            }
            await _context.SaveChangesAsync();
        }
    }
}