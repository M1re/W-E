using ECommerce.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class WishListItem
    {
        [Key]
        public int Id { get; set; }

        public int Amount { get; set; }
        public DealType DealType { get; set; }

        public int LotId { get; set; }
        [ForeignKey("LotId")]

        public Lot Lot { get; set; }

        public string WishListId { get; set; }

        public WishListModel WishListModel { get; set; }
    }
}
