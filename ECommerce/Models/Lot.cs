using ECommerce.Data.Base;
using ECommerce.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Lot:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Picture URL")]
        [Required(ErrorMessage ="Picture is required")]
        public string Picture { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50,MinimumLength =4, ErrorMessage ="Name must be between 4 and 50 characters")]
        public string Name { get; set; }

        [Display(Name = "Type")]
        [Required(ErrorMessage = "Type is required")]
        public LotType Type { get; set;}

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set;}

        [Display(Name = "Deal Type")]
        [Required(ErrorMessage = "Deal Type is required")]
        public DealType DealType { get; set; }

        [Display(Name = "Status")]
        public bool Status { get; set; }

        [Display(Name = "PublishDate")]
        public DateTime PublishDate { get; set; }

    }
}
