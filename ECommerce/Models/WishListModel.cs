using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class WishListModel
    {
        [Key]
        public string Id { get; set; }

        public string Email { get; set; }

        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]

        public ApplicationUser User { get; set; }

        public List<WishListItem> WishListItems { get; set; }
    }
}
