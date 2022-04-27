// 複合主鍵
// 優惠券使用
using Lab_Shopping_WebSite.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_Shopping_WebSite.Models
{
    [Table("Coupon_Uses")]
    public class Coupon_Uses : IModel
    {
        // Constructor
        public Coupon_Uses()
        {
        }

        #region 屬性
        [Required(ErrorMessage = "SaleID is required")]
        public string? SaleID { get; set; }

        [Required(ErrorMessage = "CouponID is required")]
        public int CouponID { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Discount is required.")]
        public int Discount { get; set; }

        [Required(ErrorMessage = "Use_Date is required.")]
        public DateTime Use_Date { get; set; }
        public int? Modifier { get; set; }
        public int? Creator { get; set; }

        [ForeignKey("SaleID"), InverseProperty("Coupon_Uses")]
        public virtual Sales? Sale { get; set; }

        [ForeignKey("CouponID"), InverseProperty("Coupon_Uses")]
        public virtual Coupons? Coupon { get; set; }

        [ForeignKey("Creator"), InverseProperty("CouponUsesCreator")]
        public virtual Members? CreateMember { get; set; }

        [ForeignKey("Modifier"), InverseProperty("CouponUsesModifer")]
        public virtual Members? ModifyMember { get; set; }
        #endregion
    }
}