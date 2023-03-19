using ECommerce.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Lot
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Picture URL")]
        public string Picture { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Type")]
        public LotType Type { get; set;}

        [Display(Name = "Description")]
        public string Description { get; set;}

        [Display(Name = "Price")]
        public int Price { get; set; }

        [Display(Name = "Status")]
        public bool Status { get; set; }

        [Display(Name = "PublishDate")]
        public DateTime PublishDate { get; set; }

    }
}
