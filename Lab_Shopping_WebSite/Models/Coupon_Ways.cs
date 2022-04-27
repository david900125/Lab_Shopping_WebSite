// 優惠方式
using Lab_Shopping_WebSite.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_Shopping_WebSite.Models
{
    [Table("Coupon_Ways")]
    public class Coupon_Ways : IModel
    {
        // Constructor
        public Coupon_Ways()
        {
        }

        #region 屬性
        [Key]
        [Required(ErrorMessage = "Coupon_WayID is required.")]
        public int Coupon_WayID { get; set; }

        [MaxLength(10)]
        [Required(ErrorMessage = "Coupon_Way is required.")]
        public string? Coupon_Way { get; set; }
        public int? Modifier { get; set; }
        public int? Creator { get; set; }

        [ForeignKey("Creator"), InverseProperty("CouponWaysCreator")]
        public virtual Members? CreateMember { get; set; }

        [ForeignKey("Modifier"), InverseProperty("CouponWaysModifer")]
        public virtual Members? ModifyMember { get; set; }

        public ICollection<Coupons>? Coupons { get; set; }
        #endregion
    }
}