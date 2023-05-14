using ECommerce.Data.Services;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.WishList
{
    public class WishList
    {
        public AppDbContext _context { get; set; }

        public string WishListId { get; set; }
        public List<WishListItem> WishListItems { get; set; }

        public WishList(AppDbContext context)
        {
            _context = context;
        }

        public static WishList GetWishList(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();

            string wishListId = session.GetString("WishListId") ?? Guid.NewGuid().ToString();
            session.SetString("WishListId", wishListId);

            return new WishList(context) { WishListId = wishListId };
        }

        public void AddItemToWishList(Lot lot)
        {
            var wishListItem = _context.WishListItems.FirstOrDefault(n => n.Lot.Id == lot.Id && n.WishListId == WishListId);

            if (wishListItem == null)
            {
                wishListItem = new WishListItem()
                {
                    WishListId = WishListId,
                    Lot = lot,
                    Amount = 1
                };

                _context.WishListItems.Add(wishListItem);
            }
            _context.SaveChanges();
        }

        public void RemoveItemFromWishList(Lot lot)
        {
            var wishListItem = _context.WishListItems.FirstOrDefault(n => n.Lot.Id == lot.Id && n.WishListId == WishListId);

            if (wishListItem != null)
            {
                _context.WishListItems.Remove(wishListItem);
            }
            _context.SaveChanges();
        }

        public List<WishListItem> GetWishListItems()
        {
            return WishListItems ?? (WishListItems = _context.WishListItems.Where(n => n.WishListId == WishListId).Include(n => n.Lot).ToList());
        }

    }
}
