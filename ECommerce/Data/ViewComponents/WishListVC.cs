using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Data.ViewComponents
{
    public class WishListVC : ViewComponent
    {
        private readonly WishList.WishList _wishList;

        public WishListVC(WishList.WishList wishList)
        {
            _wishList = wishList;
        }
        public IViewComponentResult Invoke()
        {
            var items = _wishList.GetWishListItems();

            return View(items.Count);
        }
    }
}
