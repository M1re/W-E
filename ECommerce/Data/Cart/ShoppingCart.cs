﻿using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Cart
{
    public class ShoppingCart
    {
        public AppDbContext _context { get; set; }

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }

        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddItemToCart(Lot lot)
        {
            //error
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Lot.Id == lot.Id && n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Lot = lot,
                    Amount = 1
                };

                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            _context.SaveChanges();
        }

        public void RemoveItemFromCart(Lot lot)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Lot.Id == lot.Id && n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem != null)
            {
                _context.ShoppingCartItems.Remove(shoppingCartItem);
            }
            _context.SaveChanges();
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Include(n => n.Lot).ToList());
        }

        public async Task ClearShoppingCartAsync()
        {
            var items = await _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).ToListAsync();
            _context.ShoppingCartItems.RemoveRange(items);
            await _context.SaveChangesAsync();
        }

        public ShoppingCartItem GetShoppingCartItem(int lotId)
        {
            return _context.ShoppingCartItems
                .SingleOrDefault(n => n.ShoppingCartId == ShoppingCartId && n.Lot.Id == lotId);
        }
    }
}
