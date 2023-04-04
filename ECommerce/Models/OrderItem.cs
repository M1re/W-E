using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        public int Amount { get; set; }
        public double Price { get; set; }

        public int LotId { get; set; }
        [ForeignKey("LotId")]

        public Lot Lot { get; set; }

        public int OrderId { get; set; }
        [ForeignKey("OrderId")]

        public Order Order { get; set; }
    }
}
