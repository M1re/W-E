using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class ShoppingCartItem
    {

        [Key]
        public int Id { get; set; }

        public Lot Lot { get; set; }
        public int Amount { get; set; }

        public string ShoppingCartId { get; set; }
    }
}
