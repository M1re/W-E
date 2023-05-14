using ECommerce.Data.Cart;
using ECommerce.Data.Services;
using ECommerce.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ECommerce.Data.WishList;

namespace ECommerce.Controllers
{
    public class WishListController : Controller
    {
        private readonly ILotsService _lotsService;
        private readonly IWishListService _wishListService;
        private readonly WishList _wishList;

        public WishListController(ILotsService lotsService, IWishListService wishListService, WishList wishList)
        {
            _lotsService = lotsService;
            _wishListService = wishListService;
            _wishList = wishList;
        }

        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var items = await _wishListService.GetWishListByUserIdAndRoleAsync(userId);
            return View(items);
        }

        public IActionResult WishList()
        {
            var items = _wishList.GetWishListItems();
            _wishList.WishListItems = items;

            var response = new WishListViewModel()
            {
                WishList = _wishList
            };

            return View(response);
        }

        public async Task<IActionResult> AddItemToWishList(int id)
        {
            var item = await _lotsService.GetById(id);

            if (item != null)
            {
                _wishList.AddItemToWishList(item);
            }
            return RedirectToAction(nameof(WishList));
        }

        public async Task<IActionResult> RemoveItemFromWishList(int id)
        {
            var item = await _lotsService.GetById(id);

            if (item != null)
            {
                _wishList.RemoveItemFromWishList(item);
            }
            return RedirectToAction(nameof(WishList));
        }
    }
}
